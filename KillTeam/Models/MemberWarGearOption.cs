using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace KillTeam.Models
{
    public class MemberWarGearOption
    {
        #region Native Properties 

        public string Id { get; set; }

        public string MemberId { get; set; }

        public string WarGearOptionId { get; set; }

        [JsonIgnore] // TODO: keep in the legacy model, remove in the new model, it's unused, but export fails without it
        public string WeaponId { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public Member Member { get; set; }

        [JsonIgnore]
        public WarGearOption WarGearOption { get; set; }

        #endregion Navigation Properties
    }
}
