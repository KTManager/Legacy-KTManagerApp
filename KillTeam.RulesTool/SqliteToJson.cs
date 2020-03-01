using KillTeam.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IKTRulesContext = KillTeam.Services.IKTRulesContext;
using System.IO;

namespace KillTeam.RulesTool
{
    class SqliteToJson
    {
        private IReadOnlyDictionary<string, string> FactionIdToName;

        private IKTRulesContext Db;
        private string Root;

        private string FactionsPath {
            get {
                return Path.Join(Root, "factions");
            }
        }

        public SqliteToJson(IKTRulesContext db, string root)
        {
            this.Db = db;
            this.Root = root;
        }

        public async Task Export()
        {
            FactionIdToName = await Db.Factions.ToDictionaryAsync(
                faction => faction.Id,
                faction => faction.NameEn.Replace(" ", "").Replace("'", "")
            );

            foreach (string name in FactionIdToName.Values)
            {
                Directory.CreateDirectory(Path.Join(FactionsPath, name));
            }

            await WriteOutType("faction", await GetFactionsAsync(Db));
            await WriteOutType("abilities", await GetAbilitiesAsync(Db));
            await WriteOutType("tactics", await GetTacticsAsync(Db));
            await WriteOutType("models", await GetModelsAsync(Db));
            await WriteOutType("weapons", await GetWeaponsAsync(Db));
            await WriteOutType("specialists", await GetSpecialistsAsync(Db));
            await WriteOutType("phases", await GetPhasesAsync(Db));
            await WriteOutType("weapon_types", await GetWeaponTypesAsync(Db));
            await WriteOutType("traits", await GetTraitsAsync(Db));
            await WriteOutType("psychics", await GetPsychicsAsync(Db));
            await WriteOutType("powers", await GetPowersAsync(Db));
        }

        #region Model Getters

        static async Task<Dictionary<string, Faction>> GetFactionsAsync(IKTRulesContext db)
        {
            return await db.Factions
                .GroupBy(faction => faction.Id)
                .ToDictionaryAsync(pair => pair.Key, pair => pair.Single());
        }

        static async Task<Dictionary<string, List<Ability>>> GetAbilitiesAsync(IKTRulesContext db)
        {
            return await db.Abilities
                .Include(ability => ability.Details)
                .GroupBy(ability =>
                    !string.IsNullOrEmpty(ability.FactionId) ? ability.FactionId :
                    !string.IsNullOrEmpty(ability.ModelId) ? ability.Model.FactionId :
                    !string.IsNullOrEmpty(ability.ModelProfileId) ? ability.ModelProfile.Model.FactionId :
                    null)
                .ToDictionaryAsync(
                    pair => pair.Key ?? "",
                    pair => pair.OrderBy(ability => ability.Id).ToList()
                );
        }

        static async Task<Dictionary<string, List<Tactic>>> GetTacticsAsync(IKTRulesContext db)
        {
            return await db.Tactics
                .GroupBy(tactic =>
                    !string.IsNullOrEmpty(tactic.FactionId) ? tactic.FactionId :
                    !string.IsNullOrEmpty(tactic.ModelProfileId) ? tactic.ModelProfile.Model.FactionId :
                    null)
                .ToDictionaryAsync(
                    pair => pair.Key ?? "",
                    pair => pair.OrderBy(tactic => tactic.Id).ToList()
                );
        }

        static async Task<Dictionary<string, List<Model>>> GetModelsAsync(IKTRulesContext db)
        {
            return await db.Models
                // profile, including specialisms
                .Include(model => model.ModelProfiles)
                .ThenInclude(modelProfile => modelProfile.Specialists)

                // include weapons attached to profiles
                .Include(model => model.ModelProfiles)
                .ThenInclude(modelProfile => modelProfile.ModelProfileWeapons)

                // include wargear options attached to profiles
                .Include(model => model.ModelProfiles)
                .ThenInclude(modelProfile => modelProfile.WarGearOptions)

                // include level costs associated with profiles
                .Include(model => model.ModelProfiles)
                .ThenInclude(modelProfile => modelProfile.LevelCosts)

                // include weapon cost overrides for this model
                .Include(model => model.ModelProfiles)
                .ThenInclude(modelProfile => modelProfile.CostOverrides)


                // weapons
                .Include(model => model.ModelWeapons)

                // wargear options
                .Include(model => model.WarGearOptions)

                // group and return
                .GroupBy(model => model.FactionId)
                .ToDictionaryAsync(
                    pair => pair.Key,
                    pair => pair.OrderBy(model => model.Id).ToList()
                );
        }

        static async Task<Dictionary<string, List<Weapon>>> GetWeaponsAsync(IKTRulesContext db)
        {
            // weapons aren't technically faction specific
            return new Dictionary<string, List<Weapon>> {
                [""] = await db.Weapons
                    .Include(weapon => weapon.WeaponProfiles)
                    .OrderBy(weapon => weapon.Id)
                    .ToListAsync()
            };
        }

        static async Task<Dictionary<string, List<Specialist>>> GetSpecialistsAsync(IKTRulesContext db)
        {
            return new Dictionary<string, List<Specialist>> {
                [""] = await db.Specialists.OrderBy(specialist => specialist.Id).ToListAsync()
            };
        }

        static async Task<Dictionary<string, List<Phase>>> GetPhasesAsync(IKTRulesContext db)
        {
            return new Dictionary<string, List<Phase>>
            {
                [""] = await db.Phases.OrderBy(phase => phase.Id).ToListAsync()
            };
        }

        static async Task<Dictionary<string, List<WeaponType>>> GetWeaponTypesAsync(IKTRulesContext db)
        {
            return new Dictionary<string, List<WeaponType>>
            {
                [""] = await db.WeaponTypes.OrderBy(weaponType => weaponType.Id).ToListAsync()
            };
        }

        static async Task<Dictionary<string, List<Trait>>> GetTraitsAsync(IKTRulesContext db)
        {
            return await db.Traits
                .GroupBy(trait =>
                    !string.IsNullOrEmpty(trait.ModelProfileId)
                        ? trait.ModelProfile.Model.FactionId
                        : null)
                .ToDictionaryAsync(
                    pair => pair.Key ?? "",
                    pair => pair.OrderBy(trait => trait.Id).ToList()
                );
        }

        static async Task<Dictionary<string, List<Psychic>>> GetPsychicsAsync(IKTRulesContext db)
        {
            return await db.Psychics
                .GroupBy(psychic =>
                    !string.IsNullOrEmpty(psychic.ModelProfileId)
                        ? psychic.ModelProfile.Model.FactionId
                        : null)
                .ToDictionaryAsync(
                    pair => pair.Key ?? "",
                    pair => pair.OrderBy(psychic => psychic.Id).ToList()
                );
        }

        static async Task<Dictionary<string, List<Power>>> GetPowersAsync(IKTRulesContext db)
        {
            return new Dictionary<string, List<Power>>
            {
                [""] = await db.Powers.OrderBy(power => power.Id).ToListAsync()
            };
        }

        #endregion

        #region Outputters

        private async Task WriteOutType<T>(string item_name, IDictionary<string, T> items)
        {
            // write out common items
            if (items.ContainsKey(""))
            {
                await DumpJson(items[""], Path.Join(Root, $"{item_name}.json"));
            }

            // write out per-faction items
            foreach (var kv in FactionIdToName)
            {
                // organize key and value
                var faction_id = kv.Key;
                string faction_name = kv.Value;

                if (items.ContainsKey(faction_id))
                {
                    // jsonify the faction items
                    var out_path = Path.Join(FactionsPath, $"{faction_name}/{item_name}.json");
                    await DumpJson(items[faction_id], out_path);
                }
            }
        }

        static async Task DumpJson<T>(T items, string path)
        {
            await File.WriteAllTextAsync(path, JsonConvert.SerializeObject(items, Formatting.Indented));
        }

        #endregion
    }
}
