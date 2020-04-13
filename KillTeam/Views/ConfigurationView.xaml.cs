using KillTeam.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfigurationView : ContentView
    {
        private WeaponsConfig parentPage;
        private EventHandler<ToggledEventArgs> OnSwitch;

        public ConfigurationView(WeaponsConfig page, EventHandler<ToggledEventArgs> OnSwitch)
		{
            parentPage = page;
            this.OnSwitch = OnSwitch;

            InitializeComponent();
        }

        public void OnAppearing()
        {
            WarGearCombination configuration = BindingContext as WarGearCombination;
            if (configuration == null)
                return;

            Label.Text = configuration.Resume;

            if (OnSwitch != null)
            {
                Switch.Toggled -= OnSwitch;
                Switch.IsToggled = configuration.Selected;
                Switch.Toggled += OnSwitch;
            } else
            {
                Switch.IsVisible = false;
            }

            /*

            int fontSize = 15;
            int line = 0;
            var backgroundColor = Color.LightGray;
            Configuration configuration = BindingContext as Configuration;
            if (configuration == null)
            {
                configuration = new Configuration();
                configuration.Armes = new List<Arme>();
                configuration.Armes.Add((Arme)BindingContext);
                Switch.IsVisible = false;
            }
            if (configuration.Armes.Count == 0)
                return;
            for(int i = 0; i < configuration.Armes.Count; i++)
            {
                configuration.Armes[i] = KTContext.Db.Armes.Where(a => a.Id == configuration.Armes[i].Id)
                .Include(a => a.ProfileArmes)
                .ThenInclude(pa => pa.TypeArme)
                .First();
            }

            ArmeGrid.RowDefinitions.Clear();
            ArmeGrid.ColumnDefinitions.Clear();
            ArmeGrid.Children.Clear();

            ArmeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            ArmeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            ArmeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            ArmeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            ArmeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            ArmeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            ArmeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            ArmeGrid.Children.Add(new Label { BackgroundColor = backgroundColor, FontSize = fontSize, Text = "Arme" }, 0, line);
            ArmeGrid.Children.Add(new Label { BackgroundColor = backgroundColor, FontSize = fontSize, Text = "Portée" }, 1, line);
            ArmeGrid.Children.Add(new Label { BackgroundColor = backgroundColor, FontSize = fontSize, Text = "Type" }, 2, line);
            ArmeGrid.Children.Add(new Label { BackgroundColor = backgroundColor, FontSize = fontSize, Text = "F" }, 3, line);
            ArmeGrid.Children.Add(new Label { BackgroundColor = backgroundColor, FontSize = fontSize, Text = "PA" }, 4, line);
            ArmeGrid.Children.Add(new Label { BackgroundColor = backgroundColor, FontSize = fontSize, Text = "D" }, 5, line);
            line++;
            backgroundColor = ArmeGrid.BackgroundColor;

            foreach (var arme in configuration.Armes.Where(a => !a.IsEquipement()))
            {
                string prefix = "";
                if (arme.ProfileArmes.Count > 1)
                {
                    ArmeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    ArmeGrid.Children.Add(new Label { BackgroundColor = backgroundColor, FontSize = fontSize, Text = arme.Nom }, 0, line);
                    ArmeGrid.Children.Add(new Label { BackgroundColor = backgroundColor, FontSize = fontSize, Text = arme.DescriptionAdditionnelle }, 1, 6, line, line + 1);
                    line++;
                    prefix = " - ";
                }

                foreach (var pArme in arme.ProfileArmes)
                {
                    ArmeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    ArmeGrid.Children.Add(new Label { BackgroundColor = backgroundColor, FontSize = fontSize, Text = prefix + pArme.Nom }, 0, line);
                    ArmeGrid.Children.Add(new Label { BackgroundColor = backgroundColor, FontSize = fontSize, Text = pArme.Portee.ToString() }, 1, line);
                    ArmeGrid.Children.Add(new Label { BackgroundColor = backgroundColor, FontSize = fontSize, Text = pArme.Type }, 2, line);
                    ArmeGrid.Children.Add(new Label { BackgroundColor = backgroundColor, FontSize = fontSize, Text = pArme.F }, 3, line);
                    ArmeGrid.Children.Add(new Label { BackgroundColor = backgroundColor, FontSize = fontSize, Text = pArme.PA }, 4, line);
                    ArmeGrid.Children.Add(new Label { BackgroundColor = backgroundColor, FontSize = fontSize, Text = pArme.D }, 5, line);
                    line++;
                }

                if (backgroundColor == Color.LightGray)
                    backgroundColor = ArmeGrid.BackgroundColor;
                else
                    backgroundColor = Color.LightGray;
            }

            foreach (var arme in configuration.Armes.Where(a => a.IsEquipement()))
            {
                ArmeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                ArmeGrid.Children.Add(new Label { BackgroundColor = backgroundColor, FontSize = fontSize, Text = arme.Nom }, 0, 6, line, line + 1);
                line++;

                if (backgroundColor == Color.LightGray)
                    backgroundColor = ArmeGrid.BackgroundColor;
                else
                    backgroundColor = Color.LightGray;
            }
            */
        }
    }
}