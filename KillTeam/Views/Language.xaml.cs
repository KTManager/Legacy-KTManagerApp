using KillTeam.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Language : ContentPage
	{
		public Language()
		{
			InitializeComponent();
            var vm = new Controllers.Language();
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            if (BindingContext is Controllers.Language binding)
            {
                await binding.Refresh();
            }

            base.OnAppearing();
        }
    }
}