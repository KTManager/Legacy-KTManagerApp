using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillTeam.Models;
using KillTeam.Services;
using KillTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace KillTeam.Controllers
{
    public class WargearController : BindableObject
    {
        private string _profileId;
        private List<WargearViewModel> _viewModels;

        public ObservableCollection<WargearSlotViewModel> WargearOptions { get; set; }
        public ObservableCollection<WargearViewModel> MandatoryWargear { get; set; }

        public WargearController(string profileId)
        {
            _profileId = profileId;
            _viewModels = new List<WargearViewModel>();

            WargearOptions = new ObservableCollection<WargearSlotViewModel>();
            MandatoryWargear = new ObservableCollection<WargearViewModel>();
        }

        public async Task Refresh()
        {
            await UpdateItems();
        }

        private async Task UpdateItems()
        {
            WargearOptions.Clear();

            var profile = await KTContext.Db.ModelProfiles
                .Include(x => x.ModelProfileWeapons)
                .ThenInclude(x => x.Weapon)
                .Include(x => x.Model.ModelWeapons)
                .ThenInclude(x => x.Weapon)
                .Include(x => x.WarGearOptions)
                .Include(x => x.Model.WarGearOptions)
                .Where(x => x.Id == _profileId)
                .FirstAsync();
            
            var weapons = profile.ModelProfileWeapons.Select(x => x.Weapon).ToList();
            if (!weapons.Any())
            {
                weapons = profile.Model.ModelWeapons.Select(x => x.Weapon).ToList();
            }

            var options = profile.WarGearOptions.Concat(profile.Model.WarGearOptions).ToList();

            if (!weapons.Any()) return;

            //Create a slot for each default weapon
            for (var i = 0; i < weapons.Count; i++)
            {
                var weapon = weapons[i];

                var viewModel = new WargearViewModel(weapon.Id, weapon.Name);
                _viewModels.Add(viewModel);

                if (IsReplaceable(weapon.Id, options))
                {
                    var slot = new WargearSlotViewModel($"Weapon {i + 1}:");
                    slot.Options.Add(viewModel);
                    slot.SelectedItem = viewModel;

                    WargearOptions.Add(slot);
                }
                else
                {
                    MandatoryWargear.Add(viewModel);
                }
            }

            _viewModels.ForEach(x => x.CompatibleWith = new ObservableCollection<WargearViewModel>(_viewModels.Where(y => y.Id != x.Id)));
        }

        private bool IsReplaceable(string weaponId, List<WarGearOption> options)
        {
            foreach (var option in options)
            {
                var leftSide = option.Operation.Split(':');
                if (leftSide.Contains(weaponId)) return true;
            }

            return false;
        }
    }
}
