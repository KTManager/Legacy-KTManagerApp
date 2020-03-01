using KillTeam.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KillTeam.ViewModels
{
    public class ChangeLevelViewModel
    {
        public ObservableCollection<SelectionPouvoirViewModel> SelectionPouvoirViewModels { get; set; }

        public List<Specialist> Specialites { get; set; }

        public int SelectedSpecialiteIndex { get; set; }

        public List<Power> PouvoirsGeneralite { get; set; } = new List<Power>();

        public int PouvoirsGeneraliteIndex { get; set; }

        public List<Power> PouvoirMaitreSpe { get; set; } = new List<Power>();

        public int PouvoirMaitreSpeIndex { get; set; }

        public bool GeneraliteVisible
        {
            get
            {
                return PouvoirsGeneralite != null && PouvoirsGeneralite.Count > 0;
            }
        }

        public bool MaitreSpeVisible
        {
            get
            {
                return PouvoirsGeneralite != null && PouvoirMaitreSpe.Count > 0;
            }
        }

        public bool IsSpecialiste
        {
            get {
                return SelectedSpecialiteIndex >= 0 && Specialites[SelectedSpecialiteIndex].Id != null;
            }
        }

        public int Niveau
        {
            get
            {
                int niveau = SelectionPouvoirViewModels.Count(s => s.IsSelected) + (IsSpecialiste ? 0 : 1);
                if (niveau == 3 && IsSpecialiste)
                {
                    niveau = SelectionPouvoirViewModels.Where(s => s.IsSelected).Select(p => p.Pouvoir.PreviewsId).Distinct().Count();
                }
                return niveau;
            }
        }

        public void SetEnable()
        {
            int niveau = Niveau;
            bool EnableAll = (!IsSpecialiste && niveau < 4) || (IsSpecialiste && niveau == 3);
            bool DisableAll = (!IsSpecialiste && niveau >= 4) || (IsSpecialiste && niveau >= 4);
            if (niveau <= 3)
            {
                foreach (SelectionPouvoirViewModel spv in SelectionPouvoirViewModels.Where(s => s.Parent != null && !s.Parent.IsSelected))
                {
                    spv.IsSelected = false;
                }
            }
            foreach (SelectionPouvoirViewModel spv in SelectionPouvoirViewModels)
            {
                spv.IsEnabled = spv.IsSelected || EnableAll || (!DisableAll && spv.Parent.IsSelected);
            }
        }

    }
}
