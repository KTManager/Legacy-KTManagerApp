using System;
using KillTeam.Commands.Handlers;
using KillTeam.Controllers;
using KillTeam.ViewModels;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamDetails
    {
        public TeamDetails(string teamId)
        {
            try
            {
                InitializeComponent();
                On<iOS>().SetUseSafeArea(true);

                BindingContext = new TeamDetailsController(ToolbarItems, teamId,
                    new DeleteTeamCommandHandler(),
                    new RenameTeamCommandHandler(),
                    new DeleteMemberCommandHandler(),
                    new ReorderMembersCommandHandler(),
                    new ToggleRosterCommandHandler(),
                    new ToggleMemberSelectedCommandHandler());
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
                DisplayAlert("Error", "An error occured during the page loading.", "Ok");
            }
        }

        protected override async void OnAppearing()
        {
            try
            {

                if (BindingContext is TeamDetailsController binding)
                {
                    await binding.Refresh();
                }

                base.OnAppearing();
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
                await DisplayAlert("Error", "An error occured during the data loading.", "Ok");
            }
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {

                if (!(BindingContext is TeamDetailsController binding)) return;

                var team = binding.Item;
                var answer = await DisplayAlert(Properties.Resources.Supprimer, Properties.Resources.EtesVousSur + " \"" + team.Name + "\" ?", Properties.Resources.Oui, Properties.Resources.Non);
                if (answer)
                {
                    binding.Delete.Execute(null);
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                await DisplayAlert("Error", "An error occured during the deletion.", "Ok");
            }
        }

        private void SwitchSelected_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            try
            {

                if (!(BindingContext is TeamDetailsController binding)) return;
                if (!(((Switch)sender).BindingContext is TeamDetailsMemberViewModel member)) return;
                binding.SelectMember.Execute(member);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                DisplayAlert("Error", "An error occured during the edition.", "Ok");
            }
        }
    }
}