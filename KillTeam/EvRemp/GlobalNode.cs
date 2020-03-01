using System.Collections.Generic;
using System.Text.RegularExpressions;
using KillTeam.Models;

namespace KillTeam.EvRemp
{
    public class GlobalNode : OperationNode
    {
        public override List<WarGearCombination> Evaluate(List<WarGearCombination> configs, string entry)
        {
            string nonAlpha = Regex.Replace(entry, "([A-Z1-9]+)", "");


            if (nonAlpha.StartsWith("("))
            {
                return new ParentheseNode().Evaluate(configs, entry);
            }
            else if (nonAlpha.StartsWith("&"))
            {
                return new AddNode().Evaluate(configs, entry);
            }
            else if (nonAlpha.StartsWith("!"))
            {
                return new FacultatifNode().Evaluate(configs, entry);
            }
            else if (nonAlpha.Contains("|"))
            {
                return new OrNode().Evaluate(configs, entry);
            }
            else
            {
                return new SimpleNode().Evaluate(configs, entry);
            }
        }
    }
}
