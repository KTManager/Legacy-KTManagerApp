using System.Collections.ObjectModel;

namespace KillTeam.ViewModels
{
    public class TeamDetailTeamViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

        public string Faction { get; set; }

        public bool IsRoster { get; set; }

        public string FormattedFactionCost => $"{Faction} : {Cost} {Properties.Resources.Points}";
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
    }
}
