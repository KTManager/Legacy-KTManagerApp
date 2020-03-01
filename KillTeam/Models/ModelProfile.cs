using KillTeam.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KillTeam.Models
{
    public class ModelProfile
    {
        #region Native Properties 

        public string Id { get; set; }

        [JsonIgnore]
        public string ModelId { get; set; }

        public int Movement { get; set; }

        public int WeaponSkill { get; set; }

        public int BallisticSkill { get; set; }

        public int Strength { get; set; }

        public int Toughness { get; set; }

        public int Wounds { get; set; }

        public string Attacks { get; set; }

        public int Leadership { get; set; }

        public int Save { get; set; }

        public int MaximumNumber { get; set; }

        public int Cost { get; set; }

        public string NameEn { get; set; }

        public string NameFr { get; set; }

        public string NameDe { get; set; }

        public bool IsCommander { get; set; }

        public int NumberOfKnownPsychics { get; set; }

        public int NumberOfPsychicsManifestationPerRound { get; set; }

        public int NumberOfPsychicsDenialPerRound { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public virtual Model Model { get; set; }

        [JsonIgnore]
        public virtual ICollection<Ability> Abilities { get; set; }

        public virtual ICollection<WarGearOption> WarGearOptions { get; set; }

        public virtual ICollection<ModelProfileSpecialist> Specialists { get; set; }

        public virtual ICollection<ModelProfileWeapon> ModelProfileWeapons { get; set; }

        [JsonIgnore]
        public virtual ICollection<Trait> Traits { get; set; }

        [JsonIgnore]
        public virtual ICollection<Psychic> Psychics { get; set; }

        public virtual ICollection<CostOverride> CostOverrides { get; set; }

        public virtual ICollection<LevelCost> LevelCosts { get; set; }

        [JsonIgnore]
        public virtual ICollection<Tactic> Tactics { get; set; }

        [JsonIgnore]
        public virtual ICollection<Member> Members { get; set; }

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
        public bool IsPsyker
        {
            get
            {
                return NumberOfKnownPsychics > 0;
            }
        }

        [JsonIgnore]
        public string FormattedCost
        {
            get
            {
                return Cost + " " + Resx.Translate.Points;
            }
        }

        [JsonIgnore]
        public string FormattedMaximumNumber
        {
            get
            {
                return MaximumNumber == 0 ? "" : (MaximumNumber + " Max.");
            }
        }

        #endregion Calculated Properties

        #region Methods

        public ICollection<WarGearOption> GetAllWarGearOptions()
        {
            List<WarGearOption> remp = new List<WarGearOption>();
            remp.AddRange(Model.WarGearOptions);
            remp.AddRange(WarGearOptions);
            return remp;
        }

        #endregion Methods
    }
}
