using KillTeam.Services;
using Microsoft.EntityFrameworkCore;

namespace KillTeam.Commands.Handlers
{
    public class ToggleRosterCommandHandler : IHandleCommands<ToggleRosterCommand>
    {
        public void Handle(ToggleRosterCommand command)
        {
            var teamId = command.TeamId;
            var team = KTContext.Db.Teams.Find(teamId);

            team.Roster = command.IsRoster;


            KTContext.Db.Entry(team).State = EntityState.Modified;
            KTContext.Db.SaveChanges();
        }
    }
}