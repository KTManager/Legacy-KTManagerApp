using KillTeam.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PsychiqueView : ContentView
	{
		public PsychiqueView()
		{
			InitializeComponent ();
        }

        protected override void OnBindingContextChanged()
        {
            Psychic psychique = BindingContext as Psychic;
            if (psychique == null)
                return;
            Nom.Text = psychique.Name;
            Description.Text = psychique.Description;
            Charge.Text = psychique.WarpCharge.ToString();
        }
    }
}