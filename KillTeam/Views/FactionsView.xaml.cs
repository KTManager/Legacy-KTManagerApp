using KillTeam.Commands.Handlers;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FactionsView
    {
        public FactionsView()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            var vm = new Controllers.FactionsController(new CreateTeamCommandHandler());
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            if (BindingContext is Controllers.FactionsController binding)
            {
                await binding.Refresh();
            }

            base.OnAppearing();
        }
    }
}
