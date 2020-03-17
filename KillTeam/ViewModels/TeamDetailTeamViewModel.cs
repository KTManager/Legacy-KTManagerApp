using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KillTeam.ViewModels
{
    public class TeamDetailTeamViewModel : INotifyPropertyChanged
    {
        private int _cost;
        private string _name;
        private string _faction;
        private bool _isRoster;
        public string Id { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FormattedNameCost));
            }
        }

        public int Cost
        {
            get => _cost;
            set
            {
                _cost = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FormattedCost));
                OnPropertyChanged(nameof(FormattedNameCost));
                OnPropertyChanged(nameof(FormattedFactionCost));
            }
        }

        public string Faction
        {
            get => _faction;
            set
            {
                _faction = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FormattedFactionCost));
            }
        }

        public bool IsRoster
        {
            get => _isRoster;
            set
            {
                _isRoster = value;
                OnPropertyChanged();
            }
        }

        public string FormattedNameCost => $"{Name} ({Cost})";

        public string FormattedFactionCost => $"{Faction} : {FormattedCost} {Properties.Resources.Points}";

        public string FormattedCost => $"{Cost} {Properties.Resources.Points}";

        public bool ShowFaction => Name != Faction;
        public bool ShowCostOnly => !ShowFaction;

        public ObservableCollection<TeamDetailMemberViewModel> Members { get; set; }

#if DEBUG
        public TeamDetailTeamViewModel() { }
#endif

        public TeamDetailTeamViewModel(string id, string name, int cost, string faction, bool isRoster)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Faction = faction;
            IsRoster = isRoster;
            Members = new ObservableCollection<TeamDetailMemberViewModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
