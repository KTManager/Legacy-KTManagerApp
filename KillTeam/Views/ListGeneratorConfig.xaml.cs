using KillTeam.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListGeneratorConfig : ContentPage
    {
        private readonly ListGeneratorConfigController _controller;
        public ListGeneratorConfig(string teamId)
        {
            BindingContext = _controller = new ListGeneratorConfigController(teamId);
            InitializeComponent();
        }
    }
}