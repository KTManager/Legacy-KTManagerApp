using KillTeam.Models;
using KillTeam.Services;
using KillTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Traits
    {
        private string membreId;

        public Traits(string membreId)
        {
            this.membreId = membreId;
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var membre = KTContext.Db.Members.Where(m => m.Id == membreId).Include(m => m.ModelProfile.Traits).Include(m => m.MemberTraits).ThenInclude(mt => mt.Trait).First();
            var traits = new List<ListTraitViewModel>();
            foreach (var trait in KTContext.Db.Traits.Where(t => t.ModelProfileId == membre.ModelProfile.Id || string.IsNullOrEmpty(t.ModelProfileId)))
            {
                traits.Add(new ListTraitViewModel
                {
                    Trait = trait,
                    Selected = membre.MemberTraits.Select(t => t.TraitId).Contains(trait.Id)
                });
            }
            BindingContext = traits;
            Title = membre.Title;
        }

        private void UpdateDatabase()
        {
            var traits = BindingContext as List<ListTraitViewModel>;

            var membre = KTContext.Db.Members.AsNoTracking().Where(m => m.Id == membreId).Include(m => m.ModelProfile.Traits).Include(m => m.MemberTraits).ThenInclude(mt => mt.Trait).First();

            foreach (MemberTrait mt in membre.MemberTraits)
            {
                var membreTrait = KTContext.Db.MemberTraits.AsTracking().Where(m => m.Id == mt.Id).First();
                KTContext.Db.Entry(membreTrait).State = EntityState.Deleted;
            }

            foreach (var t in traits.Where(t => t.Selected))
            {
                MemberTrait membreTrait = new MemberTrait
                {
                    Id = Guid.NewGuid().ToString(),
                    MemberId = membreId,
                    TraitId = t.Trait.Id
                };
                KTContext.Db.Entry(membreTrait).State = EntityState.Added;
            }
            if (!traits.Any(t => t.Selected && t.Trait.Id == "G5"))
            {
                var membrePouvoir = KTContext.Db.MemberPowers.AsTracking().Where(m => m.IsGeneral).FirstOrDefault();
                if (membrePouvoir != null)
                    KTContext.Db.Entry(membrePouvoir).State = EntityState.Deleted;
            }
            if (!traits.Any(t => t.Selected && t.Trait.Id == "G6"))
            {
                var membrePouvoir = KTContext.Db.MemberPowers.AsTracking().Where(m => m.IsMaster).FirstOrDefault();
                if (membrePouvoir != null)
                    KTContext.Db.Entry(membrePouvoir).State = EntityState.Deleted;
            }

            KTContext.Db.SaveChanges();
            Member trackedMembre = KTContext.Db.Members.AsNoTracking().Where(m => m.Id == membreId)
                    .Where(m => m.Id == membreId)
                    .Include(m => m.MemberPowers)
                    .Include(m => m.ModelProfile.CostOverrides)
                    .Include(m => m.ModelProfile.LevelCosts)
                    .Include(m => m.MemberWeapons)
                    .ThenInclude(m => m.Weapon)
                    .Include(m => m.MemberTraits)
                    .ThenInclude(m => m.Trait)
                    .First();

            trackedMembre.UpdateCost();

            Member mb = KTContext.Db.Members.Find(membre.Id);
            mb.Cost = trackedMembre.Cost;
            KTContext.Db.Entry(mb).State = EntityState.Modified;
            KTContext.Db.SaveChanges();

            Title = trackedMembre.Title;

        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            UpdateDatabase();
        }
    }
}