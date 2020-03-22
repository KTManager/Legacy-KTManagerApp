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
using Page = Xamarin.Forms.Page;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FactionsPage : ContentPage
    {
        public FactionsPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = KTContext.Db.Factions
                                .AsNoTracking()
                                .OrderBy(post => post.Name)
                                .ToList();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            DateTime start = DateTime.Now;

            ListView listView = (ListView)sender;
            Faction faction = (Faction)listView.SelectedItem;

            Team equipe = new Team();
            equipe.Id = Guid.NewGuid().ToString();
            equipe.Name = faction.Name;
            equipe.Faction = faction;
            equipe.Members = new List<Member>();
            equipe.Position = KTContext.Db.Teams
            .Select(a => a.Position)
            .DefaultIfEmpty(0)
            .Max() + 1;
            KTContext.Db.Entry(equipe).State = EntityState.Added;
            await KTContext.Db.SaveChangesAsync();
            
            Page page = new TeamView(equipe.Id);
            var _ = Navigation.PopModalAsync();
            await Application.Current.MainPage.Navigation.PushAsync(page);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
