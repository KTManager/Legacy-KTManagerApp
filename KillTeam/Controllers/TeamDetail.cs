using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using KillTeam.Annotations;
using KillTeam.Commands;
using KillTeam.Commands.Handlers;
using KillTeam.Properties;
using KillTeam.Services;
using KillTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace KillTeam.Controllers
{
    public class TeamDetail : INotifyPropertyChanged
    {
        public TeamDetailTeamViewModel Item
        {
            get => _item;
            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }

        public IList<ToolbarItem> ToolbarItems { get; set; }

        public ICommand AddMember { get; set; }
        public ICommand EditName { get; set; }
        public ICommand Delete { get; set; }
        public ICommand Pdf { get; set; }
        public ICommand InGame { get; set; }
        public ICommand Tactics { get; set; }
        public ICommand Share { get; set; }
        public ICommand Duplicates { get; set; }


        public ToolbarItem ButtonPdf;
        public ToolbarItem ButtonInGame;
        public ToolbarItem ButtonTactics;
        public ToolbarItem ButtonShare;
        public ToolbarItem ButtonDuplicates;

#if DEBUG
        public TeamDetail() { }
#endif

        public TeamDetail(IList<ToolbarItem> toolbarItems, string teamId, IHandleCommands<DeleteTeamCommand> deleteTeamCommandHandler, IHandleCommands<RenameTeamCommand> renameTeamCommandHandler)
        {
            _itemId = teamId;

            AddMember = new Command(AddMemberExecuted);
            EditName = new Command(async () => await EditNameExecuted());
            Delete = new Command(async () => await DeleteExecuted());

            ButtonPdf = new ToolbarItem
            {
                Text = Resources.PDF,
                Order = ToolbarItemOrder.Secondary
            };

            ButtonInGame = new ToolbarItem
            {
                Text = Resources.InGame,
                Order = ToolbarItemOrder.Secondary,
            };

            ButtonTactics = new ToolbarItem
            {
                Text = Resources.Tactiques,
                Order = ToolbarItemOrder.Secondary
            };

            ButtonShare = new ToolbarItem
            {
                Text = Resources.Partager,
                Order = ToolbarItemOrder.Secondary
            };

            ButtonDuplicates = new ToolbarItem
            {
                Text = Resources.Dupliquer,
                Order = ToolbarItemOrder.Secondary
            };

            ToolbarItems = toolbarItems;
            ToolbarItems.Add(ButtonPdf);
            ToolbarItems.Add(ButtonInGame);
            ToolbarItems.Add(ButtonTactics);
            ToolbarItems.Add(ButtonShare);
            ToolbarItems.Add(ButtonDuplicates);

            _deleteTeamCommandHandler = deleteTeamCommandHandler;
            _renameTeamCommandHandler = renameTeamCommandHandler;
        }

        public async Task Refresh()
        {
            await UpdateItem();
        }

        public async Task UpdateItem()
        {
            var team = await KTContext.Db.Teams
                .Where(e => e.Id == _itemId)
                .Include(e => e.Members)
                .ThenInclude(m => m.Specialist)
                .Include(e => e.Members)
                .ThenInclude(m => m.ModelProfile.Model.ModelWeapons)
                .ThenInclude(fa => fa.Weapon)
                .Include(e => e.Members)
                .ThenInclude(m => m.ModelProfile.ModelProfileWeapons)
                .ThenInclude(da => da.Weapon)
                .Include(e => e.Members)
                .ThenInclude(m => m.MemberWeapons)
                .ThenInclude(m => m.Weapon)
                .ThenInclude(a => a.WeaponProfiles)
                .ThenInclude(a => a.WeaponType)
                .Include(e => e.Members)
                .ThenInclude(m => m.MemberWarGearOptions)
                .ThenInclude(mr => mr.WarGearOption)
                .Include(e => e.Faction)
                .FirstAsync();

            Item = new TeamDetailTeamViewModel(team.Id, team.Name, team.Cost, team.Faction.Name, team.Roster);
            team.Members.OrderBy(o => o.Name).ToList().ForEach(y => Item.Members.Add(new TeamDetailMemberViewModel(y.Id, y.Name, y.Cost, y.ShortWeaponLevel)));
        }

        private void AddMemberExecuted()
        {
            KTApp.Navigation.PushModalAsync(new Views.ModelsList(Item.Id));
        }

        public async Task EditNameExecuted()
        {
            _renameTeamCommandHandler.Handle(new RenameTeamCommand(Item.Id, Item.Name));
            await Refresh();
        }

        public async Task DeleteExecuted()
        {
            _deleteTeamCommandHandler.Handle(new DeleteTeamCommand(Item.Id));
            await KTApp.Navigation.PushAsync(new Views.TeamsList());
        }

        private string _itemId;
        private readonly IHandleCommands<DeleteTeamCommand> _deleteTeamCommandHandler;
        private readonly IHandleCommands<RenameTeamCommand> _renameTeamCommandHandler;
        private TeamDetailTeamViewModel _item;
        public event PropertyChangedEventHandler PropertyChanged;


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
