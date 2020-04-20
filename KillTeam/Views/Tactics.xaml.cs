using KillTeam.Models;
using KillTeam.Services;
using KillTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tactics
    {
        private string equipeId;
        private TactiqueOptionsViewModel options;

        public Tactics(string equipeId)
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            this.equipeId = equipeId;
            options = new TactiqueOptionsViewModel();

            ToolbarItems.Add(new ToolbarItem
            {
                Text = Properties.Resources.Filtres,
                Order = ToolbarItemOrder.Primary,
                Command = new Command(async () => await FiltersExecuted())
            });
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
            
            TactiquesListView.ItemsSource = equipe.GetAllTactics(options);

            BindingContext = options;
        }

        private async Task FiltersExecuted()
        {
            await KTApp.Navigation.PushModalAsync(new TacticsFilters());
        }
    }
}
