using KillTeam.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;

namespace KillTeam.ViewModels
{
    class VersionPageViewModel
    {
        public VersionPageViewModel() { }

        public string AppVersion {
            get => VersionTracking.CurrentVersion;
        }

        public string RulesVersion {
            get => (KTContext.Db as KTUserContext).GetCurrentVersion().RulesVersion;
        }
    }
}
