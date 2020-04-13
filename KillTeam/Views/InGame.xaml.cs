using CarouselView.FormsPlugin.Abstractions;
using KillTeam.Models;
using KillTeam.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using Entry = Xamarin.Forms.Entry;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InGame
    {
        private string equipeId;

        public InGame(string equipeId)
        {
            InitializeComponent();
            this.equipeId = equipeId;
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

                Team equipe = KTContext.Db.Teams
                    .Where(e => e.Id == equipeId)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.Specialist.Tactics)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.ModelProfile.Model.ModelWeapons)
                    .ThenInclude(m => m.Weapon)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.ModelProfile.ModelProfileWeapons)
                    .ThenInclude(m => m.Weapon)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.ModelProfile.Model.Abilities)
                    .ThenInclude(m => m.Details)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.ModelProfile.Abilities)
                    .ThenInclude(m => m.Details)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.MemberWeapons)
                    .ThenInclude(m => m.Weapon)
                    .ThenInclude(a => a.WeaponProfiles)
                    .ThenInclude(a => a.WeaponType)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.MemberPowers)
                    .ThenInclude(mr => mr.Power)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.MemberTraits)
                    .ThenInclude(mr => mr.Trait)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.MemberPsychics)
                    .ThenInclude(mr => mr.Psychic)
                    .Include(e => e.Faction.Abilities)
                    .ThenInclude(m => m.Details).First();
            

            equipe.Members = equipe.Members.OrderBy(o => o.Position).ToList();
            BindingContext = equipe;
            MembresListView.ItemsSource = equipe.GetSelectedMembers();
            CarouselMembres.ItemsSource = equipe.GetSelectedMembers();
            
        }

        private void ArmesBindingContext(object sender, EventArgs e)
        {
            Grid grid = sender as Grid;
            MemberDetails.FillArmGrid(grid, grid.BindingContext as Member);
        }

        void OnPositionSelected(object sender, PositionSelectedEventArgs e)
        {
            if (MembresListView.ItemsSource != null)
            {
                List<Member> list = new List<Member>();
                list.AddRange(MembresListView.ItemsSource as IEnumerable<Member>);

                if (list.Count() != 0 && MembresListView.SelectedItem != list[e.NewValue])
                {
                    MembresListView.SelectedItem = list[e.NewValue];
                }
            }
        }

        private void CarouselMembres_SizeChanged(object sender, EventArgs e)
        {
            OnAppearing();
        }


        private void StackLayout_BindingContextChanged(object sender, EventArgs e)
        {
            StackLayout stackLayout = sender as StackLayout;
            stackLayout.Children.Clear();
            List<Ability> aptitudes = stackLayout.BindingContext as List<Ability>;
            foreach (Ability aptitude in aptitudes)
            {
                stackLayout.Children.Add(new AbilityDetails { BindingContext = aptitude });
            }
        }

        private void StackLayoutPsy_BindingContextChanged(object sender, EventArgs e)
        {
            StackLayout stackLayout = sender as StackLayout;
            stackLayout.Children.Clear();
            Member membre = stackLayout.BindingContext as Member;

            if (membre.IsPsyker)
            {

                if (membre.MemberPsychics.Count == 0)
                {
                    Psychic psybolt = KTContext.Db.Psychics.Find("1");
                    stackLayout.Children.Add(new PsychiqueView { BindingContext = psybolt });
                }
                else
                {
                    foreach (MemberPsychic psy in membre.MemberPsychics)
                    {
                        stackLayout.Children.Add(new PsychiqueView { BindingContext = psy.Psychic });
                    }
                }
            }
        }

        async void OnButtonTacticalClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new ListTactiquePage(equipeId));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Grid grid = sender as Grid;
            Member membre = grid.BindingContext as Member;
            if (MembresListView.ItemsSource == null)
                return;

            List<Member> list = new List<Member>();
            list.AddRange(MembresListView.ItemsSource as IEnumerable<Member>);
            int index = list.IndexOf(membre as Member);

            if (CarouselMembres.Position != index)
            {
                CarouselMembres.Position = index;
            }
        }
    }
}