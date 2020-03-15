using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KillTeam.Models;
using KillTeam.Resx;
using KillTeam.Services;
using KillTeam.Views;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace KillTeam.ViewModels
{
    public class ListEquipesViewModel
    {
        public ObservableCollection<Team> ListItems { get; set; }
        public IList<ToolbarItem> ToolbarItems { get; set; }
        public ICommand Sync { get; set; }
        public ICommand Logout { get; set; }
        public ICommand Language { get; set; }
        public ICommand Credits { get; set; }
        public ICommand AddTeam { get; set; }
        public ICommand Delete { get; set; }
        public ICommand OpenTeam { get; set; }

        public ToolbarItem ButtonSync;
        public ToolbarItem ButtonDeco;
        public ToolbarItem ButtonLang;
        public ToolbarItem ButtonCredits;

        public ListEquipesViewModel(IList<ToolbarItem> toolbarItems)
        {
            ListItems = new ObservableCollection<Team>();
            AddTeam = new Command(() => AddTeamExecuted());
            Credits = new Command(async () => await CreditsExecuted());
            Language = new Command(async () => await LanguageExecuted());
            Logout = new Command(() => LogoutExecuted());
            Sync = new Command(async () => await SyncExecuted());
            OpenTeam = new Command(async e => await OpenTeamExecuted(e as Team));
            Delete = new Command(async e => await DeleteExecuted(e as Team));

            ButtonSync = new ToolbarItem
            {
                Text = Translate.Synchro,
                Order = ToolbarItemOrder.Secondary,
                Command = Sync
            };
            
            ButtonDeco = new ToolbarItem
            {
                Text = Translate.Deconnection,
                Order = ToolbarItemOrder.Secondary,
                Command = Logout
            };
            
            ButtonLang = new ToolbarItem
            {
                Text = Translate.Language,
                Order = ToolbarItemOrder.Secondary,
                Command = Language
            };
            
            ButtonCredits = new ToolbarItem
            {
                Text = Translate.Remerciement,
                Order = ToolbarItemOrder.Secondary,
                Command = Credits
            };

            ToolbarItems = toolbarItems;
            ToolbarItems.Add(ButtonSync);
            ToolbarItems.Add(ButtonDeco);
            ToolbarItems.Add(ButtonLang);
            ToolbarItems.Add(ButtonCredits);
        }

        public async Task OpenTeamExecuted(Team equipe)
        {
            await KTApp.Navigation.PushAsync(new EquipePage(equipe.Id));
        }

        public async Task Refresh()
        {
            if (Device.RuntimePlatform != Device.Android)
            {
                ToolbarItems.Remove(ButtonDeco);
                ToolbarItems.Remove(ButtonSync);
                
                await UpdateListItems();

                return;
            }

            if (Sauvegarde.IsConnected() && await Sauvegarde.Synchro(KTContext.Db))
            {
                await UpdateListItems();
            }

            DecoUpdate();

            await UpdateListItems();
        }

        private void DecoUpdate()
        {
            if (!Sauvegarde.IsConnected())
            {
                ToolbarItems.Remove(ButtonDeco);
            }
            else if (!ToolbarItems.Contains(ButtonDeco))
            {
                ToolbarItems.Add(ButtonDeco);
            }
        }

        public async Task UpdateListItems()
        {
            ListItems.Clear();
            var teams = await KTContext.Db.Teams
                                    .Include(e => e.Faction)
                                    .Include(e => e.Members)
                                    .AsNoTracking()
                                    .OrderBy(post => post.Position)
                                    .ToListAsync();
            teams.ForEach(i => ListItems.Add(i));
        }

        public void AddTeamExecuted()
        {
            KTApp.Navigation.PushModalAsync(new FactionsPage());
        }

        public void LogoutExecuted()
        {
            Sauvegarde.Logout();
            DecoUpdate();
        }

        public async Task SyncExecuted()
        {
            Sauvegarde.Login();
            if (await Sauvegarde.Synchro(KTContext.Db))
            {
                await UpdateListItems();
            }
            DecoUpdate();
        }

        public async Task LanguageExecuted()
        {
            await KTApp.Navigation.PushAsync(new LanguagePage());
        }

        public async Task CreditsExecuted()
        {
            await KTApp.Navigation.PushAsync(new RemerciementPage());
        }

        public async Task DeleteExecuted(Team team)
        {
            //FindAllForTeam<MemberTrait>(m => m.Member.TeamId == team.Id)
            //    .ForEach(mt => SetEntityToDeleted<MemberTrait>(mt.Id));

            //FindAllForTeam<MemberPsychic>(p => p.Member?.TeamId == team.Id)
            //    .ForEach(mp => SetEntityToDeleted<MemberPsychic>(mp.Id));

            //FindAllForTeam<MemberPower>(p => p.Member?.TeamId == team.Id)
            //    .ForEach(mp => SetEntityToDeleted<MemberPower>(mp.Id));

            //FindAllForTeam<MemberWeapon>(a => a.Member?.TeamId == team.Id)
            //    .ForEach(ma => SetEntityToDeleted<MemberWeapon>(ma.Id));

            //FindAllForTeam<MemberWarGearOption>(r => r.Member?.TeamId == team.Id)
            //    .ForEach(mr => SetEntityToDeleted<MemberWarGearOption>(mr.Id));

            //FindAllForTeam<Member>(m => m.TeamId == team.Id)
            //    .ForEach(m => SetEntityToDeleted<Member>(m.Id));

            foreach (MemberTrait ma in KTContext.Db.MemberTraits.Where(m => m.Member.TeamId == team.Id).AsNoTracking().ToList())
            {
                MemberTrait mad = KTContext.Db.MemberTraits.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }

            foreach (MemberPsychic ma in KTContext.Db.MemberPsychics.Where(m => m.Member.TeamId == team.Id).AsNoTracking().ToList())
            {
                MemberPsychic mad = KTContext.Db.MemberPsychics.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }

            foreach (MemberPower ma in KTContext.Db.MemberPowers.Where(m => m.Member.TeamId == team.Id).AsNoTracking().ToList())
            {
                MemberPower mad = KTContext.Db.MemberPowers.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }

            foreach (MemberWeapon ma in KTContext.Db.MemberWeapons.Where(m => m.Member.TeamId == team.Id).AsNoTracking().ToList())
            {
                MemberWeapon mad = KTContext.Db.MemberWeapons.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }

            foreach (MemberWarGearOption ma in KTContext.Db.MemberWarGearOptions.Where(m => m.Member.TeamId == team.Id).AsNoTracking().ToList())
            {
                MemberWarGearOption mad = KTContext.Db.MemberWarGearOptions.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }

            foreach (Member ma in KTContext.Db.Members.Where(m => m.TeamId == team.Id).AsNoTracking().ToList())
            {
                Member mad = KTContext.Db.Members.Find(ma.Id);
                KTContext.Db.Entry(mad).State = EntityState.Deleted;
            }

            SetEntityToDeleted<Team>(team.Id);

            try
            {
                KTContext.Db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Debug.Write(e.InnerException);
            }

            await UpdateListItems();
        }

        private static List<T> FindAllForTeam<T>(Func<T, bool> predicate) where T : class
        {
            return KTContext.Db.Set<T>().AsNoTracking().AsEnumerable().Where(predicate).ToList();
        }

        public void SetEntityToDeleted<T>(string id) where T : class
        {
            var entity = KTContext.Db.Set<T>().Find(id);
            KTContext.Db.Entry(entity).State = EntityState.Deleted;
        }
    }
}
