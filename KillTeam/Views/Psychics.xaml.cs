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
    public partial class Psychics : ContentPage
    {
        private string membreId;
        private int NbPsyConnus;

        public Psychics(string membreId)
        {
            this.membreId = membreId;
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var membre = KTContext.Db.Members.Where(m => m.Id == membreId).Include(m => m.ModelProfile.Psychics).Include(m => m.MemberPsychics).ThenInclude(mt => mt.Psychic).First();

            if (membre.MemberPsychics.Count == 0)
            {
                Psychic psybolt = KTContext.Db.Psychics.Find("1");
                membre.MemberPsychics.Add(new MemberPsychic() { Psychic = psybolt, PsychicId = psybolt.Id, Member = membre, MemberId = membre.Id });
            }
            NbPsyConnus = membre.ModelProfile.NumberOfKnownPsychics;

            var psychiques = new List<ListPsychiqueViewModel>();
            foreach (var psy in KTContext.Db.Psychics.Where(t => t.ModelProfileId == membre.ModelProfile.Id || string.IsNullOrEmpty(t.ModelProfileId)))
            {
                psychiques.Add(new ListPsychiqueViewModel(NbPsyConnus, psychiques)
                {
                    Psychique = psy,
                    Selected = membre.MemberPsychics.Select(t => t.PsychicId).Contains(psy.Id)
                });
            }

            BindingContext = psychiques;
            Title = membre.Title;
            TitlePsy.Text = String.Format(Properties.Resources.PsyAuChoix, NbPsyConnus);
        }

        private void UpdateDatabase()
        {
            var traits = BindingContext as List<ListPsychiqueViewModel>;

            var membre = KTContext.Db.Members.AsNoTracking().Where(m => m.Id == membreId).Include(m => m.ModelProfile.Psychics).Include(m => m.MemberPsychics).ThenInclude(mt => mt.Psychic).First();

            foreach (MemberPsychic mt in membre.MemberPsychics)
            {
                var membreTrait = KTContext.Db.MemberPsychics.AsTracking().Where(m => m.Id == mt.Id).First();
                KTContext.Db.Entry(membreTrait).State = EntityState.Deleted;
            }

            foreach (var t in traits.Where(t => t.Selected))
            {
                MemberPsychic membreTrait = new MemberPsychic
                {
                    Id = Guid.NewGuid().ToString(),
                    MemberId = membreId,
                    PsychicId = t.Psychique.Id
                };
                KTContext.Db.Entry(membreTrait).State = EntityState.Added;
            }
            KTContext.Db.SaveChanges();
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            UpdateDatabase();
        }
    }
}