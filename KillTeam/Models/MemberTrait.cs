using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace KillTeam.Models
{
    public class MemberTrait
    {
        #region Native Properties 

        public string Id { get; set; }

        public string MemberId { get; set; }

        public string TraitId { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public Member Member { get; set; }

        [JsonIgnore]
        public Trait Trait { get; set; }


        #endregion Navigation Properties

    }
}
