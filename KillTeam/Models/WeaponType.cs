using System.Collections.Generic;
using KillTeam.Services;
using Newtonsoft.Json;

namespace KillTeam.Models
{
    public class WeaponType
    {
        #region Native Properties 

        public string Id { get; set; }

        public int Index { get; set; }
        
        public string NameEn { get; set; }

        public string NameFr { get; set; }

        public string NameDe { get; set; }

        #endregion Native Properties 

        #region Navigation Properties



        #endregion Navigation Properties

        #region Calculated Properties

        [JsonIgnore]
        public string Name
        {
            get
            {
                return this.Traduction(nameof(Name));
            }
        }

        [JsonIgnore]
        public IEnumerable<WeaponProfile> WeaponProfiles { get; internal set; }

        #endregion Calculated Properties

    }
}
