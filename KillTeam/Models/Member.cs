using KillTeam.EvRemp;
using KillTeam.Services;
using KillTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace KillTeam.Models
{
    public class Member : INotifyPropertyChanged
    {
        #region Backing Fields

        private string _name;

        private int _level;

        private int _cost;

        #endregion Backing Fields

        #region Native Properties 

        public string Id { get; set; }

        public string ModelProfileId { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Title));
            }
        }

        public string TeamId { get; set; }

        public string SpecialistId { get; set; }

        public int Position { get; set; }

        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SpecialistLevel));
            }
        }

        public int Xp { get; set; }

        public bool Selected { get; set; }

        public int FleshWounds { get; set; }
        
        public bool Convalescence { get; set; }

        public bool Recruit { get; set; }

        public int Cost
        {
            get { return _cost; }
            set
            {
                _cost = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Title));
            }
        }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public virtual Team Team { get; set; }

        [JsonIgnore]
        public virtual ModelProfile ModelProfile { get; set; }

        public virtual Specialist Specialist { get; set; }

        public virtual ICollection<MemberPower> MemberPowers { get; set; }

        public virtual ICollection<MemberWeapon> MemberWeapons { get; set; }

        public virtual ICollection<MemberTrait> MemberTraits { get; set; }

        public virtual ICollection<MemberWarGearOption> MemberWarGearOptions { get; set; }
        
        public virtual ICollection<MemberPsychic> MemberPsychics { get; set; }
        
        #endregion Navigation Properties

        #region Calculated Properties

        public bool IsCommander => ModelProfile?.IsCommander == true;

        [JsonIgnore]
        public string FormattedXp
        {
            get
            {
                string ret = Properties.Resources.Experience + " : " + Xp;
                if (Convalescence)
                {
                    ret += ", " + Properties.Resources.Convalescence;
                }
                if (Recruit)
                {
                    ret += ", " + Properties.Resources.Recrue;
                }
                return ret;
            }
        }

        [JsonIgnore]
        public string Experience
        {
            get
            {
                return Properties.Resources.Experience + " : ";
            }
        }

        [JsonIgnore]
        public string Blessure
        {
            get
            {
                return Properties.Resources.Blessures + " : ";
            }
        }

        [JsonIgnore]
        public bool IsPsyker
        {
            get
            {
                return ModelProfile.NumberOfPsychicsManifestationPerRound > 0;
            }
        }

        [JsonIgnore]
        public string PsykerDesc
        {
            get
            {
                return String.Format(Properties.Resources.PsykerDesc, ModelProfile.NumberOfPsychicsManifestationPerRound, ModelProfile.NumberOfPsychicsDenialPerRound);
            }
        }

        [JsonIgnore]
        public bool HasAbilities
        {
            get
            {
                return Abilities.Count > 0;
            }
        }

        [JsonIgnore]
        public string FormattedConvRecruit
        {
            get
            {
                string ret = "";
                if (Convalescence)
                {
                    ret += "" + Properties.Resources.Convalescence;
                }
                if (Recruit)
                {
                    ret += ", " + Properties.Resources.Recrue;
                }
                return ret;
            }
        }
        
        public string Title
        {
            get
            {
                return Name + " (" + Cost + ")"; ;
            }
        }

        [JsonIgnore]
        public string SpecialistLevel
        {
            get
            {
                string ret = ModelProfile.Name;
                if (Specialist != null)
                {
                    ret += ", " + Specialist.Name;
                }
                if (_level > 1)
                {
                    ret += ", " + Properties.Resources.Niveau + " " + Level;
                }
                return ret;
            }
        }

        [JsonIgnore]
        public string ShortWeaponLevel
        {
            get
            {
                var armesBase = GetDefaultWeapons();
                var armesPrincipale = MemberWeapons.Select(a => a.Weapon).ToList();
                foreach (Weapon arme in armesBase)
                {
                    var removedArme = armesPrincipale.Where(a => a.Id == arme.Id).FirstOrDefault();
                    if (removedArme != null)
                        armesPrincipale.Remove(removedArme);
                }
                string armes = string.Join(", ", armesPrincipale.OrderByDescending(a => a).Select(a => a.Name));
                string ret = SpecialistLevel;
                if (!string.IsNullOrWhiteSpace(armes))
                {
                    ret += ", " + armes;
                }
                return ret;
            }
        }

        [JsonIgnore]
        public string ShortWeapon
        {
            get
            {
                var armesBase = GetDefaultWeapons();
                var armesPrincipale = MemberWeapons.Select(a => a.Weapon).ToList();
                foreach (Weapon arme in armesBase)
                {
                    var removedArme = armesPrincipale.Where(a => a.Id == arme.Id).FirstOrDefault();
                    if (removedArme != null)
                        armesPrincipale.Remove(removedArme);
                }
                return string.Join(", ", armesPrincipale.OrderByDescending(a => a).Select(a => a.ShortName));
            }
        }

        [JsonIgnore]
        [NotMapped]
        public List<Ability> Abilities
        {
            get
            {

                List<Ability> aptitudes = new List<Ability>();

                if (Team == null)
                {
                    return aptitudes;
                }

                aptitudes.AddRange(Team.Faction.Abilities);
                aptitudes.AddRange(ModelProfile.Model.Abilities);
                aptitudes.AddRange(ModelProfile.Abilities);

                foreach (Weapon arme in MemberWeapons.Select(a => a.Weapon).Where(a => a.WeaponProfiles.Count == 0))
                {
                    aptitudes.Add(new Ability()
                    {
                        NameEn = arme.NameEn,
                        NameFr = arme.NameFr,
                        NameDe = arme.NameDe,
                        DescriptionEn = arme.DescriptionEn,
                        DescriptionFr = arme.DescriptionFr,
                        DescriptionDe = arme.DescriptionDe
                    });
                }

                foreach (MemberPower pouvoir in MemberPowers)
                {
                    aptitudes.Add(new Ability()
                    {
                        NameEn = pouvoir.Power.NameEn,
                        NameFr = pouvoir.Power.NameFr,
                        NameDe = pouvoir.Power.NameDe,
                        DescriptionEn = pouvoir.Power.DescriptionEn,
                        DescriptionFr = pouvoir.Power.DescriptionFr,
                        DescriptionDe = pouvoir.Power.DescriptionDe
                    });
                }

                if (ModelProfile.IsCommander)
                {

                    foreach (Trait trait in MemberTraits.Select(t => t.Trait))
                    {
                        aptitudes.Add(new Ability()
                        {
                            NameEn = trait.NameEn,
                            NameFr = trait.NameFr,
                            NameDe = trait.NameDe,
                            DescriptionEn = trait.DescriptionEn,
                            DescriptionFr = trait.DescriptionFr,
                            DescriptionDe = trait.DescriptionDe
                        });
                    }
                }

                aptitudes = aptitudes.OrderBy(a => a.Name).ToList();

                return aptitudes;
            }
        }

        #endregion Calculated Properties

        #region Constructors

        public Member()
        {
            MemberPowers = new List<MemberPower>();
            MemberWeapons = new List<MemberWeapon>();
            MemberTraits = new List<MemberTrait>();
            MemberPsychics = new List<MemberPsychic>();
            MemberWarGearOptions = new List<MemberWarGearOption>();
        }

        #endregion Constructors

        #region Methods

        public void UpdateCost()
        {
            if (ModelProfile.IsCommander)
            {
                Cost = ModelProfile.LevelCosts.First(c => c.Level == _level).Cost;
                Cost += MemberTraits.Sum(tr => tr.Trait.Cost);
            }
            else
            {
                Cost = ModelProfile.Cost;
                Cost += (Level - 1) * (SpecialistId != null ? 4 : 1);
            }

            foreach (MemberWeapon marme in MemberWeapons)
            {
                CostOverride sca = ModelProfile.CostOverrides.Where(s => s.WeaponId == marme.Weapon.Id).FirstOrDefault();
                if (sca == null)
                {
                    Cost += marme.Weapon.Cost;
                }
                else
                {
                    Cost += sca.Cost;
                }
            }

        }

        public List<Weapon> GetDefaultWeapons()
        {
            List<Weapon> ArmesBase = new List<Weapon>();
            if (ModelProfile.ModelProfileWeapons.Count > 0)
            {
                foreach (ModelProfileWeapon arme in ModelProfile.ModelProfileWeapons)
                {
                    ArmesBase.Add(arme.Weapon);
                }
            }
            else
            {
                foreach (ModelWeapon arme in ModelProfile.Model.ModelWeapons)
                {
                    ArmesBase.Add(arme.Weapon);
                }

            }
            return ArmesBase;
        }

        public List<WarGearCombination> GetAllowedCombinations()
        {
            //On recupere complètement les données nécessaires
            Member membre = KTContext.Db.Members.Where(m => m.Id == Id)
                .Include(m => m.ModelProfile.WarGearOptions)
                .Include(m => m.ModelProfile.Model.WarGearOptions)
                .Include(m => m.ModelProfile.Model.ModelWeapons)
                .ThenInclude(sn => sn.Weapon)
                .First();

            List<WarGearCombination> configs = new List<WarGearCombination>();
            List<Weapon> ArmesBase = membre.GetDefaultWeapons();

            //Configuration de base
            WarGearCombination config = new WarGearCombination() { Weapons = ArmesBase };
            configs.Add(config);
            foreach (WarGearOption remplacement in membre.ModelProfile.GetAllWarGearOptions())
            {
                List<WarGearCombination> configInit = new List<WarGearCombination>();
                WarGearCombination oldconf = new WarGearCombination();
                oldconf.Weapons.AddRange(ArmesBase);
                configInit.Add(oldconf);
                configs.AddRange(new ReplaceNode().Evaluate(configInit, remplacement.Operation));
            }


            return configs;
        }

        public static async Task<Member> DuplicateFrom(string memberId, string teamId = null)
        {
            Member duplicateMembre = duplicateMembre = KTContext.Db.Members
                .Where(m => m.Id == memberId)
                .Include(e => e.MemberPowers)
                .ThenInclude(e => e.Power)
                .Include(m => m.Specialist)
                .ThenInclude(e => e.Tactics)
                .Include(e => e.Specialist.Tactics)
                .Include(e => e.Specialist.Powers)
                .Include(e => e.MemberWeapons)
                .ThenInclude(e => e.Weapon.WeaponProfiles)
                .ThenInclude(e => e.WeaponType)
                .Include(e => e.ModelProfile)
                .ThenInclude(e => e.Abilities)
                .ThenInclude(a => a.Details)
                .Include(e => e.ModelProfile.Model)
                .ThenInclude(e => e.Abilities)
                .ThenInclude(a => a.Details)
                .Include(e => e.ModelProfile.Tactics)
                .Include(m => m.MemberTraits)
                .ThenInclude(ma => ma.Trait)
                .Include(m => m.ModelProfile.CostOverrides)
                .Include(m => m.ModelProfile.LevelCosts)
                .Include(m => m.MemberPsychics)
                .ThenInclude(ma => ma.Psychic)
                .AsNoTracking()
                .First();

            Team equipe = new Team();
            if (teamId == null)
            {
                equipe = KTContext.Db.Teams
                    .AsNoTracking()
                    .Where(e => e.Id == duplicateMembre.TeamId)
                    .Include(e => e.Faction.Tactics)
                    .Include(e => e.Faction.Abilities)
                    .ThenInclude(a => a.Details)
                    .Include(e => e.Members)
                    .First();
            }

            Member membre = new Member();
            membre.Id = Guid.NewGuid().ToString();
            membre.Name = duplicateMembre.Name;
            membre.ModelProfile = duplicateMembre.ModelProfile;
            membre.Level = duplicateMembre.Level;
            membre.Specialist = duplicateMembre.Specialist;
            membre.TeamId = teamId != null ? teamId : duplicateMembre.TeamId;
            membre.Position = teamId != null ? duplicateMembre.Position : equipe.Members.Count();
            membre.Xp = duplicateMembre.Xp;
            membre.FleshWounds = duplicateMembre.FleshWounds;
            membre.Convalescence = duplicateMembre.Convalescence;
            membre.Recruit = duplicateMembre.Recruit;
            membre.Selected = duplicateMembre.Selected;

            KTContext.Db.Entry(membre).State = EntityState.Added;

            foreach (Weapon arme in duplicateMembre.MemberWeapons.Select(a => a.Weapon))
            {
                MemberWeapon membreArme = new MemberWeapon();
                membreArme.Id = Guid.NewGuid().ToString();
                membreArme.Weapon = arme;
                membreArme.WeaponId = arme.Id;
                membreArme.MemberId = membre.Id;
                KTContext.Db.Entry(membreArme).State = EntityState.Added;
            }
            foreach (Trait trait in duplicateMembre.MemberTraits.Select(a => a.Trait))
            {
                MemberTrait membreTrait = new MemberTrait();
                membreTrait.Id = Guid.NewGuid().ToString();
                membreTrait.Trait = trait;
                membreTrait.TraitId = trait.Id;
                membreTrait.MemberId = membre.Id;
                KTContext.Db.Entry(membreTrait).State = EntityState.Added;
            }

            foreach (Power pouvoir in duplicateMembre.MemberPowers.Select(a => a.Power))
            {
                MemberPower membrePouvoir = new MemberPower();
                membrePouvoir.Id = Guid.NewGuid().ToString();
                membrePouvoir.Power = pouvoir;
                membrePouvoir.PowerId = pouvoir.Id;
                membrePouvoir.MembrerId = membre.Id;
                KTContext.Db.Entry(membrePouvoir).State = EntityState.Added;
            }
            foreach (Psychic psychique in duplicateMembre.MemberPsychics.Select(a => a.Psychic))
            {
                MemberPsychic membrePsychique = new MemberPsychic();
                membrePsychique.Id = Guid.NewGuid().ToString();
                membrePsychique.Psychic = psychique;
                membrePsychique.PsychicId = psychique.Id;
                membrePsychique.MemberId = membre.Id;
                KTContext.Db.Entry(membrePsychique).State = EntityState.Added;
            }
            foreach (WarGearOption remplacement in duplicateMembre.MemberWarGearOptions.Select(a => a.WarGearOption))
            {
                MemberWarGearOption membreRemplacement = new MemberWarGearOption();
                membreRemplacement.Id = Guid.NewGuid().ToString();
                membreRemplacement.WarGearOption = remplacement;
                membreRemplacement.WarGearOptionId = remplacement.Id;
                membreRemplacement.MemberId = membre.Id;
                KTContext.Db.Entry(membreRemplacement).State = EntityState.Added;
            }

            membre.UpdateCost();

            if (teamId == null)
            {
                int nbSameName = equipe.Members.Where(m => m.Name.Contains(membre.Name)).Count();
                string membreNom = membre.Name;
                if (nbSameName != 0)
                {
                    int i = 1;
                    while (equipe.Members.Where(m => m.Name == membreNom).Count() == 1)
                    {
                        membreNom = membre.Name + " - " + Properties.Resources.Copier + " (" + i + ")";
                        i++;
                    }
                }
                membre.Name = membreNom;
                equipe.Members.Add(membre);
            }
            await KTContext.Db.SaveChangesAsync();

            return membre;
        }


        public static async Task<Member> CreateFrom(string teamId, string modelProfileId)
        {
            ModelProfile declinaison = KTContext.Db.ModelProfiles
                .Where(e => e.Id == modelProfileId)
                .Include(m => m.CostOverrides)
                .Include(m => m.LevelCosts)
                .Include(m => m.WarGearOptions)
                .Include(m => m.ModelProfileWeapons)
                .ThenInclude(sn => sn.Weapon)
                .Include(m => m.Psychics)
                .Include(m => m.Model.ModelWeapons)
                .ThenInclude(sn => sn.Weapon)
                .AsNoTracking()
                .First();


            Team equipe = KTContext.Db.Teams.Find(teamId);
            int nbSameName = equipe.Members.Where(m => m.Name.Contains(declinaison.Name)).Count();
            string membreNom = declinaison.Name;

            if (nbSameName != 0)
            {
                int i = 1;
                while (equipe.Members.Where(m => m.Name == membreNom).Count() == 1)
                {
                    membreNom = declinaison.Name + " " + i;
                    i++;
                }
            }


            Member membre = new Member();
            membre.Id = Guid.NewGuid().ToString();
            membre.Name = membreNom;
            membre.ModelProfile = declinaison;
            membre.Level = 1;
            membre.TeamId = teamId;
            membre.Position = KTContext.Db.Members
            .Where(m => m.TeamId == teamId)
            .Select(a => a.Position)
            .ToList()
            .DefaultIfEmpty(0)
            .Max() + 1;

            KTContext.Db.Entry(membre).State = EntityState.Added;

            foreach (Weapon arme in membre.GetDefaultWeapons())
            {
                MemberWeapon membreArme = new MemberWeapon();
                membreArme.Id = Guid.NewGuid().ToString();
                membreArme.Weapon = arme;
                membreArme.WeaponId = arme.Id;
                membreArme.MemberId = membre.Id;
                KTContext.Db.Entry(membreArme).State = EntityState.Added;
            }
            membre.UpdateCost();

            if (declinaison.NumberOfPsychicsManifestationPerRound > 0)
            {
                Psychic psybolt = KTContext.Db.Psychics.Find("1");
                MemberPsychic mp = new MemberPsychic() { Psychic = psybolt, PsychicId = psybolt.Id, Member = membre, MemberId = membre.Id };
                KTContext.Db.Entry(mp).State = EntityState.Added;

                foreach (Psychic psy in KTContext.Db.Psychics.Where(p => p.ModelProfileId == declinaison.Id).Take(declinaison.NumberOfKnownPsychics))
                {
                    MemberPsychic mp2 = new MemberPsychic() { Psychic = psy, PsychicId = psy.Id, Member = membre, MemberId = membre.Id };
                    KTContext.Db.Entry(mp2).State = EntityState.Added;
                }
            }

            return membre;

        }

        public bool Identical(Member member)
        {
            return member.MemberWeapons.Select(a => a.WeaponId).SequenceEqual(MemberWeapons.Select(a => a.WeaponId))
                && member.MemberPowers.Select(a => a.PowerId).SequenceEqual(MemberPowers.Select(a => a.PowerId))
                && member.ModelProfile.Id == ModelProfile.Id
                && member.Level == Level
                && member.Specialist == Specialist;
        }

        public List<SelectionPouvoirViewModel> GetSelectedPowers(ChangeLevelViewModel changeLevelViewModel)
        {
            List<SelectionPouvoirViewModel> pouvoirs = new List<SelectionPouvoirViewModel>();

            foreach (Power pouvoir in KTContext.Db.Powers.Where(p => p.SpecialistId == SpecialistId).Include(p => p.Previews).OrderBy(p => p.Id))
            {
                SelectionPouvoirViewModel selection = new SelectionPouvoirViewModel(changeLevelViewModel);
                selection.IsSelected = MemberPowers.Any(p => p.PowerId == pouvoir.Id);
                selection.Pouvoir = pouvoir;
                pouvoirs.Add(selection);
            }

            if (SpecialistId != null)
            {
                foreach (SelectionPouvoirViewModel pvm in pouvoirs)
                {
                    pvm.Parent = pouvoirs.FirstOrDefault(p => p.Pouvoir.Id == pvm.Pouvoir.PreviewsId);
                    pvm.Childrens = pouvoirs.Where(p => p.Pouvoir.PreviewsId == pvm.Pouvoir.Id).ToList();
                    pvm.Brothers = pouvoirs.Where(p => p.Pouvoir.PreviewsId == pvm.Pouvoir.PreviewsId && p.Pouvoir.Id != pvm.Pouvoir.Id).ToList();
                }
                var first = pouvoirs.Where(p => p.Pouvoir.Previews == null).First();
                first.IsSelected = true;
                first.IsVisible = false;
            }

            return pouvoirs;
        }

        #endregion Methods

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (propertyName == null) return;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
    }
}
