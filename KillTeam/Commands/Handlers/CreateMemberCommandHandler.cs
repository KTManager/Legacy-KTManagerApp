using System.Linq;
using System.Threading.Tasks;
using KillTeam.Models;
using KillTeam.Services;
using Microsoft.EntityFrameworkCore;

namespace KillTeam.Commands.Handlers
{
    public class CreateMemberCommandHandler : IHandleCommands<CreateMemberCommand>
    {
        public void Handle(CreateMemberCommand command)
        {
            var teamId = command.TeamId;
            var profileId = command.ProfileId;

            var member = Member.CreateFrom(teamId, profileId);

            KTContext.Db.Entry(member).State = EntityState.Added;
            KTContext.Db.SaveChanges();
        }
    }
}