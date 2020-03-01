using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace KillTeam.Models
{
    public class LevelCost
    {
        #region Native Properties 

        [JsonIgnore]
        public string Id { get; set; }

        public int Level { get; set; }

        public int Cost { get; set; }

        [JsonIgnore]
        public string ModelProfileId { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public ModelProfile ModelProfile { get; set; }

        #endregion Navigation Properties


    }
}
