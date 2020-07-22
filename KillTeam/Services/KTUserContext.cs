using KillTeam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace KillTeam.Services
{
    public class KTUserContext : KTRulesContext, IKTContext
    {
        public KTUserContext(string dbpath) : base(dbpath)
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // TODO
        }

        public DbSet<Team> Teams { get; protected set; }
        public DbSet<Member> Members { get; protected set; }
        public DbSet<MemberWeapon> MemberWeapons { get; protected set; }
        public DbSet<MemberPower> MemberPowers { get; protected set; }
        public DbSet<MemberTrait> MemberTraits { get; protected set; }
        public DbSet<MemberPsychic> MemberPsychics { get; protected set; }
        public DbSet<MemberWarGearOption> MemberWarGearOptions { get; protected set; }
        public DbSet<MemberSubFaction> MemberSubFactions { get; protected set; }

    }
}
