using System;
using Syncfusion.ListView.XForms;
using KillTeam.Commands.Handlers;

using KillTeam.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamView
    {
        public TeamView(string teamId)
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            BindingContext = new Controllers.TeamController(ToolbarItems, teamId,
                new DeleteTeamCommandHandler(),
                new RenameTeamCommandHandler(),
                new DeleteMemberCommandHandler(),
                new ReorderMembersCommandHandler(),
                new ToggleRosterCommandHandler(),
                new ToggleMemberSelectedCommandHandler());
        }

        protected override async void OnAppearing()
        {
            if (BindingContext is Controllers.TeamController binding)
            {
                await binding.Refresh();
            }

            base.OnAppearing();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            if (!(BindingContext is Controllers.TeamController binding)) return;

            var team = binding.Item;
            var answer = await DisplayAlert(Properties.Resources.Supprimer, Properties.Resources.EtesVousSur + " \"" + team.Name + "\" ?", Properties.Resources.Oui, Properties.Resources.Non);
            if (answer)
            {
                binding.Delete.Execute(null);
            }
        }

        private void SelectedSwitchToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (!(BindingContext is Controllers.TeamController binding)) return;
            if (!(((Switch)sender).BindingContext is TeamMemberViewModel member)) return;
            binding.SelectMember.Execute(member);
        }

        private async void MembresListView_ItemDragging(object sender, ItemDraggingEventArgs e)
        {
            if (e.Action != DragAction.Drop || e.ItemData == null) return;

            if (!(BindingContext is Controllers.TeamController binding)) return;

            var member = e.ItemData as TeamMemberViewModel;
            var members = binding.Item.Members;
            
            members.Move(members.IndexOf(member), e.NewIndex);

            binding.ReorderMembers.Execute(null);
        }
    }
}