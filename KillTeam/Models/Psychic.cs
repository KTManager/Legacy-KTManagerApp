using System.Collections.Generic;
using KillTeam.Services;
using Newtonsoft.Json;

namespace KillTeam.Models
{
    // TODO(jakemco): similar to abilities, these can probably be re-used
    //   across multiple models with a junction table.
    public class Psychic
    {
        #region Native Properties 

        public string Id { get; set; }

        public string ModelProfileId { get; set; }

        public int WarpCharge { get; set; }

        public int Dices { get; set; }

        public string NameEn { get; set; }

        public string NameFr { get; set; }

        public string NameDe { get; set; }

        public string DescriptionEn { get; set; }

        public string DescriptionFr { get; set; }

        public string DescriptionDe { get; set; }

        public bool Commander { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public IEnumerable<MemberPsychic> MemberPsychics { get; internal set; }

        [JsonIgnore]
        public ModelProfile ModelProfile { get; internal set; }

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
        public string Discipline
        {
            get
            {
                return ModelProfileId == null ? "" : Resx.Translate.Discipline;
            }
        }

        #endregion Calculated Properties
    }
}
