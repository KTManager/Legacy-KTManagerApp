using KillTeam.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace KillTeam.ViewModels
{
    public class ListPsychiqueViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<ListPsychiqueViewModel> Psychiques { get; set; } = new List<ListPsychiqueViewModel>();
        public int nbPsyConnus { get; set; }

        public Psychic Psychique { get; set; }

        public ListPsychiqueViewModel(int nbPsyConnus, List<ListPsychiqueViewModel> psychiques)
        {
            this.Psychiques = psychiques;
            this.nbPsyConnus = nbPsyConnus;
        }

        private bool selected { get; set; }
        public bool Selected
        {
            set
            {
                if (value != selected)
                {
                    selected = value;

                    if (selected)
                    {
                        //Pouvoirs spécifiques
                        if(Psychique.ModelProfileId != null)
                        {
                            int totalDec = Psychiques.Count(p => p.Selected && p.Psychique.ModelProfileId != null);
                            if (totalDec > nbPsyConnus)
                            {
                                Psychiques.First(p => p.Selected && p.Psychique.Id != Psychique.Id && p.Psychique.ModelProfileId != null).Selected = false;
                            }
                        }

                        //Total de pouvoirs
                        int total = Psychiques.Count(p => p.Selected);
                        if(total > nbPsyConnus+1)
                        {
                            Psychiques.First(p => p.Selected && p.Psychique.Id != Psychique.Id).Selected = false;
                        }

                    }
                    
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Selected"));
                }
            }
            get
            {
                return selected;
            }
        }
    }
}
