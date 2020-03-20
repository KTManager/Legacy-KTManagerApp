using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KillTeam.Views;
using KillTeam.Services;

#if !DEBUG
using KillTeam.Themes;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
#endif
using Xamarin.Essentials;

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

            MainPage = new NavigationPage(new DatabaseLoadPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            var theme = DependencyService.Get<IEnvironment>().GetOperatingSystemTheme();

            SetTheme(theme);

#if !DEBUG
            AppCenter.Start($"android={ANDROID_SECRET};ios={IOS_SECRET}", typeof(Analytics), typeof(Crashes));
#endif
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            var theme = DependencyService.Get<IEnvironment>().GetOperatingSystemTheme();

            SetTheme(theme);
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        
        void SetTheme(Theme theme)
        {
            var mergedDictionaries = Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                switch (theme)
                {
                    case Theme.Dark:
                        mergedDictionaries.Add(new DarkTheme());
                        break;
                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
            }
        }
    }
}
