using KillTeam.Commands.Handlers;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModelsView
    {
        public ModelsView(string teamId)
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            BindingContext = new Controllers.ModelsController(teamId, new CreateMemberCommandHandler());
        }

        protected override async void OnAppearing()
        {
            if (BindingContext is Controllers.ModelsController binding)
            {
                await binding.Refresh();
            }

            base.OnAppearing();
        }
    }
}
