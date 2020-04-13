using KillTeam.Services;
using KillTeam.Views;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;

namespace KillTeam.ViewModels
{
    public class LanguageViewModel : INotifyPropertyChanged
    {
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;
        public bool German
        {
            get => Equals(currentCulture, CultureInfo.GetCultureInfo("de-DE"));
            set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("German"));
                if (value && !Equals(CultureInfo.CurrentUICulture, CultureInfo.GetCultureInfo("de-DE")))
                {
                    French = false;
                    ChangeLanguage("de-DE");
                }
            }
        }

        public bool French
        {
            get
            {
                return currentCulture.Name == "fr-FR";
            }
            set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("French"));
                if (value && !Equals(CultureInfo.CurrentUICulture, CultureInfo.GetCultureInfo("fr-FR")))
                {
                    German = false;
                    ChangeLanguage("fr-FR");
                }
            }
        }

        public bool English
        {
            get => !German && !French;
            set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("English"));
                if (value && !Equals(CultureInfo.CurrentUICulture, CultureInfo.GetCultureInfo("en-US")))
                {
                    French = false;
                    German = false;
                    ChangeLanguage("en-US");
                }
            }
        }

        public async void ChangeLanguage(string langue)
        {
            var culture = CultureInfo.GetCultureInfo(langue);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            Application.Current.Properties["Language"] = langue;
            await Application.Current.SavePropertiesAsync();

            Page mainPage = new NavigationPage(new Teams());
            Application.Current.MainPage = mainPage;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
