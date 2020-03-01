using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace KillTeam.Services.RulesProviders
{
    public abstract class RulesProvider
    {
        abstract public string GetVersion();
        abstract protected string GetReplacementsName();
        public string GetReplacementsJSON()
        {
            return this.GetJSON(this.GetReplacementsName());
        }

        abstract protected IEnumerable<string> GetAllNames();

        abstract protected string GetType(string name);
        abstract protected string GetFaction(string name);
        abstract protected string GetJSON(string name);

        public IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> getJSON()
        {
            // eg: "ability" => {"" => "[{...},...]", "Orks" => "[{...},...]"}
            var namesByType = this.GetAllNames()
                .GroupBy(name => this.GetType(name))
                .ToDictionary(pair => pair.Key, pair => pair.ToList());

            var rulesJsonByTypeAndFaction = new Dictionary<string, IReadOnlyDictionary<string, string>> { };
            foreach (var kv in namesByType)
            {
                var type = kv.Key;
                var rulesManifests = kv.Value;
                var typeRules = new Dictionary<string, string> { };

                foreach (var name in rulesManifests)
                {
                    string faction = this.GetFaction(name);
                    string json = this.GetJSON(name);

                    Debug.Assert(
                        !typeRules.ContainsKey(faction),
                        $"Expected typeRules not to contain '{faction}': {string.Join(", ", typeRules.Keys.Select(k => $"'{k}'"))}"
                    );
                    typeRules[faction] = json;
                }

                // add the rules to the master dictionary
                Debug.Assert(!rulesJsonByTypeAndFaction.ContainsKey(type));
                rulesJsonByTypeAndFaction[type] = typeRules;
            }
            return rulesJsonByTypeAndFaction;
        }
    }
}
