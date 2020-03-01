using Newtonsoft.Json;

namespace KillTeam.Models
{
    public class ModelProfileWeapon
    {
        #region Native Properties 

        [JsonIgnore]
        public string ModelProfileId { get; set; }

        public string WeaponId { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public ModelProfile ModelProfile { get; set; }

        [JsonIgnore]
        public Weapon Weapon { get; set; }

        #endregion Navigation Properties
    }
}

