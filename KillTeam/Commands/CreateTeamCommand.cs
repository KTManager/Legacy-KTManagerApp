namespace KillTeam.Commands
{
    public class CreateTeamCommand
    {
        public string FactionId { get; }

        public CreateTeamCommand(string factionId)
        {
            FactionId = factionId;
        }
    }
}