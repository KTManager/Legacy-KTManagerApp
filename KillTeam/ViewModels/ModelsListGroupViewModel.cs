using System.Collections.ObjectModel;

namespace KillTeam.ViewModels
{
    public class ModelsListGroupViewModel : ObservableCollection<ModelsListProfileViewModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }
        
#if DEBUG
        public ModelsListGroupViewModel() { }
#endif

        public ModelsListGroupViewModel(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
