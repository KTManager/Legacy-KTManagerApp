using KillTeam.Services;
using Microsoft.EntityFrameworkCore;

namespace KillTeam.Commands.Handlers
{
    public class EditMaxPointsCommandHandler : IHandleCommands<EditMaxPointsCommand>
    {
        public void Handle(EditMaxPointsCommand command)
        {
            var teamId = command.TeamId;
            var team = KTContext.Db.Teams.Find(teamId);

            team.MaxPoints = command.MaxPoints;


            KTContext.Db.Entry(team).State = EntityState.Modified;
            KTContext.Db.SaveChanges();
        }
    }
}