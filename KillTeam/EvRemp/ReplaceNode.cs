using System;
using System.Collections.Generic;
using KillTeam.Models;

namespace KillTeam.EvRemp
{
    public class ReplaceNode : OperationNode
    {
        public override List<WarGearCombination> Evaluate(List<WarGearCombination> configs, string entry)
        {
            int indexSep = entry.IndexOf(":");
            String right = entry.Substring(indexSep+1);


            List<WarGearCombination> oldconfigs = new List<WarGearCombination>();
            

            if (indexSep >= 0)
            {
                //On retire la partie de gauche
                String left = entry.Substring(0, indexSep);

                List<WarGearCombination> confGauche = new GlobalNode().Evaluate(configs, left);
                foreach (WarGearCombination cg in confGauche)
                {
                    foreach (WarGearCombination old in configs)
                    {
                        WarGearCombination copy = old.Copy();
                        foreach (Weapon arme in cg.Weapons)
                        {
                            copy.Weapons.RemoveAll(a => a.Id == arme.Id);
                        }
                        if (copy.Weapons.Count + cg.Weapons.Count == old.Weapons.Count)
                        {
                            oldconfigs.Add(copy);
                        }
                    }
                }

             }
            else
            {
                //recopie sans modif
                foreach (WarGearCombination old in configs)
                {
                    WarGearCombination copy = old.Copy();
                    oldconfigs.Add(copy);
                }
            }

            List<WarGearCombination> conf = new List<WarGearCombination>();

            //On ajoute la partie droite
            List<WarGearCombination> confDroite = new GlobalNode().Evaluate(configs, right); 

            foreach (WarGearCombination old in oldconfigs)
            {
                foreach(WarGearCombination droite in confDroite)
                {
                    WarGearCombination copy = old.Copy();
                    foreach (Weapon arme in droite.Weapons)
                    {
                        copy.Weapons.Add(arme);
                    }
                    conf.Add(copy);
                }
            }
            return conf;
        }
    }
}