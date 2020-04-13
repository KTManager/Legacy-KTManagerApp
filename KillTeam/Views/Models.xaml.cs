using System;
using KillTeam.Commands.Handlers;
using KillTeam.Controllers;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Models
    {
        public Models(string teamId)
        {
            try
            {
                InitializeComponent();
                On<iOS>().SetUseSafeArea(true);

                BindingContext = new ModelsController(teamId, new CreateMemberCommandHandler());
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

                if (BindingContext is ModelsController binding)
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
