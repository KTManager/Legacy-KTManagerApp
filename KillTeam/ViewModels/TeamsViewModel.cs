namespace KillTeam.ViewModels
{
    public class TeamsTeamViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

        public string FactionAndMembersCount { get; set; }

        public TeamsTeamViewModel(string id, string name, int cost, string factionAndMembersCount)
        {
            Id = id;
            Name = name;
            Cost = cost;
            FactionAndMembersCount = factionAndMembersCount;
        }
    }
}
