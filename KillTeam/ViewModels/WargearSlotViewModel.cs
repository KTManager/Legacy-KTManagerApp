using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace KillTeam.ViewModels
{
    public class WargearSlotViewModel : INotifyPropertyChanged
    {
        private WargearViewModel _selectedItem;
        public int Id { get; set; }

        public string Name { get; set; }

        public WargearViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value; 
                OnPropertyChanged();
            }
        }

        public ObservableCollection<WargearViewModel> CompatibleWith => SelectedItem?.ComesWith.Any() == true
            ? SelectedItem?.ComesWith
            : SelectedItem?.CompatibleWith;

        public ObservableCollection<WargearViewModel> Options { get; set; }

        public WargearSlotViewModel(string name)
        {
            Name = name;
            Options = new ObservableCollection<WargearViewModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}