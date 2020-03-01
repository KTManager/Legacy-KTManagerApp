using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KillTeam.Models
{
    [Table("MembreArme")]
    public class MemberWeapon : IComparable
    {
        #region Native Properties 

        public string Id { get; set; }

        public string WeaponId { get; set; }

        public string MemberId { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public Member Member { get; set; }

        [JsonIgnore]
        public Weapon Weapon { get; set; }
        
        #endregion Navigation Properties

        #region Methods

        public int CompareTo(object obj)
        {
            MemberWeapon other = (MemberWeapon)obj;
            return Weapon.CompareTo(other.Weapon);
        }

        #endregion Methods

    }
}
