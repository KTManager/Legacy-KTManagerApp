using KillTeam.Commands.Handlers;
using KillTeam.Controllers;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamsView
    {
        public TeamsView()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            BindingContext = new TeamsController(ToolbarItems, new DeleteTeamCommandHandler(), new ReorderTeamsCommandHandler());
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
