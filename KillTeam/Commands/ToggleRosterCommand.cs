namespace KillTeam.Commands
{
    public class ToggleRosterCommand
    {
        public string TeamId { get; }

        public bool IsRoster { get; set; }

        public ToggleRosterCommand(string teamId, bool isRoster)
        {
            TeamId = teamId;
            IsRoster = isRoster;
        }
    }
}