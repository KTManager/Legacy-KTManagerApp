using KillTeam.Commands.Handlers;
using KillTeam.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamsListPage : ContentPage
    {
        public TeamsListPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            var deleteTeamCommandHandler = new DeleteTeamCommandHandler();
            
            var ctr = new TeamsListViewModel(ToolbarItems, deleteTeamCommandHandler);
            BindingContext = ctr;
        }

        protected async override void OnAppearing()
        {
            if (this.BindingContext is TeamsListViewModel binding)
            {
                await binding.Refresh();
            }

            base.OnAppearing();
        }
    }
}
