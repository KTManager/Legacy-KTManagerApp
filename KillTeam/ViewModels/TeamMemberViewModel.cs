namespace KillTeam.ViewModels
{
    public class TeamMemberViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

        public string Description { get; set; }

        public bool IsSelected { get; set; }

        public TeamMemberViewModel(string id, string name, int cost, string description, bool isSelected)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
            IsSelected = isSelected;
        }
    }
}