using KillTeam.Commands.Handlers;
using KillTeam.Controllers;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Teams
    {
        public Teams()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            var vm = new TeamsController(ToolbarItems, new DeleteTeamCommandHandler(), new ReorderTeamsCommandHandler());
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            if (BindingContext is TeamsController binding)
            {
                await binding.Refresh();
            }

            base.OnAppearing();
        }
    }
}