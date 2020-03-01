using KillTeam.Models;
using KillTeam.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KillTeam.RulesTool
{
    class CostTable
    {
        private readonly IKTRulesContext db;
        private readonly string factionId;

        private Dictionary<string, List<Weapon>> modelProfileToWeapons = null;
        private List<Model> orderedModels = null;
        private Dictionary<string, List<Weapon>> wargear = null;

        public CostTable(IKTRulesContext db, string factionId)
        {
            this.db = db;
            this.factionId = factionId;
        }

        private async Task PrefetchDataAsync()
        {
            if (this.modelProfileToWeapons == null)
            {
                this.modelProfileToWeapons = await this.GetModelProfileToWeaponsAsync();
            }

            if (this.orderedModels == null)
            {
                this.orderedModels = await this.GetOrderedModelsAsync();
            }

            if (this.wargear == null)
            {
                this.wargear = await this.GetWargearAsync();
            }
        }

        public async Task PrintModelTable()
        {
            await this.PrefetchDataAsync();

            Console.WriteLine("\n== Models: ==\n");

            Debug.Assert(this.orderedModels != null);
            foreach (Model model in this.orderedModels)
            {
                Console.WriteLine($"[{model.Id}] {model.NameEn}");
                foreach (ModelProfile modelProfile in model.ModelProfiles)
                {
                    if (modelProfile.LevelCosts.Count != 0)
                    {
                        foreach (var levelCost in modelProfile.LevelCosts.OrderBy(lc => lc.Level))
                        {
                            Console.WriteLine($" - [{modelProfile.Id}] {modelProfile.NameEn} ({levelCost.Level}): {levelCost.Cost}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($" - [{modelProfile.Id}] {modelProfile.NameEn}: {modelProfile.Cost}");
                    }
                }
            }
        }

        public async Task PrintWargearTable()
        {
            await this.PrefetchDataAsync();

            Console.WriteLine("\n== Wargear: ==\n");

            Debug.Assert(this.wargear != null);
            foreach (var kv in this.wargear)
            {
                Console.WriteLine($"=== {kv.Key} ===");
                await PrintWargearList(kv.Value);
            }
        }

        private async Task PrintWargearList(List<Weapon> wargear)
        {
            foreach (Weapon weapon in wargear)
            {
                // model to cost to list of modelProfiles
                var overrides = await this.db.Weapons.Where(w => w.Id == weapon.Id)
                    .SelectMany(w => w.CostOverrides)
                    .Where(co => co.ModelProfile.Model.FactionId == this.factionId)
                    .Include(co => co.ModelProfile)
                    .GroupBy(co => co.ModelProfile.ModelId)
                    .ToDictionaryAsync(
                        g => g.Key,
                        g => g.GroupBy(co => co.Cost).ToDictionary(
                            h => h.Key,
                            h => h.Select(co => co.ModelProfile).ToList()
                        )
                    );

                /* if a particular wargear/weapon has an override for *all*
                 * models in the army, then that's the new "default" for that
                 * army, eg: storm bolters are 2pts for AA, but 0 pts for GK. In
                 * our DB, we picked 2pts cost, and added a cost override to
                 * every GK to set it to zero. This bit of logic hides that
                 * particular weirdness to match the book.
                 */
                var base_cost = weapon.Cost;
                if (this.orderedModels.Count == overrides.Count)
                {
                    var counts = overrides.Values.SelectMany(x => x.Keys).GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
                    base_cost = counts.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
                }


                Console.WriteLine($"[{weapon.Id}] {weapon.NameEn}: {base_cost}");

                foreach (var modelId in overrides.Keys)
                {
                    /* Cost overrides are defined on the modelProfile, but the
                     * book typically defines cost overrides on the model, not
                     * the profile. That means that for most of these, there
                     * should only be one cost override for a given model (with
                     * all of the profiles under it). If we see that we've got
                     * model profiles lacking a cost override, or different
                     * profiles under the same model where the cost is wrong, we
                     * have a data inconsistency
                     */
                    var model = this.orderedModels.Single(m => m.Id == modelId);

                    // and that model can actually wield that weapon....
                    var mp_can_wield = model.ModelProfiles.Where(mp => CanModelProfileUseWeapon(mp, weapon.Id));
                    var mp_with_co = overrides[modelId].Values.SelectMany(x => x).Where(mp => CanModelProfileUseWeapon(mp, weapon.Id));

                    if (mp_can_wield.Count() != mp_with_co.Count())
                    {
                        Console.WriteLine($" ERROR: some model profiles under {model.NameEn} missing a cost override for {weapon.Id}");
                        Console.WriteLine($"        can wield [{string.Join(", ", mp_can_wield.Select(mp => mp.Id))}] vs with co [{string.Join(", ", mp_with_co.Select(mp => mp.Id))}]");
                    }


                    // most should be a single cost across all profiles for that model
                    if (overrides[modelId].Count == 1)
                    {
                        var cost = overrides[modelId].First().Key;
                        if (base_cost == cost && base_cost != weapon.Cost)
                        {
                            // this is just one of the default base costs
                            continue;
                        }
                        Console.WriteLine($" - [{model.Id}] {model.NameEn}: {cost}");
                    }
                    else
                    {
                        Console.WriteLine($" ERROR: some model profiles under {model.NameEn} differ for cost override on {weapon.Id}");
                        // then print by model profile
                        foreach (var cost in overrides[modelId].Keys)
                        {
                            foreach (var modelProfile in overrides[modelId][cost])
                            {
                                Console.WriteLine($" - [{modelProfile.Id}] {modelProfile.NameEn}: {cost}");
                            }
                        }
                    }

                }
            }
        }

        private bool CanModelProfileUseWeapon(ModelProfile modelProfile, string weaponId)
        {
            Debug.Assert(this.modelProfileToWeapons != null);
            return this.modelProfileToWeapons[modelProfile.Id].Any(w => w.Id == weaponId);
        }

        private IQueryable<Weapon> QueryAllWargearFromModelProfiles(IQueryable<ModelProfile> mpq)
        {
            // directly included weapons
            IQueryable<Weapon> modelProfileWeapons = mpq.SelectMany(mp => mp.ModelProfileWeapons).Select(mpw => mpw.Weapon);
            IQueryable<Weapon> modelWeapons = mpq.Select(mp => mp.Model).SelectMany(m => m.ModelWeapons).Select(mw => mw.Weapon);

            // swap-in-able weapons
            IQueryable<string> wargearOptionIds = mpq
                .SelectMany(mp => mp.WarGearOptions)
                .Union(mpq.Select(mp => mp.Model).SelectMany(m => m.WarGearOptions))
                .SelectMany(wgo => Regex.Split(wgo.Operation, @"[^A-Z0-9]+"));
            IQueryable<Weapon> allWgoWeapons = this.db.Weapons.Where(w => wargearOptionIds.Contains(w.Id));

            // join it all together
            return modelProfileWeapons.Union(modelWeapons).Union(allWgoWeapons);
        }

        private async Task<List<Model>> GetOrderedModelsAsync()
        {
            return await this.db.Models.Where(m => m.FactionId == this.factionId)
                .Include(m => m.ModelProfiles)
                .ThenInclude(mp => mp.LevelCosts)
                .OrderByDescending(m => m.KeywordsEn.Contains("COMMANDER"))
                .ThenBy(m => m.NameEn)
                .ToListAsync();
        }

        private async Task<Dictionary<string, List<Weapon>>> GetWargearAsync()
        {
            var models = this.db.Models
                .Where(m => m.FactionId == this.factionId);

            return await QueryAllWargearFromModelProfiles(models.SelectMany(m => m.ModelProfiles))
                .Include(m => m.WeaponProfiles)
                .OrderBy(w => w.NameEn)
                .GroupBy(w => (w.WeaponProfiles.Count == 0)
                    ? "Equipment"
                    : (w.WeaponProfiles.Any(wp => wp.WeaponTypeId == "M")
                        ? "Melee"
                        : "Ranged"
                ))
                .ToDictionaryAsync(k => k.Key, v => v.ToList());
        }

        private async Task<Dictionary<string, List<Weapon>>> GetModelProfileToWeaponsAsync()
        {
            var modelProfiles = await this.db.Factions.Where(f => f.Id == this.factionId)
                .SelectMany(f => f.Models)
                .SelectMany(m => m.ModelProfiles)
                .ToListAsync();


            var modelProfileToWeapons = new Dictionary<string, Task<List<Weapon>>>();

            foreach (ModelProfile modelProfile in modelProfiles)
            {
                modelProfileToWeapons[modelProfile.Id] = QueryAllWargearFromModelProfiles(
                    this.db.ModelProfiles.Where(mp => mp.Id == modelProfile.Id)
                ).ToListAsync();
            }

            var pairs = await Task.WhenAll(modelProfileToWeapons.Select(async kvp => new { Key = kvp.Key, Value = await kvp.Value }));
            return pairs.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

    }
}
