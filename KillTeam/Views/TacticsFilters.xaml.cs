using System;
using System.Collections.Generic;
using System.Linq;
using KillTeam.Models;
using KillTeam.Services;
using KillTeam.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TacticsFilters : ContentPage
    {
        private TactiqueOptionsViewModel options;
        private List<View> phasesSwitch;

        public TacticsFilters()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            options = new TactiqueOptionsViewModel();
            phasesSwitch = new List<View>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            options.ChoosedPhase = KTContext.Db.Phases.Where(p => p.Id != "7").Select(p => p.Id).ToList();

            phasesSwitch.ForEach(p => StackLayoutOptions.Children.Remove(p));
            phasesSwitch.Clear();
            foreach (var phase in KTContext.Db.Phases.Where(p => p.Id != "7").OrderBy(p => p.Id))
            {
                var stackLayout = new StackLayout();
                stackLayout.Orientation = StackOrientation.Horizontal;
                stackLayout.Children.Add(
                    new Label
                    {
                        Text = phase.Name,
                        LineBreakMode = LineBreakMode.NoWrap,
                        FontSize = 16
                    }
                );

                var @switch = new Switch();
                @switch.BindingContext = phase;
                @switch.Toggled += PhaseSwitchToggled;
                @switch.HorizontalOptions = LayoutOptions.EndAndExpand;
                @switch.IsToggled = true;
                stackLayout.Children.Add(@switch);

                StackLayoutOptions.Children.Add(stackLayout);
                phasesSwitch.Add(stackLayout);
            }

            BindingContext = options;
        }

        void PhaseSwitchToggled(object sender, EventArgs e)
        {
            var @switch = sender as Switch;
            var phase = @switch.BindingContext as Phase;
            if (@switch.IsToggled)
            {
                if (!options.ChoosedPhase.Contains(phase.Id))
                {
                    options.ChoosedPhase.Add(phase.Id);
                }
            }
            else
            {
                if (options.ChoosedPhase.Contains(phase.Id))
                {
                    options.ChoosedPhase.Remove(phase.Id);
                }
            }

        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await KTApp.Navigation.PopModalAsync();
        }
    }
}