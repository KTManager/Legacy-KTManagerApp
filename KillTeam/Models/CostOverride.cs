using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace KillTeam.Models
{
    public class CostOverride
    {
        #region Native Properties 

        [JsonIgnore]
        public string Id { get; set; }

        [JsonIgnore]
        public string ModelProfileId { get; set; }

        public string WeaponId { get; set; }

        public int Cost { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public ModelProfile ModelProfile { get; set; }

        [JsonIgnore]
        public Weapon Weapon { get; set; }

        #endregion Navigation Properties

    }
}
