namespace KillTeam.Commands
{
    public class CreateMemberCommand
    {
        public string TeamId { get; }

        public string ProfileId { get; }

        public CreateMemberCommand(string teamId, string profileId)
        {
            TeamId = teamId;
            ProfileId = profileId;
        }
    }
}