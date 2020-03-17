namespace KillTeam.Commands
{
    public class RenameTeamCommand
    {
        public string TeamId { get; }

        public string Name { get; }

        public RenameTeamCommand(string teamId, string name)
        {
            TeamId = teamId;
            Name = name;
        }
    }
}