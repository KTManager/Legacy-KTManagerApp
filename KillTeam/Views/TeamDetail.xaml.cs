using System;
using KillTeam.Commands.Handlers;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamDetail
    {
        public TeamDetail(string teamId)
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            var vm = new Controllers.TeamDetail(ToolbarItems, teamId, new DeleteTeamCommandHandler(), new RenameTeamCommandHandler(), new DeleteMemberCommandHandler());
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            if (BindingContext is Controllers.TeamDetail binding)
            {
                await binding.Refresh();
            }

            base.OnAppearing();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            if (!(BindingContext is Controllers.TeamDetail binding)) return;

            var team = binding.Item;
            var answer = await DisplayAlert(Properties.Resources.Supprimer, Properties.Resources.EtesVousSur + " \"" + team.Name + "\" ?", Properties.Resources.Oui, Properties.Resources.Non);
            if (answer)
            {
                binding.Delete.Execute(null);
            }
        }
    }
}