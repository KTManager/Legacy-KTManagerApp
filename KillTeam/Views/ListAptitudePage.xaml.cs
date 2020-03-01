using KillTeam.Models;
using KillTeam.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListAptitudePage : ContentPage
    {
        private string membreId;

        public ListAptitudePage(string membreId)
        {
            this.membreId = membreId;
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Member membre = KTContext.Db.Members
                .AsNoTracking()
                .Where(m => m.Id == membreId)
                .Include(m => m.Team.Faction.Abilities)
                .ThenInclude(a => a.Details)
                .Include(m => m.ModelProfile.Model.Abilities)
                .ThenInclude(a => a.Details)
                .Include(m => m.ModelProfile.Abilities)
                .ThenInclude(a => a.Details)
                .Include(m => m.Specialist.Powers)
                .Include(m => m.MemberWeapons)
                .ThenInclude(ma => ma.Weapon.WeaponProfiles)
                .Include(m => m.MemberTraits)
                .ThenInclude(ma => ma.Trait)
                .Include(m => m.MemberPowers)
                .ThenInclude(ma => ma.Power)
                .First();

            Title = membre.Team.Name + " (" + membre.Team.Cost + ")";
            BindingContext = membre.Abilities;
        }
    }
}