using KillTeam.Services;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace KillTeam.Models
{

    // TODO(jakemco): lots of duplicate abilities in the data, lets make
    //   model/profile to ability many to many instead of one to many and re-use
    //   the abilities across models/profiles.
    public class Ability
    {
        #region Native Properties 

        public string Id { get; set; }

        [JsonIgnore]
        public string FactionId { get; set; }
        
        public string ModelId { get; set; }
        
        public string ModelProfileId { get; set; }
        
        public string NameEn { get; set; }
        
        public string NameFr { get; set; }
        
        public string NameDe { get; set; }
        
        public string DescriptionEn { get; set; }
        
        public string DescriptionFr { get; set; }
        
        public string DescriptionDe { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public Faction Faction { get; internal set; }

        [JsonIgnore]
        public Model Model { get; internal set; }

        [JsonIgnore]
        public ModelProfile ModelProfile { get; internal set; }

        public virtual ICollection<AbilityDetail> Details { get; set; }

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
