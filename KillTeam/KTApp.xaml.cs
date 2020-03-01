using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KillTeam.Views;
using KillTeam.Services;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace KillTeam
{
    public partial class KTApp : Application
    {
        private const string SYNCFUSION_LICENSE = "MzIzNzhAMzEzNjJlMzMyZTMwS2VQY1lYdkNubDdzY09ySURNenlFK0hDQklsT0pNdmxPNXhsY0FPakFCbz0=";
        private const string ANDROID_SECRET = "6d5c2bed-d805-4345-904d-37da46738451";
        private const string IOS_SECRET = "656a7e6a-4297-44af-bb5e-3672dc169434";

        public static INavigation Navigation {
            get {
                return KTApp.Current.MainPage.Navigation;
            }
        }

        public KTApp()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(SYNCFUSION_LICENSE);
            if (Xamarin.Forms.Application.Current.Properties.ContainsKey("Language"))
            {
                string langue = (string)Xamarin.Forms.Application.Current.Properties["Language"];
                if (!string.IsNullOrEmpty(langue))
                {
                    TranslateExtension.Ci = new System.Globalization.CultureInfo(langue);
                    StringExtensions.Ci = new System.Globalization.CultureInfo(langue);
                }
            }
            MainPage = new NavigationPage(new ListEquipesPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts

            AppCenter.Start($"android={ANDROID_SECRET};ios={IOS_SECRET}", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
