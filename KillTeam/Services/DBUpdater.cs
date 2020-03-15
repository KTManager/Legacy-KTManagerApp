using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace KillTeam.Services
{
    public class UpdateEventArgs : EventArgs
    {
        private string message;
        private float? percent;
        private string submessage;
        public UpdateEventArgs(string message, float? percent = null, string submessage = null)
        {
            this.message = message;
            this.percent = percent;
            this.submessage = submessage;
        }

        public string Message => message;
        public float? Percent => percent;
        public string SubMessage => submessage;
    }

    public class DBUpdater
    {
        private readonly string DBPath;
        private readonly RulesProviders.RulesProvider Provider;
        private readonly EventHandler<UpdateEventArgs> Callback;
        private readonly KTUserContext OldUdb;

        public DBUpdater(string dbpath, RulesProviders.RulesProvider provider, EventHandler<UpdateEventArgs> callback = null)
        {
            DBPath = dbpath;
            Provider = provider;
            Callback = callback;

            if (File.Exists(dbpath))
            {
                OldUdb = new KTUserContext(dbpath);
            }
        }

        private void Log(string msg, float? percent = null, string submessage = null)
        {
            if (this.Callback != null)
            {
                Callback(this, new UpdateEventArgs(msg, percent, submessage));
            }
        }

        private bool NeedsUpdate()
        {
            var version = OldUdb?.GetCurrentVersion();
            return version == null || version?.RulesVersion != Provider.GetVersion() || Provider.GetVersion().EndsWith("dev");
        }

        private IKTContext GetBackupContext()
        {
            if (OldUdb == null && File.Exists(KTLegacyContext.DBPath))
            {
                return new KTLegacyContext();
            }

            return OldUdb;
        }

        public KTUserContext GetUpdatedContext()
        {
            Log("Checking if Database needs update");
            if (NeedsUpdate())
            {
                Log($"Updating Database to {Provider.GetVersion()}");
                // creates new UDB, clobbers any old or unfinished updates
                var newUdbPath = DBPath + ".new";
                if (File.Exists(newUdbPath))
                {
                    File.Delete(newUdbPath);
                }
                var newUdb = new KTUserContext(newUdbPath);

                IKTContext backup = GetBackupContext();

                Log($"Importing rules to new database");
                // import the rules and user data to the new db
                newUdb.ImportRules(Provider);
                if (backup != null)
                {
                    Log($"Backing up old Database");
                    var replacements = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(Provider.GetReplacementsJSON());
                    Log($"Applying backup to new Database");
                    Sauvegarde.SetSerializedData(
                        newUdb,
                        Sauvegarde.GetSerializedData(backup),
                        false,
                        replacements,
                        (float? p, string s) => Log(null, p, s)
                    );
                }

                Log($"Applying New Database");
                // clobber the old db with the new one
                newUdb.Database.CloseConnection();
                OldUdb?.Database?.CloseConnection();
                File.Copy(newUdbPath, DBPath, true);
                File.Delete(newUdbPath);
            }

            Log($"Loading Database");
            return new KTUserContext(DBPath);
        }

    }
}
