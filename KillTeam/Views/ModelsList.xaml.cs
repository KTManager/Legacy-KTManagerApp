using KillTeam.Commands.Handlers;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModelsList : ContentPage
    {
        public ModelsList(string teamId)
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            var vm = new Controllers.ModelsList(teamId, new CreateMemberCommandHandler());
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            if (BindingContext is Controllers.ModelsList binding)
            {
                await binding.Refresh();
            }

            base.OnAppearing();
        }
    }
}
