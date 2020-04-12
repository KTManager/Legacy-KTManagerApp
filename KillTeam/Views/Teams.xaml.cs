using System;
using KillTeam.Commands.Handlers;
using KillTeam.Controllers;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Teams
    {
        public Teams()
        {
            try
            {
                InitializeComponent();
                On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

                BindingContext = new TeamsController(ToolbarItems, new DeleteTeamCommandHandler(), new ReorderTeamsCommandHandler());
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
                if (BindingContext is TeamsController binding)
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
    }
}