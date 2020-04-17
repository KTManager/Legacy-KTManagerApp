using System;
using KillTeam.Services;
using KillTeam.Templates;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AbilityCell
	{
		public AbilityCell ()
		{
			InitializeComponent ();
		}
		
		async void GeneratePdf(object sender, EventArgs args)
		{
			// New up the Razor template
			
			var printTemplate = new KillTeamManagerPdf();
 
			// Set the model property (ViewModel is a custom property within containing view - FYI)
			// printTemplate.Model = ViewModel.ezPrints.ToList();
 
			// Generate the HTML
			var htmlString = printTemplate.GenerateString();
 
			// Create a source for the webview
			var htmlSource = new HtmlWebViewSource {Html = htmlString};

			// Create and populate the Xamarin.Forms.WebView
			var browser = new WebView {Source = htmlSource};
			
			var printService = DependencyService.Get<IPrintService>();
			printService.Print(browser);
		}
	}
}