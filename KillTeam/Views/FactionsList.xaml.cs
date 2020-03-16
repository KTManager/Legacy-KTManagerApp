using KillTeam.Commands.Handlers;
using KillTeam.ViewModels;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FactionsList
    {
        public FactionsList()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            var vm = new Controllers.FactionsList(new CreateTeamCommandHandler());
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            if (BindingContext is Controllers.FactionsList binding)
            {
                await binding.Refresh();
            }

            base.OnAppearing();
        }
    }
}
