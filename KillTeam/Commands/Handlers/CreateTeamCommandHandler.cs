using System;
using System.Collections.Generic;
using System.Linq;
using KillTeam.Models;
using KillTeam.Services;
using Microsoft.EntityFrameworkCore;

namespace KillTeam.Commands.Handlers
{
    public class CreateTeamCommandHandler : IHandleCommands<CreateTeamCommand>
    {
        public void Handle(CreateTeamCommand command)
        {
            var factionId = command.FactionId;
            var faction = KTContext.Db.Factions.Find(factionId);

            var team = new Team
            {
                Id = Guid.NewGuid().ToString(),
                Name = faction.Name,
                FactionId = factionId,
                Members = new List<Member>(),
                Position = KTContext.Db.Teams.Select(a => a.Position).ToList().DefaultIfEmpty(0).Max() + 1
            };


            KTContext.Db.Entry(team).State = EntityState.Added;
            KTContext.Db.SaveChanges();
        }
    }
}