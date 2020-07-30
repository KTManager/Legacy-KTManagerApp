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
    public class KTLegacyContext : DbContext, IKTContext {

        public KTLegacyContext()
        {
            this.Database.Migrate();

            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            Debug.WriteLine("Running the update");

            if (!IsUpToDate())
            {
                Update();
            }
        }

        private static string DBName {
            get {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return "KTDatabaseProd.db";
                    case Device.Android:
                    default:
                        return "KTDatabase.db";
                }
            }
        }

        public static string DBPath
        {
            get {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DBName);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            String databasePath;
            databasePath = DBPath;
            // Specify that we will use sqlite and the path of the database here
            optionsBuilder.UseSqlite($"Filename={databasePath}");

        }

        public bool IsUpToDate()
        {
            // The *last* legacy sql update puts the "phases" table in place, so check if that's present.
            // if we ever add another sql file to "LegacyDatabaseUpdate", we'll have to update this.
            return (Database.ExecuteSqlCommand("SELECT count(*) FROM sqlite_master WHERE type='table' AND name='Phases';") > 0);
        }

        private void Update()
        {
            Trace.WriteLine($"Updating Database: {Database.GetDbConnection().ConnectionString}");

            // fetch all the updates from the embedded resources, and apply them to the db
            var sql_updates = this.GetType().Assembly.GetManifestResourceNames()
                .Where(x => x.StartsWith("KillTeam.SharedAssets.DatabaseUpdate") && x.EndsWith(".sql"))
                .OrderBy(x => x);
            foreach (string key in sql_updates)
            {
                string value;
                using (var sr = new StreamReader(this.GetType().Assembly.GetManifestResourceStream(key)))
                {
                    value = sr.ReadToEnd();
                }

                try
                {
                    Database.ExecuteSqlCommand(value);
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);

                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildFactionsMapping(modelBuilder);
            BuildTacticsMapping(modelBuilder);
            BuildModelMapping(modelBuilder);
            BuildModelProfilesMapping(modelBuilder);
            BuildWeaponMapping(modelBuilder);
            BuildSpecialistsMapping(modelBuilder);
            BuildAbilitiesMapping(modelBuilder);
            BuildAbilityDetailsMapping(modelBuilder);
            BuildPhasesMapping(modelBuilder);
            BuildWeaponTypesMapping(modelBuilder);
            BuildTraitsMapping(modelBuilder);
            BuildPsychicsMapping(modelBuilder);
            BuildPowersMapping(modelBuilder);
            BuildWeaponProfilesMapping(modelBuilder);
            BuildModelWeaponMapping(modelBuilder);
            BuildModelProfileWeaponMapping(modelBuilder);
            BuildModelProfileSpecialistMapping(modelBuilder);
            BuildModelProfileSubFactionMapping(modelBuilder);
            BuildCostOverridesMapping(modelBuilder);
            BuildWarGearOptionsMapping(modelBuilder);
            BuildLevelCostsMapping(modelBuilder);

            BuildTeamMapping(modelBuilder);
            BuildMembersMapping(modelBuilder);
            BuildMemberWeaponsMapping(modelBuilder);
            BuildMemberPowersMapping(modelBuilder);
            BuildMemberPsychicsMapping(modelBuilder);
            BuildMemberWarGearOptionsMapping(modelBuilder);
            BuildMemberTraitsMapping(modelBuilder);
        }

        private void BuildFactionsMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faction>().ToTable("Factions");

            modelBuilder.Entity<Faction>().HasKey(faction => faction.Id);
            modelBuilder.Entity<Faction>().Property(faction => faction.Id).HasColumnName("Id");

            modelBuilder.Entity<Faction>().Property(faction => faction.NameEn).HasColumnName("NomEn");
            modelBuilder.Entity<Faction>().Property(faction => faction.NameFr).HasColumnName("NomFr");
            modelBuilder.Entity<Faction>().Property(faction => faction.NameDe).HasColumnName("NomDe");
        }

        private void BuildTacticsMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tactic>().ToTable("Tactiques");

            modelBuilder.Entity<Tactic>().HasKey(tactic => tactic.Id);
            modelBuilder.Entity<Tactic>().Property(tactic => tactic.Id).HasColumnName("Id");

            modelBuilder.Entity<Tactic>().Property(tactic => tactic.FactionId).HasColumnName("FactionId");
            modelBuilder.Entity<Tactic>().Property(tactic => tactic.SpecialistId).HasColumnName("SpecialiteId");
            modelBuilder.Entity<Tactic>().Property(tactic => tactic.ModelProfileId).HasColumnName("DeclinaisonId");
            modelBuilder.Entity<Tactic>().Property(tactic => tactic.PhaseId).HasColumnName("PhaseId");

            modelBuilder.Entity<Tactic>().Property(tactic => tactic.NameEn).HasColumnName("NomEn");
            modelBuilder.Entity<Tactic>().Property(tactic => tactic.NameFr).HasColumnName("NomFr");
            modelBuilder.Entity<Tactic>().Property(tactic => tactic.NameDe).HasColumnName("NomDe");
            modelBuilder.Entity<Tactic>().Property(tactic => tactic.DescriptionEn).HasColumnName("DescriptionEn");
            modelBuilder.Entity<Tactic>().Property(tactic => tactic.DescriptionFr).HasColumnName("DescriptionFr");
            modelBuilder.Entity<Tactic>().Property(tactic => tactic.DescriptionDe).HasColumnName("DescriptionDe");
            modelBuilder.Entity<Tactic>().Property(tactic => tactic.Cost).HasColumnName("Point");
            modelBuilder.Entity<Tactic>().Property(tactic => tactic.Level).HasColumnName("Niveau");
            modelBuilder.Entity<Tactic>().Property(tactic => tactic.Aura).HasColumnName("Aura");
            modelBuilder.Entity<Tactic>().Property(tactic => tactic.Commander).HasColumnName("Commandant");

            modelBuilder.Entity<Tactic>()
                .HasOne(tactic => tactic.Faction)
                .WithMany(faction => faction.Tactics)
                .HasForeignKey(tactic => tactic.FactionId);

            modelBuilder.Entity<Tactic>()
                .HasOne(tactic => tactic.Specialist)
                .WithMany(specialist => specialist.Tactics)
                .HasForeignKey(tactic => tactic.SpecialistId);

            modelBuilder.Entity<Tactic>()
                .HasOne(tactic => tactic.ModelProfile)
                .WithMany(modelProfile => modelProfile.Tactics)
                .HasForeignKey(tactic => tactic.ModelProfileId);

            modelBuilder.Entity<Tactic>()
                .HasOne(tactic => tactic.Phase)
                .WithMany(phase => phase.Tactics)
                .HasForeignKey(tactic => tactic.PhaseId);
        }

        private void BuildModelMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>().ToTable("Figurines");

            modelBuilder.Entity<Model>().HasKey(model => model.Id);
            modelBuilder.Entity<Model>().Property(model => model.Id).HasColumnName("Id");

            modelBuilder.Entity<Model>().Property(model => model.FactionId).HasColumnName("FactionId");

            modelBuilder.Entity<Model>().Property(model => model.NameEn).HasColumnName("NomEn");
            modelBuilder.Entity<Model>().Property(model => model.NameFr).HasColumnName("NomFr");
            modelBuilder.Entity<Model>().Property(model => model.NameDe).HasColumnName("NomDe");
            modelBuilder.Entity<Model>().Property(model => model.KeywordsEn).HasColumnName("MotClesEn");
            modelBuilder.Entity<Model>().Property(model => model.KeywordsFr).HasColumnName("MotClesFr");
            modelBuilder.Entity<Model>().Property(model => model.KeywordsDe).HasColumnName("MotClesDe");

            modelBuilder.Entity<Model>()
                .HasOne(model => model.Faction)
                .WithMany(faction => faction.Models)
                .HasForeignKey(model => model.FactionId);
        }

        private void BuildModelProfilesMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelProfile>().ToTable("Declinaisons");

            modelBuilder.Entity<ModelProfile>().HasKey(modelProfile => modelProfile.Id);
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.Id).HasColumnName("Id");

            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.ModelId).HasColumnName("FigurineId");

            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.NameEn).HasColumnName("NomEn");
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.NameFr).HasColumnName("NomFr");
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.NameDe).HasColumnName("NomDe");
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.Attacks).HasColumnName("A");
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.WeaponSkill).HasColumnName("CC");
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.BallisticSkill).HasColumnName("CT");
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.Leadership).HasColumnName("Cd");
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.Toughness).HasColumnName("E");
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.Strength).HasColumnName("F");
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.Movement).HasColumnName("M");
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.MaximumNumber).HasColumnName("Max");
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.Wounds).HasColumnName("PV");
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.Save).HasColumnName("Sv");
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.Cost).HasColumnName("cout");
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.IsCommander).HasColumnName("Commandant");
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.NumberOfKnownPsychics).HasColumnName("NbPsyConnus");
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.NumberOfPsychicsManifestationPerRound).HasColumnName("NbPsyManifestes");
            modelBuilder.Entity<ModelProfile>().Property(modelProfile => modelProfile.NumberOfPsychicsDenialPerRound).HasColumnName("NbPsyAbjures");

            modelBuilder.Entity<ModelProfile>()
                .HasOne(modelProfile => modelProfile.Model)
                .WithMany(model => model.ModelProfiles)
                .HasForeignKey(modelProfile => modelProfile.ModelId);
        }

        private void BuildWeaponMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weapon>().ToTable("Armes");

            modelBuilder.Entity<Weapon>().HasKey(model => model.Id);
            modelBuilder.Entity<Weapon>().Property(model => model.Id).HasColumnName("Id");

            modelBuilder.Entity<Weapon>().Property(model => model.Cost).HasColumnName("cout");
            modelBuilder.Entity<Weapon>().Property(model => model.NameEn).HasColumnName("NomEn");
            modelBuilder.Entity<Weapon>().Property(model => model.NameFr).HasColumnName("NomFr");
            modelBuilder.Entity<Weapon>().Property(model => model.NameDe).HasColumnName("NomDe");
            modelBuilder.Entity<Weapon>().Property(model => model.DescriptionEn).HasColumnName("DescriptionAdditionnelleEn");
            modelBuilder.Entity<Weapon>().Property(model => model.DescriptionFr).HasColumnName("DescriptionAdditionnelleFr");
            modelBuilder.Entity<Weapon>().Property(model => model.DescriptionDe).HasColumnName("DescriptionAdditionnelleDe");
        }

        private void BuildSpecialistsMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialist>().ToTable("Specialites");

            modelBuilder.Entity<Specialist>().HasKey(specialist => specialist.Id);
            modelBuilder.Entity<Specialist>().Property(specialist => specialist.Id).HasColumnName("Id");

            modelBuilder.Entity<Specialist>().Property(specialist => specialist.NameEn).HasColumnName("NomEn");
            modelBuilder.Entity<Specialist>().Property(specialist => specialist.NameFr).HasColumnName("NomFr");
            modelBuilder.Entity<Specialist>().Property(specialist => specialist.NameDe).HasColumnName("NomDe");
        }

        private void BuildAbilitiesMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ability>().ToTable("Aptitudes");

            modelBuilder.Entity<Ability>().HasKey(ability => ability.Id);
            modelBuilder.Entity<Ability>().Property(ability => ability.Id).HasColumnName("Id");

            modelBuilder.Entity<Ability>().Property(ability => ability.FactionId).HasColumnName("FactionId");
            modelBuilder.Entity<Ability>().Property(ability => ability.ModelId).HasColumnName("FigurineId");
            modelBuilder.Entity<Ability>().Property(ability => ability.ModelProfileId).HasColumnName("DeclinaisonId");

            modelBuilder.Entity<Ability>().Property(ability => ability.NameEn).HasColumnName("NomEn");
            modelBuilder.Entity<Ability>().Property(ability => ability.NameFr).HasColumnName("NomFr");
            modelBuilder.Entity<Ability>().Property(ability => ability.NameDe).HasColumnName("NomDe");
            modelBuilder.Entity<Ability>().Property(ability => ability.DescriptionEn).HasColumnName("DescriptionEn");
            modelBuilder.Entity<Ability>().Property(ability => ability.DescriptionFr).HasColumnName("DescriptionFr");
            modelBuilder.Entity<Ability>().Property(ability => ability.DescriptionDe).HasColumnName("DescriptionDe");

            modelBuilder.Entity<Ability>()
                .HasOne(ability => ability.Faction)
                .WithMany(faction => faction.Abilities)
                .HasForeignKey(ability => ability.FactionId);

            modelBuilder.Entity<Ability>()
                .HasOne(ability => ability.Model)
                .WithMany(model => model.Abilities)
                .HasForeignKey(ability => ability.ModelId);

            modelBuilder.Entity<Ability>()
                .HasOne(ability => ability.ModelProfile)
                .WithMany(modelProfile => modelProfile.Abilities)
                .HasForeignKey(ability => ability.ModelProfileId);

        }

        private void BuildAbilityDetailsMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbilityDetail>().ToTable("AptitudesDetails");

            modelBuilder.Entity<AbilityDetail>().HasKey(abilityDetail => abilityDetail.Id);
            modelBuilder.Entity<AbilityDetail>().Property(abilityDetail => abilityDetail.Id).HasColumnName("Id");

            modelBuilder.Entity<AbilityDetail>().Property(abilityDetail => abilityDetail.AbilityId).HasColumnName("AptitudesId");

            modelBuilder.Entity<AbilityDetail>().Property(abilityDetail => abilityDetail.Row).HasColumnName("Ligne");
            modelBuilder.Entity<AbilityDetail>().Property(abilityDetail => abilityDetail.Column).HasColumnName("Colonne");
            modelBuilder.Entity<AbilityDetail>().Property(abilityDetail => abilityDetail.ContentEn).HasColumnName("ContenuEn");
            modelBuilder.Entity<AbilityDetail>().Property(abilityDetail => abilityDetail.ContentFr).HasColumnName("ContenuFr");
            modelBuilder.Entity<AbilityDetail>().Property(abilityDetail => abilityDetail.ContentDe).HasColumnName("ContenuDe");

            modelBuilder.Entity<AbilityDetail>()
                .HasOne(ability => ability.Ability)
                .WithMany(faction => faction.Details)
                .HasForeignKey(ability => ability.AbilityId);

        }

        private void BuildPhasesMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phase>().ToTable("Phases");

            modelBuilder.Entity<Phase>().HasKey(phase => phase.Id);
            modelBuilder.Entity<Phase>().Property(phase => phase.Id).HasColumnName("Id");

            modelBuilder.Entity<Phase>().Property(phase => phase.NameEn).HasColumnName("NomEn");
            modelBuilder.Entity<Phase>().Property(phase => phase.NameFr).HasColumnName("NomFr");
            modelBuilder.Entity<Phase>().Property(phase => phase.NameDe).HasColumnName("NomDe");
        }

        private void BuildWeaponTypesMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeaponType>().ToTable("TypeArmes");

            modelBuilder.Entity<WeaponType>().HasKey(phase => phase.Id);
            modelBuilder.Entity<WeaponType>().Property(phase => phase.Id).HasColumnName("Id");

            modelBuilder.Entity<WeaponType>().Property(phase => phase.Index).HasColumnName("Index");
            modelBuilder.Entity<WeaponType>().Property(phase => phase.NameEn).HasColumnName("NomEn");
            modelBuilder.Entity<WeaponType>().Property(phase => phase.NameFr).HasColumnName("NomFr");
            modelBuilder.Entity<WeaponType>().Property(phase => phase.NameDe).HasColumnName("NomDe");
        }

        private void BuildTraitsMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trait>().ToTable("Traits");

            modelBuilder.Entity<Trait>().HasKey(trait => trait.Id);
            modelBuilder.Entity<Trait>().Property(trait => trait.Id).HasColumnName("Id");

            modelBuilder.Entity<Trait>().Property(trait => trait.ModelProfileId).HasColumnName("DeclinaisonId");

            modelBuilder.Entity<Trait>().Property(trait => trait.NameEn).HasColumnName("NomEn");
            modelBuilder.Entity<Trait>().Property(trait => trait.NameFr).HasColumnName("NomFr");
            modelBuilder.Entity<Trait>().Property(trait => trait.NameDe).HasColumnName("NomDe");
            modelBuilder.Entity<Trait>().Property(trait => trait.DescriptionEn).HasColumnName("DescriptionEn");
            modelBuilder.Entity<Trait>().Property(trait => trait.DescriptionFr).HasColumnName("DescriptionFr");
            modelBuilder.Entity<Trait>().Property(trait => trait.DescriptionDe).HasColumnName("DescriptionDe");
            modelBuilder.Entity<Trait>().Property(trait => trait.Cost).HasColumnName("Point");
            modelBuilder.Entity<Trait>().Property(trait => trait.Level).HasColumnName("Niveau");

            modelBuilder.Entity<Trait>()
                .HasOne(trait => trait.ModelProfile)
                .WithMany(modelProfile => modelProfile.Traits)
                .HasForeignKey(trait => trait.ModelProfileId);
        }

        private void BuildPsychicsMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Psychic>().ToTable("Psychiques");

            modelBuilder.Entity<Psychic>().HasKey(psychic => psychic.Id);
            modelBuilder.Entity<Psychic>().Property(psychic => psychic.Id).HasColumnName("Id");

            modelBuilder.Entity<Psychic>().Property(psychic => psychic.ModelProfileId).HasColumnName("DeclinaisonId");

            modelBuilder.Entity<Psychic>().Property(psychic => psychic.NameEn).HasColumnName("NomEn");
            modelBuilder.Entity<Psychic>().Property(psychic => psychic.NameFr).HasColumnName("NomFr");
            modelBuilder.Entity<Psychic>().Property(psychic => psychic.NameDe).HasColumnName("NomDe");
            modelBuilder.Entity<Psychic>().Property(psychic => psychic.DescriptionEn).HasColumnName("DescriptionEn");
            modelBuilder.Entity<Psychic>().Property(psychic => psychic.DescriptionFr).HasColumnName("DescriptionFr");
            modelBuilder.Entity<Psychic>().Property(psychic => psychic.DescriptionDe).HasColumnName("DescriptionDe");
            modelBuilder.Entity<Psychic>().Property(psychic => psychic.Commander).HasColumnName("Commandant");
            modelBuilder.Entity<Psychic>().Property(psychic => psychic.Dices).HasColumnName("De");
            modelBuilder.Entity<Psychic>().Property(psychic => psychic.WarpCharge).HasColumnName("Charge");

            modelBuilder.Entity<Psychic>()
                .HasOne(psychic => psychic.ModelProfile)
                .WithMany(modelProfile => modelProfile.Psychics)
                .HasForeignKey(psychic => psychic.ModelProfileId);
        }

        private void BuildPowersMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Power>().ToTable("Pouvoirs");

            modelBuilder.Entity<Power>().HasKey(power => power.Id);
            modelBuilder.Entity<Power>().Property(power => power.Id).HasColumnName("Id");

            modelBuilder.Entity<Power>().Property(power => power.PreviewsId).HasColumnName("PrecedentId");
            modelBuilder.Entity<Power>().Property(power => power.SpecialistId).HasColumnName("SpecialiteId");

            modelBuilder.Entity<Power>().Property(power => power.NameEn).HasColumnName("NomEn");
            modelBuilder.Entity<Power>().Property(power => power.NameFr).HasColumnName("NomFr");
            modelBuilder.Entity<Power>().Property(power => power.NameDe).HasColumnName("NomDe");
            modelBuilder.Entity<Power>().Property(power => power.DescriptionEn).HasColumnName("DescriptionEn");
            modelBuilder.Entity<Power>().Property(power => power.DescriptionFr).HasColumnName("DescriptionFr");
            modelBuilder.Entity<Power>().Property(power => power.DescriptionDe).HasColumnName("DescriptionDe");

            modelBuilder.Entity<Power>()
                .HasOne(power => power.Previews)
                .WithMany(power => power.Nexts)
                .HasForeignKey(power => power.PreviewsId);

            modelBuilder.Entity<Power>()
                .HasOne(power => power.Specialist)
                .WithMany(specialist => specialist.Powers)
                .HasForeignKey(power => power.SpecialistId);
        }

        private void BuildWeaponProfilesMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeaponProfile>().ToTable("ProfileArmes");

            modelBuilder.Entity<WeaponProfile>().HasKey(weaponProfile => weaponProfile.Id);
            modelBuilder.Entity<WeaponProfile>().Property(weaponProfile => weaponProfile.Id).HasColumnName("Id");

            modelBuilder.Entity<WeaponProfile>().Property(weaponProfile => weaponProfile.WeaponId).HasColumnName("ArmeId");
            modelBuilder.Entity<WeaponProfile>().Property(weaponProfile => weaponProfile.WeaponTypeId).HasColumnName("TypeArmeId");

            modelBuilder.Entity<WeaponProfile>().Property(weaponProfile => weaponProfile.NameEn).HasColumnName("NomEn");
            modelBuilder.Entity<WeaponProfile>().Property(weaponProfile => weaponProfile.NameFr).HasColumnName("NomFr");
            modelBuilder.Entity<WeaponProfile>().Property(weaponProfile => weaponProfile.NameDe).HasColumnName("NomDe");
            modelBuilder.Entity<WeaponProfile>().Property(weaponProfile => weaponProfile.DescriptionEn).HasColumnName("AptitudesEn");
            modelBuilder.Entity<WeaponProfile>().Property(weaponProfile => weaponProfile.DescriptionFr).HasColumnName("AptitudesFr");
            modelBuilder.Entity<WeaponProfile>().Property(weaponProfile => weaponProfile.DescriptionDe).HasColumnName("AptitudesDe");
            modelBuilder.Entity<WeaponProfile>().Property(weaponProfile => weaponProfile.Damages).HasColumnName("D");
            modelBuilder.Entity<WeaponProfile>().Property(weaponProfile => weaponProfile.Strength).HasColumnName("F");
            modelBuilder.Entity<WeaponProfile>().Property(weaponProfile => weaponProfile.ShotNumber).HasColumnName("NbTir");
            modelBuilder.Entity<WeaponProfile>().Property(weaponProfile => weaponProfile.ArmourPenetration).HasColumnName("PA");
            modelBuilder.Entity<WeaponProfile>().Property(weaponProfile => weaponProfile.Range).HasColumnName("Portee");

            modelBuilder.Entity<WeaponProfile>()
                .HasOne(weaponProfile => weaponProfile.Weapon)
                .WithMany(weapon => weapon.WeaponProfiles)
                .HasForeignKey(weaponProfile => weaponProfile.WeaponId);

            modelBuilder.Entity<WeaponProfile>()
                .HasOne(weaponProfile => weaponProfile.WeaponType)
                .WithMany(weaponType => weaponType.WeaponProfiles)
                .HasForeignKey(weaponProfile => weaponProfile.WeaponTypeId);
        }

        private void BuildModelWeaponMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelWeapon>().ToTable("FigurineArme");

            modelBuilder.Entity<ModelWeapon>().HasKey(modelWeapon => new { modelWeapon.ModelId, modelWeapon.WeaponId });
            modelBuilder.Entity<ModelWeapon>().Property(modelWeapon => modelWeapon.ModelId).HasColumnName("FigurineId");
            modelBuilder.Entity<ModelWeapon>().Property(modelWeapon => modelWeapon.WeaponId).HasColumnName("ArmeId");

            modelBuilder.Entity<ModelWeapon>()
                .HasOne(modelWeapon => modelWeapon.Model)
                .WithMany(model => model.ModelWeapons)
                .HasForeignKey(modelWeapon => modelWeapon.ModelId);

            modelBuilder.Entity<ModelWeapon>()
                .HasOne(modelWeapon => modelWeapon.Weapon)
                .WithMany(weapon => weapon.ModelWeapons)
                .HasForeignKey(modelWeapon => modelWeapon.WeaponId);
        }

        private void BuildModelProfileWeaponMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelProfileWeapon>().ToTable("DeclinaisonArme");

            modelBuilder.Entity<ModelProfileWeapon>().HasKey(modelProfileWeapon => new { modelProfileWeapon.ModelProfileId, modelProfileWeapon.WeaponId });
            modelBuilder.Entity<ModelProfileWeapon>().Property(modelProfileWeapon => modelProfileWeapon.ModelProfileId).HasColumnName("DeclinaisonId");
            modelBuilder.Entity<ModelProfileWeapon>().Property(modelProfileWeapon => modelProfileWeapon.WeaponId).HasColumnName("ArmeId");

            modelBuilder.Entity<ModelProfileWeapon>()
                .HasOne(modelProfileWeapon => modelProfileWeapon.ModelProfile)
                .WithMany(modelProfile => modelProfile.ModelProfileWeapons)
                .HasForeignKey(modelProfileWeapon => modelProfileWeapon.ModelProfileId);

            modelBuilder.Entity<ModelProfileWeapon>()
                .HasOne(modelWeapon => modelWeapon.Weapon)
                .WithMany(weapon => weapon.ModelProfileWeapons)
                .HasForeignKey(modelWeapon => modelWeapon.WeaponId);
        }

        private void BuildModelProfileSpecialistMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelProfileSpecialist>().ToTable("DeclinaisonSpecialite");

            modelBuilder.Entity<ModelProfileSpecialist>().HasKey(modelProfileSpecialist => new { modelProfileSpecialist.ModelProfileId, modelProfileSpecialist.SpecialistId });
            modelBuilder.Entity<ModelProfileSpecialist>().Property(modelProfileSpecialist => modelProfileSpecialist.ModelProfileId).HasColumnName("DeclinaisonId");
            modelBuilder.Entity<ModelProfileSpecialist>().Property(modelProfileSpecialist => modelProfileSpecialist.SpecialistId).HasColumnName("SpecialiteId");

            modelBuilder.Entity<ModelProfileSpecialist>()
                .HasOne(modelProfileSpecialist => modelProfileSpecialist.Specialist)
                .WithMany(modelProfile => modelProfile.ModelProfileSpecialists)
                .HasForeignKey(modelProfileSpecialist => modelProfileSpecialist.SpecialistId);

            modelBuilder.Entity<ModelProfileSpecialist>()
                .HasOne(modelProfileSpecialist => modelProfileSpecialist.ModelProfile)
                .WithMany(specialist => specialist.Specialists)
                .HasForeignKey(modelProfileSpecialist => modelProfileSpecialist.ModelProfileId);
        }

        private void BuildModelProfileSubFactionMapping(ModelBuilder modelBuilder)
        {
            // todo: implement this method
            throw new NotImplementedException();
            
        }
        private void BuildCostOverridesMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostOverride>().ToTable("SurchargeCoutArme");

            modelBuilder.Entity<CostOverride>().HasKey(costOverride => costOverride.Id);
            modelBuilder.Entity<CostOverride>().Property(costOverride => costOverride.Id).HasColumnName("Id");

            modelBuilder.Entity<CostOverride>().Property(costOverride => costOverride.WeaponId).HasColumnName("ArmeId");
            modelBuilder.Entity<CostOverride>().Property(costOverride => costOverride.ModelProfileId).HasColumnName("DeclinaisonId");

            modelBuilder.Entity<CostOverride>().Property(costOverride => costOverride.Cost).HasColumnName("Cout");

            modelBuilder.Entity<CostOverride>()
                .HasOne(costOverride => costOverride.Weapon)
                .WithMany(weapon => weapon.CostOverrides)
                .HasForeignKey(costOverride => costOverride.WeaponId);

            modelBuilder.Entity<CostOverride>()
                .HasOne(costOverride => costOverride.ModelProfile)
                .WithMany(modelProfile => modelProfile.CostOverrides)
                .HasForeignKey(costOverride => costOverride.ModelProfileId);

        }

        private void BuildLevelCostsMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LevelCost>().ToTable("CoutNiveau");

            modelBuilder.Entity<LevelCost>().HasKey(levelCost => levelCost.Id);
            modelBuilder.Entity<LevelCost>().Property(levelCost => levelCost.Id).HasColumnName("Id");

            modelBuilder.Entity<LevelCost>().Property(levelCost => levelCost.ModelProfileId).HasColumnName("DeclinaisonId");

            modelBuilder.Entity<LevelCost>().Property(levelCost => levelCost.Level).HasColumnName("Niveau");
            modelBuilder.Entity<LevelCost>().Property(levelCost => levelCost.Cost).HasColumnName("Cout");

            modelBuilder.Entity<LevelCost>()
                .HasOne(levelCost => levelCost.ModelProfile)
                .WithMany(modelProfile => modelProfile.LevelCosts)
                .HasForeignKey(levelCost => levelCost.ModelProfileId);

        }

        private void BuildWarGearOptionsMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WarGearOption>().ToTable("Remplacement");

            modelBuilder.Entity<WarGearOption>().HasKey(warGearOption => warGearOption.Id);
            modelBuilder.Entity<WarGearOption>().Property(warGearOption => warGearOption.Id).HasColumnName("Id");

            modelBuilder.Entity<WarGearOption>().Property(warGearOption => warGearOption.ModelId).HasColumnName("FigurineId");
            modelBuilder.Entity<WarGearOption>().Property(warGearOption => warGearOption.ModelProfileId).HasColumnName("DeclinaisonId");

            modelBuilder.Entity<WarGearOption>().Property(warGearOption => warGearOption.Exclusion).HasColumnName("Exclusion");
            modelBuilder.Entity<WarGearOption>().Property(warGearOption => warGearOption.MaximumPerTeam).HasColumnName("MaxParTeam");
            modelBuilder.Entity<WarGearOption>().Property(warGearOption => warGearOption.Operation).HasColumnName("Operation");

            modelBuilder.Entity<WarGearOption>()
                .HasOne(warGearOption => warGearOption.Model)
                .WithMany(model => model.WarGearOptions)
                .HasForeignKey(warGearOption => warGearOption.ModelId);

            modelBuilder.Entity<WarGearOption>()
                .HasOne(warGearOption => warGearOption.ModelProfile)
                .WithMany(modelProfile => modelProfile.WarGearOptions)
                .HasForeignKey(warGearOption => warGearOption.ModelProfileId);
        }

        private void BuildTeamMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().ToTable("Equipes");

            modelBuilder.Entity<Team>().HasKey(team => team.Id);
            modelBuilder.Entity<Team>().Property(team => team.Id).HasColumnName("Id");

            modelBuilder.Entity<Team>().Property(team => team.FactionId).HasColumnName("FactionId");

            modelBuilder.Entity<Team>().Property(team => team.Name).HasColumnName("Nom");
            modelBuilder.Entity<Team>().Property(team => team.Roster).HasColumnName("Roster");
            modelBuilder.Entity<Team>().Property(team => team.Position).HasColumnName("Position");
        }

        private void BuildMembersMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().ToTable("Membres");

            modelBuilder.Entity<Member>().HasKey(member => member.Id);
            modelBuilder.Entity<Member>().Property(member => member.Id).HasColumnName("Id");

            modelBuilder.Entity<Member>().Property(member => member.ModelProfileId).HasColumnName("DeclinaisonId");
            modelBuilder.Entity<Member>().Property(member => member.TeamId).HasColumnName("EquipeId");
            modelBuilder.Entity<Member>().Property(member => member.SpecialistId).HasColumnName("SpecialiteId");

            modelBuilder.Entity<Member>().Property(member => member.Level).HasColumnName("Niveau");
            modelBuilder.Entity<Member>().Property(member => member.Name).HasColumnName("Nom");
            modelBuilder.Entity<Member>().Property(member => member.Cost).HasColumnName("Points");
            modelBuilder.Entity<Member>().Property(member => member.Xp).HasColumnName("XP");
            modelBuilder.Entity<Member>().Property(member => member.FleshWounds).HasColumnName("Blessures");
            modelBuilder.Entity<Member>().Property(member => member.Convalescence).HasColumnName("Convalescence");
            modelBuilder.Entity<Member>().Property(member => member.Recruit).HasColumnName("Recrue");
            modelBuilder.Entity<Member>().Property(member => member.Selected).HasColumnName("Selected");
            modelBuilder.Entity<Member>().Property(member => member.Position).HasColumnName("Position");

            modelBuilder.Entity<Member>()
                .HasOne(member => member.ModelProfile)
                .WithMany(modelProfile => modelProfile.Members)
                .HasForeignKey(member => member.ModelProfileId);

            modelBuilder.Entity<Member>()
                .HasOne(member => member.Team)
                .WithMany(team => team.Members)
                .HasForeignKey(member => member.TeamId);

            modelBuilder.Entity<Member>()
                .HasOne(member => member.Specialist)
                .WithMany(team => team.Members)
                .HasForeignKey(member => member.SpecialistId);

        }

        private void BuildMemberWeaponsMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberWeapon>().ToTable("MembreArme");

            modelBuilder.Entity<MemberWeapon>().HasKey(memberWeapon => memberWeapon.Id);
            modelBuilder.Entity<MemberWeapon>().Property(memberWeapon => memberWeapon.Id).HasColumnName("Id");

            modelBuilder.Entity<MemberWeapon>().Property(memberWeapon => memberWeapon.MemberId).HasColumnName("MembreId");
            modelBuilder.Entity<MemberWeapon>().Property(memberWeapon => memberWeapon.WeaponId).HasColumnName("ArmeId");

            modelBuilder.Entity<MemberWeapon>()
                .HasOne(memberWeapon => memberWeapon.Member)
                .WithMany(member => member.MemberWeapons)
                .HasForeignKey(memberWeapon => memberWeapon.MemberId);

            modelBuilder.Entity<MemberWeapon>()
                .HasOne(memberWeapon => memberWeapon.Weapon)
                .WithMany(weapon => weapon.MemberWeapons)
                .HasForeignKey(memberWeapon => memberWeapon.WeaponId);
        }

        private void BuildMemberPowersMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberPower>().ToTable("MembrePouvoir");

            modelBuilder.Entity<MemberPower>().HasKey(memberPower => memberPower.Id);
            modelBuilder.Entity<MemberPower>().Property(memberPower => memberPower.Id).HasColumnName("Id");

            modelBuilder.Entity<MemberPower>().Property(memberPower => memberPower.MembrerId).HasColumnName("MembreId");
            modelBuilder.Entity<MemberPower>().Property(memberPower => memberPower.PowerId).HasColumnName("PouvoirId");
            modelBuilder.Entity<MemberPower>().Property(memberPower => memberPower.IsGeneral).HasColumnName("IsGeneralite");
            modelBuilder.Entity<MemberPower>().Property(memberPower => memberPower.IsMaster).HasColumnName("IsMaitreSpe");

            modelBuilder.Entity<MemberPower>()
                .HasOne(memberPower => memberPower.Member)
                .WithMany(member => member.MemberPowers)
                .HasForeignKey(memberPower => memberPower.MembrerId);

            modelBuilder.Entity<MemberPower>()
                .HasOne(memberPower => memberPower.Power)
                .WithMany(power => power.MemberPowers)
                .HasForeignKey(memberPower => memberPower.PowerId);
        }

        private void BuildMemberPsychicsMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberPsychic>().ToTable("MembrePsychique");

            modelBuilder.Entity<MemberPsychic>().HasKey(memberPsychic => memberPsychic.Id);
            modelBuilder.Entity<MemberPsychic>().Property(memberPsychic => memberPsychic.Id).HasColumnName("Id");

            modelBuilder.Entity<MemberPsychic>().Property(memberPsychic => memberPsychic.MemberId).HasColumnName("MembreId");
            modelBuilder.Entity<MemberPsychic>().Property(memberPsychic => memberPsychic.PsychicId).HasColumnName("PsychiqueId");

            modelBuilder.Entity<MemberPsychic>()
                .HasOne(memberPsychic => memberPsychic.Member)
                .WithMany(member => member.MemberPsychics)
                .HasForeignKey(memberPsychic => memberPsychic.MemberId);

            modelBuilder.Entity<MemberPsychic>()
                .HasOne(memberPsychic => memberPsychic.Psychic)
                .WithMany(psychic => psychic.MemberPsychics)
                .HasForeignKey(memberPsychic => memberPsychic.PsychicId);
        }

        private void BuildMemberWarGearOptionsMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberWarGearOption>().ToTable("MembreRemplacement");

            modelBuilder.Entity<MemberWarGearOption>().HasKey(memberWarGearOption => memberWarGearOption.Id);
            modelBuilder.Entity<MemberWarGearOption>().Property(memberWarGearOption => memberWarGearOption.Id).HasColumnName("Id");

            modelBuilder.Entity<MemberWarGearOption>().Property(memberWarGearOption => memberWarGearOption.MemberId).HasColumnName("MembreId");
            modelBuilder.Entity<MemberWarGearOption>().Property(memberWarGearOption => memberWarGearOption.WarGearOptionId).HasColumnName("RemplacementId");
            modelBuilder.Entity<MemberWarGearOption>().Property(memberWarGearOption => memberWarGearOption.WeaponId).HasColumnName("ArmeId");

            modelBuilder.Entity<MemberWarGearOption>()
                .HasOne(memberWarGearOption => memberWarGearOption.Member)
                .WithMany(member => member.MemberWarGearOptions)
                .HasForeignKey(memberWarGearOption => memberWarGearOption.MemberId);

            modelBuilder.Entity<MemberWarGearOption>()
                .HasOne(memberWarGearOption => memberWarGearOption.WarGearOption)
                .WithMany(warGearOption => warGearOption.MemberWarGearOptions)
                .HasForeignKey(memberWarGearOption => memberWarGearOption.WarGearOptionId);
        }

        private void BuildMemberTraitsMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberTrait>().ToTable("MembreTrait");

            modelBuilder.Entity<MemberTrait>().HasKey(memberTrait => memberTrait.Id);
            modelBuilder.Entity<MemberTrait>().Property(memberTrait => memberTrait.Id).HasColumnName("Id");

            modelBuilder.Entity<MemberTrait>().Property(memberTrait => memberTrait.MemberId).HasColumnName("MembreId");
            modelBuilder.Entity<MemberTrait>().Property(memberTrait => memberTrait.TraitId).HasColumnName("TraitId");

            modelBuilder.Entity<MemberTrait>()
                .HasOne(memberTrait => memberTrait.Member)
                .WithMany(Membre => Membre.MemberTraits)
                .HasForeignKey(memberTrait => memberTrait.MemberId);

            modelBuilder.Entity<MemberTrait>()
                .HasOne(memberTrait => memberTrait.Trait)
                .WithMany(Trait => Trait.MemberTraits)
                .HasForeignKey(memberTrait => memberTrait.TraitId);
        }

        public DbSet<Faction> Factions { get; set; }

        public DbSet<Tactic> Tactics { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<ModelProfile> ModelProfiles { get; set; }

        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<Specialist> Specialists { get; set; }

        public DbSet<Ability> Abilities { get; set; }

        public DbSet<Phase> Phases { get; set; }

        public DbSet<WeaponType> WeaponTypes { get; set; }

        public DbSet<Trait> Traits { get; set; }

        public DbSet<Psychic> Psychics { get; set; }

        public DbSet<Power> Powers { get; set; }

        public DbSet<WeaponProfile> WeaponProfiles { get; set; }

        public DbSet<SubFaction> SubFactions { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Member> Members { get; set; }
        
        public DbSet<MemberWeapon> MemberWeapons { get; set; }
        
        public DbSet<MemberPower> MemberPowers { get; set; }
        
        public DbSet<MemberTrait> MemberTraits { get; set; }
        
        public DbSet<MemberPsychic> MemberPsychics { get; set; }
        
        public DbSet<MemberWarGearOption> MemberWarGearOptions { get; set; }

        public DbSet<MemberSubFaction> MemberSubFactions { get; set; }
    }
}
