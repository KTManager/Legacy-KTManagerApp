using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KillTeam.Services;
using KillTeam.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace KillTeam.Queries.Handlers
{
    public class AllTeamsQueryHandler : IQueryHandler<AllTeamsQuery, List<TeamsViewModel>>
    {
        public async Task<List<TeamsViewModel>> Execute(AllTeamsQuery query)
        {
            var teams = await KTContext.Db.Teams
                .Include(e => e.Faction)
                .Include(e => e.Members)
                .AsNoTracking()
                .OrderBy(post => post.Position)
                .Select(t => new
                {
                    t.Id,
                    t.Name,
                    t.Members,
                    t.Faction,
                    t.Roster
                })
                .ToListAsync();

            return teams
                .Select(t =>
                {
                    var selectedMembers = t.Members.Where(m => m.Selected || !t.Roster).ToList();
                    var count = selectedMembers.Count();
                    var cost = selectedMembers.Sum(m => m.Cost);
                    var subtitle = $"{t.Faction.Name} - {count} {(count <= 1 ? Properties.Resources.Membre : Properties.Resources.Membres)}";
                    
                    return new TeamsViewModel(t.Id, t.Name, cost, subtitle);
                })
                .ToList();
        }
    }
}