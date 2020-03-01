using System;
using System.ComponentModel;
using Microsoft.AppCenter.Crashes;

namespace KillTeam.Models
{
    public class PdfConfiguration : INotifyPropertyChanged
    {
        public bool GroupIdenticalMembers
        {
            get
            {
                try
                {
                    return (bool)Xamarin.Forms.Application.Current.Properties["RegrouperIdentique"];
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);
                    return false;
                }
            }
            set
            {
                Xamarin.Forms.Application.Current.Properties["RegrouperIdentique"] = value;
            }
        }

        public bool AbilityDetails
        {
            get
            {
                try
                {
                    return (bool)Xamarin.Forms.Application.Current.Properties["DetailAptitudes"];
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);
                    return false;
                }
            }
            set
            {
                Xamarin.Forms.Application.Current.Properties["DetailAptitudes"] = value;
            }
        }

        public bool Compact
        {
            get
            {
                try
                {
                    return (bool)Xamarin.Forms.Application.Current.Properties["Compact"];
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);
                    return false;
                }
            }
            set
            {
                Xamarin.Forms.Application.Current.Properties["Compact"] = value;
            }
        }

        public bool XpRecruitConvalescence
        {
            get
            {
                try
                {
                    return (bool)Xamarin.Forms.Application.Current.Properties["XPRecrueConvalescence"];
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);
                    return false;
                }
            }
            set
            {
                Xamarin.Forms.Application.Current.Properties["XPRecrueConvalescence"] = value;
            }
        }

        public bool Tactics
        {
            get
            {
                try
                {
                    return (bool)Xamarin.Forms.Application.Current.Properties["Tactiques"];
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);
                    return false;
                }
            }
            set
            {
                Xamarin.Forms.Application.Current.Properties["Tactiques"] = value;
            }
        }

        public bool GroupAbilities
        {
            get
            {
                try
                {
                    return (bool)Xamarin.Forms.Application.Current.Properties["RegrouperAptitudes"];
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);
                    return false;
                }
            }
            set
            {
                Xamarin.Forms.Application.Current.Properties["RegrouperAptitudes"] = value;
            }
        }

        public bool OfficialPdf
        {
            get
            {
                try
                {
                    return (bool)Xamarin.Forms.Application.Current.Properties["PdfOfficiel"];
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);
                    return false;
                }
            }
            set
            {
                Xamarin.Forms.Application.Current.Properties["PdfOfficiel"] = value;
            }
        }

        private bool generateButtonVisible = true;
        private bool busyIndicatorVisible = false;
        private bool openButtonVisible = false;
        public bool GenerateButtonVisible
        {
            get
            {
                return generateButtonVisible;
            }
            set
            {
                generateButtonVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GenerateButtonVisible"));
            }
        }
        public bool BusyIndicatorVisible
        {
            get
            {
                return busyIndicatorVisible;
            }
            set
            {
                busyIndicatorVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BusyIndicatorVisible"));
            }
        }
        public bool OpenButtonVisible
        {
            get
            {
                return openButtonVisible;
            }
            set
            {
                openButtonVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OpenButtonVisible"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
