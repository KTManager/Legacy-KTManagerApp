using Newtonsoft.Json;

namespace KillTeam.Models
{
    public class ModelProfileSubFaction
    {
        #region Native Properties 

        [JsonIgnore]
        public string ModelProfileId { get; set; }

        public string SubFactionId { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public ModelProfile ModelProfile { get; set; }

        [JsonIgnore]
        public SubFaction SubFaction { get; set; }

        #endregion Navigation Properties
    }
}

