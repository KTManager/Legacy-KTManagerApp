using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using KillTeam.Properties;
using KillTeam.Services;
using KillTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms.Internals;

namespace KillTeam.Controllers
{
    public class TacticsList
    {
        public ObservableCollection<TacticsListTacticViewModel> Items { get; set; }

        public string Title { get; set; }

        public TacticsList(string teamId)
        {
            Items = new ObservableCollection<TacticsListTacticViewModel>();

            _teamId = teamId;
        }
        
        public async Task Refresh()
        {
            await UpdateItems();
        }

        public async Task UpdateItems()
        {
            Items.Clear();
            var team = KTContext.Db.Teams
                .Where(t => t.Id == _teamId)
                .Include(t => t.Members)
                .ThenInclude(m => m.Specialist.Tactics)
                .ThenInclude(m => m.ModelProfile.Tactics)
                .Include(e => e.Faction.Tactics)
                .ThenInclude(t => t.Phase)
                .AsTracking()
                .First();

            Title = team.Name + " (" + team.Cost + ")";

            var members = team.GetSelectedMembers().ToList();
            var hasCommander = members.Any(m => m.IsCommander);

            KTContext.Db.Tactics
                .Include(t => t.Phase)
                .Where(t => t.FactionId == null && t.SpecialistId == null && t.ModelProfileId == null && (hasCommander || t.Commander == false))
                .ForEach(x => Items.Add(new TacticsListTacticViewModel(x.Id, x.Name, Resources.Specialite, x.Description, x.Cost)));
            
            team.Faction.Tactics
                .Where(t => hasCommander || t.Commander == false)
                .ForEach(x => Items.Add(new TacticsListTacticViewModel(x.Id, x.Name, Resources.Specialite, x.Description, x.Cost)));

            foreach (var member in members)
            {
                member.Specialist?.Tactics
                    .Where(t => t.Level <= member.Level && (hasCommander || t.Commander == false))
                    .ForEach(x => Items.Add(new TacticsListTacticViewModel(x.Id, x.Name, Resources.Specialite, x.Description, x.Cost)));

                member.ModelProfile?.Tactics
                    .Where(t => member.IsCommander || t.Commander == false)
                    .ForEach(x => Items.Add(new TacticsListTacticViewModel(x.Id, x.Name, x.ModelProfile.Name, x.Description, x.Cost)));
            }
        }

        private string _teamId;
    }
}
