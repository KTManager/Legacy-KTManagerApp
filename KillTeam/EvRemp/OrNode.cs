using KillTeam.Models;
using System;
using System.Collections.Generic;

namespace KillTeam.EvRemp
{
    public class OrNode : OperationNode
    {
        public override List<WarGearCombination> Evaluate(List<WarGearCombination> configs, string entry)
        {
            int indexSep = entry.IndexOf("|");
            String left = entry.Substring(0, indexSep);
            String right = entry.Substring(indexSep + 1);

            List<WarGearCombination> newconf = new List<WarGearCombination>();

            //On ajoute la partie droite
            List<WarGearCombination> confGauche;
            if (left.Length>0)
            {
                confGauche = new GlobalNode().Evaluate(configs, left);
            }
            else
            {
                confGauche = new List<WarGearCombination>();
                foreach(WarGearCombination config in configs)
                {
                    confGauche.Add(config.Copy());
                }
            }
            List<WarGearCombination> confDroite = new GlobalNode().Evaluate(configs, right);


            newconf.AddRange(confGauche);
            newconf.AddRange(confDroite);
            
            return newconf;

        }
    }
}
