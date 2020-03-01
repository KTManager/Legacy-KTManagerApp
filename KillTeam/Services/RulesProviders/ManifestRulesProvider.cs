using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace KillTeam.Services.RulesProviders
{
    public class ManifestRulesProvider : RulesProvider
    {
        public const string MANIFEST_RULES_PREFIX = "KillTeam.SharedAssets.Rules.";

        private System.Reflection.Assembly assembly;
        private string prefix;

        public ManifestRulesProvider(System.Reflection.Assembly assembly, string prefix)
        {
            this.assembly = assembly;
            this.prefix = prefix;
        }

        public override string GetVersion()
        {
            return new StreamReader(assembly.GetManifestResourceStream(prefix + "version.txt")).ReadToEnd();
        }

        protected override string GetReplacementsName()
        {
            return prefix + "replacements.json";
        }

        protected override IEnumerable<string> GetAllNames()
        {
            return assembly.GetManifestResourceNames()
                .Where(name => name.StartsWith(this.prefix) && name.EndsWith(".json"));
        }

        protected override string GetType(string name)
        {
            Debug.Assert(name.StartsWith(this.prefix));
            return name.Split('.').Skip(3).TakeWhile(y => y != "json").Last();
        }

        protected override string GetFaction(string name)
        {
            Debug.Assert(name.StartsWith(this.prefix));
            name = name.Replace(this.prefix, "");
            return name.StartsWith("faction") ? name.Split('.')[1] : "";
        }

        protected override string GetJSON(string name)
        {
            Debug.Assert(name.StartsWith(this.prefix));
            return new StreamReader(this.assembly.GetManifestResourceStream(name)).ReadToEnd();
        }
    }
}
