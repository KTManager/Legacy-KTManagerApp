using System.Linq;
using KillTeam.Models;
using KillTeam.Services;
using Microsoft.EntityFrameworkCore;

namespace KillTeam.Commands.Handlers
{
    public class ReorderTeamsCommandHandler : IHandleCommands<ReorderTeamsCommand>
    {
        public void Handle(ReorderTeamsCommand command)
        {
            var teamsIds = command.TeamsIds;
            var teams = KTContext.Db.Set<Team>().AsTracking().ToList();

            for (var i = 0; i < teamsIds.Count; i++)
            {
                var team = teams.First(x => x.Id == teamsIds[i]);
                team.Position = i;
            }
            
            KTContext.Db.SaveChanges();
        }
    }
}