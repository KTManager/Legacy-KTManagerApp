using System.Linq;
using KillTeam.Services;
using Microsoft.EntityFrameworkCore;

namespace KillTeam.Commands.Handlers
{
    public class DeleteMemberCommandHandler : IHandleCommands<DeleteMemberCommand>
    {
        public void Handle(DeleteMemberCommand command)
        {
            var memberId = command.MemberId;

            foreach (var ma in KTContext.Db.MemberTraits.Where(m => m.MemberId == memberId).AsNoTracking().ToList())
            {
                var mad = KTContext.Db.MemberTraits.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }
            foreach (var ma in KTContext.Db.MemberPowers.Where(m => m.MembrerId == memberId).AsNoTracking().ToList())
            {
                var mad = KTContext.Db.MemberPowers.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }
            foreach (var ma in KTContext.Db.MemberWeapons.Where(m => m.MemberId == memberId).AsNoTracking().ToList())
            {
                var mad = KTContext.Db.MemberWeapons.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }
            foreach (var ma in KTContext.Db.MemberPsychics.Where(m => m.MemberId == memberId).AsNoTracking().ToList())
            {
                var mad = KTContext.Db.MemberPsychics.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }
            foreach (var ma in KTContext.Db.MemberWarGearOptions.Where(m => m.MemberId == memberId).AsNoTracking().ToList())
            {
                var mad = KTContext.Db.MemberWarGearOptions.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }
            foreach (var sf in KTContext.Db.MemberSubFactions.Where(m => m.MemberId == memberId).AsNoTracking().ToList())
            {
                var mad = KTContext.Db.MemberSubFactions.Find(sf.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }

            var membre = KTContext.Db.Members.Find(memberId);
            KTContext.Db.Entry(membre).State = EntityState.Deleted;
            KTContext.Db.SaveChanges();
        }
    }
}