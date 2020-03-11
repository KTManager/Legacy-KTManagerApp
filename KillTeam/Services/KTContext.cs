using KillTeam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AppCenter.Crashes;

namespace KillTeam.Services
{
    public abstract class KTContext
    {
        public static IKTContext Db => _Db.Value;
        private static readonly Lazy<KTUserContext> _Db;

        public static event EventHandler<string> UpdateEvent;

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

    }
}
