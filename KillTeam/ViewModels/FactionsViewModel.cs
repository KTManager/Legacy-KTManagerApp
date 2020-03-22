namespace KillTeam.ViewModels
{
    public class FactionsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public FactionsViewModel(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}