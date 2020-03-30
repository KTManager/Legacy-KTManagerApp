using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillTeam.Models;
using KillTeam.Services;
using KillTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using Superpower;
using Syncfusion.DataSource.Extensions;
using Xamarin.Forms;

namespace KillTeam.Controllers
{
    public class WargearController : BindableObject
    {
        private string _profileId;
        List<WarGearOption> _options;
        IEnumerable<Operation> _parsedOptions;


        public ObservableCollection<WargearSlotViewModel> WargearSlots { get; set; }
        public ObservableCollection<WargearViewModel> MandatoryWargear { get; set; }

        public WargearController(string profileId)
        {
            _profileId = profileId;

            WargearSlots = new ObservableCollection<WargearSlotViewModel>();
            MandatoryWargear = new ObservableCollection<WargearViewModel>();
        }

        public async Task Refresh()
        {
            await UpdateItems();
        }

        private async Task UpdateItems()
        {
            try
            {
                WargearSlots.Clear();
                MandatoryWargear.Clear();

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

                if (!weapons.Any()) return;

                _options = profile.WarGearOptions.Concat(profile.Model.WarGearOptions).ToList();
                _parsedOptions = _options.Select(x => OperationParser.Operation.Parse(new Tokenizer().Tokenize(x.Operation)));

                //Adds the first weapon to the first slot
                var weapon1 = weapons.FirstOrDefault(x => IsReplaceable(x.Id)) ?? weapons[0];
                var viewModel1 = new WargearViewModel(weapon1.Id, weapon1.Name);

                //Adds all other default weapons as "ComesWith" for the first weapon
                foreach (var weapon in weapons)
                {
                    WargearViewModel viewModel;

                    //One weapon as already been treated
                    if (weapon == weapon1)
                    {
                        viewModel = viewModel1;
                    }
                    else
                    {
                        viewModel = new WargearViewModel(weapon.Id, weapon.Name);
                        viewModel1.ComesWith.Add(viewModel);
                    }

                    GetReplacements(viewModel.Id).ForEach(viewModel.ReplaceableWith.Add);
                }

                AddToSlotOrMandatory(viewModel1, 1);
                viewModel1.ReplaceableWith.ForEach(x => AddToSlot(x, 1));

                //Select the first weapon to trigger the other slots generation
                if (WargearSlots.Any() && WargearSlots.First().Options.Any())
                {
                    WargearSlots.First().SelectedItem = WargearSlots.First().Options.First();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private List<WargearViewModel> GetReplacements(string wargearId)
        {
            //TODO Hard coded value for testing purpose
            if (wargearId == "PB")
                return new List<WargearViewModel> {new WargearViewModel("PGV", "Dummy Pistol")
                {
                    ComesWith = new ObservableCollection<WargearViewModel>(new List<WargearViewModel>{new WargearViewModel("GL", "Grenade Launcher")})
                }};
            if (wargearId == "PGV")
                return new List<WargearViewModel> { new WargearViewModel("PB", "Bolt Pistol") };
            return new List<WargearViewModel>();
        }

        private void AddToSlotOrMandatory(WargearViewModel wargear, int slotId)
        {
            try
            {
                if (wargear.ReplaceableWith.Any())
                {
                    AddToSlot(wargear, slotId);
                }
                else
                {
                    if (MandatoryWargear.All(x => x.Id != wargear.Id))
                    {
                        MandatoryWargear.Add(wargear);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void AddToSlot(WargearViewModel wargear, int slotId)
        {
            try
            {
                var slotIndex = slotId < 1 ? 0 : slotId - 1;

                WargearSlotViewModel slot;
                if (WargearSlots.Count > slotIndex)
                {
                    slot = WargearSlots[slotIndex];
                }
                else
                {
                    slot = new WargearSlotViewModel($"Weapon {slotId}:");
                    slot.PropertyChanged += OnWargearSlotPropertyChanged;
                    WargearSlots.Add(slot);

                }

                slot.Options.Add(wargear);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void OnWargearSlotPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (!(sender is WargearSlotViewModel slot)) return;
                if (e.PropertyName != nameof(WargearSlotViewModel.SelectedItem)) return;

                //Removes all the slots being after the one that as changed selection
                ClearSlotsAfter(WargearSlots.IndexOf(slot));

                if (slot.SelectedItem == null) return;

                if (slot.SelectedItem.ComesWith.Any())
                {
                    //The selected weapon comes with others.
                    foreach (var wargear in slot.SelectedItem.ComesWith) //TODO : Recursive
                    {
                        AddToSlotOrMandatory(wargear, WargearSlots.Count + 1);
                    }
                }
                else if (slot.SelectedItem.CompatibleWith.Any())
                {
                    var newSlotId = WargearSlots.Count + 1;

                    foreach (var wargear in slot.SelectedItem.ComesWith) //TODO : Recursive
                    {
                        AddToSlot(wargear, newSlotId);
                        wargear.CompatibleWith.ForEach(x => AddToSlot(x, 1));
                    }
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        private void ClearSlotsAfter(int slotId)
        {
            try
            {
                WargearSlots.Skip(slotId + 1).ForEach(x => x.PropertyChanged -= OnWargearSlotPropertyChanged);
                WargearSlots = new ObservableCollection<WargearSlotViewModel>(WargearSlots.Take(slotId + 1));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private bool IsReplaceable(string weaponId)
        {
            foreach (var option in _options)
            {
                var leftSide = option.Operation.Split(':').FirstOrDefault();
                if (leftSide?.Contains(weaponId) == true) return true;
            }

            return false;
        }
    }
}
