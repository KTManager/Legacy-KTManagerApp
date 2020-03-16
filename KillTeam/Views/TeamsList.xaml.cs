using KillTeam.Commands.Handlers;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamsList
    {
        public TeamsList()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            var vm = new Controllers.TeamsList(ToolbarItems, new DeleteTeamCommandHandler());
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            if (BindingContext is Controllers.TeamsList binding)
            {
                await binding.Refresh();
            }

            base.OnAppearing();
        }
    }
}
