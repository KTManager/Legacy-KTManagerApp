using KillTeam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KillTeam.Services
{
    public interface IDBContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }

    public interface IKTRulesContext : IDBContext
    {
        DbSet<Faction> Factions { get; }
        DbSet<Tactic> Tactics { get; }
        DbSet<Model> Models { get; }
        DbSet<ModelProfile> ModelProfiles { get; }
        DbSet<Weapon> Weapons { get; }
        DbSet<Specialist> Specialists { get; }
        DbSet<Ability> Abilities { get; }
        DbSet<Phase> Phases { get; }
        DbSet<WeaponType> WeaponTypes { get; }
        DbSet<Trait> Traits { get; }
        DbSet<Psychic> Psychics { get; }
        DbSet<Power> Powers { get; }
        DbSet<WeaponProfile> WeaponProfiles { get; }
    }

    public interface IKTContext : IKTRulesContext
    {
        DbSet<Team> Teams { get; }
        DbSet<Member> Members { get; }
        DbSet<MemberWeapon> MemberWeapons { get; }
        DbSet<MemberPower> MemberPowers { get; }
        DbSet<MemberTrait> MemberTraits { get; }
        DbSet<MemberPsychic> MemberPsychics { get; }
        DbSet<MemberWarGearOption> MemberWarGearOptions { get; }
    }
}
