using KillTeam.Models;
using KillTeam.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChoixImpression : ContentPage
	{
        private string equipeId;
        public PdfConfiguration configPDF;
        private string pdfPath;

        public ChoixImpression (string equipeId)
		{
            this.equipeId = equipeId;
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (this.configPDF == null)
            {
                configPDF = new PdfConfiguration();
            }

            Team equipe = KTContext.Db.Teams
                .Where(e => e.Id == equipeId)
                .Include(e => e.Members)
                .ThenInclude(m => m.Specialist)
                .Include(e => e.Members)
                .ThenInclude(m => m.ModelProfile)
                .Include(e => e.Faction).First();

            Title = equipe.Name + " (" + equipe.Cost + ")";
            BindingContext = configPDF;
            BusyIndicator.IsVisible = false;
            PDFButton.IsVisible = true;
        }

        async void OnButtonPdfClicked(object sender, EventArgs e)
        {
            if (Xamarin.Forms.DependencyService.Get<ISave>().HasRight())
            {
                try
                {
                    configPDF.BusyIndicatorVisible = true;
                    configPDF.GenerateButtonVisible = false;
                    configPDF.OpenButtonVisible = false;
                    var t = new Thread(new ThreadStart(PDF));
                    t.Start();
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);
                    await DisplayAlert(Properties.Resources.Erreurs, ex.ToString(), "Ok");
                }
            }
            else
            {
                await DisplayAlert(Properties.Resources.Erreurs, Properties.Resources.DroitFichier, "Ok");
            }
        }
        
        public void PDF()
        {
            pdfPath = PdfGeneration.Generate(equipeId, configPDF);
            configPDF.BusyIndicatorVisible = false;
            configPDF.GenerateButtonVisible = true;
            if(pdfPath != null)
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    Xamarin.Forms.DependencyService.Get<ISave>().OpenPDF(pdfPath);
                }
                else
                {
                    configPDF.OpenButtonVisible = true;
                }
            }
        }

        void NoneOfficialPdfToggled(object sender, ToggledEventArgs e)
        {
            if(e.Value == true)
            {
                PdfOfficiel.IsToggled = false;
            }
        }

        void OfficialPdfToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                RegrouperAptitudes.IsToggled = false;
                DetailAptitudes.IsToggled = false;
                RegrouperIdentique.IsToggled = false;
                Tactiques.IsToggled = false;
                XPRecrueConvalescence.IsToggled = false;
            }
        }

        private void OpenButton_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(pdfPath))
                Xamarin.Forms.DependencyService.Get<ISave>().OpenPDF(pdfPath);
        }
    }
}