using KillTeam.Models;
using MvvmHelpers;

namespace KillTeam.ViewModels
{
    public class ListGeneratorConfigViewModel : BaseViewModel
    {
        public ListGeneratorConfigViewModel()
        {
            _listGenerationConfig = new ListGenerationConfig();

            _groupIdenticalMembers = _listGenerationConfig.GroupIdenticalMembers;
            _showAbilityDetails = _listGenerationConfig.ShowAbilityDetails;
            _groupAbilities = _listGenerationConfig.GroupAbilities;
            _showTactics = _listGenerationConfig.ShowTactics;
            _showXpNewRecruitConvalescence = _listGenerationConfig.ShowXpNewRecruitConvalescence;
        }
        
        public bool GroupIdenticalMembers
        {
            get => _groupIdenticalMembers;
            set
            {
                SetProperty(ref _groupIdenticalMembers, value, nameof(GroupIdenticalMembers));
                _listGenerationConfig.GroupIdenticalMembers = value;
            }
        }

        public bool ShowAbilityDetails
        {
            get => _showAbilityDetails;
            set
            {
                SetProperty(ref _showAbilityDetails, value, nameof(ShowAbilityDetails));
                _listGenerationConfig.ShowAbilityDetails = value;
            }
        }

        public bool GroupAbilities
        {
            get => _groupAbilities;
            set
            {
                SetProperty(ref _groupAbilities, value, nameof(GroupAbilities));
                _listGenerationConfig.GroupAbilities = value;
            }
        }

        public bool ShowTactics
        {
            get => _showTactics;
            set
            {
                SetProperty(ref _showTactics, value, nameof(ShowTactics));
                _listGenerationConfig.ShowTactics = value;
            }
        }

        public bool ShowXpNewRecruitConvalescence
        {
            get => _showXpNewRecruitConvalescence;
            set
            {
                SetProperty(ref _showXpNewRecruitConvalescence, value, nameof(ShowXpNewRecruitConvalescence));
                _listGenerationConfig.ShowXpNewRecruitConvalescence = value;
            }
        }
        
        private readonly ListGenerationConfig _listGenerationConfig;
        
        private bool _groupIdenticalMembers;
        private bool _showAbilityDetails;
        private bool _groupAbilities;
        private bool _showTactics;
        private bool _showXpNewRecruitConvalescence;
    }
}