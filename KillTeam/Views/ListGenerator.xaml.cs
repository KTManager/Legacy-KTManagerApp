using KillTeam.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListGenerator : ContentPage
    {
        public ListGenerator(string teamName, string teamList)
        {
            BindingContext = new ListGeneratorController(teamName, teamList);
            
            InitializeComponent();

            KtmListView.Source = new HtmlWebViewSource {Html = teamList};
        }
    }
}