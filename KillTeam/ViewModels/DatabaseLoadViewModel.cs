using KillTeam.Services;
using KillTeam.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace KillTeam.ViewModels
{
    public class DatabaseLoadViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DatabaseLoadViewModel()
        {
            // TODO
            ThreadPool.QueueUserWorkItem(_o => this.UpdateDB());
        }

        private void UpdateDB()
        {
            KTContext.UpdateEvent += OnUpdate;
            var _ = KTContext.Db; // trigger lazy load
            Device.BeginInvokeOnMainThread(() => {
                KTApp.Current.MainPage = new NavigationPage(new ListEquipesPage());
            });
        }

        private void OnUpdate(object _sender, UpdateEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => {
                if (e.Message != null)
                {
                    this.Message = e.Message;
                }
                this.Percent = e.Percent;
                this.SubMessage = e.SubMessage;
            });
        }

        string message;

        public string Message {
            set {
                if (message != value)
                {
                    message = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));
                }
            }

            get => message;
        }

        float? percent;
        public float? Percent {
            set {
                if (percent != value)
                {
                    percent = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Percent)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsPercentNull)));
                }
            }
            get => percent != null ? percent : 0;
        }

        public bool IsPercentNull => percent == null;

        string submessage;
        public string SubMessage {
            set {
                if (submessage != value)
                {
                    submessage = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SubMessage)));
                }
            }
            get => submessage;
        }
    }
}
