using System.Collections.ObjectModel;

namespace KillTeam.ViewModels
{
    public class WargearViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ObservableCollection<WargearViewModel> ComesWith { get; set; }

        public ObservableCollection<WargearViewModel> CompatibleWith { get; set; }

        public ObservableCollection<WargearViewModel> ReplaceableWith { get; set; }

        public WargearViewModel(string id, string name)
        {
            Id = id;
            Name = name;
            ComesWith = new ObservableCollection<WargearViewModel>();
            CompatibleWith = new ObservableCollection<WargearViewModel>();
            ReplaceableWith = new ObservableCollection<WargearViewModel>();
        }
    }
}
