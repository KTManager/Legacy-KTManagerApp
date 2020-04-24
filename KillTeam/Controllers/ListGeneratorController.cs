using System.Windows.Input;
using KillTeam.Services;
using MvvmHelpers;
using Xamarin.Forms;

namespace KillTeam.Controllers
{
    public class ListGeneratorController : BaseViewModel
    {
        public ICommand Save { get; }
        
        public ListGeneratorController(string teamName, string teamList)
        {
            _teamName = teamName;
            _teamList = teamList;
            
            Save = new Command(SaveList);
        }

        public string TeamList
        {
            get => _teamList;
            set => SetProperty(ref _teamList, value, nameof(TeamList));
        }

        private void SaveList()
        {
            DependencyService.Get<ISave>().Save($"{_teamName}.html", "text/html", _teamList);
        }

        private string _teamName;
        private string _teamList;
    }
}