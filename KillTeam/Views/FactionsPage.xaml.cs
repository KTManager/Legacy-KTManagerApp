using KillTeam.Commands.Handlers;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using KillTeam.ViewModels;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FactionsPage
    {
        public FactionsPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            var vm = new FactionsViewModel(new CreateTeamCommandHandler());
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            if (BindingContext is FactionsViewModel binding)
            {
                await binding.Refresh();
            }

            base.OnAppearing();
        }
    }
}
