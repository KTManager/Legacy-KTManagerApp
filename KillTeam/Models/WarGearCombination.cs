using System.Collections.Generic;
using System.Linq;

namespace KillTeam.Models
{
    public class WarGearCombination
    {
        public bool Selected { get; set; }
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public List<WarGearOption> WarGearOption { get; set; } = new List<WarGearOption>();
        public List<CostOverride> CostOverrides { get; set; } = new List<CostOverride>();

        public string Resume
        {
            get
            {
                return ToString();
            }
        }

        public WarGearCombination Copy()
        {
            WarGearCombination conf = new WarGearCombination();
            conf.Weapons.AddRange(Weapons);
            CostOverrides.AddRange(CostOverrides);
            return conf;
        }

        public string GetEquation()
        {
            string str = "";

            foreach (Weapon arme in Weapons)
            {
                str += arme.Id + "&";
            }

            str = str.Substring(0, str.Length - 1);
            return str;
        }

        public override string ToString()
        {
            string str = "";

            int cost = 0;
            foreach (Weapon arme in Weapons)
            {
                str += arme + ", ";
                if(CostOverrides.Any(s => s.WeaponId == arme.Id))
                {
                    cost += CostOverrides.First(s => s.WeaponId == arme.Id).Cost;
                }
                else
                {
                    cost += arme.Cost;
                }
            }

            if (str.Length > 2)
            {
                str = str.Substring(0, str.Length - 2);
            }

            if(cost > 0)
            {
                str += " (+"+ cost + ")";
            }

            return str;

        }
    }
}
