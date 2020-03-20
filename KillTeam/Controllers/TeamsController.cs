using System.Collections.Generic;
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
    public class TeamsController
    {
        public ObservableCollection<TeamsViewModel> Items { get; }
        public IList<ToolbarItem> ToolbarItems { get; private set; }

        public ICommand AddTeam { get; private set; }
        public ICommand ReorderTeam { get; private set; }
        public ICommand OpenTeam { get; private set; }
        public ICommand DeleteTeam { get; private set; }

        public TeamsController(IList<ToolbarItem> toolbarItems,
            IHandleCommands<DeleteTeamCommand> deleteTeamCommandHandler,
            IHandleCommands<ReorderTeamsCommand> reorderTeamsCommandHandler)
        {
            Items = new ObservableCollection<TeamsViewModel>();

            InitializeCommands();
            InitializeToolbar(toolbarItems);

            _reorderTeamsCommandHandler = reorderTeamsCommandHandler;
            _deleteTeamCommandHandler = deleteTeamCommandHandler;
        }

        public async Task Refresh()
        {
            await UpdateItems();
        }

        private void InitializeToolbar(IList<ToolbarItem> toolbarItems)
        {
            ToolbarItems = toolbarItems;
            ToolbarItems.Add(new ToolbarItem
            {
                Text = Properties.Resources.Language,
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(async () => await LanguageExecuted())
            });
            ToolbarItems.Add(new ToolbarItem
            {
                Text = Properties.Resources.Remerciement,
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(async () => await CreditsExecuted())
            });
            ToolbarItems.Add(new ToolbarItem
            {
                Text = "Version",
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(async () => await VersionExecuted())
            });
        }

        private void InitializeCommands()
        {
            AddTeam = new Command(AddTeamExecuted);
            ReorderTeam = new Command(ReorderTeamExecuted);
            OpenTeam = new Command(async e => await OpenTeamExecuted(e as TeamsViewModel));
            DeleteTeam = new Command(async e => await DeleteExecuted(e as TeamsViewModel));

        }

        private async Task UpdateItems()
        {
            Items.Clear();
            var teams = await KTContext.Db.Teams
                                    .Include(e => e.Faction)
                                    .Include(e => e.Members)
                                    .AsNoTracking()
                                    .OrderBy(post => post.Position)
                                    .ToListAsync();
            teams.ForEach(i => Items.Add(new TeamsViewModel(i.Id, i.Name, i.Cost, i.FactionNameAndMembersCount)));
        }

        private void AddTeamExecuted()
        {
            KTApp.Navigation.PushModalAsync(new Views.FactionsView());
        }

        private void ReorderTeamExecuted()
        {
            _reorderTeamsCommandHandler.Handle(new ReorderTeamsCommand(Items.Select(x => x.Id).ToList()));
        }

        private async Task OpenTeamExecuted(TeamsViewModel team)
        {
            await KTApp.Navigation.PushAsync(new Views.TeamView(team.Id));
        }

        private async Task DeleteExecuted(TeamsViewModel team)
        {
            _deleteTeamCommandHandler.Handle(new DeleteTeamCommand(team.Id));

            await Refresh();
        }

        private async Task LanguageExecuted()
        {
            await KTApp.Navigation.PushAsync(new Views.LanguagePage());
        }

        private async Task CreditsExecuted()
        {
            await KTApp.Navigation.PushAsync(new Views.RemerciementPage());
        }

        private async Task VersionExecuted()
        {
            await KTApp.Navigation.PushAsync(new Views.VersionPage());
        }

        private readonly IHandleCommands<ReorderTeamsCommand> _reorderTeamsCommandHandler;
        private readonly IHandleCommands<DeleteTeamCommand> _deleteTeamCommandHandler;
    }
}
