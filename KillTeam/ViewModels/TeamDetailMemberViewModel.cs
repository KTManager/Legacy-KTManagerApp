namespace KillTeam.ViewModels
{
    public class TeamDetailMemberViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

        public string Description { get; set; }

        public bool IsSelected { get; set; }
        
        public TeamDetailMemberViewModel(string id, string name, int cost, string description, bool isSelected)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
            IsSelected = isSelected;
        }
    }
}
