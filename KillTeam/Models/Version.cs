using System;
using System.Collections.Generic;
using System.Text;

namespace KillTeam.Models
{
    public class Version
    {
        public int Id { get; set; } // TODO: `PRIMARY KEY CHECK (id = 0),`

        //TODO: public DateTime ImportType { get; set; }

        public string RulesVersion { get; set; }

        public string AppVersion { get; set; }
    }
}
