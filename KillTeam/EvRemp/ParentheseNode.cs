using KillTeam.Models;
using System.Collections.Generic;

namespace KillTeam.EvRemp
{
    public class ParentheseNode : OperationNode
    {
        public override List<WarGearCombination> Evaluate(List<WarGearCombination> configs, string entry)
        {
            int indexParentheseFermente = 1;
            int nbOuvrante = 1;

            for (; indexParentheseFermente < entry.Length; indexParentheseFermente++)
            {
                if (entry[indexParentheseFermente] == '(')
                {
                    nbOuvrante++;
                }

                else if (entry[indexParentheseFermente] == ')')
                {
                    nbOuvrante--;
                }
                if(nbOuvrante==0)
                {
                    break;
                }
            }

            string between = entry.Substring(1, indexParentheseFermente-1);
            string betweenAvecPar = entry.Substring(0, indexParentheseFermente+1);


            //calcul la partie entre parenthèse
            List<WarGearCombination> confDroite = new GlobalNode().Evaluate(new List<WarGearCombination>(), between);

            List<WarGearCombination> newconf = new List<WarGearCombination>();
            foreach (WarGearCombination conf in confDroite)
            {
                string precalcul = entry.Replace(betweenAvecPar, "");
                if (precalcul.Length > 0)
                {
                    List<WarGearCombination> lc = new List<WarGearCombination>();
                    lc.Add(conf.Copy());
                    newconf.AddRange(new GlobalNode().Evaluate(lc, precalcul));
                }
                else
                {
                    newconf.Add(conf);
                }
            }

            return newconf;

        }
    }
}
