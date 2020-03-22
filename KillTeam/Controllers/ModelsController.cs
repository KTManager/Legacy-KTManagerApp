using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KillTeam.Commands;
using KillTeam.Commands.Handlers;
using KillTeam.Services;
using KillTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace KillTeam.Controllers
{
    public class ModelsController
    {
        public ObservableCollection<ModelsViewModel> Items { get; set; }
        
        public ICommand Selected { get; set; }

        public ModelsController(string teamId, IHandleCommands<CreateMemberCommand> createMemberCommandHandler)
        {
            _teamId = teamId;

            Items = new ObservableCollection<ModelsViewModel>();

            InitializeCommands();

            _createMemberCommandHandler = createMemberCommandHandler;
        }

        private void InitializeCommands()
        {
            Selected = new Command(async e => await SelectedExecuted(e as ModelsProfileViewModel));
        }

        public async Task Refresh()
        {
            await UpdateItems();
        }

        public async Task UpdateItems()
        {
            Items.Clear();

            var team = KTContext.Db.Teams
                .Where(e => e.Id == _teamId)
                .Include(e => e.Members)
                .ThenInclude(fig => fig.ModelProfile)
                .Include(f => f.Faction.Models)
                .ThenInclude(fig => fig.ModelProfiles)
                .AsNoTracking()
                .First();

            var commanderGroup = new ModelsViewModel(Properties.Resources.Commandant);
            foreach (var model in team.Faction.Models)
            {
                var currentGroup = new ModelsViewModel(model.Name);
                foreach (var profile in model.ModelProfiles)
                {
                    profile.ModelId = model.Id;
                    profile.Model = model;

                    if (profile.MaximumNumber == 0 || team.Roster || profile.MaximumNumber > team.GetSelectedMembers().Count(m => m.ModelProfile.Id == profile.Id))
                    {
                        if (!profile.IsCommander || team.Members.Count(m => m.ModelProfile.Id == profile.Id) == 0 && (team.Roster || team.GetSelectedMembers().Count(m => m.ModelProfile.IsCommander) == 0))
                        {
                            var profileViewModel = new ModelsProfileViewModel(profile.Id, profile.Name, profile.FormattedCost, profile.FormattedMaximumNumber);
                            if (profile.IsCommander)
                            {
                                commanderGroup.Add(profileViewModel);
                            }
                            else
                            {
                                currentGroup.Add(profileViewModel);
                            }
                        }
                    }
                }
                if (currentGroup.Count > 0)
                {
                    Items.Add(currentGroup);
                }
            }

            if (commanderGroup.Count > 0)
            {
                Items.Add(commanderGroup);
            }
        }
        
        private async Task SelectedExecuted(ModelsProfileViewModel profile)
        {
            _createMemberCommandHandler.Handle(new CreateMemberCommand(_teamId, profile.Id));

            await KTApp.Navigation.PopModalAsync(true);

        }

        private readonly string _teamId;
        private readonly IHandleCommands<CreateMemberCommand> _createMemberCommandHandler;
    }
}
