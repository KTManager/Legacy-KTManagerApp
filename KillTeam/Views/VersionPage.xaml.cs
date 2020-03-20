using KillTeam.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VersionPage : ContentPage
    {
        public VersionPage()
        {
            InitializeComponent();

            BindingContext = new VersionPageViewModel();
        }
    }
}