using System.Collections.Generic;
using KillTeam.Models;
using KillTeam.Services;

namespace KillTeam.EvRemp
{
    public class SimpleNode : OperationNode
    {
        public override List<WarGearCombination> Evaluate(List<WarGearCombination> configs, string entry)
        {
            Weapon arme = KTContext.Db.Weapons.Find(entry);
            List<WarGearCombination> conf = new List<WarGearCombination>();
            WarGearCombination copy = new WarGearCombination();
            copy.Weapons.Add(arme);
            conf.Add(copy);            
            return conf;
        }
    }
}