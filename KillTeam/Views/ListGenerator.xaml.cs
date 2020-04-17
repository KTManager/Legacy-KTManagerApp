using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using KillTeam.Models;
using KillTeam.Services;
using KillTeam.Templates;
using KillTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListGenerator : ContentPage
    {
        public ListGenerator(string teamId)
        {
            InitializeComponent();

            ThreadPool.QueueUserWorkItem (o =>
            {
                var team = FetchTeam(teamId);
            
                GeneratePdf(team); 
            });
        }

        public void GeneratePdf(Team team)
        {
            var config = new PdfConfiguration();
            
            var printTemplate = new Template
            {
                Model = new GeneratedList(team, config)
            };
            
            var htmlString = printTemplate.GenerateString();
     
            var htmlSource = new HtmlWebViewSource {Html = htmlString};

            MainThread.BeginInvokeOnMainThread(() =>
            {
                KtmListView.Source = htmlSource;
            });
        }

        private Team FetchTeam(string teamId)
        {
            var team = KTContext.Db.Teams
                    .AsNoTracking()
                    .Where(e => e.Id == teamId)
                    .Include(e => e.Faction.Tactics)
                    .Include(e => e.Faction.Abilities)
                    .ThenInclude(a => a.Details)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.MemberPowers)
                    .ThenInclude(e => e.Power)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.Specialist.Tactics)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.Specialist.Powers)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.MemberWeapons)
                    .ThenInclude(e => e.Weapon.WeaponProfiles)
                    .ThenInclude(e => e.WeaponType)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.ModelProfile)
                    .ThenInclude(e => e.Abilities)
                    .ThenInclude(a => a.Details)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.ModelProfile.Model)
                    .ThenInclude(e => e.Abilities)
                    .ThenInclude(a => a.Details)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.ModelProfile.Tactics)
                    .Include(e => e.Faction.Models)
                    .ThenInclude(e => e.Abilities)
                    .ThenInclude(a => a.Details)
                    .Include(e => e.Faction.Models)
                    .ThenInclude(d => d.ModelWeapons)
                    .ThenInclude(d => d.Weapon.WeaponProfiles)
                    .ThenInclude(d => d.WeaponType)
                    .Include(e => e.Faction.Models)
                    .ThenInclude(f => f.ModelProfiles)
                    .ThenInclude(d => d.ModelProfileWeapons)
                    .ThenInclude(d => d.Weapon.WeaponProfiles)
                    .ThenInclude(d => d.WeaponType)
                    .Include(f => f.Faction.Models)
                    .ThenInclude(f => f.ModelProfiles)
                    .ThenInclude(f => f.Abilities)
                    .ThenInclude(a => a.Details)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.MemberTraits)
                    .ThenInclude(ma => ma.Trait)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.MemberPsychics)
                    .ThenInclude(ma => ma.Psychic)
                    .First();

            return team;
        }
        
    }

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