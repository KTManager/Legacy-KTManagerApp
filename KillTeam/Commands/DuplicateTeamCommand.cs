namespace KillTeam.Commands
{
    public class DuplicateTeamCommand
    {
        public string TeamId { get; }

        public DuplicateTeamCommand(string teamId)
        {
            TeamId = teamId;
        }
    }
}