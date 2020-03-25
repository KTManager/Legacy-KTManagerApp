using KillTeam.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WargearView
    {
        public WargearView(string profileId)
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            BindingContext = new WargearController(profileId);
        }

        protected override async void OnAppearing()
        {
            if (BindingContext is WargearController binding)
            {
                await binding.Refresh();
            }

            base.OnAppearing();
        }
    }
}