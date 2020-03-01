using KillTeam.Services;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace KillTeam.Models
{
    public class Power
    {
        #region Native Properties 

        public string Id { get; set; }

        public string NameEn { get; set; }

        public string NameFr { get; set; }

        public string NameDe { get; set; }

        public string PreviewsId { get; set; }

        public string DescriptionEn { get; set; }

        public string DescriptionFr { get; set; }

        public string DescriptionDe { get; set; }

        public string SpecialistId { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public Power Previews { get; set; }

        [JsonIgnore]
        public IEnumerable<MemberPower> MemberPowers { get; internal set; }

        [JsonIgnore]
        public IEnumerable<Power> Nexts { get; internal set; }

        [JsonIgnore]
        public Specialist Specialist { get; internal set; }

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

        #region Methods

        public override string ToString()
        {
            return Name;
        }

        #endregion Methods
    }
}
