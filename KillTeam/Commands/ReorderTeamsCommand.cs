using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KillTeam.Commands
{
    public class ReorderTeamsCommand
    {
        public List<string> TeamIds { get; }

        public ReorderTeamsCommand(List<string> teamIds)
        {
            TeamIds = teamIds;
        }
    }
}