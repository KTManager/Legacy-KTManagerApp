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
                .ToListAsync();

            return teams
                .Select(t => new TeamsViewModel(t.Id, t.Name, t.Cost, t.FactionNameAndMembersCount))
                .ToList();
        }
    }
}