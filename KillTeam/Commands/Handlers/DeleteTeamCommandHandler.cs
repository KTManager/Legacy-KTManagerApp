using System.Linq;
using KillTeam.Models;
using KillTeam.Services;
using Microsoft.EntityFrameworkCore;

namespace KillTeam.Commands.Handlers
{
    public class DeleteTeamCommandHandler : IHandleCommands<DeleteTeamCommand>
    {
        public void Handle(DeleteTeamCommand command)
        {
            var teamId = command.TeamId;

            foreach (MemberTrait ma in KTContext.Db.MemberTraits.Where(m => m.Member.TeamId == teamId).AsNoTracking().ToList())
            {
                MemberTrait mad = KTContext.Db.MemberTraits.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }

            foreach (MemberPsychic ma in KTContext.Db.MemberPsychics.Where(m => m.Member.TeamId == teamId).AsNoTracking().ToList())
            {
                MemberPsychic mad = KTContext.Db.MemberPsychics.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }

            foreach (MemberPower ma in KTContext.Db.MemberPowers.Where(m => m.Member.TeamId == teamId).AsNoTracking().ToList())
            {
                MemberPower mad = KTContext.Db.MemberPowers.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }

            foreach (MemberWeapon ma in KTContext.Db.MemberWeapons.Where(m => m.Member.TeamId == teamId).AsNoTracking().ToList())
            {
                MemberWeapon mad = KTContext.Db.MemberWeapons.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }

            foreach (MemberWarGearOption ma in KTContext.Db.MemberWarGearOptions.Where(m => m.Member.TeamId == teamId).AsNoTracking().ToList())
            {
                MemberWarGearOption mad = KTContext.Db.MemberWarGearOptions.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }

            foreach (Member ma in KTContext.Db.Members.Where(m => m.TeamId == teamId).AsNoTracking().ToList())
            {
                Member mad = KTContext.Db.Members.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }

            var team = KTContext.Db.Teams.Find(teamId);

            KTContext.Db.Set<Team>().Remove(team);
            KTContext.Db.SaveChanges();
        }
    }
}