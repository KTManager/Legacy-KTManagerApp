using KillTeam.Services;
using Newtonsoft.Json;

namespace KillTeam.Models
{
    public class WeaponProfile
    {
        #region Native Properties 

        public string Id { get; set; }

        public string NameEn { get; set; }
        
        public string NameFr { get; set; }
        
        public string NameDe { get; set; }
        
        public string DescriptionEn { get; set; }
        
        public string DescriptionFr { get; set; }
        
        public string DescriptionDe { get; set; }
        
        public int Range { get; set; }
        
        public string ShotNumber { get; set; }
        
        public string Strength { get; set; }
        
        public string ArmourPenetration { get; set; }
        
        public string Damages { get; set; }
        
        [JsonIgnore]
        public string WeaponId { get; set; }
        
        public string WeaponTypeId { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public virtual Weapon Weapon { get; set; }

        [JsonIgnore]
        public virtual WeaponType WeaponType { get; set; }

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

        [JsonIgnore]
        public string Type
        {
            get
            {
                return WeaponType?.Name + (WeaponType?.Id != "M" ? (" " + ShotNumber) : "");
            }
        }

        #endregion Calculated Properties
    }
}
