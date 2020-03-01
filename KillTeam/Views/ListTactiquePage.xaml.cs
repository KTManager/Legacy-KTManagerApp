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
using Switch = Xamarin.Forms.Switch;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListTactiquePage : ContentPage
    {
        private string equipeId;
        private TactiqueOptionsViewModel options;
        private List<View> phasesSwitch;

        public ListTactiquePage(String equipeId)
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            this.equipeId = equipeId;
            options = new TactiqueOptionsViewModel();
            phasesSwitch = new List<View>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Team equipe = KTContext.Db.Teams
                .Where(e => e.Id == equipeId)
                .Include(e => e.Members)
                .ThenInclude(e => e.Specialist.Tactics)
                .Include(e => e.Members)
                .ThenInclude(e => e.ModelProfile.Tactics)
                .Include(e => e.Faction.Tactics)
                .ThenInclude(t => t.Phase)
                .First();

            Title = equipe.Name + " (" + equipe.Cost + ")";
            options.ChoosedPhase = KTContext.Db.Phases.Where(p => p.Id != "7").Select(p => p.Id).ToList();
            var tactiques = equipe.GetAllTactics(options);

            phasesSwitch.ForEach(p => StackLayoutOptions.Children.Remove(p));
            phasesSwitch.Clear();
            foreach (Phase phase in KTContext.Db.Phases.Where(p => p.Id != "7").OrderBy(p => p.Id))
            {
                StackLayout stackLayout = new StackLayout();
                stackLayout.Orientation = StackOrientation.Horizontal;
                stackLayout.Children.Add(
                    new Label
                    {
                        Text = phase.Name,
                        LineBreakMode = LineBreakMode.NoWrap,
                        FontSize = 16
                    }
                );

                Switch @switch = new Switch();
                @switch.BindingContext = phase;
                @switch.Toggled += PhaseSwitchToggled;
                @switch.HorizontalOptions = LayoutOptions.EndAndExpand;
                @switch.IsToggled = true;
                stackLayout.Children.Add(@switch);

                StackLayoutOptions.Children.Add(stackLayout);
                phasesSwitch.Add(stackLayout);
            }


            TactiquesListView.ItemsSource = equipe.GetAllTactics(options);

            BindingContext = options;
        }

        private void UpdateTactiques()
        {
            Team equipe = KTContext.Db.Teams
                .Where(eq => eq.Id == equipeId)
                .Include(eq => eq.Members)
                .ThenInclude(eq => eq.Specialist.Tactics)
                .ThenInclude(t => t.Phase)
                .Include(eq => eq.Members)
                .ThenInclude(eq => eq.ModelProfile.Tactics)
                .ThenInclude(t => t.Phase)
                .Include(eq => eq.Faction.Tactics)
                .ThenInclude(t => t.Phase)
                .First();

            TactiquesListView.ItemsSource = equipe.GetAllTactics(options);
        }

        void PhaseSwitchToggled(object sender, EventArgs e)
        {
            Switch @switch = sender as Switch;
            Phase phase = @switch.BindingContext as Phase;
            if (@switch.IsToggled)
            {
                if (!options.ChoosedPhase.Contains(phase.Id))
                {
                    options.ChoosedPhase.Add(phase.Id);
                    UpdateTactiques();
                }
            } else
            {
                if (options.ChoosedPhase.Contains(phase.Id))
                {
                    options.ChoosedPhase.Remove(phase.Id);
                    UpdateTactiques();
                }
            }

        }

        void TactiquesSwitchToggled(object sender, EventArgs e)
        {
            UpdateTactiques();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            navigationDrawer.IsOpen = !navigationDrawer.IsOpen;
        }
    }
}
