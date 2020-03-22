using System.Collections.Generic;

namespace KillTeam.Commands
{
    public class ReorderMembersCommand
    {
        public List<string> MemberIds { get; }

        public ReorderMembersCommand(List<string> memberIds)
        {
            MemberIds = memberIds;
        }
    }
}