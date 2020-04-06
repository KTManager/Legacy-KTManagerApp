using KillTeam.Commands.Handlers;
using KillTeam.Controllers;
using KillTeam.ViewModels;
using Syncfusion.ListView.XForms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamsView
    {
        public TeamsView()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            BindingContext = new TeamsController(ToolbarItems, new DeleteTeamCommandHandler(), new ReorderTeamsCommandHandler());
        }

        protected override async void OnAppearing()
        {
            if (BindingContext is TeamsController binding)
            {
                await binding.Refresh();
            }

            base.OnAppearing();
        }

        private void TeamsView_ItemDragging(object sender, ItemDraggingEventArgs e)
        {
            if (e.Action != DragAction.Drop || e.ItemData == null) return;

            if (!(BindingContext is TeamsController binding)) return;

            var team = e.ItemData as TeamsViewModel;
            var teams = binding.Items;
            
            teams.Move(teams.IndexOf(team), e.NewIndex);

            binding.ReorderTeam.Execute(null);
        }
    }
}
