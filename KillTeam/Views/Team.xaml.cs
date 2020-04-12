using System;
using KillTeam.Commands.Handlers;
using KillTeam.Controllers;
using KillTeam.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Team
    {
        public Team(string teamId)
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            var vm = new TeamController(ToolbarItems, teamId,
                new DeleteTeamCommandHandler(),
                new RenameTeamCommandHandler(),
                new DeleteMemberCommandHandler(),
                new ReorderMembersCommandHandler(),
                new ToggleRosterCommandHandler(),
                new ToggleMemberSelectedCommandHandler());
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            if (BindingContext is TeamController binding)
            {
                await binding.Refresh();
            }

            base.OnAppearing();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            if (!(BindingContext is TeamController binding)) return;

            var team = binding.Item;
            var answer = await DisplayAlert(Properties.Resources.Supprimer, Properties.Resources.EtesVousSur + " \"" + team.Name + "\" ?", Properties.Resources.Oui, Properties.Resources.Non);
            if (answer)
            {
                binding.Delete.Execute(null);
            }
        }

        private void SwitchSelected_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (!(BindingContext is TeamController binding)) return;
            if (!(((Switch)sender).BindingContext is TeamMemberViewModel member)) return;
            binding.SelectMember.Execute(member);
        }
    }
}