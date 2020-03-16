using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KillTeam.Services;
using KillTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace KillTeam.Controllers
{
    public class TeamDetail
    {
        public TeamDetailTeamViewModel Item { get; set; }

        public IList<ToolbarItem> ToolbarItems { get; set; }

        public ICommand AddMember { get; set; }
        public ICommand EditName { get; set; }

#if DEBUG
        public TeamDetail() { }
#endif

        public TeamDetail(IList<ToolbarItem> toolbarItems, string teamId)
        {
            _itemId = teamId;

            AddMember = new Command(() => AddMemberExecuted());
            EditName = new Command(async () => await EditNameExecuted());
        }

        public async Task Refresh()
        {
            await UpdateItem();
        }

        public async Task UpdateItem()
        {
            var team = KTContext.Db.Teams
                .Where(e => e.Id == _itemId)
                .Include(e => e.Members)
                .ThenInclude(m => m.Specialist)
                .Include(e => e.Members)
                .ThenInclude(m => m.ModelProfile.Model.ModelWeapons)
                .ThenInclude(fa => fa.Weapon)
                .Include(e => e.Members)
                .ThenInclude(m => m.ModelProfile.ModelProfileWeapons)
                .ThenInclude(da => da.Weapon)
                .Include(e => e.Members)
                .ThenInclude(m => m.MemberWeapons)
                .ThenInclude(m => m.Weapon)
                .ThenInclude(a => a.WeaponProfiles)
                .ThenInclude(a => a.WeaponType)
                .Include(e => e.Members)
                .ThenInclude(m => m.MemberWarGearOptions)
                .ThenInclude(mr => mr.WarGearOption)
                .Include(e => e.Faction)
                .First();

            Item = new TeamDetailTeamViewModel(team.Id, team.Name, team.Cost, team.Faction.Name, team.Roster);
            team.Members.OrderBy(o => o.Name).ToList().ForEach(y => Item.Members.Add(new TeamDetailMemberViewModel(y.Id, y.Name, y.Cost, y.ShortWeaponLevel)));
        }

        private void AddMemberExecuted()
        {
            //KTApp.Navigation.PushModalAsync(new Views.FactionsList());
        }

        public async Task EditNameExecuted()
        {
            //await KTApp.Navigation.PushAsync(new RemerciementPage());
        }

        private string _itemId;
    }
}
