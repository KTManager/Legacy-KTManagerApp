using KillTeam.Services;
using Microsoft.EntityFrameworkCore;

namespace KillTeam.Commands.Handlers
{
    public class ToggleMemberSelectedCommandHandler : IHandleCommands<ToggleMemberSelectedCommand>
    {
        public void Handle(ToggleMemberSelectedCommand command)
        {
            var memberId = command.MemberId;
            var member = KTContext.Db.Members.Find(memberId);

            member.Selected = command.IsSelected;


            KTContext.Db.Entry(member).State = EntityState.Modified;
            KTContext.Db.SaveChanges();
        }
    }
}