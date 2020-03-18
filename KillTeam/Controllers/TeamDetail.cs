using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KillTeam.Commands;
using KillTeam.Commands.Handlers;
using KillTeam.Properties;
using KillTeam.Services;
using KillTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using Plugin.Share;
using Plugin.Share.Abstractions;
using Xamarin.Forms;

namespace KillTeam.Controllers
{
    public class TeamDetail : BindableObject
    {
        public BindableProperty ItemProperty = BindableProperty.Create(nameof(Item), typeof(TeamDetailTeamViewModel), typeof(TeamDetail));
        public TeamDetailTeamViewModel Item
        {
            get => (TeamDetailTeamViewModel)GetValue(ItemProperty);
            set => SetValue(ItemProperty, value);
        }

        public IList<ToolbarItem> ToolbarItems { get; set; }

        public ICommand AddMember { get; set; }
        public ICommand DeleteMember { get; set; }
        public ICommand ToggleSelected { get; set; }
        public ICommand ReorderMembers { get; set; }
        public ICommand EditName { get; set; }
        public ICommand ToggleRoster { get; set; }
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

        public TeamDetail(IList<ToolbarItem> toolbarItems, string teamId, 
            IHandleCommands<DeleteTeamCommand> deleteTeamCommandHandler, 
            IHandleCommands<RenameTeamCommand> renameTeamCommandHandler,
            IHandleCommands<DeleteMemberCommand> deleteMemberCommandHandler,
            IHandleCommands<ReorderMembersCommand> reorderMembersCommandHandler,
            IHandleCommands<ToggleRosterCommand> toggleRosterCommandHandler,
            IHandleCommands<ToggleMemberSelectedCommand> toggleSelectedCommandHandler)
        {
            _itemId = teamId;

            AddMember = new Command(AddMemberExecuted);
            DeleteMember = new Command(async e => await DeleteMemberExecuted(e as TeamDetailMemberViewModel));
            ReorderMembers = new Command(ReorderMembersExecuted);
            EditName = new Command(async () => await EditNameExecuted());
            ToggleRoster = new Command(async () => await ToggleRosterExecuted());
            ToggleSelected = new Command(async e => await ToggleSelectedExecuted(e as TeamDetailMemberViewModel));
            Delete = new Command(async () => await DeleteExecuted());

            Share = new Command(async () => await ShareExecuted());

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
                Order = ToolbarItemOrder.Secondary,
                Command = Share
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

            _deleteMemberCommandHandler = deleteMemberCommandHandler;
            _toggleSelectedCommandHandler = toggleSelectedCommandHandler;
            _reorderMembersCommandHandler = reorderMembersCommandHandler;
            _toggleRosterCommandHandler = toggleRosterCommandHandler;
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
            team.Members.OrderBy(o => o.Position).ToList().ForEach(y => Item.Members.Add(new TeamDetailMemberViewModel(y.Id, y.Name, y.Cost, y.ShortWeaponLevel, y.Selected)));
        }

        private void AddMemberExecuted()
        {
            KTApp.Navigation.PushModalAsync(new Views.ModelsList(Item.Id));
        }

        public async Task DeleteMemberExecuted(TeamDetailMemberViewModel member)
        {
            _deleteMemberCommandHandler.Handle(new DeleteMemberCommand(member.Id));
            await Refresh();
        }

        public async Task ToggleSelectedExecuted(TeamDetailMemberViewModel member)
        {
            _toggleSelectedCommandHandler.Handle(new ToggleMemberSelectedCommand(member.Id, member.IsSelected));
            await UpdateTeamCost();
        }

        public void ReorderMembersExecuted()
        {
            _reorderMembersCommandHandler.Handle(new ReorderMembersCommand(Item.Members.Select(x => x.Id).ToList()));
        }

        public async Task EditNameExecuted()
        {
            _renameTeamCommandHandler.Handle(new RenameTeamCommand(Item.Id, Item.Name));
            await Refresh();
        }

        public async Task ToggleRosterExecuted()
        {
            _toggleRosterCommandHandler.Handle(new ToggleRosterCommand(Item.Id, Item.IsRoster));
            await UpdateTeamCost();
        }

        public async Task ShareExecuted()
        {
            var team = KTContext.Db.Teams
                .Where(e => e.Id == Item.Id)
                .Include(e => e.Members)
                .ThenInclude(m => m.Specialist)
                .Include(e => e.Members)
                .ThenInclude(m => m.ModelProfile)
                .Include(e => e.Members)
                .ThenInclude(m => m.MemberWeapons)
                .ThenInclude(m => m.Weapon)
                .Include(e => e.Faction).First();

            await CrossShare.Current.Share(new ShareMessage
            {
                Text = $"{team.GetSummary()}\n{Resources.PartageDepuis}",
                Url = "https://www.facebook.com/KillTeamManager"
            });
        }

        private async Task UpdateTeamCost()
        {
            var team = await KTContext.Db.Teams
                .Where(e => e.Id == _itemId)
                .Include(e => e.Members)
                .FirstAsync();

            Item.Cost = team.Cost;
        }

        public async Task DeleteExecuted()
        {
            _deleteTeamCommandHandler.Handle(new DeleteTeamCommand(Item.Id));
            await KTApp.Navigation.PushAsync(new Views.TeamsList());
        }

        private string _itemId;
        private readonly IHandleCommands<DeleteMemberCommand> _deleteMemberCommandHandler;
        private readonly IHandleCommands<ToggleMemberSelectedCommand> _toggleSelectedCommandHandler;
        private readonly IHandleCommands<ReorderMembersCommand> _reorderMembersCommandHandler;
        private readonly IHandleCommands<ToggleRosterCommand> _toggleRosterCommandHandler;
        private readonly IHandleCommands<DeleteTeamCommand> _deleteTeamCommandHandler;
        private readonly IHandleCommands<RenameTeamCommand> _renameTeamCommandHandler;
        private TeamDetailTeamViewModel _item;
    }
}
