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
            
            var vm = new TeamsListViewModel(ToolbarItems, deleteTeamCommandHandler);
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            var binding = this.BindingContext as TeamsListViewModel;
            if (binding != null)
            {
                await binding.Refresh();
            }

            base.OnAppearing();
        }
    }
}
