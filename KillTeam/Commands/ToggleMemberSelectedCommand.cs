namespace KillTeam.Commands
{
    public class ToggleMemberSelectedCommand
    {
        public string MemberId { get; }

        public bool IsSelected { get; set; }

        public ToggleMemberSelectedCommand(string memberId, bool isSelected)
        {
            MemberId = memberId;
            IsSelected = isSelected;
        }
    }
}