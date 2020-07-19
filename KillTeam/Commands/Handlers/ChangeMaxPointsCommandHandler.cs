using KillTeam.Services;
using Microsoft.EntityFrameworkCore;

namespace KillTeam.Commands.Handlers
{
    public class ChangeMaxPointsCommandHandler : IHandleCommands<ChangeMaxPointsCommand>
    {
        public void Handle(ChangeMaxPointsCommand command)
        {
            var teamId = command.TeamId;
            var team = KTContext.Db.Teams.Find(teamId);

            team.MaxPoints = command.MaxPoints;


            KTContext.Db.Entry(team).State = EntityState.Modified;
            KTContext.Db.SaveChanges();
        }
    }
}