using KillTeam.Models;
using KillTeam.Resx;
using KillTeam.Services;
using Microsoft.EntityFrameworkCore;
using Plugin.Share;
using Plugin.Share.Abstractions;
using Syncfusion.ListView.XForms;
using System;
using System.Linq;
using System.Threading.Tasks;
using KillTeam.Commands;
using KillTeam.Commands.Handlers;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using Entry = Xamarin.Forms.Entry;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EquipePage : ContentPage
    {
        public Team Equipe { get; set; }
        private string equipeId;


        public EquipePage(string equipeId)
        {
            InitializeComponent();
            this.equipeId = equipeId;
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Equipe = KTContext.Db.Teams
                .Where(e => e.Id == equipeId)
                .Include(e => e.Members)
                .ThenInclude(m => m.Specialist)
                .Include(e => e.Members)
                .ThenInclude(m => m.ModelProfile.Model.ModelWeapons)
                .ThenInclude(fa => fa.Weapon)
                .Include(e => e.Members)
                .ThenInclude(m => m.ModelProfile.ModelProfileWeapons)
                .ThenInclude(da => da.Weapon)
                .Include(e => e.Members)
                .ThenInclude(m => m.MemberWeapons)
                .ThenInclude(m => m.Weapon)
                .ThenInclude(a => a.WeaponProfiles)
                .ThenInclude(a => a.WeaponType)
                .Include(e => e.Members)
                .ThenInclude(m => m.MemberWarGearOptions)
                .ThenInclude(mr => mr.WarGearOption)
                .Include(e => e.Faction)
                .First();

            Equipe.Members = Equipe.Members.OrderBy(o => o.Name).ToList();
            BindingContext = Equipe;

            ErreursUpdate();
            if (Sauvegarde.IsConnected())
            {
                if (await Sauvegarde.Synchro(KTContext.Db))
                {
                    Equipe = KTContext.Db.Teams
                    .Where(e => e.Id == equipeId)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.Specialist)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.ModelProfile)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.MemberWarGearOptions)
                    .ThenInclude(mr => mr.WarGearOption)
                    .Include(e => e.Faction).First();

                    Equipe.Members = Equipe.Members.OrderBy(o => o.Name).ToList();
                    BindingContext = Equipe;
                }
            }            
        }

        private void ErreursUpdate()
        {
            if (Equipe.Errors.Count == 0)
            {
                ToolbarItems.Remove(Erreurs);
            }
            else if (!ToolbarItems.Contains(Erreurs))
            {
                ToolbarItems.Add(Erreurs);
            }
        }


        async void SelectedSwitchToggled(object sender, ToggledEventArgs e)
        {
            Member membre = ((Switch)sender).BindingContext as Member;

            Member mb = KTContext.Db.Members.Find(membre.Id);
            mb.Selected = e.Value;
            KTContext.Db.Entry(mb).State = EntityState.Modified;
            await KTContext.Db.SaveChangesAsync();

            //Force le refresh des points
            membre.Team.Roster = membre.Team.Roster;
            ErreursUpdate();
        }

        async void RosterSwitchToggled(object sender, ToggledEventArgs e)
        {
            Team equipe = KTContext.Db.Teams.Find(equipeId);
            equipe.Roster = e.Value;
            KTContext.Db.Entry(equipe).State = EntityState.Modified;
            await KTContext.Db.SaveChangesAsync();
            ErreursUpdate();
        }

        async void OnButtonAddCliked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListDeclinaisonPage(equipeId));
        }

        async void OnButtonTacticalClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListTactiquePage(equipeId));
        }

        async void OnButtonDangerClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListErreurPage(equipeId));
        }

        async void OnButtonChoixImpressionClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChoixImpression(equipeId));
        }


        async void OnButtonInGameClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InGamePage(equipeId));
        }

        async void NameChanged(object sender, EventArgs e)
        {
            Entry entry = (Entry)sender;

            Team equipe = KTContext.Db.Teams.Find(equipeId);
            equipe.Name = entry.Text;
            KTContext.Db.Entry(equipe).State = EntityState.Modified;
            await KTContext.Db.SaveChangesAsync();
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            string membreId = mi.CommandParameter as string;
            DeleteMembre(membreId);
        }
        

        private void OnButtonShareClicked(object sender, EventArgs eargs)
        {
            Team equipe = KTContext.Db.Teams
                .Where(e => e.Id == equipeId)
                .Include(e => e.Members)
                .ThenInclude(m => m.Specialist)
                .Include(e => e.Members)
                .ThenInclude(m => m.ModelProfile)
                .Include(e => e.Members)
                .ThenInclude(m => m.MemberWeapons)
                .ThenInclude(m => m.Weapon)
                .Include(e => e.Faction).First();

            CrossShare.Current.Share(new ShareMessage
            {
                Text = equipe.GetSummary() + "\n" + Translate.PartageDepuis,
                Url = "https://www.facebook.com/KillTeamManager"
            });
        }

        private void MembresListView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            if (e.SwipeOffset <= 0)
                return;

            Member membre = e.ItemData as Member;
            SfListView listView = sender as SfListView;
            listView.ResetSwipe();

            DeleteMembre(membre.Id);
        }

        bool drag = false;

        async void MembresListView_ItemTapped(object sender, EventArgs e)
        {
            if (!drag)
            {
                StackLayout stackLayout = sender as StackLayout;
                Member membre = stackLayout.BindingContext as Member;

                await Navigation.PushAsync(new MembrePage(membre.Id));
            }
        }

        private async void MembresListView_ItemDragging(object sender, ItemDraggingEventArgs e)
        {
            if(e.Action == DragAction.Start && e.ItemData != null)
            {
                drag = true;
            }

            if (e.Action != DragAction.Drop || e.ItemData == null)
                return;

            Member membre = e.ItemData as Member;

            var membres = KTContext.Db.Teams.AsNoTracking().Where(eq => eq.Id == membre.TeamId).Include(eq => eq.Members).Select(eq => eq.Members).First();

            var trackedSelectedMembre = KTContext.Db.Members.AsTracking().Where(me => me.Id == membre.Id).First();
            trackedSelectedMembre.Position = e.NewIndex;
            KTContext.Db.Entry(trackedSelectedMembre).State = EntityState.Modified;

            int pos = 0;
            foreach (Member m in membres.Where(m => m.Id != membre.Id).OrderBy(m => m.Position))
            {
                if (pos == e.NewIndex)
                    pos++;

                var trackedmembre = KTContext.Db.Members.AsTracking().Where(me => me.Id == m.Id).First();
                trackedmembre.Position = pos;
                KTContext.Db.Entry(trackedmembre).State = EntityState.Modified;
                pos++;
            }
            KTContext.Db.SaveChanges();
            await Task.Delay(500);
            drag = false;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Grid grid = sender as Grid;
            Member membre = grid.BindingContext as Member;
            DeleteMembre(membre.Id);
            MembresListView.ResetSwipe();
        }

        private void DeleteMembre(string membreId)
        {
            
            foreach (MemberTrait ma in KTContext.Db.MemberTraits.Where(m => m.MemberId == membreId).AsNoTracking().ToList())
            {
                MemberTrait mad = KTContext.Db.MemberTraits.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }
            foreach (MemberPower ma in KTContext.Db.MemberPowers.Where(m => m.MembrerId == membreId).AsNoTracking().ToList())
            {
                MemberPower mad = KTContext.Db.MemberPowers.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }
            foreach (MemberWeapon ma in KTContext.Db.MemberWeapons.Where(m => m.MemberId == membreId).AsNoTracking().ToList())
            {
                MemberWeapon mad = KTContext.Db.MemberWeapons.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }
            foreach (MemberPsychic ma in KTContext.Db.MemberPsychics.Where(m => m.MemberId == membreId).AsNoTracking().ToList())
            {
                MemberPsychic mad = KTContext.Db.MemberPsychics.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }
            foreach (MemberWarGearOption ma in KTContext.Db.MemberWarGearOptions.Where(m => m.MemberId == membreId).AsNoTracking().ToList())
            {
                MemberWarGearOption mad = KTContext.Db.MemberWarGearOptions.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }

            var membre = KTContext.Db.Members.Find(membreId);
            KTContext.Db.Entry(membre).State = EntityState.Deleted;
            KTContext.Db.SaveChanges();

            OnAppearing();
        }

        async void ButtonSupprimerClicked(object sender, EventArgs e)
        {
            string NomEquipe = KTContext.Db.Teams.Where(eq => eq.Id == equipeId).Select(m => m.Name).First();
            bool reponse = await DisplayAlert(Translate.Supprimer, Translate.EtesVousSur + " \"" + NomEquipe + "\" ?", Translate.Oui, Translate.Non);
            if (reponse)
            {
                var handler = new DeleteTeamCommandHandler();
                handler.Handle(new DeleteTeamCommand(equipeId));
                
                await Navigation.PopAsync();
            }
        }

        async void OnButtonDuplicateClicked(object sender, EventArgs e)
        {
            Team.DuplicateTeam(equipeId);
            await Navigation.PopAsync();
        }

        private void StackLayout_BindingContextChanged(object sender, EventArgs e)
        {
            StackLayout stackLayout = sender as StackLayout;
            string resume = stackLayout.BindingContext as string;
            stackLayout.IsVisible = !string.IsNullOrWhiteSpace(resume);
        }
    }
}