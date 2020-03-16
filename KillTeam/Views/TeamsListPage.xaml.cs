using KillTeam.Commands.Handlers;
using KillTeam.ViewModels;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamsListPage
    {
        public TeamsListPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            var vm = new TeamsListViewModel(ToolbarItems, new DeleteTeamCommandHandler());
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            if (BindingContext is TeamsListViewModel binding)
            {
                await binding.Refresh();
            }

            base.OnAppearing();
        }
    }
}
