using KillTeam.Models;
using System;
using System.Collections.Generic;

namespace KillTeam.EvRemp
{
    public class FacultatifNode : OperationNode
    {
        public override List<WarGearCombination> Evaluate(List<WarGearCombination> configs, string entry)
        {
            String right = entry.Substring(1);

            //On garde l'ancien sans modif
            List<WarGearCombination> newconf = new List<WarGearCombination>();
            newconf.Add(new WarGearCombination());

            //On ajoute la partie droite
            List<WarGearCombination> confDroite = new GlobalNode().Evaluate(configs, right);
            newconf.AddRange(confDroite);

            return newconf;

        }
    }
}
