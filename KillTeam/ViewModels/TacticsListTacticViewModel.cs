namespace KillTeam.ViewModels
{
    public class TacticsListTacticViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Origin { get; set; }

        public string Description { get; set; }

        public int Cost { get; set; }

        public TacticsListTacticViewModel(string id, string name, string origin, string description, int cost)
        {
            Id = id;
            Name = name;
            Origin = origin;
            Description = description;
            Cost = cost;
        }
    }
}
