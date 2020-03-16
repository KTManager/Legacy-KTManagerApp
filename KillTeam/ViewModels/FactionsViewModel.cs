using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KillTeam.Commands;
using KillTeam.Commands.Handlers;
using KillTeam.Models;
using KillTeam.Properties;
using KillTeam.Services;
using KillTeam.Views;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace KillTeam.ViewModels
{
    public class FactionsViewModel
    {
        public ObservableCollection<FactionsFactionViewModel> Items { get; set; }
        
        public ICommand Selected { get; set; }
       

        /// <summary>To use only on desgin time to build views.</summary>
        public FactionsViewModel()
        {

        }

        public FactionsViewModel(IHandleCommands<CreateTeamCommand> createTeamCommandHandler)
        {
            Items = new ObservableCollection<FactionsFactionViewModel>();

            Selected = new Command(async e => await SelectedExecuted(e as FactionsFactionViewModel));

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
                .ForEach(i => Items.Add(new FactionsFactionViewModel(i.Id, i.Name)));
        }
        
        public async Task SelectedExecuted(FactionsFactionViewModel faction)
        {
            _createTeamCommandHandler.Handle(new CreateTeamCommand(faction.Id));

            await KTApp.Navigation.PopModalAsync(true);

        }

        private readonly IHandleCommands<CreateTeamCommand> _createTeamCommandHandler;
    }
}
