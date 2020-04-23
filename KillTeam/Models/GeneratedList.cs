using System.Collections.Generic;
using System.Linq;
using KillTeam.Services;
using KillTeam.ViewModels;

namespace KillTeam.Models
{
    public class GeneratedList
    {
        private readonly Team _team;
        private readonly PdfConfiguration _config;

        public GeneratedList(Team team, PdfConfiguration config)
        {
            _team = team;
            _config = config;
        }

        public string Faction => _team.Faction.Name;
        public List<Ability> FactionAbilities => _team.Faction.Abilities;
        public string Name => _team.Name;
        public int Points => _team.Cost;
        public bool ShowTactics => _config.Tactics;
        public bool ShowAbilityDetails => _config.AbilityDetails;
        public bool GroupAbilities => _config.GroupAbilities;
        public List<TactiqueViewModel> Tactics => _team. GetAllTactics(new TactiqueOptionsViewModel());

        public List<Ability> Abilities
        {
            get
            {
                var abilities = _team.Faction.Abilities.ToList();

                if (!_config.GroupAbilities)
                    return abilities;

                abilities.AddRange(
                _team.Members
                            .SelectMany(m => m.Abilities)
                            .Where(a => abilities.All(ab => ab.Id != a.Id))
                );

                return abilities
                    .GroupBy(a => a.Name)
                    .Select(a => a.First())
                    .ToList();
            }
        }

        public List<Member> Members
        {
            get
            {
                var members = _team.GetSelectedMembers().ToList();
                
                if (!_config.GroupIdenticalMembers)
                    return members.OrderBy(m => m.Position).ToList();

                var groupedMembers = new List<Member>();
                
                foreach (var member in members)
                {
                    var identicalMembers = members.Where(m => m.Identical(member)).ToList();
                    
                    if (groupedMembers.Any(m => m.Identical(member)))
                        continue;

                    var identicalMember = identicalMembers.First();
                    identicalMember.Name = $"{string.Join(",", identicalMembers.Select(im => im.Name))} x {identicalMembers.Count}";
                    
                    groupedMembers.Add(identicalMember);
                }

                return groupedMembers;
            }
        }

        public Psychic Psybolt => _psybolt ?? (_psybolt = KTContext.Db.Psychics.Find("1"));

        private Psychic _psybolt;
    }
}