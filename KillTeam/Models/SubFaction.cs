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

        public string DescriptionEn { get; set; }

        public string DescriptionFr { get; set; }

        public string DescriptionDe { get; set; }

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

        [JsonIgnore]
        public string Description
        {
            get
            {
                return this.Traduction(nameof(Description));
            }
        }

        #endregion Calculated Properties
    }
}
