using System.Collections.ObjectModel;

namespace KillTeam.ViewModels
{
    public class ModelsViewModel : ObservableCollection<ModelsProfileViewModel>
    {
        public string Name { get; set; }

        public ModelsViewModel(string name)
        {
            Name = name;
        }
    }
}
