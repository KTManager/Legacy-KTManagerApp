using System.Collections.ObjectModel;
using System.Linq;

namespace KillTeam.ViewModels
{
    public class WargearSlotViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public WargearViewModel SelectedItem { get; set; }

        public ObservableCollection<WargearViewModel> CompatibleWith => SelectedItem?.ComesWith.Any() == true
            ? SelectedItem?.ComesWith
            : SelectedItem?.CompatibleWith;

        public ObservableCollection<WargearViewModel> Options { get; set; }

        public WargearSlotViewModel(string name)
        {
            Name = name;
            Options = new ObservableCollection<WargearViewModel>();
        }
    }
}