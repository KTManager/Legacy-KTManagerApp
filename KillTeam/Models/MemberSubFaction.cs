using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace KillTeam.Models
{
    public class MemberSubFaction
    {
        #region Native Properties 

        public string Id { get; set; }

        public string MemberId { get; set; }

        public string SubFactionId { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public Member Member { get; set; }

        [JsonIgnore]
        public SubFaction SubFaction { get; set; }

        #endregion Navigation Properties
    }
}
