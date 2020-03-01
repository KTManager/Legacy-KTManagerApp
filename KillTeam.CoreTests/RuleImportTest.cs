using NUnit.Framework;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using KillTeam.Services;
using KillTeam.Services.RulesProviders;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System;

namespace KillTeam.CoreTests
{
    public class RuleImportTest
    {
        private string TmpDir;
        private KTUserContext udb;

        [SetUp]
        public void Setup()
        {
            var tmpDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tmpDir);
            this.TmpDir = tmpDir;

            this.udb = new KTUserContext(Path.Combine(tmpDir, "testUser.db"));
        }

        [Test]
        public void TestImportWeaponTypes()
        {
            var weaponTypes = new dynamic[] {
                new Dictionary<string, dynamic>
                {
                    { "Id", "A" },
                    { "Index", "2" },
                    { "NameEn", "Assault" },
                    { "NameFr", "" },
                    { "NameDe", "" },
                },
            };

            var weapons = new dynamic[] {
                new Dictionary<string, dynamic>
                {
                    { "Id", "CBO" },
                    { "Cost", 0 },
                    { "NameEn", "Bolt Carbine" },
                    { "NameFr", "Carabine Bolter" },
                    { "NameDe", "Boltkarabiner" },
                    { "DescriptionEn", "den" },
                    { "DescriptionFr", "dfr" },
                    { "DescriptionDe", "dde" },
                    { "WeaponProfiles", new dynamic[] {
                        new Dictionary<string, dynamic> {
                            { "Id", "CBO" },
                            { "NameEn", "Bolt Carbine" },
                            { "NameFr", "Carabine Bolter" },
                            { "NameDe", "Boltkarabiner" },
                            { "DescriptionEn", "den" },
                            { "DescriptionFr", "dfr" },
                            { "DescriptionDe", "dde" },
                            { "Range", 24 },
                            { "ShotNumber", "2" },
                            { "Strength", "4" },
                            { "ArmourPenetration", "0" },
                            { "Damages", "1" },
                            { "WeaponTypeId", "A"},
                        },
                    }},
                },
            };

            // set up the rules directory
            var rulesDir = Path.Combine(this.TmpDir, "rules");
            Directory.CreateDirectory(rulesDir);
            Directory.CreateDirectory(Path.Combine(rulesDir, "factions"));
            File.WriteAllText(Path.Combine(rulesDir, "version.txt"), "TestImportWeaponTypes");

            // dump the above json into that directory
            File.WriteAllText(Path.Combine(rulesDir, "weapon_types.json"), JsonConvert.SerializeObject(weaponTypes));
            File.WriteAllText(Path.Combine(rulesDir, "weapons.json"), JsonConvert.SerializeObject(weapons));

            // import the rules from file into the db
            this.udb.ImportRules(new FileRulesProvider(rulesDir));

            // pull them out and check that they imported correctly
            var version = udb.GetCurrentVersion();
            Assert.AreEqual("TestImportWeaponTypes", version.RulesVersion);

            var result = udb.Weapons.Include(weapon => weapon.WeaponProfiles).ThenInclude(profile => profile.WeaponType).ToList();
            Assert.AreEqual(1, result.Count);

            var carbine = result.First();
            Assert.AreEqual("Bolt Carbine", carbine.NameEn);
            Assert.AreEqual("den", carbine.DescriptionEn);

            Assert.AreEqual("A", carbine.WeaponProfiles.First().WeaponTypeId);
        }

        [Test]
        public void TestUserAndRules()
        {
            udb.Database.CloseConnection();
            udb = new DBUpdater(udb.DBPath, KTContext.Provider).GetUpdatedContext();
            udb.Teams.Add(new Models.Team { FactionId = "AA", Name = "Test Team" });
            udb.SaveChanges();

            var team = udb.Teams.Include(t => t.Faction).ToList().First();
            Assert.AreEqual("Adeptus Astartes", team.Faction.Name);


        }
    }
}