using KillTeam.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListErreurPage : ContentPage
    {
        private string equipeId;

        public ListErreurPage (string equipeId)
		{
            this.equipeId = equipeId;
			InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var equipe = KTContext.Db.Teams
                .Where(e => e.Id == equipeId)
                .Include(e => e.Members)
                .ThenInclude(m => m.Specialist)
                .Include(e => e.Members)
                .ThenInclude(m => m.ModelProfile)
                .Include(e => e.Members)
                .ThenInclude(m => m.MemberWarGearOptions)
                .ThenInclude(mr => mr.WarGearOption)
                .First();

            Title = equipe.Name + " (" + equipe.Cost + ")";
            BindingContext = equipe.Errors;
        }
    }
}