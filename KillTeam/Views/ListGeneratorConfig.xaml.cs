using KillTeam.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListGeneratorConfig : ContentPage
    {
        public ListGeneratorConfig(string teamId)
        {
            var controller = new ListGeneratorConfigController(teamId);
            
            BindingContext = controller;
            
            InitializeComponent();
        }
    }
}