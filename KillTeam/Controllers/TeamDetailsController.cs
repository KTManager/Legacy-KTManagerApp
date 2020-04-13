using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KillTeam.Commands;
using KillTeam.Commands.Handlers;

using KillTeam.Services;
using KillTeam.ViewModels;
using KillTeam.Views;
using Microsoft.EntityFrameworkCore;
using Plugin.Share;
using Plugin.Share.Abstractions;
using Xamarin.Forms;

namespace KillTeam.Controllers
{
    public class TeamDetailsController : BindableObject
    {
        public BindableProperty ItemProperty = BindableProperty.Create(nameof(Item), typeof(TeamDetailsViewModel), typeof(TeamDetailsController));
        public TeamDetailsViewModel Item
        {
            get => (TeamDetailsViewModel)GetValue(ItemProperty);
            set => SetValue(ItemProperty, value);
        }

        public IList<ToolbarItem> ToolbarItems { get; private set; }

        public ICommand AddMember { get; private set; }
        public ICommand ReorderMembers { get; private set; }
        public ICommand OpenMember { get; private set; }
        public ICommand DeleteMember { get; private set; }
        public ICommand SelectMember { get; private set; }
        public ICommand EditName { get; private set; }
        public ICommand EditRoster { get; private set; }
        public ICommand Delete { get; private set; }

        private ToolbarItem _errors;

        public TeamDetailsController(IList<ToolbarItem> toolbarItems, string teamId,
            IHandleCommands<DeleteTeamCommand> deleteTeamCommandHandler,
            IHandleCommands<RenameTeamCommand> renameTeamCommandHandler,
            IHandleCommands<DeleteMemberCommand> deleteMemberCommandHandler,
            IHandleCommands<ReorderMembersCommand> reorderMembersCommandHandler,
            IHandleCommands<ToggleRosterCommand> toggleRosterCommandHandler,
            IHandleCommands<ToggleMemberSelectedCommand> toggleSelectedCommandHandler,
            IHandleCommands<DuplicateTeamCommand> duplicateTeamCommandHandler)
        {
            _itemId = teamId;

            InitializeCommands();
            InitializeToolbar(toolbarItems);

            _deleteMemberCommandHandler = deleteMemberCommandHandler;
            _toggleSelectedCommandHandler = toggleSelectedCommandHandler;
            _reorderMembersCommandHandler = reorderMembersCommandHandler;
            _toggleRosterCommandHandler = toggleRosterCommandHandler;
            _deleteTeamCommandHandler = deleteTeamCommandHandler;
            _renameTeamCommandHandler = renameTeamCommandHandler;
            _duplicateTeamCommandHandler = duplicateTeamCommandHandler;
        }

        private void InitializeToolbar(IList<ToolbarItem> toolbarItems)
        {
            ToolbarItems = toolbarItems;
            ToolbarItems.Add(new ToolbarItem
            {
                Text = Properties.Resources.PDF,
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(async () => await PdfExecuted())
            });
            ToolbarItems.Add(new ToolbarItem
            {
                Text = Properties.Resources.InGame,
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(async () => await InGameExecuted())
            });
            ToolbarItems.Add(new ToolbarItem
            {
                Text = Properties.Resources.Tactiques,
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(async () => await TacticsExecuted())
            });
            ToolbarItems.Add(new ToolbarItem
            {
                Text = Properties.Resources.Partager,
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(async () => await ShareExecuted())
            });
            ToolbarItems.Add(new ToolbarItem
            {
                Text = Properties.Resources.Dupliquer,
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(async () => await DuplicateExecuted())
            });

            _errors = new ToolbarItem
            {
                Text = Properties.Resources.Erreurs,
                Order = ToolbarItemOrder.Primary,
                Icon = "Ressources/drawable/danger.png",
                Command = new Command(async () => await ErrorsExecuted())
            };
        }

        private void InitializeCommands()
        {
            AddMember = new Command(async () => await AddMemberExecuted());
            ReorderMembers = new Command(ReorderMembersExecuted);
            OpenMember = new Command(async e => await OpenMemberExecuted(e as TeamDetailsMemberViewModel));
            DeleteMember = new Command(async e => await DeleteMemberExecuted(e as TeamDetailsMemberViewModel));
            SelectMember = new Command(async e => await SelectMemberExecuted(e as TeamDetailsMemberViewModel));
            EditName = new Command(async () => await EditNameExecuted());
            EditRoster = new Command(async () => await EditRosterExecuted());
            Delete = new Command(async () => await DeleteExecuted());
        }

        public async Task Refresh()
        {
            await UpdateItem();
        }

        private async Task UpdateItem()
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

            Item = new TeamDetailsViewModel(team.Id, team.Name, team.Cost, team.Faction.Name, team.Roster);
            team.Members.OrderBy(o => o.Position).ToList().ForEach(y => Item.Members.Add(new TeamDetailsMemberViewModel(y.Id, y.Name, y.Cost, y.ShortWeaponLevel, y.Selected)));

            UpdateErrors(team.Errors);
        }

        private async Task AddMemberExecuted()
        {
            await KTApp.Navigation.PushModalAsync(new Views.ModelsView(Item.Id));
            await Refresh();
        }

        private void ReorderMembersExecuted()
        {
            _reorderMembersCommandHandler.Handle(new ReorderMembersCommand(Item.Members.Select(x => x.Id).ToList()));
        }

        private async Task OpenMemberExecuted(TeamDetailsMemberViewModel member)
        {
            await KTApp.Navigation.PushAsync(new Views.MembrePage(member.Id));
        }

        private async Task DeleteMemberExecuted(TeamDetailsMemberViewModel member)
        {
            _deleteMemberCommandHandler.Handle(new DeleteMemberCommand(member.Id));
            await Refresh();
        }

        private async Task SelectMemberExecuted(TeamDetailsMemberViewModel member)
        {
            _toggleSelectedCommandHandler.Handle(new ToggleMemberSelectedCommand(member.Id, member.IsSelected));
            await UpdateTeamCost();
            await UpdateErrors();
        }

        private async Task EditNameExecuted()
        {
            _renameTeamCommandHandler.Handle(new RenameTeamCommand(Item.Id, Item.Name));
            await Refresh();
        }

        private async Task EditRosterExecuted()
        {
            _toggleRosterCommandHandler.Handle(new ToggleRosterCommand(Item.Id, Item.IsRoster));
            await UpdateTeamCost();
            await UpdateErrors();
        }

        private async Task ShareExecuted()
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
                Text = $"{team.GetSummary()}\n{Properties.Resources.PartageDepuis}",
                Url = "https://www.facebook.com/KillTeamManager"
            });
        }

        private async Task DuplicateExecuted()
        {

            _duplicateTeamCommandHandler.Handle(new DuplicateTeamCommand(Item.Id));
            await KTApp.Navigation.PushAsync(new Teams());
        }

        private async Task TacticsExecuted()
        {
            //await KTApp.Navigation.PushAsync(new Views.ListTactiquePage(Item.Id)); //TODO : UI/UX Rewriting. To reactivate !
        }

        private async Task PdfExecuted()
        {
            //await KTApp.Navigation.PushAsync(new Views.PdfChoices(Item.Id)); //TODO : UI/UX Rewriting. To reactivate !
        }

        private async Task InGameExecuted()
        {
            //await KTApp.Navigation.PushAsync(new Views.InGame(Item.Id)); //TODO : UI/UX Rewriting. To reactivate !
        }

        private async Task ErrorsExecuted()
        {
            await KTApp.Navigation.PushAsync(new Views.ListErreurPage(Item.Id));
        }

        private async Task UpdateTeamCost()
        {
            var team = await KTContext.Db.Teams
                .Where(e => e.Id == _itemId)
                .Include(e => e.Members)
                .FirstAsync();

            Item.Cost = team.Cost;
        }

        private async Task UpdateErrors()
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

            UpdateErrors(team.Errors);
        }

        private void UpdateErrors(List<string> errors)
        {
            Item.Errors = errors;

            if (Item.Errors.Count == 0)
            {
                ToolbarItems.Remove(_errors);
            }
            else if (!ToolbarItems.Contains(_errors))
            {
                ToolbarItems.Add(_errors);
            }
        }

        private async Task DeleteExecuted()
        {
            _deleteTeamCommandHandler.Handle(new DeleteTeamCommand(Item.Id));
            await KTApp.Navigation.PushAsync(new Teams());
        }

        private readonly string _itemId;
        private readonly IHandleCommands<DeleteMemberCommand> _deleteMemberCommandHandler;
        private readonly IHandleCommands<ToggleMemberSelectedCommand> _toggleSelectedCommandHandler;
        private readonly IHandleCommands<ReorderMembersCommand> _reorderMembersCommandHandler;
        private readonly IHandleCommands<ToggleRosterCommand> _toggleRosterCommandHandler;
        private readonly IHandleCommands<DeleteTeamCommand> _deleteTeamCommandHandler;
        private readonly IHandleCommands<RenameTeamCommand> _renameTeamCommandHandler;
        private readonly IHandleCommands<DuplicateTeamCommand> _duplicateTeamCommandHandler;
    }
}