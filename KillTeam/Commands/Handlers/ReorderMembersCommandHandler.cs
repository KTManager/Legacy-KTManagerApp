using System.Linq;
using KillTeam.Models;
using KillTeam.Services;
using Microsoft.EntityFrameworkCore;

namespace KillTeam.Commands.Handlers
{
    public class ReorderMembersCommandHandler : IHandleCommands<ReorderMembersCommand>
    {
        public void Handle(ReorderMembersCommand command)
        {
            var memberIds = command.MemberIds;
            var members = KTContext.Db.Set<Member>().AsTracking().ToList();

            for (var i = 0; i < memberIds.Count; i++)
            {
                var member = members.First(x => x.Id == memberIds[i]);
                member.Position = i;

                KTContext.Db.SaveChanges();
            }
        }
    }
}