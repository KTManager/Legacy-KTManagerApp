using KillTeam.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;

namespace KillTeam.ViewModels
{

    public class VersionInfo
    {
        public string Title { get; set; }
        public string Detail { get; set; }
    }
    class VersionPageViewModel
    {
        public ObservableCollection<VersionInfo> VersionList { get; } = new ObservableCollection<VersionInfo>();
        public VersionPageViewModel()
        {
            var userDB = KTContext.Db as KTUserContext;

            VersionList.Add(new VersionInfo { Title = "App Version", Detail = VersionTracking.CurrentVersion });
            VersionList.Add(new VersionInfo { Title = "Rules Version", Detail = userDB.GetCurrentVersion().RulesVersion });

            var importVersion = userDB.GetCurrentVersion().AppVersion;
            if (importVersion != null)
            {
                VersionList.Add(new VersionInfo { Title = "Last Rules Import App Version", Detail = importVersion });
            }
        }
    }
}
