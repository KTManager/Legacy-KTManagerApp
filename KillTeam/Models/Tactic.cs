using KillTeam.Services;
using Newtonsoft.Json;

namespace KillTeam.Models
{
    public class Tactic
    {
        #region Native Properties 

        public string Id { get; set; }

        [JsonIgnore]
        public string FactionId { get; set; }

        public string SpecialistId { get; set; }

        public string ModelProfileId { get; set; }

        public string PhaseId { get; set; }

        public bool Aura { get; set; }

        public bool Commander { get; set; }

        public string NameEn { get; set; }

        public string NameFr { get; set; }

        public string NameDe { get; set; }

        public string DescriptionEn { get; set; }

        public string DescriptionFr { get; set; }

        public string DescriptionDe { get; set; }

        public int Level { get; set; }

        public int Cost { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public Phase Phase { get; set; }

        [JsonIgnore]
        public Faction Faction { get; set; }

        [JsonIgnore]
        public Specialist Specialist { get; set; }

        [JsonIgnore]
        public ModelProfile ModelProfile { get; set; }

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
