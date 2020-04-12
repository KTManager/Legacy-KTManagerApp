using KillTeam.Services;
using KillTeam.Views;
using System.ComponentModel;
using Xamarin.Forms;

namespace KillTeam.ViewModels
{
    public class LanguageViewModel : INotifyPropertyChanged
    {
        public bool German
        {
            get
            {
                bool german = false;
                if (TranslateExtension.Ci.TwoLetterISOLanguageName == "de")
                {
                    german = true;
                }
                return german;
            }
            set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("German"));
                if (value)
                {
                    French = false;
                    English = false;
                    ChangeLanguage("de");
                }
            }
        }

        public bool English
        {
            get
            {
                bool english = false;
                if (TranslateExtension.Ci.TwoLetterISOLanguageName == "en")
                {
                    english = true;
                }
                return english;
            }
            set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("English"));
                if (value)
                {
                    French = false;
                    //German = false;
                    ChangeLanguage("en");
                }
            }
        }

        public bool French
        {
            get
            {
                bool french = false;
                if (TranslateExtension.Ci.TwoLetterISOLanguageName == "fr")
                {
                    french = true;
                }
                return french;
            }
            set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("French"));
                if (value)
                {
                    English = false;
                    //German = false;
                    ChangeLanguage("fr");
                }
            }
        }

        public void ChangeLanguage(string langue)
        {
            if(TranslateExtension.Ci.TwoLetterISOLanguageName != langue)
            {
                Xamarin.Forms.Application.Current.Properties["Language"] = langue;
                TranslateExtension.Ci = new System.Globalization.CultureInfo(langue);
                StringExtensions.Ci = new System.Globalization.CultureInfo(langue);
                Page mainPage = new NavigationPage(new Teams());
                Application.Current.MainPage = mainPage;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
