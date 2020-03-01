using KillTeam.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace KillTeam.ViewModels
{
    public class SelectionPouvoirViewModel : INotifyPropertyChanged
    {
        public SelectionPouvoirViewModel Parent { get; set; }
        public List<SelectionPouvoirViewModel> Childrens { get; set; } = new List<SelectionPouvoirViewModel>();
        public List<SelectionPouvoirViewModel> Brothers { get; set; } = new List<SelectionPouvoirViewModel>();
        private ChangeLevelViewModel changeLevelViewModel;

        public SelectionPouvoirViewModel(ChangeLevelViewModel changeLevelViewModel)
        {
            this.changeLevelViewModel = changeLevelViewModel;
        }

        public Power Pouvoir { get; set; }
        private bool isSelected { get; set; }
        public bool IsSelected
        {
            set
            {
                if (value != isSelected)
                {
                    isSelected = value;
                    if (changeLevelViewModel.Niveau < 3)
                    {
                        foreach (SelectionPouvoirViewModel pvm in Childrens)
                        {
                            pvm.IsEnabled = isSelected;
                            if (!isSelected)
                            {
                                pvm.IsSelected = false;
                            }
                        }

                        if (isSelected)
                        {
                            foreach (SelectionPouvoirViewModel pvm in Brothers)
                            {
                                pvm.IsSelected = false;
                            }
                        }
                    }
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsSelected"));
                }
            }
            get
            {
                return isSelected;
            }
        }

        private bool isEnabled { get; set; }
        public bool IsEnabled
        {
            set
            {
                if (value != isEnabled)
                {
                    isEnabled = value;                    
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsEnabled"));
                }
            }
            get
            {
                return isEnabled;
            }
        }

        public bool IsVisible { get; set; } = true;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
