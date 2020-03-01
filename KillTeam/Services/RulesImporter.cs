using System;
using System.Collections.Generic;
using Debug = System.Diagnostics.Debug;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using KillTeam.Models;
using Microsoft.EntityFrameworkCore;

namespace KillTeam.Services
{
    class RulesImporter
    {

        private static void ImportType<T>(
            DbSet<T> dbSet,
            IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> rules,
            string type,
            Func<string, T, T> mutator = null
        ) where T : class
        {
            // If this type doesn't exist, return early
            if (!rules.ContainsKey(type)) {
                return;
            }

            // otherwise loop through each faction and deserialize and import
            var jsonByFaction = rules[type];
            foreach (string faction in jsonByFaction.Keys)
            {
                IEnumerable<T> list = JsonConvert.DeserializeObject<List<T>>(jsonByFaction[faction]);
                if (mutator != null && faction != "")
                {
                    list = list.Select(x => mutator(faction, x));
                }

                dbSet.AddRange(list);
            }
        }

        public static void ImportJSON(
            IKTRulesContext db,
            RulesProviders.RulesProvider rulesProvider)
        {
            var rules = rulesProvider.getJSON();
            // factions are the only ones that aren't lists and we need the IDs
            var factionToId = new Dictionary<string, string>();
            int nrows = 0;
            if (rules.ContainsKey("faction"))  // tests don't always include factions
            {
                foreach (var kv in rules["faction"])
                {
                    string faction = kv.Key;
                    Faction info = JsonConvert.DeserializeObject<Faction>(kv.Value);
                    factionToId[faction] = info.Id;
                    db.Factions.Add(info);
                }
                nrows = db.SaveChanges();
            }
            Debug.WriteLine($"Saved {nrows} factions");

            // import everything else

            // global: no dependencies
            ImportType(db.Phases, rules, "phases");
            ImportType(db.Specialists, rules, "specialists");
            ImportType(db.WeaponTypes, rules, "weapon_types");

            // global: depends on specialists
            ImportType(db.Powers, rules, "powers");

            // global: depends on weapon_types
            ImportType(db.Weapons, rules, "weapons");

            // depends on specialists, weapons
            ImportType(db.Models, rules, "models", (faction, model) => {
                model.FactionId = factionToId[faction];
                return model;
            });

            // depends on models
            ImportType(db.Abilities, rules, "abilities", (faction, ability) => {
                if (ability.ModelId == null && ability.ModelProfileId == null)
                {
                    ability.FactionId = factionToId[faction];
                }
                return ability;
            });
            ImportType(db.Psychics, rules, "psychics");
            ImportType(db.Traits, rules, "traits");

            // depends on models, specialists
            ImportType(db.Tactics, rules, "tactics", (faction, tactic) => {
                tactic.FactionId = factionToId[faction];
                return tactic;
            });

            // TODO make sure we didn't miss anything

            nrows = db.SaveChanges();
            Console.WriteLine($"Saved {nrows} other rows");
        }
    }
}
