using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TacticsList : ContentPage
    {
        public TacticsList(string teamId)
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            var vm = new Controllers.TacticsList(teamId);
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            if (BindingContext is Controllers.TacticsList binding)
            {
                await binding.Refresh();
            }

            base.OnAppearing();
        }
    }
}
