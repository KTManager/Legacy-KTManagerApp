using System;
using KillTeam.Models;
using KillTeam.Services;
using Microsoft.EntityFrameworkCore;

namespace KillTeam.Commands.Handlers
{
    public class DuplicateTeamCommandHandler : IHandleCommands<DuplicateTeamCommand>
    {
        public void Handle(DuplicateTeamCommand command)
        {
            try
            {
                var teamId = command.TeamId;
                var team = Team.DuplicateTeam(teamId);

                KTContext.Db.Entry(team).State = EntityState.Added;
                KTContext.Db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}