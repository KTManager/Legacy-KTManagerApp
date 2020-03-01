using Newtonsoft.Json;

namespace KillTeam.Models
{
    public class ModelWeapon
    {
        #region Native Properties 

        [JsonIgnore]
        public string ModelId { get; set; }

        public string WeaponId { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public Model Model { get; set; }

        [JsonIgnore]
        public Weapon Weapon { get; set; }

        #endregion Navigation Properties
    }
}
