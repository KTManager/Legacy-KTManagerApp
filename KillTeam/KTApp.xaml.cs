using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KillTeam.Views;
using KillTeam.Services;

#if !DEBUG
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
#endif

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace KillTeam
{
    public partial class KTApp : Application
    {

#if !DEBUG
        private const string ANDROID_SECRET = "6d5c2bed-d805-4345-904d-37da46738451";
        private const string IOS_SECRET = "656a7e6a-4297-44af-bb5e-3672dc169434";
#endif
        public static INavigation Navigation => Current.MainPage.Navigation;

        public KTApp()
        {
            InitializeComponent();

            if (Current.Properties.ContainsKey("Language"))
            {
                var language = (string)Current.Properties["Language"];
                if (!string.IsNullOrEmpty(language))
                {
                    TranslateExtension.Ci = new System.Globalization.CultureInfo(language);
                    StringExtensions.Ci = new System.Globalization.CultureInfo(language);
                }
            }

            MainPage = new NavigationPage(new TeamsListPage()); // new DatabaseLoadPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts

#if !DEBUG
            AppCenter.Start($"android={ANDROID_SECRET};ios={IOS_SECRET}", typeof(Analytics), typeof(Crashes));
#endif
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
