using KillTeam.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KillTeam.Models
{
    public class Weapon : IComparable
    {
        #region Native Properties 

        public string Id { get; set; }

        public int Cost { get; set; }

        public string NameEn { get; set; }

        public string NameFr { get; set; }

        public string NameDe { get; set; }

        public string DescriptionEn { get; set; }

        public string DescriptionFr { get; set; }

        public string DescriptionDe { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        public virtual ICollection<WeaponProfile> WeaponProfiles { get; set; }
        [JsonIgnore]
        public virtual ICollection<MemberWeapon> MemberWeapons { get; set; }
        [JsonIgnore]
        public virtual ICollection<ModelWeapon> ModelWeapons { get; set; }
        [JsonIgnore]
        public virtual ICollection<ModelProfileWeapon> ModelProfileWeapons { get; set; }
        [JsonIgnore]
        public virtual ICollection<MemberWarGearOption> WarGearOptions { get; set; }
        [JsonIgnore]
        public virtual ICollection<CostOverride> CostOverrides { get; set; }

        #endregion Navigation Properties

        #region Calculated Properties

        [JsonIgnore]
        public string ShortName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    return "";
                }
                return string.Concat(Name.Split(new char[] { ' ', '-', '\'' }).Select(s => s.Substring(0, 1).ToUpper()));
            }
        }

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

        public bool IsEquipement()
        {
            return WeaponProfiles.Count == 0;
        }

        public bool IsMultiWeapons()
        {
            return WeaponProfiles.Count > 1;
        }

        public int CompareTo(object obj)
        {
            Weapon other = (Weapon)obj;
            int ret = WeaponProfiles.Count - other.WeaponProfiles.Count;
            if (ret != 0) return ret;

            if (WeaponProfiles.Count > 0)
            {
                ret = WeaponProfiles.First().WeaponType?.Index ?? Int32.MinValue - other.WeaponProfiles.First().WeaponType?.Index ?? Int32.MaxValue;
                if (ret != 0) return ret;

                return WeaponProfiles.First().ShotNumber.CompareTo(other.WeaponProfiles.First().ShotNumber);
            }

            return 0;
        }

        #endregion Methods
    }
}
