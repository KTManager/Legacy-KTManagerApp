using System.Collections.Generic;

namespace KillTeam.Commands
{
    public class ReorderTeamsCommand
    {
        public List<string> TeamsIds { get; }

        public ReorderTeamsCommand(List<string> teamsIds)
        {
            TeamsIds = teamsIds;
        }
    }
}