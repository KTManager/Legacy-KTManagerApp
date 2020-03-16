namespace KillTeam.ViewModels
{
    public class FactionsFactionViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public FactionsFactionViewModel()
        {
        }

        public FactionsFactionViewModel(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
