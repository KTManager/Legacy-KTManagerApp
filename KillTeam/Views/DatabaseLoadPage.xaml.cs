using KillTeam.Services;
using KillTeam.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatabaseLoadPage : ContentPage
    {
        public DatabaseLoadPage()
        {
            InitializeComponent();

            BindingContext = new DatabaseLoadViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            bool showModal = KTContext.ShouldShowLegacyImportModal();
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (showModal)
                {
                    bool result = await Application.Current.MainPage.DisplayAlert(
                        "Which Version?",
                        "There was a bug in v2.1.4 that lost teams before that. Would you like to restore your teams from before, or keep the new ones you made in 2.1.4?",
                        "Use Old Teams",
                        "Keep Teams from v2.1.4"
                    );
                    if (result)
                    {
                        // deleting the old user db before we start the DBUpdater will cause it to fall back to the LegacyDB
                        File.Delete(KTContext.DBPath);
                    }
                }

                (BindingContext as DatabaseLoadViewModel).StartUpdate();
            });
        }

    }
}