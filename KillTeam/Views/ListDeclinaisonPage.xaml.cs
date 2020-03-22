using KillTeam.Models;
using KillTeam.Services;
using KillTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using Application = Xamarin.Forms.Application;
using ListView = Xamarin.Forms.ListView;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListDeclinaisonPage : ContentPage
    {

        public List<GroupFigurineViewModel> GroupedFigurines { get; set; }
        
        public string EquipeId { get; set; }

        public ListDeclinaisonPage(string equipeId)
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            this.EquipeId = equipeId;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Team equipe = KTContext.Db.Teams
                .Where(e => e.Id == EquipeId)
                .Include(e => e.Members)
                .ThenInclude(fig => fig.ModelProfile)
                .Include(f => f.Faction.Models)
                .ThenInclude(fig => fig.ModelProfiles)
                .AsNoTracking()
                .First();

            GroupedFigurines = new List<GroupFigurineViewModel>();
            GroupFigurineViewModel commandantGroup = new GroupFigurineViewModel() { GroupName = Resx.Translate.Commandant };
            foreach (var figurine in equipe.Faction.Models)
            {

                GroupFigurineViewModel currentGroup = new GroupFigurineViewModel() { GroupName = figurine.Name };
                foreach (var declinaison in figurine.ModelProfiles)
                {
                    declinaison.ModelId = figurine.Id;
                    declinaison.Model = figurine;

                    if (declinaison.MaximumNumber == 0 || equipe.Roster || declinaison.MaximumNumber > equipe.GetSelectedMembers().Count(m => m.ModelProfile.Id == declinaison.Id))
                    {
                        if (!declinaison.IsCommander || (equipe.Members.Count(m => m.ModelProfile.Id == declinaison.Id) == 0 && (equipe.Roster || equipe.GetSelectedMembers().Count(m => m.ModelProfile.IsCommander) == 0)))
                        {
                            if(declinaison.IsCommander)
                            {
                                commandantGroup.Add(declinaison);
                            }
                            else
                            {
                                currentGroup.Add(declinaison);
                            }
                        }
                    }
                }
                if (currentGroup.Count > 0)
                {
                    GroupedFigurines.Add(currentGroup);
                }
            }

            if (commandantGroup.Count > 0)
            {
                GroupedFigurines.Add(commandantGroup);
            }


            Title = equipe.Name + " (" + equipe.Cost + ")";
            BindingContext = GroupedFigurines;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            ListView listView = (ListView)sender;
            ModelProfile declinaisonModel = (ModelProfile)listView.SelectedItem;

            await Member.CreateFrom(EquipeId, declinaisonModel.Id);

            await KTApp.Navigation.PopModalAsync(true);
        }
    }
}
