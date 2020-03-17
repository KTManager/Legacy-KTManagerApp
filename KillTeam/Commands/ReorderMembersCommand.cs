using System.Collections;
using System.Collections.Generic;
using System.Linq;

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