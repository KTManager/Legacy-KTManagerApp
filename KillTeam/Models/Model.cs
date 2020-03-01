using KillTeam.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace KillTeam.Models
{
    public class Model
    {
        #region Native Properties 

        public string Id { get; set; }

        [JsonIgnore]
        public string FactionId { get; set; }

        public string NameEn { get; set; }

        public string NameFr { get; set; }

        public string NameDe { get; set; }

        public string KeywordsEn { get; set; }

        public string KeywordsFr { get; set; }

        public string KeywordsDe { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        public virtual ICollection<ModelProfile> ModelProfiles { get; set; }

        [JsonIgnore]
        public virtual ICollection<Ability> Abilities { get; set; }

        public virtual ICollection<ModelWeapon> ModelWeapons { get; set; }

        public virtual ICollection<WarGearOption> WarGearOptions { get; set; }

        [JsonIgnore]
        public virtual Faction Faction { get; set; }

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
        public string Keywords
        {
            get
            {
                return this.Traduction(nameof(Keywords));
            }
        }
        
        #endregion Calculated Properties

        #region Methods

        public IEnumerator<ModelProfile> GetEnumerator()
        {
            return ModelProfiles.GetEnumerator();
        }

        #endregion Methods

    }
}
