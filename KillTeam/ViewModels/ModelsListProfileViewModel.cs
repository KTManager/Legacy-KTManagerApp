using KillTeam.Models;

namespace KillTeam.ViewModels
{
    public class ModelsListProfileViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
        
        public string MaximumNumber { get; set; }

        public string Cost { get; set; }

#if DEBUG
        public ModelsListProfileViewModel() { }
#endif

        public ModelsListProfileViewModel(string id, string name, string cost, string maximumNumber)
        {
            Id = id;
            Name = name;
            Cost = cost;
            MaximumNumber = maximumNumber;
        }
    }
}
