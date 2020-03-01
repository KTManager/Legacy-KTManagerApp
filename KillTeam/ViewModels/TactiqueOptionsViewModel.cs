using System;
using System.Collections.Generic;
using Microsoft.AppCenter.Crashes;

namespace KillTeam.ViewModels
{
    public class TactiqueOptionsViewModel
    {
        public List<string> ChoosedPhase { get; set; } = new List<string>();

        private bool faction;
        public bool Faction
        {
            get
            {
                try
                {
                    faction = (bool)Xamarin.Forms.Application.Current.Properties["Faction"];
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);
                    faction = true;
                }
                return faction;
            }
            set
            {
                Xamarin.Forms.Application.Current.Properties["Faction"] = value;
            }
        }

        private bool specialite;
        public bool Specialite
        {
            get
            {
                try
                {
                    specialite = (bool)Xamarin.Forms.Application.Current.Properties["Specialite"];
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);
                    specialite = true;
                }
                return specialite;
            }
            set
            {
                Xamarin.Forms.Application.Current.Properties["Specialite"] = value;
            }
        }

        private bool generale;
        public bool Generale
        {
            get
            {
                try
                {
                    generale = (bool)Xamarin.Forms.Application.Current.Properties["Generale"];
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);
                    generale = true;
                }
                return generale;
            }
            set
            {
                Xamarin.Forms.Application.Current.Properties["Generale"] = value;
            }
        }

        private bool declinaison;
        public bool Declinaison
        {
            get
            {
                try
                {
                    declinaison = (bool)Xamarin.Forms.Application.Current.Properties["Declinaison"];
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);
                    declinaison = true;
                }
                return declinaison;
            }
            set
            {
                Xamarin.Forms.Application.Current.Properties["Declinaison"] = value;
            }
        }
    }
}
