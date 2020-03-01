using Newtonsoft.Json;

namespace KillTeam.Models
{
    public class MemberPower
    {
        #region Native Properties 

        public string Id { get; set; }

        public string MembrerId { get; set; }

        public string PowerId { get; set; }

        public bool IsGeneral { get; set; }

        public bool IsMaster { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        [JsonIgnore]
        public Member Member { get; set; }

        [JsonIgnore]
        public Power Power { get; set; }
        
        #endregion Navigation Properties
    }
}
