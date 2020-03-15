using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KillTeam.Models
{
    public class SaveModel
    {
        public List<Team> Teams { get; set; }
        public DateTime DateTime { get; set; }

        [JsonIgnore]
        public int Size {
            get {
                return Teams.Sum(team => team.Members.Count);
            }
        }
    }
}
