using System.Collections.Generic;
using KillTeam.Services;
using Newtonsoft.Json;

namespace KillTeam.Models
{
    public class Phase
    {
        #region Native Properties 

        public string Id { get; set; }

        public string NameEn { get; set; }

        public string NameFr { get; set; }

        public string NameDe { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public IEnumerable<Tactic> Tactics { get; internal set; }

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
