using KillTeam.Models;
using KillTeam.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using Application = Xamarin.Forms.Application;
using ListView = Xamarin.Forms.ListView;

namespace KillTeam.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Specialists
    {
        private String membreId;

        public Specialists (string membreId)
        {
            InitializeComponent ();
            this.membreId = membreId;
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Member membre = KTContext.Db.Members
                                .Where(m => m.Id == membreId)
                                .Include(e => e.ModelProfile.Specialists)
                                .ThenInclude(e => e.Specialist)
                                .First();
            List<Specialist> specialites = new List<Specialist>();
            specialites.Add(new Specialist() { NameEn = "None", NameFr = "Aucune", NameDe = "Keine" });
            foreach(ModelProfileSpecialist spec in membre.ModelProfile.Specialists)
            {
                specialites.Add(spec.Specialist);
            }
            BindingContext = specialites;

        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            ListView listView = (ListView)sender;
            Specialist specialite = (Specialist)listView.SelectedItem;

            Member membre = KTContext.Db.Members.Find(membreId);
            if (specialite.NameFr == "Aucune")
            {
                membre.SpecialistId = null;
                membre.Specialist = null;
            }
            else
            {
                membre.SpecialistId = specialite.Id;
            }
            KTContext.Db.Entry(membre).State = EntityState.Modified;
            await KTContext.Db.SaveChangesAsync();

            await Application.Current.MainPage.Navigation.PopAsync();

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}