using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace KillTeam.Models
{
    public class WarGearOption
    {

        // TODO(jakemco): refactor MemberWarGearOption so we can JsonIgnore this
        public string Id { get; set; }

        public int MaximumPerTeam { get; set; }

        //Operation exemple : BO:BOL|(LM&!CAP)|(SN&CAP)
        //Replace BO with : BOL, or LM and CAP (optional), or SN and CAP.
        public string Operation { get; set; }

        //2 warGearOption with the same Exclusion can't be used on the same model.
        public string Exclusion { get; set; }

        [JsonIgnore]
        public string ModelProfileId { get; set; }

        [JsonIgnore]
        public string ModelId { get; set; }

        #region Navigation Properties

        [JsonIgnore]
        public Model Model { get; internal set; }

        [JsonIgnore]
        public ModelProfile ModelProfile { get; internal set; }

        [JsonIgnore]
        public virtual ICollection<MemberWarGearOption> MemberWarGearOptions { get; set; } = new List<MemberWarGearOption>();

        #endregion Navigation Properties

        #region Methods

        public bool IsOption()
        {
            return Regex.IsMatch(Operation, @"^[A-Z0-9]+$");
        }

        #endregion Methods
    }
}
