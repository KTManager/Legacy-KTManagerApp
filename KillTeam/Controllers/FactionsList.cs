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
    public class FactionsList
    {
        public ObservableCollection<FactionsListFactionViewModel> Items { get; set; }
        
        public ICommand Selected { get; set; }


#if DEBUG
        public FactionsList() { }
#endif

        public FactionsList(IHandleCommands<CreateTeamCommand> createTeamCommandHandler)
        {
            Items = new ObservableCollection<FactionsListFactionViewModel>();

            Selected = new Command(async e => await SelectedExecuted(e as FactionsListFactionViewModel));

            _createTeamCommandHandler = createTeamCommandHandler;
        }
        
        public async Task Refresh()
        {
            await UpdateListItems();
        }

        public async Task UpdateListItems()
        {
            Items.Clear();
            var fations = KTContext.Db.Factions
                .AsNoTracking()
                .ToList();

            fations.OrderBy(post => post.Name)
                .ToList()
                .ForEach(i => Items.Add(new FactionsListFactionViewModel(i.Id, i.Name)));
        }
        
        public async Task SelectedExecuted(FactionsListFactionViewModel faction)
        {
            _createTeamCommandHandler.Handle(new CreateTeamCommand(faction.Id));

            await KTApp.Navigation.PopModalAsync(true);

        }

        private readonly IHandleCommands<CreateTeamCommand> _createTeamCommandHandler;
    }
}
