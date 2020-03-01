using KillTeam.Services;
using Newtonsoft.Json;

namespace KillTeam.Models
{
    public class AbilityDetail
    {
        #region Native Properties 

        [JsonIgnore]
        public string Id { get; set; }

        [JsonIgnore]
        public string AbilityId { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public string ContentEn { get; set; }

        public string ContentFr { get; set; }

        public string ContentDe { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public virtual Ability Ability { get; set; }

        #endregion Navigation Properties

        #region Calculated Properties

        [JsonIgnore]
        public string Content
        {
            get
            {
                return this.Traduction(nameof(Content));
            }
        }

        #endregion Calculated Properties
    }
}
