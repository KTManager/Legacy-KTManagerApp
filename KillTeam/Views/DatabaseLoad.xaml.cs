using KillTeam.Services;
using KillTeam.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatabaseLoad
    {
        public DatabaseLoad()
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
                    var title = Equals(CultureInfo.CurrentCulture, CultureInfo.GetCultureInfo("fr-FR"))
                        ? "Quelle version ?"
                        : "Which Version?";

                    var message = Equals(CultureInfo.CurrentCulture, CultureInfo.GetCultureInfo("fr-FR"))
                        ? "La mise à jour 2.1.4 a pu provoqué la suppression de vos équipes. Souhaitez-vous les récupérer, ou utiliser celle que vous avez créé dans la version 2.1.4 ?"
                        : "There was a bug in v2.1.4 that lost teams before that. Would you like to restore your teams from before, or keep the new ones you made in 2.1.4?";

                    var accept = Equals(CultureInfo.CurrentCulture, CultureInfo.GetCultureInfo("fr-FR"))
                        ? "Récupérer mes anciennes équipes"
                        : "Use Old Teams";

                    var cancel = Equals(CultureInfo.CurrentCulture, CultureInfo.GetCultureInfo("fr-FR"))
                        ? "Garder mes équipes v2.1.4"
                        : "Keep Teams from v2.1.4";

                    bool result = await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
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