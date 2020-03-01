using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class KickStarter : ContentPage
	{
		public KickStarter ()
		{
			InitializeComponent ();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        private void Voir_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.kickstarter.com/projects/1237141124/myminireport-visual-battle-report?ref=killteamapp"));
        }

        private void NePlusAfficher_Clicked(object sender, EventArgs e)
        {
            Xamarin.Forms.Application.Current.Properties["SkipKickstarter"] = true;
            Navigation.PopModalAsync();
        }

        private void Continuer_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}