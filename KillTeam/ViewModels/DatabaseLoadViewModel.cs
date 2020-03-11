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

        private void OnUpdate(object _sender, string msg)
        {
            Device.BeginInvokeOnMainThread(() => this.Message = msg);
        }

        string message;

        public string Message {
            set {
                if (message != value)
                {
                    message = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(nameof(Message)));
                    }
                }
            }

            get {
                return message;
            }
        }
    }
}
