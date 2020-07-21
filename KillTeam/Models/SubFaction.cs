using KillTeam.Services;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace KillTeam.Models
{
    public class SubFaction
    {
        #region Native Properties 

        public string Id { get; set; }

        public string NameEn { get; set; }

        public string NameFr { get; set; }

        public string NameDe { get; set; }

        #endregion Native Properties

        #region Navigation Properties

        public Faction Faction { get; set; }

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


        #endregion Calculated Properties
    }
}
