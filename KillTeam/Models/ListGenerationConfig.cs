using Xamarin.Forms;

namespace KillTeam.Models
{
    public class ListGenerationConfig
    {
        public bool GroupIdenticalMembers
        {
            get => FetchValueOrDefault(nameof(GroupIdenticalMembers));
            set => Application.Current.Properties[nameof(GroupIdenticalMembers)] = value;
        }

        public bool ShowAbilityDetails
        {
            get => FetchValueOrDefault(nameof(ShowAbilityDetails));
            set => Application.Current.Properties[nameof(ShowAbilityDetails)] = value;
        }

        public bool GroupAbilities
        {
            get => FetchValueOrDefault(nameof(GroupAbilities));
            set => Application.Current.Properties[nameof(GroupAbilities)] = value;
        }

        public bool ShowTactics
        {
            get => FetchValueOrDefault(nameof(ShowTactics));
            set => Application.Current.Properties[nameof(ShowTactics)] = value;
        }

        public bool ShowXpNewRecruitConvalescence
        {
            get => FetchValueOrDefault(nameof(ShowXpNewRecruitConvalescence));
            set => Application.Current.Properties[nameof(ShowXpNewRecruitConvalescence)] = value;
        }

        private bool FetchValueOrDefault(string key)
        {
            if (Application.Current.Properties.ContainsKey(key))
                return (bool) Application.Current.Properties[key];

            return false;
        }
    }
}