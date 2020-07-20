using System;
namespace KillTeam.Commands
{
    public class EditMaxPointsCommand
    {
        public string TeamId { get; }

        public int MaxPoints { get; set; }

        public EditMaxPointsCommand(string teamId, int maxPoints)
        {
            TeamId = teamId;
            MaxPoints = maxPoints;
        }
    }
}
