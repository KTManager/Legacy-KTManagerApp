using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using KillTeam.Services;
using KillTeam.ViewModels;
using Xamarin.Forms;

namespace KillTeam.Controllers
{
    public class Language : INotifyPropertyChanged
    {
        public ObservableCollection<LanguageViewModel> Items { get; set; }

        public ICommand ChangeLanguage { get; set; }

        public Language()
        {
            Items = new ObservableCollection<LanguageViewModel>();
            ChangeLanguage = new Command(e => ChangeLanguageExecuted(e as LanguageViewModel));
        }

        public async Task Refresh()
        {
           await UpdateItems();
        }

        public async Task UpdateItems()
        {
            Items.Clear();

            //TODO : Include available languages into Json files.
            Items.Add(new LanguageViewModel(Properties.Resources.English, "en-US"));
            Items.Add(new LanguageViewModel(Properties.Resources.French, "fr-FR"));
            Items.Add(new LanguageViewModel(Properties.Resources.German, "de-DE"));
        }

        public void ChangeLanguageExecuted(LanguageViewModel language)
        {
            var currentLanguage = System.Globalization.CultureInfo.CurrentUICulture;
            
            if (currentLanguage.Name == language.ShortCode) return;
            
            System.Globalization.CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo(language.ShortCode);
            
            Page mainPage = new NavigationPage(new Views.TeamsList());
            Application.Current.MainPage = mainPage;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
