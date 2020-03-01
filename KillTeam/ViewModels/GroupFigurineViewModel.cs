using KillTeam.Models;
using System.Collections.ObjectModel;

namespace KillTeam.ViewModels
{
    public class GroupFigurineViewModel : ObservableCollection<ModelProfile>
    {
        public string GroupName { get; set; }
    }



}