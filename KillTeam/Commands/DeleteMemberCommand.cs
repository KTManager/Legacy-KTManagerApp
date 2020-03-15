namespace KillTeam.Commands
{
    public class DeleteMemberCommand
    {
        public string MemberId { get; }

        public DeleteMemberCommand(string memberId)
        {
            MemberId = memberId;
        }
    }
}