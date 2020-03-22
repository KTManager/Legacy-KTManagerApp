using KillTeam.Models;

using KillTeam.Services;
using KillTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KillTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChangeLevelPage : ContentPage
    {
        private string membreId;

        public ChangeLevelPage (string membreId)
        {
            this.membreId = membreId;
            InitializeComponent ();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Member membre = KTContext.Db.Members
                .AsNoTracking()
                .Where(m => m.Id == membreId)
                .Include(m => m.MemberPowers)
                .ThenInclude(p => p.Power)
                .Include(m => m.Team.Members)
                .Include(m => m.ModelProfile.Specialists)
                .ThenInclude(e => e.Specialist)
                .Include(m => m.Specialist)
                .Include(m => m.MemberTraits)
                .First();

            Title = membre.Name + " (" + membre.Cost + ")";
            NiveauLabel.Text = Properties.Resources.Niveau + " " + membre.Level;

            List<Specialist> specialites = new List<Specialist>();
            specialites.Add(new Specialist() { NameEn = "None", NameFr = "Aucune", NameDe = "Keine" });
            foreach (ModelProfileSpecialist spec in membre.ModelProfile.Specialists)
            {
                specialites.Add(spec.Specialist);
            }

            ChangeLevelViewModel changeLevelViewModel = new ChangeLevelViewModel
            {
                Specialites = specialites,
                SelectedSpecialiteIndex = specialites.IndexOf(membre.Specialist)
            };

            if (membre.MemberTraits.Select(t => t.TraitId).Contains("G6"))
            {
                changeLevelViewModel.PouvoirMaitreSpe = KTContext.Db.Powers.Include(p => p.Previews).Where(p => p.SpecialistId == membre.SpecialistId).ToList();
                var pouvoir = membre.MemberPowers.Where(p => p.IsMaster).FirstOrDefault();
                if (pouvoir == null)
                    changeLevelViewModel.PouvoirMaitreSpeIndex = 0;
                else
                    changeLevelViewModel.PouvoirMaitreSpeIndex = changeLevelViewModel.PouvoirMaitreSpe.Select(p => p.Id).ToList().IndexOf(pouvoir.PowerId);
            }
            if (membre.MemberTraits.Select(t => t.TraitId).Contains("G5"))
            {
                changeLevelViewModel.PouvoirsGeneralite = KTContext.Db.Powers.Where(p => p.PreviewsId == null).ToList();
                var pouvoir = membre.MemberPowers.Where(p => p.IsGeneral).FirstOrDefault();
                if (pouvoir == null)
                    changeLevelViewModel.PouvoirsGeneraliteIndex = 0;
                else
                    changeLevelViewModel.PouvoirsGeneraliteIndex = changeLevelViewModel.PouvoirsGeneralite.Select(p => p.Id).ToList().IndexOf(pouvoir.PowerId);
            }
			
            if (membre.Specialist == null)
            {
                changeLevelViewModel.SelectedSpecialiteIndex = 0;
            }

            changeLevelViewModel.SelectionPouvoirViewModels = new ObservableCollection<SelectionPouvoirViewModel>();
            foreach (var spe in membre.GetSelectedPowers(changeLevelViewModel))
            {
                changeLevelViewModel.SelectionPouvoirViewModels.Add(spe);
            }
            changeLevelViewModel.SetEnable();
            BindingContext = changeLevelViewModel;
        }

        private void UpdateTitle()
        {
            Member membre = KTContext.Db.Members
                .AsNoTracking()
                .Where(m => m.Id == membreId)
                .Include(m => m.MemberPowers)
                .ThenInclude(p => p.Power)
                .Include(m => m.Team.Members)
                .Include(m => m.ModelProfile.Specialists)
                .ThenInclude(e => e.Specialist)
                .Include(m => m.Specialist)
                .First();

            Title = membre.Name + " (" + membre.Cost + ")";
            NiveauLabel.Text = Properties.Resources.Niveau + " " + membre.Level;
        }

        private void UpdateMembre()
        {
            ChangeLevelViewModel changeLevelViewModel = BindingContext as ChangeLevelViewModel;

            try
            {
                Member membre = KTContext.Db.Members
                    .AsNoTracking()
                    .Where(m => m.Id == membreId)
                    .Include(m => m.MemberPowers)
                    .Include(m => m.ModelProfile.CostOverrides)
                    .Include(m => m.ModelProfile.LevelCosts)
                    .Include(m => m.MemberWeapons)
                    .ThenInclude(m => m.Weapon)
                    .Include(m => m.MemberTraits)
                    .ThenInclude(m => m.Trait)
                    .First();

                foreach (var membrePouvoir in membre.MemberPowers.Where(p => !p.IsGeneral && !p.IsMaster))
                {
                    var mp = KTContext.Db.MemberPowers.AsTracking().Where(m => m.Id == membrePouvoir.Id).First();
                    KTContext.Db.Entry(mp).State = EntityState.Deleted;
                }

                foreach (var pouvoir in changeLevelViewModel.SelectionPouvoirViewModels.Where(sp => sp.IsSelected).Select(sp => sp.Pouvoir))
                {
                    MemberPower mp = new MemberPower();
                    mp.Power = pouvoir;
                    mp.Member = membre;
                    mp.Id = Guid.NewGuid().ToString();
                    KTContext.Db.Entry(mp).State = EntityState.Added;
                }

                if (membre.MemberTraits.Select(t => t.TraitId).Any(id => id == "G5" || id == "G6"))
                    membre.Level = 4;
                else
                    membre.Level = changeLevelViewModel.Niveau;
                membre.UpdateCost();

                Member mb = KTContext.Db.Members.Find(membreId);
                mb.Level = membre.Level;
                mb.Cost = membre.Cost;
                KTContext.Db.Entry(mb).State = EntityState.Modified;


                KTContext.Db.SaveChanges();
                UpdateTitle();
                changeLevelViewModel.SetEnable();
            }catch (Exception ex)
            {
                Crashes.TrackError(ex);

            }
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            UpdateMembre();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeLevelViewModel changeLevelViewModel = BindingContext as ChangeLevelViewModel;
            KTContext.Db.Members.AsTracking().Where(m => m.Id == membreId).First().SpecialistId = changeLevelViewModel.Specialites[changeLevelViewModel.SelectedSpecialiteIndex].Id;
            KTContext.Db.SaveChanges();

            Member membre = KTContext.Db.Members
                .AsNoTracking()
                .Where(m => m.Id == membreId)
                .Include(m => m.MemberPowers)
                .ThenInclude(p => p.Power)
                .Include(m => m.Team.Members)
                .Include(m => m.ModelProfile.Specialists)
                .ThenInclude(s => s.Specialist)
                .Include(m => m.Specialist)
                .First();

            changeLevelViewModel.SelectionPouvoirViewModels.Clear();
            foreach (var spe in membre.GetSelectedPowers(changeLevelViewModel))
            {
                changeLevelViewModel.SelectionPouvoirViewModels.Add(spe);
            }

            UpdateMembre();
        }

        private void Picker_PouvoirsGeneraliteIndexChanged(object sender, EventArgs e)
        {
            ChangeLevelViewModel viewModel = BindingContext as ChangeLevelViewModel;
            Power pouvoir = viewModel.PouvoirsGeneralite[viewModel.PouvoirsGeneraliteIndex];

            MemberPower old = KTContext.Db.MemberPowers.AsTracking().Where(m => m.IsGeneral).FirstOrDefault();
            if (old != null)
                KTContext.Db.Entry(old).State = EntityState.Deleted;

            MemberPower mp = new MemberPower();
            mp.PowerId = pouvoir.Id;
            mp.MembrerId = membreId;
            mp.Id = Guid.NewGuid().ToString();
            mp.IsGeneral = true;
            KTContext.Db.Entry(mp).State = EntityState.Added;

            KTContext.Db.SaveChanges();
        }

        private void Picker_MaitreSpeIndexChanged(object sender, EventArgs e)
        {
            ChangeLevelViewModel viewModel = BindingContext as ChangeLevelViewModel;
            Power pouvoir = viewModel.PouvoirMaitreSpe[viewModel.PouvoirMaitreSpeIndex];

            MemberPower old = KTContext.Db.MemberPowers.AsTracking().Where(m => m.IsMaster).FirstOrDefault();
            if (old != null)
                KTContext.Db.Entry(old).State = EntityState.Deleted;

            MemberPower mp = new MemberPower();
            mp.PowerId = pouvoir.Id;
            mp.MembrerId = membreId;
            mp.Id = Guid.NewGuid().ToString();
            mp.IsMaster = true;
            KTContext.Db.Entry(mp).State = EntityState.Added;

            KTContext.Db.SaveChanges();
        }
    }
}