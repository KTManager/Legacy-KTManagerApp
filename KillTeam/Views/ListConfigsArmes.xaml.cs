using KillTeam.Models;
using KillTeam.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListConfigsArmes : ContentPage
	{
        private string membreId;

        private bool isBusy = false;

        private List<ConfigurationView> listConfigView;
        private List<ConfigurationView> listOptionnellesView;
        private List<ConfigurationView> listFixeView;

        public ListConfigsArmes(string membreId)
		{
			InitializeComponent();
            this.membreId = membreId;
            listConfigView = new List<ConfigurationView>();
            listOptionnellesView = new List<ConfigurationView>();
            listFixeView = new List<ConfigurationView>();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PossibleSwap cp = PossibleSwap.Create(membreId);
            BindingContext = cp;

            if (listConfigView.Count != cp.WarGearCombinations.Count)
            {
                LayoutConfig.Children.Clear();
                foreach (WarGearCombination config in cp.WarGearCombinations)
                {
                    ConfigurationView configurationView = new ConfigurationView(this, OnConfigSelected);
                    LayoutConfig.Children.Add(configurationView);
                    configurationView.BindingContext = config;
                    configurationView.OnAppearing();
                    listConfigView.Add(configurationView);
                }
            } else
            {
                for (int i = 0; i < listConfigView.Count; i++)
                {
                    listConfigView[i].BindingContext = cp.WarGearCombinations[i];
                    listConfigView[i].OnAppearing();
                }
            }
            if (listOptionnellesView.Count != cp.OptionalWeapons.Count)
            {
                LayoutOptionnelles.Children.Clear();
                foreach (WarGearCombination config in cp.OptionalWeapons)
                {
                    ConfigurationView configurationView = new ConfigurationView(this, OnOptionnellesSelected);
                    LayoutOptionnelles.Children.Add(configurationView);
                    configurationView.BindingContext = config;
                    configurationView.OnAppearing();
                    listOptionnellesView.Add(configurationView);
                }
            } else
            {
                for (int i = 0; i < listOptionnellesView.Count; i++)
                {
                    listOptionnellesView[i].BindingContext = cp.OptionalWeapons[i];
                    listOptionnellesView[i].OnAppearing();
                }
            }
            if (listFixeView.Count != cp.FixedWeapons.Count)
            {
                LayoutFixe.Children.Clear();
                foreach (Weapon arme in cp.FixedWeapons)
                {
                    WarGearCombination configuration = new WarGearCombination();
                    configuration.Weapons.Add(arme);
                    ConfigurationView configurationView = new ConfigurationView(this, null);
                    LayoutFixe.Children.Add(configurationView);
                    configurationView.BindingContext = configuration;
                    configurationView.OnAppearing();
                    listFixeView.Add(configurationView);
                }
            }

            
            if (cp.WarGearCombinations.Count == 0)
            {
                LayoutConfig.IsVisible = false;
                ConfigLabel.IsVisible = false;
            }
            if (cp.OptionalWeapons.Count == 0)
            {
                LayoutOptionnelles.IsVisible = false;
                ArmesOptionnellesLabel.IsVisible = false;
                ArmesOptionnellesSep.IsVisible = false;
            }
            if (cp.FixedWeapons.Count == 0)
            {
                LayoutFixe.IsVisible = false;
                ArmesFixeLabel.IsVisible = false;
                ArmesFixeSep.IsVisible = false;
            }

            Title = cp.Member.Name + " (" + cp.Member.Cost + ")";
        }

        void OnConfigSelected(object sender, ToggledEventArgs e)
        {
            Switch pSwitch = sender as Switch;
            WarGearCombination configuration = pSwitch.BindingContext as WarGearCombination;

            PossibleSwap changementPossible = (PossibleSwap)BindingContext;
            changementPossible.WarGearCombinations.Where(c => c.Selected).ForEach(c => c.Selected = false);
            configuration.Selected = true;

            UpdateMembre();
            OnAppearing();
        }

        void OnOptionnellesSelected(object sender, ToggledEventArgs e)
        {
            Switch pSwitch = sender as Switch;
            WarGearCombination configuration = pSwitch.BindingContext as WarGearCombination;

            configuration.Selected = !configuration.Selected;

            UpdateMembre();
            OnAppearing();
        }

        public bool UpdateMembre()
        {
            if (isBusy)
                return false;

            isBusy = true;

            PossibleSwap changementPossible = (PossibleSwap)BindingContext;

            //suppression des anciens remplacements
            var remplacements = KTContext.Db.MemberWarGearOptions.AsNoTracking().Where(m => m.MemberId == membreId).ToList();
            foreach (MemberWarGearOption mr in remplacements)
            {
                MemberWarGearOption mr2 = KTContext.Db.MemberWarGearOptions.AsTracking().Where(aa => aa.Id == mr.Id).First();
                KTContext.Db.Entry(mr2).State = EntityState.Deleted;
            }

            //Suppression des anciennes armes
            var armes = KTContext.Db.MemberWeapons.AsNoTracking().Where(m => m.MemberId == membreId).ToList();
            foreach (MemberWeapon ma in armes)
            {
                MemberWeapon ma2 = KTContext.Db.MemberWeapons.AsTracking().Where(aa => aa.Id == ma.Id).First();
                KTContext.Db.Entry(ma2).State = EntityState.Deleted;
            }

            //Ajout de la config
            foreach (WarGearCombination configuration in changementPossible.WarGearCombinations.Where(c => c.Selected))
            {
                foreach (Weapon arme in configuration.Weapons)
                {
                    MemberWeapon membreArme = new MemberWeapon();
                    membreArme.Id = Guid.NewGuid().ToString();
                    membreArme.WeaponId = arme.Id;
                    membreArme.MemberId = membreId;
                    KTContext.Db.Entry(membreArme).State = EntityState.Added;
                }

                foreach (WarGearOption remp in configuration.WarGearOption)
                {
                    MemberWarGearOption membreRemplacement = new MemberWarGearOption();
                    membreRemplacement.Id = Guid.NewGuid().ToString();
                    membreRemplacement.WarGearOptionId = remp.Id;
                    membreRemplacement.MemberId = membreId;
                    KTContext.Db.Entry(membreRemplacement).State = EntityState.Added;
                }
            }


            //Ajout armes optionnelles
            foreach (WarGearCombination configuration in changementPossible.OptionalWeapons.Where(c => c.Selected))
            {
                foreach (Weapon arme in configuration.Weapons)
                {
                    MemberWeapon membreArme = new MemberWeapon();
                    membreArme.Id = Guid.NewGuid().ToString();
                    membreArme.WeaponId = arme.Id;
                    membreArme.MemberId = membreId;
                    KTContext.Db.Entry(membreArme).State = EntityState.Added;
                }

                foreach (WarGearOption remp in configuration.WarGearOption)
                {
                    MemberWarGearOption membreRemplacement = new MemberWarGearOption();
                    membreRemplacement.Id = Guid.NewGuid().ToString();
                    membreRemplacement.WarGearOptionId = remp.Id;
                    membreRemplacement.MemberId = membreId;
                    KTContext.Db.Entry(membreRemplacement).State = EntityState.Added;
                }
            }

            //Ajout armes obligatoires
            foreach (Weapon arme in changementPossible.FixedWeapons)
            {
                MemberWeapon membreArme = new MemberWeapon();
                membreArme.Id = Guid.NewGuid().ToString();
                membreArme.WeaponId = arme.Id;
                membreArme.MemberId = membreId;
                KTContext.Db.Entry(membreArme).State = EntityState.Added;
            }


            KTContext.Db.SaveChanges();


            Member membre = KTContext.Db.Members
                .Where(m => m.Id == membreId)
                .Include(m => m.ModelProfile.CostOverrides)
                .Include(m => m.ModelProfile.LevelCosts)
                .Include(m => m.MemberWeapons)
                .ThenInclude(m => m.Weapon)
                .Include(m => m.MemberTraits)
                .ThenInclude(m => m.Trait)
                .AsNoTracking()
                .First();
            membre.UpdateCost();

            Member mb = KTContext.Db.Members.Find(membre.Id);
            mb.Cost = membre.Cost;
            KTContext.Db.Entry(mb).State = EntityState.Modified;
            KTContext.Db.SaveChanges();

            isBusy = false;

            return true;
        }

    }
}