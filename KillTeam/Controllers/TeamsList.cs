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
using KillTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace KillTeam.Controllers
{
    public class TeamsList
    {
        public ObservableCollection<TeamsListTeamViewModel> Items { get; set; }
        public IList<ToolbarItem> ToolbarItems { get; set; }
        public ICommand Sync { get; set; }
        public ICommand Logout { get; set; }
        public ICommand Language { get; set; }
        public ICommand Credits { get; set; }
        public ICommand AddTeam { get; set; }
        public ICommand Delete { get; set; }
        public ICommand OpenTeam { get; set; }

        public ToolbarItem ButtonSync;
        public ToolbarItem ButtonDeco;
        public ToolbarItem ButtonLang;
        public ToolbarItem ButtonCredits;

#if DEBUG
        public TeamsList() { }
#endif

        public TeamsList(IList<ToolbarItem> toolbarItems, IHandleCommands<DeleteTeamCommand> deleteTeamCommandHandler)
        {
            Items = new ObservableCollection<TeamsListTeamViewModel>();
            AddTeam = new Command(() => AddTeamExecuted());
            Credits = new Command(async () => await CreditsExecuted());
            Language = new Command(async () => await LanguageExecuted());
            Logout = new Command(() => LogoutExecuted());
            Sync = new Command(async () => await SyncExecuted());
            OpenTeam = new Command(async e => await OpenTeamExecuted(e as TeamsListTeamViewModel));
            Delete = new Command(async e => await DeleteExecuted(e as TeamsListTeamViewModel));

            ButtonSync = new ToolbarItem
            {
                Text = Resources.Synchro,
                Order = ToolbarItemOrder.Secondary,
                Command = Sync
            };
            
            ButtonDeco = new ToolbarItem
            {
                Text = Resources.Deconnection,
                Order = ToolbarItemOrder.Secondary,
                Command = Logout
            };
            
            ButtonLang = new ToolbarItem
            {
                Text = Resources.Language,
                Order = ToolbarItemOrder.Secondary,
                Command = Language
            };
            
            ButtonCredits = new ToolbarItem
            {
                Text = Resources.Remerciement,
                Order = ToolbarItemOrder.Secondary,
                Command = Credits
            };

            ToolbarItems = toolbarItems;
            ToolbarItems.Add(ButtonSync);
            ToolbarItems.Add(ButtonDeco);
            ToolbarItems.Add(ButtonLang);
            ToolbarItems.Add(ButtonCredits);

            _deleteTeamCommandHandler = deleteTeamCommandHandler;
        }

        public async Task OpenTeamExecuted(TeamsListTeamViewModel team)
        {
            await KTApp.Navigation.PushAsync(new Views.TeamDetail(team.Id));
        }

        public async Task Refresh()
        {
            if (Device.RuntimePlatform != Device.Android)
            {
                ToolbarItems.Remove(ButtonDeco);
                ToolbarItems.Remove(ButtonSync);
                
                await UpdateItems();

                return;
            }

            if (Sauvegarde.IsConnected() && await Sauvegarde.Synchro(KTContext.Db))
            {
                await UpdateItems();
            }

            DecoUpdate();

            await UpdateItems();
        }

        private void DecoUpdate()
        {
            if (!Sauvegarde.IsConnected())
            {
                ToolbarItems.Remove(ButtonDeco);
            }
            else if (!ToolbarItems.Contains(ButtonDeco))
            {
                ToolbarItems.Add(ButtonDeco);
            }
        }

        public async Task UpdateItems()
        {
            Items.Clear();
            var teams = await KTContext.Db.Teams
                                    .Include(e => e.Faction)
                                    .Include(e => e.Members)
                                    .AsNoTracking()
                                    .OrderBy(post => post.Position)
                                    .ToListAsync();
            teams.ForEach(i => Items.Add(new TeamsListTeamViewModel(i.Id, i.Name, i.Cost, i.FactionNameAndMembersCount)));
        }

        public void AddTeamExecuted()
        {
            KTApp.Navigation.PushModalAsync(new Views.FactionsList());
        }

        public void LogoutExecuted()
        {
            Sauvegarde.Logout();
            DecoUpdate();
        }

        public async Task SyncExecuted()
        {
            Sauvegarde.Login();
            if (await Sauvegarde.Synchro(KTContext.Db))
            {
                await UpdateItems();
            }
            DecoUpdate();
        }

        public async Task LanguageExecuted()
        {
            await KTApp.Navigation.PushAsync(new Views.Language());
        }

        public async Task CreditsExecuted()
        {
            await KTApp.Navigation.PushAsync(new Views.Credits());
        }

        public async Task DeleteExecuted(TeamsListTeamViewModel team)
        {
            _deleteTeamCommandHandler.Handle(new DeleteTeamCommand(team.Id));   

            await UpdateItems();
        }

        private readonly IHandleCommands<DeleteTeamCommand> _deleteTeamCommandHandler;
    }
}
