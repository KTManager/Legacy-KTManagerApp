using KillTeam.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillTeam.Services
{
    public static class Sauvegarde
    {

        public static void Login()
        {
            Xamarin.Forms.DependencyService.Get<ICloud>().SignIn();
        }
        public static void Logout()
        {
            Xamarin.Forms.DependencyService.Get<ICloud>().SignOut();
        }

        public static async Task<bool> Synchro(IKTContext db)
        {          
            byte[] data = await Xamarin.Forms.DependencyService.Get<ICloud>().Synchro(Encoding.UTF8.GetBytes(GetSerializedData(db)));
            if (data != null && data.Length >0)
            {
                try
                {
                    var dataString = Encoding.UTF8.GetString(data);
                    SetSerializedData(db, dataString);
                } catch (Exception)
                {
                    Xamarin.Forms.DependencyService.Get<ICloud>().Save(Encoding.UTF8.GetBytes(GetSerializedData(db)));
                }
                return true;
            }            
            return false;
        }

        public static string GetSerializedData(IKTContext db)
        {
            var equipes = db.Teams
                .Include(e => e.Faction)
                .Include(e => e.Members)
                .ThenInclude(m => m.MemberPowers)
                .Include(e => e.Members)
                .ThenInclude(m => m.MemberWeapons)
                .Include(e => e.Members)
                .ThenInclude(m => m.MemberWarGearOptions)
                .Include(e => e.Members)
                .ThenInclude(m => m.ModelProfile)
                .Include(e => e.Members)
                .ThenInclude(m => m.Specialist)
                .Include(e => e.Members)
                .ThenInclude(m => m.MemberTraits)
                .Include(e => e.Members)
                .ThenInclude(m => m.MemberPsychics)
                .ToList();
            
            return CompressString(JsonConvert.SerializeObject(new SaveModel { DateTime = DateTime.Now, Teams = equipes }));
        }

        public static bool IsConnected()
        {
            return Xamarin.Forms.DependencyService.Get<ICloud>().IsConnected();
        }

        private static void DeleteUserData(IKTContext db)
        {
                foreach (MemberTrait MembreTrait in db.MemberTraits.AsTracking())
                {
                    db.Entry(MembreTrait).State = EntityState.Deleted;
                }
                foreach (MemberPsychic MembrePsychique in db.MemberPsychics.AsTracking())
                {
                    db.Entry(MembrePsychique).State = EntityState.Deleted;
                }
                foreach (MemberWeapon MembreArme in db.MemberWeapons.AsTracking())
                {
                    db.Entry(MembreArme).State = EntityState.Deleted;
                }
                foreach (MemberPower MembrePouvoir in db.MemberPowers.AsTracking())
                {
                    db.Entry(MembrePouvoir).State = EntityState.Deleted;
                }
                foreach (MemberWarGearOption MembreRemplacement in db.MemberWarGearOptions.AsTracking())
                {
                    db.Entry(MembreRemplacement).State = EntityState.Deleted;
                }
                foreach (Member Membre in db.Members.AsTracking())
                {
                    db.Entry(Membre).State = EntityState.Deleted;
                }
                foreach (Team equipe in db.Teams.AsTracking())
                {
                    db.Entry(equipe).State = EntityState.Deleted;
                }

                db.SaveChanges();
        }

        private static SaveModel ReplaceData(SaveModel saveModel, Dictionary<string, Dictionary<string, string>> replacements)
        {
            if (!replacements.ContainsKey("Weapons"))
            {
                return saveModel;
            }

            var weaponReplacements = replacements["Weapons"];

            if (weaponReplacements == null || weaponReplacements.Count == 0)
            {
                return saveModel;
            }

            foreach (Team team in saveModel.Teams)
            {
                foreach (Member member in team.Members)
                {
                    foreach (MemberWeapon memberWeapon in member.MemberWeapons)
                    {
                        if (memberWeapon.WeaponId != null && weaponReplacements.ContainsKey(memberWeapon.WeaponId))
                        {
                            memberWeapon.WeaponId = weaponReplacements[memberWeapon.WeaponId];
                        }
                    }
                }

            }
            return saveModel;
        }

        public static void SetSerializedData(
            IKTContext db,
            string data,
            bool deleteFirst = true,
            Dictionary<string, Dictionary<string, string>> replacements = default,
            Action<float?, string> callback = null
        )
        {

            callback?.Invoke(0, "Reading backup");
            SaveModel saveModel = JsonConvert.DeserializeObject<SaveModel>(DecompressString(data));
            int size = saveModel.Size;

            if (deleteFirst)
            {
                DeleteUserData(db);
            }

            callback?.Invoke(0, "Cleaning up old data");
            if (replacements != null && replacements.Count != 0)
            {
                saveModel = ReplaceData(saveModel, replacements);
            }

            var existing_options = db.Set<WarGearOption>()
                .Where(wgo => saveModel.Teams
                    .SelectMany(t => t.Members)
                    .SelectMany(m => m.MemberWarGearOptions)
                    .Select(m => m.WarGearOptionId)
                    .Contains(wgo.Id)
                )
                .Select(wgo => wgo.Id)
                .ToList();

            // import everything
            int progress = 0;
            List<Team> equipes = saveModel.Teams;
            foreach (Team equipe in equipes)
            {
                db.Entry(equipe).State = EntityState.Added;
                foreach (Member membre in equipe.Members)
                {
                    float percent = (float)progress / size;
                    callback?.Invoke(percent, $"Adding {membre.Name} from {equipe.Name}");
                    progress += 1;

                    db.Entry(membre).State = EntityState.Added;
                    foreach (MemberTrait MembreTrait in membre.MemberTraits)
                    {
                        db.Entry(MembreTrait).State = EntityState.Added;
                    }
                    foreach (MemberPsychic MembrePsychique in membre.MemberPsychics)
                    {
                        db.Entry(MembrePsychique).State = EntityState.Added;
                    }
                    foreach (MemberWeapon MembreArme in membre.MemberWeapons)
                    {
                        db.Entry(MembreArme).State = EntityState.Added;
                    }
                    foreach (MemberPower MembrePouvoir in membre.MemberPowers)
                    {
                        db.Entry(MembrePouvoir).State = EntityState.Added;
                    }
                    foreach (MemberWarGearOption MembreRemplacement in membre.MemberWarGearOptions)
                    {
                        // if the id still exists add it, otherwise skip
                        if (existing_options.Contains(MembreRemplacement.WarGearOptionId)) {
                            db.Entry(MembreRemplacement).State = EntityState.Added;
                        }
                    }
                }
            }

            db.SaveChanges();
        }

        public static string CompressString(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            var memoryStream = new MemoryStream();
            using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer, 0, buffer.Length);
            }

            memoryStream.Position = 0;

            var compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);

            var gZipBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
            string result = Convert.ToBase64String(gZipBuffer);

            for(int i = 1; i < result.Length / 100; i++)
            {
                result = result.Insert(i * 100, "\n");
            }
            return result;
        }

        public static string DecompressString(string compressedText)
        {
            byte[] gZipBuffer = Convert.FromBase64String(compressedText);
            using (var memoryStream = new MemoryStream())
            {
                int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                var buffer = new byte[dataLength];

                memoryStream.Position = 0;
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    gZipStream.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer).Replace("\n", "");
            }
        }

    }
}
