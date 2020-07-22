using KillTeam.EvRemp;
using KillTeam.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Internals;

namespace KillTeam.Models
{
    public class PossibleSwap
    {
        public List<Weapon> FixedWeapons { get; set; } = new List<Weapon>();
        public List<WarGearCombination> OptionalWeapons { get; set; } = new List<WarGearCombination>();
        public List<WarGearCombination> WarGearCombinations { get; set; } = new List<WarGearCombination>();
        public Member Member { get; set; }

        public static PossibleSwap Create(String membreId)
        {
            PossibleSwap cp = new PossibleSwap();

            //On recupere complètement les données nécessaires
            cp.Member = KTContext.Db.Members.Where(m => m.Id == membreId)
                .Include(m => m.Team)
                .Include(m => m.MemberWarGearOptions)
                .Include(m => m.MemberWeapons)
                .Include(m => m.ModelProfile.CostOverrides)
                .Include(m => m.ModelProfile.WarGearOptions)
                .Include(m => m.ModelProfile.Model.WarGearOptions)
                .Include(m => m.ModelProfile.Model.ModelWeapons)
                .ThenInclude(sn => sn.Weapon)
                .Include(m => m.ModelProfile.ModelProfileWeapons)
                .ThenInclude(sn => sn.Weapon)
                .AsNoTracking()
                .First();

            List<CostOverride> costOverrides = cp.Member.ModelProfile.CostOverrides.ToList();
            List<Weapon> baseWeapon = cp.Member.GetDefaultWeapons();

            //Configuration de base
            WarGearCombination combination = new WarGearCombination() { Weapons = baseWeapon };
            cp.WarGearCombinations.Add(combination);


            //On passe toutes les modifs sans exclusions
            ICollection<WarGearOption> remplPossibles = cp.Member.ModelProfile.GetAllWarGearOptions();            
            foreach (WarGearOption remplacement in remplPossibles.Where(r => String.IsNullOrWhiteSpace(r.Exclusion)))
            {
                //Remplacement limité en nombre
                if(remplacement.MaximumPerTeam>0 && !cp.Member.Team.Roster)
                {
                    int nbUsed = KTContext.Db.MemberWarGearOptions.Count(mr => mr.Member.TeamId == cp.Member.TeamId && mr.MemberId != cp.Member.Id && mr.WarGearOptionId == remplacement.Id);
                    if (nbUsed >= remplacement.MaximumPerTeam)
                    {
                        continue;
                    }
                }

                if(remplacement.IsOption())
                {
                    List < WarGearCombination > lc = new List<WarGearCombination>();
                    lc.Add(new WarGearCombination());
                    Weapon arme = new ReplaceNode().Evaluate(lc, remplacement.Operation).First().Weapons.First();
                    WarGearCombination cf = new WarGearCombination();
                    cf.CostOverrides = costOverrides;
                    cf.Weapons.Add(arme);
                    cf.WarGearOption.Add(remplacement);
                    cf.Selected = cp.Member.MemberWarGearOptions.Any(mr => mr.WarGearOptionId == remplacement.Id);
                    cp.OptionalWeapons.Add(cf);
                }
                else
                {
                    List<WarGearCombination> confs = new ReplaceNode().Evaluate(cp.WarGearCombinations, remplacement.Operation);
                    confs.ForEach(c => c.Weapons = c.Weapons.Where(a => a != null).ToList());
                    AddRemplacement(confs, remplacement);
                    cp.WarGearCombinations.AddRange(confs);                    
                }
            }

            //On copie les configurations simples
            List<WarGearCombination> confSimples = new List<WarGearCombination>();
            confSimples.AddRange(cp.WarGearCombinations);

            //puis on passe tous ceux avec exclusion l'un après l'autre
            foreach (WarGearOption remplacement in remplPossibles.Where(r => !String.IsNullOrWhiteSpace(r.Exclusion)))
            {
                //Remplacement limité en nombre
                if (remplacement.MaximumPerTeam > 0 && !cp.Member.Team.Roster)
                {
                    int nbUsed = KTContext.Db.MemberWarGearOptions.Count(mr => mr.Member.TeamId == cp.Member.TeamId && mr.MemberId != cp.Member.Id && mr.WarGearOptionId == remplacement.Id);
                    if (nbUsed >= remplacement.MaximumPerTeam)
                    {
                        continue;
                    }
                }

                List<WarGearCombination> confs = new ReplaceNode().Evaluate(confSimples, remplacement.Operation);
                AddRemplacement(confs, remplacement);
                cp.WarGearCombinations.AddRange(confs);
            }

            cp.ExtractArmesCommunes();

            //Marque les remplacements utilisés précédement
            foreach(WarGearCombination configuration in cp.WarGearCombinations)
            {
                //C'est la bonne configuration si toutes les armes et tous les remplacements sont présents
                configuration.Selected = true;
                foreach(WarGearOption remplacement in configuration.WarGearOption)
                {
                    configuration.Selected = configuration.Selected && cp.Member.MemberWarGearOptions.Any(mr => mr.WarGearOptionId == remplacement.Id);
                    configuration.CostOverrides = costOverrides;
                }
                foreach (Weapon arme in configuration.Weapons)
                {
                    configuration.Selected = configuration.Selected && cp.Member.MemberWeapons.Any(mr => mr.WeaponId == arme.Id);
                    configuration.CostOverrides = costOverrides;
                }
            }
            Dictionary<string, WarGearCombination> uniques = new Dictionary<string, WarGearCombination>();
            foreach (WarGearCombination configuration in cp.WarGearCombinations)
            {
                var key = string.Join("_", configuration.Weapons.Select(a => a.Id).OrderBy(id => id));
                uniques[key] = configuration;
            }
            cp.WarGearCombinations = uniques.Values.ToList();

            var configSelected = cp.WarGearCombinations.Where(c => c.Selected);
            if (configSelected.Count() > 1 && configSelected.SelectMany(c => c.Weapons).Select(a => a.Id).Distinct().Count() == 1)
            {
                configSelected.OrderByDescending(c => c.Weapons.Count()).Skip(1).ForEach(c => c.Selected = false);
            }

            if (configSelected.Count() > 1)
            {
                configSelected.Where(c => c.Weapons.Count != c.Weapons.Select(a => a.Id).Distinct().Count()).ForEach(c => c.Selected = false);
                configSelected.OrderByDescending(c => c.Weapons.Count).Skip(1).ForEach(c => c.Selected = false);
            }

            return cp;
        }

        private static void AddRemplacement(List<WarGearCombination> configurations, WarGearOption remp)
        {
            foreach(WarGearCombination conf in configurations)
            {
                if(!conf.WarGearOption.Contains(remp))
                {
                    conf.WarGearOption.Add(remp);
                }
            }
        }

        private void ExtractArmesCommunes()
        {
            FixedWeapons = WarGearCombinations.SelectMany(c => c.Weapons).Distinct().Where(a => WarGearCombinations.Where(c => c.Weapons.Contains(a)).Count() == WarGearCombinations.Count()).ToList();
            foreach(WarGearCombination config in WarGearCombinations.ToList())
            {
                config.Weapons.RemoveAll(ar => FixedWeapons.Contains(ar));
                if(config.Weapons.Count == 0)
                {
                    WarGearCombinations.Remove(config);
                }
            }
        }

        public override string ToString()
        {
            string str = "*** " + Member.ModelProfile.Name + "\n";

            str += "Armes Fixes : ";

            foreach (Weapon arme in FixedWeapons)
            {
                str += arme + ", ";
            }

            str += "\nOptions : ";
            foreach (WarGearCombination conf in OptionalWeapons)
            { 
                foreach (Weapon arme in conf.Weapons)
                {
                    str += arme + ", ";
                }
            }
            str += "\nConfigurations : ";
            foreach (WarGearCombination conf in WarGearCombinations)
            {
                str += conf + "\n";
            }

            str += "\n***";
            return str;

        }
    }
}
