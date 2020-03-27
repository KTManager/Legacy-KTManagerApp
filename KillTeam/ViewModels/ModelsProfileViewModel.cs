namespace KillTeam.ViewModels
{
    public class ModelsProfileViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
        
        public string MaximumNumber { get; set; }

        public string Cost { get; set; }

        public ModelsProfileViewModel(string id, string name, string cost, string maximumNumber)
        {
            Id = id;
            Name = name;
            Cost = cost;
            MaximumNumber = maximumNumber;
        }
    }
}
