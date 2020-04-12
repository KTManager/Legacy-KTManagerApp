using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KillTeam.Commands;
using KillTeam.Commands.Handlers;
using KillTeam.Services;
using KillTeam.ViewModels;
using KillTeam.Views;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace KillTeam.Controllers
{
    public class FactionsController
    {
        public ObservableCollection<FactionsViewModel> Items { get; set; }

        public ICommand Selected { get; set; }

        public FactionsController(IHandleCommands<string, CreateTeamCommand> createTeamCommandHandler)
        {
            Items = new ObservableCollection<FactionsViewModel>();

            InitializeCommands();

            _createTeamCommandHandler = createTeamCommandHandler;
        }

        private void InitializeCommands()
        {
            Selected = new Command(async e => await SelectedExecuted(e as FactionsViewModel));
        }

        public async Task Refresh()
        {
            await UpdateItems();
        }

        private async Task UpdateItems()
        {
            Items.Clear();
            var fations = await KTContext.Db.Factions
                .AsNoTracking()
                .ToListAsync();

            fations.OrderBy(post => post.Name)
                .ToList()
                .ForEach(i => Items.Add(new FactionsViewModel(i.Id, i.Name)));
        }

        private async Task SelectedExecuted(FactionsViewModel faction)
        {
            var teamId = _createTeamCommandHandler.Handle(new CreateTeamCommand(faction.Id));

            await KTApp.Navigation.PopModalAsync(true);
            await KTApp.Navigation.PushAsync(new TeamDetails(teamId));
        }

        private readonly IHandleCommands<string, CreateTeamCommand> _createTeamCommandHandler;
    }
}