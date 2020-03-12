namespace KillTeam.Commands
{
    public class DeleteTeamCommand
    {
        public string TeamId { get; }

        public DeleteTeamCommand(string teamId)
        {
            TeamId = teamId;
        }
    }
}