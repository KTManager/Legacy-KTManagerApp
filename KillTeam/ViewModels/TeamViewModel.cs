using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using KillTeam.Resx;

namespace KillTeam.ViewModels
{
    public class TeamViewModel : INotifyPropertyChanged
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

        public List<string> Errors { get; set; }

        public string FormattedNameCost => $"{Name} ({Cost})";

        public string FormattedFactionCost => $"{Faction} : {FormattedCost}";

        public string FormattedCost => $"{Cost} {Translate.Points}";

        public bool ShowFaction => Name != Faction;
        public bool ShowCostOnly => !ShowFaction;

        public ObservableCollection<TeamMemberViewModel> Members { get; set; }

        public TeamViewModel(string id, string name, int cost, string faction, bool isRoster)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Faction = faction;
            IsRoster = isRoster;
            Members = new ObservableCollection<TeamMemberViewModel>();
            Errors = new List<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
