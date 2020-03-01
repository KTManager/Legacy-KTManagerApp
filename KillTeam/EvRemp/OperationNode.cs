using KillTeam.Models;
using System.Collections.Generic;

namespace KillTeam.EvRemp
{
    public abstract class OperationNode
    {
        public OperationNode m_Op1 { get; set; }
        public OperationNode m_Op2 { get; set; }

        public abstract List<WarGearCombination> Evaluate(List<WarGearCombination> configs, string entry);
    }
}
