using CommandLine;
using KillTeam.Models;
using KillTeam.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Superpower;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KillTeam.RulesTool
{
    class Program
    {
        public class Options
        {
            [Option('d', "db", Required = false, SetName = "db", HelpText = "Database path to be used, defaults to main db")]
            public string DBPath { get; set; }

            [Option('l', "legacy-db", Default = false, SetName = "legacy-db", HelpText = "Use the legacy db (default path)")]
            public bool LegacyDB { get; set; }

        }

        [Verb("import", HelpText = "Import a given rules path to the DB")]
        public class ImportOptions : Options
        {
            [Option('r', "rules", Required = false, HelpText = "Rules path to be used, defaults to manifest rules")]
            public string RulesPath { get; set; }
        }

        [Verb("export", HelpText = "Export rules from a sqlite db to json")]
        public class ExportOptions : Options
        {
            [Option('o', "out", Default = ROOT, HelpText = "Where to output the rules json")]
            public string OutPath { get; set; }
        }

        [Verb("cost", HelpText = "Show the costs of various things in a format similar to the book")]
        public class CostOptions : Options
        {
            [Value(0, MetaName = "faction", Required = true, HelpText = "Which faction to display costs for")]
            public string Faction { get; set; }

            [Value(1, MetaName = "unit", Required = false, HelpText = "Which Unit to display costs for")]
            public string Unit { get; set; }

            [Option('a', "all", Default = false, HelpText = "Display all units for this faction")]
            public bool All { get; set; }

        }

        private const string ROOT = "../../../Rules";

        static async Task<int> Main(string[] args)
        {
            return await Parser.Default.ParseArguments<ImportOptions, ExportOptions, CostOptions>(args)
                .MapResult(
                    async (ImportOptions opts) => await RunImport(opts),
                    async (ExportOptions opts) => await RunExport(opts),
                    async (CostOptions opts) => await RunCost(opts),
                    async errs => 1
                );
        }

        static async Task<IKTRulesContext> GetKTContextAsync(Options opts)
        {
            if (opts.LegacyDB)
            {
                return new KTLegacyContext();
            }

            var dbpath = opts.DBPath ?? KTContext.DBPath;
            // create a KT Context manually to avoid running DBUpdater
            // TODO export from legacy?
            Console.WriteLine($"Using DB at {dbpath}");
            var db = new KTUserContext(dbpath);

            return db;
        }

        static async Task<int> RunExport(ExportOptions opts)
        {
            var db = await GetKTContextAsync(opts);
            await new SqliteToJson(db, opts.OutPath ?? ROOT).Export();
            return 0;
        }

        static async Task<int> RunImport(ImportOptions opts)
        {
            var db =(await GetKTContextAsync(opts)) as KTRulesContext;
            var provider = KTContext.Provider;
            if (opts.RulesPath != null)
            {
                Console.WriteLine($"Importing Rules from {opts.RulesPath}");
                provider = new Services.RulesProviders.FileRulesProvider(opts.RulesPath);
            }
            db.Database.CloseConnection();
            db = new DBUpdater(db.DBPath, provider).GetUpdatedContext();
            return 0;
        }


        static async Task<int> RunCost(CostOptions opts)
        {
            var db = await GetKTContextAsync(opts);
            var faction_id = opts.Faction;

            Faction faction = await db.Factions
                .Where(f => f.Id == faction_id)
                .Include(f => f.Models)
                .ThenInclude(m => m.Abilities)
                .Include(f => f.Models)
                .ThenInclude(m => m.ModelProfiles)
                .ThenInclude(mp => mp.Abilities)
                .Include(f => f.Models)
                .ThenInclude(m => m.ModelProfiles)
                .ThenInclude(mp => mp.Psychics)
                .Include(f => f.Models)
                .ThenInclude(m => m.ModelProfiles)
                .ThenInclude(mp => mp.Specialists)
                .ThenInclude(sp => sp.Specialist)
                .Include(f => f.Models)
                .ThenInclude(m => m.WarGearOptions)
                .Include(f => f.Models)
                .ThenInclude(m => m.ModelProfiles)
                .ThenInclude(mp => mp.WarGearOptions)
                .Include(f => f.Models)
                .ThenInclude(m => m.ModelProfiles)
                .ThenInclude(mp => mp.LevelCosts)
                .Include(f => f.Models)
                .ThenInclude(m => m.ModelProfiles)
                .ThenInclude(mp => mp.CostOverrides)
                .ThenInclude(co => co.Weapon)
                .Include(f => f.Models)
                .ThenInclude(m => m.ModelProfiles)
                .ThenInclude(mp => mp.ModelProfileWeapons)
                .ThenInclude(mpw => mpw.Weapon)
                .Include(f => f.Models)
                .ThenInclude(m => m.ModelWeapons)
                .ThenInclude(mv => mv.Weapon)
                .FirstAsync();

            Console.WriteLine($"Faction: {faction.NameEn}");

            if (opts.All)
            {
                int returncode = 0;
                foreach (var unit in faction.Models.OrderByDescending(m => m.KeywordsEn.Contains("COMMANDER")).ThenBy(m => m.NameEn))
                {
                    returncode += await ShowUnitTable(db, unit);
                    Console.WriteLine("\n---------------------------------------------------------------------");
                }
                return returncode;
            }
            else if (opts.Unit != null)
            {
                var unit = faction.Models.Where(m => m.Id == opts.Unit).First();
                return await ShowUnitTable(db, unit);
            }
            else
            {
                
                return await ShowCostTable(db, faction);
            }
        }

        static async Task<int> ShowCostTable(IKTRulesContext db, Faction faction)
        {
            var costTable = new CostTable(db, faction.Id);
            await costTable.PrintModelTable();
            await costTable.PrintWargearTable();
            return 0;

        }
        static async Task<int> ShowUnitTable(IKTRulesContext db, Model unit)
        {
            Console.WriteLine($"\n== {unit.NameEn} ==");
            var table = new ConsoleTables.ConsoleTable("Name", "M", "WS", "BS", "S", "T", "W", "A", "Ld", "Sv", "Max");
            foreach( var profile in unit.ModelProfiles)
            {
                table.AddRow(
                    profile.NameEn,
                    profile.Movement.ToString() + '"',
                    profile.WeaponSkill.ToString() + '+',
                    profile.BallisticSkill.ToString() + '+',
                    profile.Strength,
                    profile.Toughness,
                    profile.Wounds,
                    profile.Attacks,
                    profile.Leadership,
                    profile.Save.ToString() + '+',
                    profile.MaximumNumber > 0 ? profile.MaximumNumber.ToString() : "-"
                );
            }
            table.Configure(o => o.EnableCount = false);
            table.Write();

            var weapons = unit.ModelWeapons.Select(w => w.Weapon.NameEn);
            Console.WriteLine($"This model is armed with: {string.Join(", ", weapons)}");

            /* WARGEAR OPTIONS */

            if (unit.WarGearOptions.Count > 0 || unit.ModelProfiles.Any(mp => mp.WarGearOptions.Count > 0))
            {
                Console.WriteLine("\n=== Wargear Options ===");
                foreach (var option in unit.WarGearOptions)
                {
                    PrintWarGearOption(db, option);
                }
                foreach (var modelProfile in unit.ModelProfiles)
                {
                    if (modelProfile.WarGearOptions.Count == 0)
                    {
                        continue;
                    }

                    Console.WriteLine($" - {modelProfile.NameEn}");
                    foreach (var option in modelProfile.WarGearOptions)
                    {
                        PrintWarGearOption(db, option);
                    }
                }
            }

            /* ABILITIES */

            Console.WriteLine("\n=== Abilities ===");

            // faction abilities
            foreach (var ability in db.Factions.Where(f => f.Id == unit.FactionId).Include(f => f.Abilities).First().Abilities)
            {
                Console.WriteLine($"*{ability.NameEn}*: {ability.DescriptionEn}");
            }

            // model abilities
            foreach (var ability in unit.Abilities)
            {
                Console.WriteLine($"*{ability.NameEn}*: {ability.DescriptionEn}");
            }

            // model profile abilities
            foreach (var modelProfile in unit.ModelProfiles)
            {
                if (modelProfile.Abilities.Count == 0)
                {
                    continue;
                }

                Console.WriteLine($" - {modelProfile.NameEn}");
                foreach (var ability in modelProfile.Abilities)
                {
                    Console.WriteLine($"*{ability.NameEn}*: {ability.DescriptionEn}");
                }
            }

            /* PSYKER */

            var psykers = unit.ModelProfiles.Where(mp => mp.NumberOfKnownPsychics > 0 || mp.NumberOfPsychicsManifestationPerRound > 0 || mp.NumberOfPsychicsDenialPerRound > 0);
            if (psykers.Count() > 0)
            {
                Console.WriteLine("\n=== Psyker ===");
                foreach (var mp in psykers)
                {
                    Console.WriteLine($"{mp.NameEn}: Cast {mp.NumberOfPsychicsManifestationPerRound}, Deny {mp.NumberOfPsychicsDenialPerRound}, Know {mp.NumberOfKnownPsychics}");
                    foreach (var psychic in mp.Psychics)
                    {
                        Console.WriteLine($" - {psychic.NameEn}");
                    }
                    // TODO: psybolt? Or like, does everyone know that?
                }
            }

            /* SPECIALISTS */

            Console.WriteLine("\n=== Specialists ===");
            foreach (var mp in unit.ModelProfiles)
            {
                Console.WriteLine($"{mp.NameEn}: {string.Join(", ", mp.Specialists.Select(s => s.Specialist.NameEn))}");
            }

            /* KEYWORDS */

            Console.WriteLine("\n=== Keywords ===");
            Console.WriteLine(unit.KeywordsEn);

            return 0;
        }

        static void PrintWarGearOption(IKTRulesContext db, WarGearOption option)
        {
            Console.Write($"[{option.Operation}]: ");
            var tokens = (new WargearOption.Tokenizer()).Tokenize(option.Operation);
            var op = WargearOption.OperationParser.Operation.Parse(tokens);
            Console.WriteLine(op.ToString(x => db.Weapons.Find(x)?.NameEn ?? x));
        }
    }
}
