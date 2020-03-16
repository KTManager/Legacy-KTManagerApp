namespace KillTeam.ViewModels
{
    public class FactionsListFactionViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

#if DEBUG
        public FactionsListFactionViewModel() { }
#endif

        public FactionsListFactionViewModel(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
