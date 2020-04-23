using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListGenerator : ContentPage
    {
        public ListGenerator(string teamList)
        {
            InitializeComponent();

            KtmListView.Source = new HtmlWebViewSource {Html = teamList};
        }
    }
}