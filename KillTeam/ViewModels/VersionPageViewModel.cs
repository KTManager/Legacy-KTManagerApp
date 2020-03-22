using KillTeam.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;

namespace KillTeam.ViewModels
{

    class VersionInfo
    {
        public string Title;
        public string Detail;
    }
    class VersionPageViewModel
    {
        private ObservableCollection<VersionInfo> versionList;
        public ObservableCollection<VersionInfo> VersionList => versionList;
        public VersionPageViewModel()
        {
            var userDB = KTContext.Db as KTUserContext;

            versionList.Add(new VersionInfo { Title = "App Version", Detail = VersionTracking.CurrentVersion });
            versionList.Add(new VersionInfo { Title = "Rules Version", Detail = userDB.GetCurrentVersion().RulesVersion });

            var importVersion = userDB.GetCurrentVersion().AppVersion;
            if (importVersion != null)
            {
                versionList.Add(new VersionInfo { Title = "Last Rules Import App Version", Detail = importVersion });
            }
        }
    }
}
