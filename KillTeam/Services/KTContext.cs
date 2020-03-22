using KillTeam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace KillTeam.Services
{
    public abstract class KTContext
    {
        public static IKTContext Db => _Db.Value;
        private static readonly Lazy<KTUserContext> _Db;

        public static event EventHandler<UpdateEventArgs> UpdateEvent;

        static KTContext()
        {
            _Db = new Lazy<KTUserContext>(() => new DBUpdater(DBPath, Provider, UpdateEvent).GetUpdatedContext());
            Debug.WriteLine("Successfully created the global db");
        }

        public static string DBPath {
            get {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "KTUser.db");
            }
        }

        public static RulesProviders.RulesProvider Provider {
            get {
                return new RulesProviders.ManifestRulesProvider(
                    typeof(KTContext).Assembly,
                    RulesProviders.ManifestRulesProvider.MANIFEST_RULES_PREFIX);
            }
        }

        public static bool ShouldShowLegacyImportModal()
        {
            if (Device.RuntimePlatform != Device.iOS)
            {
                return false;
            }

            if (!File.Exists(DBPath) || !File.Exists(KTLegacyContext.DBPath))
            {
                return false;
            }

            var oldDB = new KTUserContext(DBPath);
            return (oldDB.GetCurrentVersion().RulesVersion == "1.1.1-c3a06fceb2f395c3f188ecd9bbfcd86781b8face5e29032b969b3a97b72c84c7");
        }

    }
}
