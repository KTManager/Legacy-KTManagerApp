using Newtonsoft.Json;

namespace KillTeam.Models
{
    public class ModelProfileSpecialist
    {
        #region Native Properties 

        [JsonIgnore]
        public string ModelProfileId { get; set; }

        public string SpecialistId { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public ModelProfile ModelProfile { get; set; }

        [JsonIgnore]
        public Specialist Specialist { get; set; }

        #endregion Navigation Properties
    }
}
