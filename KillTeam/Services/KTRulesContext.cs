using KillTeam.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillTeam.Services
{
    public class KTRulesContext : DbContext, IKTRulesContext
    {
        public string DBPath { get; private set; }

        protected KTRulesContext(string dbpath)
        {
            this.DBPath = dbpath;
            // NOTE: without this line, adding a new member to a team requires
            // you to go back and forward again to see it.
            // TODO: determine why this line is required
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public Models.Version GetCurrentVersion()
        {
            var versions = this.Versions.OrderByDescending(v => v.Id).ToList();
            if (versions.Count() == 0) { return null; }
            return versions.First();
        }

        public void ImportRules(RulesProviders.RulesProvider provider)
        {
            RulesImporter.ImportJSON(this, provider);
            this.Versions.Add(new Models.Version { RulesVersion = provider.GetVersion() });
            this.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseSqlite($"Filename={DBPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelWeapon>()
                .HasKey(mw => new { mw.ModelId, mw.WeaponId });
            modelBuilder.Entity<ModelProfileWeapon>()
                .HasKey(mpw => new { mpw.ModelProfileId, mpw.WeaponId });
            modelBuilder.Entity<ModelProfileSpecialist>()
                .HasKey(mps => new { mps.ModelProfileId, mps.SpecialistId });
        }

        public DbSet<Faction> Factions { get; protected set; }
        public DbSet<Tactic> Tactics { get; protected set; }
        public DbSet<Model> Models { get; protected set; }
        public DbSet<ModelProfile> ModelProfiles { get; protected set; }
        public DbSet<Weapon> Weapons { get; protected set; }
        public DbSet<Specialist> Specialists { get; protected set; }
        public DbSet<Ability> Abilities { get; protected set; }
        public DbSet<Phase> Phases { get; protected set; }
        public DbSet<WeaponType> WeaponTypes { get; protected set; }
        public DbSet<Trait> Traits { get; protected set; }
        public DbSet<Psychic> Psychics { get; protected set; }
        public DbSet<Power> Powers { get; protected set; }
        public DbSet<WeaponProfile> WeaponProfiles { get; protected set; }
        public DbSet<Models.Version> Versions { get; protected set; }
    }
}
