using System;
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
            var teamIds = command.TeamIds;
            var teams = KTContext.Db.Set<Team>().AsTracking().ToList();

            for (var i = 0; i < teamIds.Count; i++)
            {
                var team = teams.First(x => x.Id == teamIds[i]);
                team.Position = i;

                KTContext.Db.SaveChanges();
            }
        }
    }
}