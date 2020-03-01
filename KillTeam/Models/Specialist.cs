using KillTeam.Services;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KillTeam.Models
{
    public class Specialist
    {
        #region Native Properties 

        public string Id { get; set; }

        public string NameEn { get; set; }

        public string NameFr { get; set; }

        public string NameDe { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public virtual ICollection<ModelProfileSpecialist> ModelProfileSpecialists { get; set; }

        [JsonIgnore]
        public virtual ICollection<Tactic> Tactics { get; set; }

        [JsonIgnore]
        public virtual ICollection<Power> Powers { get; set; }

        [JsonIgnore]
        public virtual ICollection<Member> Members { get; set; }

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

        #region Constructors



        #endregion Constructors

        #region Methods

        public override string ToString()
        {
            return Name;
        }

        #endregion Methods
    }
}
