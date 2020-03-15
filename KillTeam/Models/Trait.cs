using System.Collections.Generic;
using KillTeam.Properties;
using KillTeam.Services;
using Newtonsoft.Json;

namespace KillTeam.Models
{
    public class Trait
    {
        #region Native Properties

        public string Id { get; set; }

        public string ModelProfileId { get; set; }

        public int Level { get; set; }

        public int Cost { get; set; }

        public string NameEn { get; set; }

        public string NameFr { get; set; }

        public string NameDe { get; set; }

        public string DescriptionEn { get; set; }

        public string DescriptionFr { get; set; }

        public string DescriptionDe { get; set; }

        #endregion Native Properties

        #region Navigation Properties

        [JsonIgnore]
        public IEnumerable<MemberTrait> MemberTraits { get; internal set; }
        
        #endregion Navigation Properties

        #region Calculated Properties

        [JsonIgnore]
        public string Name => this.Traduction(nameof(Name));

        [JsonIgnore]
        public string Description => this.Traduction(nameof(Description));

        [JsonIgnore]
        public ModelProfile ModelProfile { get; internal set; }

        #endregion Calculated Properties


    }
}
