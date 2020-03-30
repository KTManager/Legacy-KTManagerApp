using KillTeam.Models;

using KillTeam.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using KillTeam.Commands;
using KillTeam.Commands.Handlers;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using Application = Xamarin.Forms.Application;
using Entry = Xamarin.Forms.Entry;

namespace KillTeam.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MembrePage : ContentPage
	{
        private string membreId;

		public MembrePage(string membreId)
		{
            InitializeComponent();
            this.membreId = membreId;
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        public static void FillArmGrid(Grid ArmeGrid, Member membre)
        {
            int fontSize = 15;
            int line = 0;
            var evenStyle = Application.Current.Resources["GridRowEven"] as Style;
            var oddStyle = Application.Current.Resources["GridRowOdd"] as Style;
            var labelStyle = evenStyle;
            bool isGerman = TranslateExtension.Ci.TwoLetterISOLanguageName == "de";

            ArmeGrid.RowDefinitions.Clear();
            ArmeGrid.ColumnDefinitions.Clear();
            ArmeGrid.Children.Clear();

            ArmeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            ArmeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            ArmeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            ArmeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            ArmeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
            ArmeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
            ArmeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
            ArmeGrid.Children.Add(new Label {Style= labelStyle, FontSize = fontSize, Text = Properties.Resources.Arme }, 0, line);
            ArmeGrid.Children.Add(new Label {Style= labelStyle, FontSize = fontSize, Text = Properties.Resources.Portee }, 1, line);
            ArmeGrid.Children.Add(new Label {Style= labelStyle, FontSize = fontSize, Text = Properties.Resources.Type }, 2, line);
            ArmeGrid.Children.Add(new Label {Style= labelStyle, FontSize = fontSize, Text = Properties.Resources.F }, 3, line);
            ArmeGrid.Children.Add(new Label {Style= labelStyle, FontSize = fontSize, Text = Properties.Resources.PA }, 4, line);
            ArmeGrid.Children.Add(new Label {Style= labelStyle, FontSize = fontSize, Text = Properties.Resources.D }, 5, line);
            line++;
            labelStyle = oddStyle;

            List<MemberWeapon> armements = membre.MemberWeapons.ToList();
            armements.Sort();
            foreach (var arme in armements.Select(a => a.Weapon).Where(a => !a.IsEquipement()))
            {
                string prefix = "";
                if (arme.WeaponProfiles.Count > 1)
                {
                    ArmeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    ArmeGrid.Children.Add(new Label { Style= labelStyle, FontSize = fontSize, Text = arme.Name }, 0, line);
                    ArmeGrid.Children.Add(new Label { Style = labelStyle, FontSize = fontSize, Text = arme.Description }, 1, 6, line, line + 1);
                    line++;
                    prefix = " - ";
                }

                foreach (var pArme in arme.WeaponProfiles)
                {
                    ArmeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    ArmeGrid.Children.Add(new Label { Style= labelStyle, FontSize = fontSize, Text = prefix + pArme.Name }, 0, line);
                    ArmeGrid.Children.Add(new Label { Style= labelStyle, FontSize = fontSize, Text = pArme.Range.ToString() }, 1, line);
                    ArmeGrid.Children.Add(new Label { Style= labelStyle, FontSize = fontSize, Text = pArme.Type }, 2, line);
                    ArmeGrid.Children.Add(new Label { Style= labelStyle, FontSize = fontSize, Text = isGerman && pArme.Strength == "U" ? "T" : pArme.Strength }, 3, line);
                    ArmeGrid.Children.Add(new Label { Style= labelStyle, FontSize = fontSize, Text = pArme.ArmourPenetration }, 4, line);
                    ArmeGrid.Children.Add(new Label { Style = labelStyle, FontSize = fontSize, Text = pArme.Damages }, 5, line);
                    line++;
                    ArmeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    ArmeGrid.Children.Add(new Label { Style = labelStyle, FontSize = fontSize, Text = pArme.Description }, 0, 6, line, line + 1);
                    line++;
                }

                labelStyle = labelStyle == evenStyle ? oddStyle : evenStyle;
            }

            foreach (var arme in armements.Select(a => a.Weapon).Where(a => a.IsEquipement()))
            {
                ArmeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                ArmeGrid.Children.Add(new Label { Style = labelStyle, FontSize = fontSize, Text = arme.Name }, 0, 6, line, line + 1);
                line++;

                labelStyle = labelStyle == evenStyle ? oddStyle : evenStyle;
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            Member membre = KTContext.Db.Members.Where(m => m.Id == membreId)
                .Include(m => m.ModelProfile)
                .Include(m => m.Specialist.Powers)
                .Include(m => m.MemberWeapons)
                .ThenInclude(a => a.Weapon)
                .ThenInclude(a => a.WeaponProfiles)
                .ThenInclude(pa => pa.WeaponType).First();


            FillArmGrid(ArmeGrid, membre);


            BindingContext = membre;

            if (Sauvegarde.IsConnected())
            {
                await Sauvegarde.Synchro(KTContext.Db);
            }
        }

        async void NameChanged(object sender, EventArgs e)
        {
            Entry entry = (Entry)sender;

            Member membre = KTContext.Db.Members.Find(membreId);
            membre.Name = entry.Text;
            KTContext.Db.Entry(membre).State = EntityState.Modified;
            await KTContext.Db.SaveChangesAsync();

        }

        async void ExperienceChanged(object sender, EventArgs e)
        {
            Entry entry = (Entry)sender;

            Member membre = KTContext.Db.Members.Find(membreId);
            int x = 0;
            Int32.TryParse(entry.Text, out x);

            membre.Xp = x;
            KTContext.Db.Entry(membre).State = EntityState.Modified;
            await KTContext.Db.SaveChangesAsync();
        }

        async void RecrueSwitchToggled(object sender, ToggledEventArgs e)
        {
            Member membre = KTContext.Db.Members.Find(membreId);

            membre.Recruit = e.Value;
            KTContext.Db.Entry(membre).State = EntityState.Modified;
            await KTContext.Db.SaveChangesAsync();
        }

        async void ConvalescenceSwitchToggled(object sender, ToggledEventArgs e)
        {
            Member membre = KTContext.Db.Members.Find(membreId);

            membre.Convalescence = e.Value;
            KTContext.Db.Entry(membre).State = EntityState.Modified;
            await KTContext.Db.SaveChangesAsync();
        }

        async void OnButtonArmeCliked(object sender, EventArgs e)
        {
            Member membre = await KTContext.Db.Members.Where(m => m.Id == membreId)
                .Include(m => m.ModelProfile)
                .Include(m => m.MemberWeapons)
                .ThenInclude(m => m.Weapon)
                .FirstAsync();
            await Navigation.PushAsync(new WargearView(membre.ModelProfileId));
        }

        async void OnButtonAptitudeCliked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListAptitudePage(membreId));
        }

        async void ChangeNiveauClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangeLevelPage(membreId));
        }

        async void ButtonSupprimerClicked(object sender, EventArgs e)
        {
            string NomMembre = KTContext.Db.Members.Where(m => m.Id == membreId).Select(m => m.Name).First();
            bool reponse = await DisplayAlert(Properties.Resources.Supprimer, Properties.Resources.EtesVousSur + " \"" + NomMembre + "\" ?", Properties.Resources.Oui, Properties.Resources.Non);
            if (reponse)
            {
                DeleteMembre();
                await Navigation.PopAsync();
            }
        }

        private void DeleteMembre()
        {
            var deleteMemberCommandHandler = new DeleteMemberCommandHandler();
            deleteMemberCommandHandler.Handle(new DeleteMemberCommand(membreId));

        }

        async void ButtonChangeTraitClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListTraitPage(membreId));
        }

        async void ButtonChangePsyClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListPsychiquePage(membreId));
        }

        async void OnButtonDuplicateClicked(object sender, EventArgs e)
        {
            await Member.DuplicateFrom(membreId);
            await Navigation.PopAsync();
        }
    }
}