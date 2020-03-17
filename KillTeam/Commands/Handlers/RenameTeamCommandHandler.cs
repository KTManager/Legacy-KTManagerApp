using KillTeam.Services;
using Microsoft.EntityFrameworkCore;

namespace KillTeam.Commands.Handlers
{
    public class RenameTeamCommandHandler : IHandleCommands<RenameTeamCommand>
    {
        public void Handle(RenameTeamCommand command)
        {
            var teamId = command.TeamId;
            var team = KTContext.Db.Teams.Find(teamId);

            team.Name = command.Name;


            KTContext.Db.Entry(team).State = EntityState.Modified;
            KTContext.Db.SaveChanges();
        }
    }
}