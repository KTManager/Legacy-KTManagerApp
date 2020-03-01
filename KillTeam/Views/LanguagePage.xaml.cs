using KillTeam.Resx;
using KillTeam.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LanguagePage : ContentPage
	{
        LanguageViewModel languageViewModel;

		public LanguagePage ()
		{
			InitializeComponent();
            languageViewModel = new LanguageViewModel();
            BindingContext = languageViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Title = Translate.Language;
        }
    }
}