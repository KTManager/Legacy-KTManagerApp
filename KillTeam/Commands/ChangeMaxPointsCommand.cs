using System;
namespace KillTeam.Commands
{
    public class ChangeMaxPointsCommand
    {
        public string TeamId { get; }

        public int MaxPoints { get; set; }

        public ChangeMaxPointsCommand(string teamId, int maxPoints)
        {
            TeamId = teamId;
            MaxPoints = maxPoints;
        }
    }
}
