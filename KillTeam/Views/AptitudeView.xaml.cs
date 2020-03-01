using KillTeam.Models;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AptitudeView : ContentView
	{
		public AptitudeView ()
		{
			InitializeComponent ();
        }

        protected override void OnBindingContextChanged()
        {
            Ability aptitude = BindingContext as Ability;
            if (aptitude == null)
                return;
            Nom.Text = aptitude.Name;
            Description.Text = aptitude.Description;

            int fontSize = 15;

            Grid.RowDefinitions.Clear();
            Grid.ColumnDefinitions.Clear();
            Grid.Children.Clear();

            if (aptitude.Details == null || aptitude.Details.Count == 0)
                return;

            Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

            for (int i = 0; i < aptitude.Details.Max(a => a.Row); i++)
                Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

            foreach (var aptitudesDetails in aptitude.Details.OrderBy(a => a.Row))
            {
                var color = aptitudesDetails.Row % 2 == 0 ? Grid.BackgroundColor : Color.LightGray;
                Grid.Children.Add(new Label { BackgroundColor = color, FontSize = fontSize, Text = aptitudesDetails.Content }, aptitudesDetails.Column - 1, aptitudesDetails.Row);
            }
        }
    }
}