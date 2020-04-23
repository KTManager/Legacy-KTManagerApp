using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KillTeam.Models;
using KillTeam.Services;
using KillTeam.Templates;
using KillTeam.Views;
using Microsoft.EntityFrameworkCore;
using MvvmHelpers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace KillTeam.Controllers
{
    public class ListGeneratorConfigController : BaseViewModel
    {
        public ICommand GenerateList { get; }
        public ICommand OpenList { get; }

        public ListGeneratorConfigController(string teamId)
        {
            _listGenerationConfig = new ListGenerationConfig();
            _teamId = teamId;
            _groupIdenticalMembers = _listGenerationConfig.GroupIdenticalMembers;
            _showAbilityDetails = _listGenerationConfig.ShowAbilityDetails;
            _groupAbilities = _listGenerationConfig.GroupAbilities;
            _showTactics = _listGenerationConfig.ShowTactics;
            _showXpNewRecruitConvalescence = _listGenerationConfig.ShowXpNewRecruitConvalescence;
            
            GenerateList = new Command(async () => await LoadTeam());
            OpenList = new Command(async  () => await OpenGeneratedList());
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

        public bool GenerateListEnabled
        {
            get => _generateListEnabled;
            set => SetProperty(ref _generateListEnabled, value, nameof(GenerateListEnabled));
        }

        public string GenerateListText
        {
            get => _generateListText;
            set => SetProperty(ref _generateListText, value, nameof(GenerateListText));
        }

        public bool OpenButtonVisible
        {
            get => _openButtonVisible;
            set => SetProperty(ref _openButtonVisible, value, nameof(OpenButtonVisible));
        }

        private async Task LoadTeam()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                GenerateListEnabled = true;
                GenerateListText = "Loading Team...";
            });

            await Task.Run(async () =>
            {
                if (_team != null)
                    return;
                
                _team = await KTContext.Db.Teams
                    .AsNoTracking()
                    .Where(e => e.Id == _teamId)
                    .Include(e => e.Faction.Tactics)
                    .Include(e => e.Faction.Abilities)
                    .ThenInclude(a => a.Details)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.MemberPowers)
                    .ThenInclude(e => e.Power)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.Specialist.Tactics)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.Specialist.Powers)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.MemberWeapons)
                    .ThenInclude(e => e.Weapon.WeaponProfiles)
                    .ThenInclude(e => e.WeaponType)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.ModelProfile)
                    .ThenInclude(e => e.Abilities)
                    .ThenInclude(a => a.Details)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.ModelProfile.Model)
                    .ThenInclude(e => e.Abilities)
                    .ThenInclude(a => a.Details)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.ModelProfile.Tactics)
                    .Include(e => e.Faction.Models)
                    .ThenInclude(e => e.Abilities)
                    .ThenInclude(a => a.Details)
                    .Include(e => e.Faction.Models)
                    .ThenInclude(d => d.ModelWeapons)
                    .ThenInclude(d => d.Weapon.WeaponProfiles)
                    .ThenInclude(d => d.WeaponType)
                    .Include(e => e.Faction.Models)
                    .ThenInclude(f => f.ModelProfiles)
                    .ThenInclude(d => d.ModelProfileWeapons)
                    .ThenInclude(d => d.Weapon.WeaponProfiles)
                    .ThenInclude(d => d.WeaponType)
                    .Include(f => f.Faction.Models)
                    .ThenInclude(f => f.ModelProfiles)
                    .ThenInclude(f => f.Abilities)
                    .ThenInclude(a => a.Details)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.MemberTraits)
                    .ThenInclude(ma => ma.Trait)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.MemberPsychics)
                    .ThenInclude(ma => ma.Psychic)
                    .FirstAsync();
            });
            
            MainThread.BeginInvokeOnMainThread(() =>
            {
                GenerateListText = "Building List...";
            });

            await Task.Run(() =>
            {
                var config = new PdfConfiguration
                {
                    GroupIdenticalMembers = GroupIdenticalMembers,
                    AbilityDetails = ShowAbilityDetails,
                    GroupAbilities = GroupAbilities,
                    Tactics = ShowTactics,
                    XpRecruitConvalescence = ShowXpNewRecruitConvalescence
                };
                
                var template = new Template
                {
                    Model = new GeneratedList(_team, config)
                };
                
                _htmlString = template.GenerateString();
            });

            MainThread.BeginInvokeOnMainThread(() =>
            {
                GenerateListEnabled = false;
                GenerateListText = Properties.Resources.GeneratePDF;
                OpenButtonVisible = true;
            });
        }

        private async Task OpenGeneratedList()
        {
            await KTApp.Navigation.PushAsync(new ListGenerator(_htmlString));
        }
        
        private readonly ListGenerationConfig _listGenerationConfig;
        private string _teamId;
        private bool _groupIdenticalMembers;
        private bool _showAbilityDetails;
        private bool _groupAbilities;
        private bool _showTactics;
        private bool _showXpNewRecruitConvalescence;
        private bool _generateListEnabled;
        private string _generateListText = Properties.Resources.GeneratePDF;
        private Team _team;
        private string _htmlString;
        private bool _openButtonVisible;
    }

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