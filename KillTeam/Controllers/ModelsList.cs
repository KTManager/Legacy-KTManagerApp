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
    public class ModelsList
    {
        public ObservableCollection<ModelsListGroupViewModel> Items { get; set; }
        
        public ICommand Selected { get; set; }

#if DEBUG
        public ModelsList() { }
#endif

        public ModelsList(string teamId, IHandleCommands<CreateMemberCommand> createMemberCommandHandler)
        {
            _teamId = teamId;

            Items = new ObservableCollection<ModelsListGroupViewModel>();

            Selected = new Command(async e => await SelectedExecuted(e as ModelsListProfileViewModel));

            _createMemberCommandHandler = createMemberCommandHandler;
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

            var commanderGroup = new ModelsListGroupViewModel { Name = Properties.Resources.Commandant };
            foreach (var model in team.Faction.Models)
            {
                var currentGroup = new ModelsListGroupViewModel { Name = model.Name };
                foreach (var profile in model.ModelProfiles)
                {
                    profile.ModelId = model.Id;
                    profile.Model = model;

                    if (profile.MaximumNumber == 0 || team.Roster || profile.MaximumNumber > team.GetSelectedMembers().Count(m => m.ModelProfile.Id == profile.Id))
                    {
                        if (!profile.IsCommander || team.Members.Count(m => m.ModelProfile.Id == profile.Id) == 0 && (team.Roster || team.GetSelectedMembers().Count(m => m.ModelProfile.IsCommander) == 0))
                        {
                            var profileViewModel = new ModelsListProfileViewModel(profile.Id, profile.Name, profile.FormattedCost, profile.FormattedMaximumNumber);
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
        
        public async Task SelectedExecuted(ModelsListProfileViewModel profile)
        {
            _createMemberCommandHandler.Handle(new CreateMemberCommand(_teamId, profile.Id));

            await KTApp.Navigation.PopModalAsync(true);

        }

        private string _teamId;
        private readonly IHandleCommands<CreateMemberCommand> _createMemberCommandHandler;
    }
}
