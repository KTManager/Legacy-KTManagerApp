using KillTeam.Properties;
using KillTeam.Services;
using KillTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace KillTeam.Models
{
    public class Team : INotifyPropertyChanged
    {
        #region Backing Fields

        private string _name;
        private bool _roster;

        #endregion Backing Fields

        #region Native Properties 

        public string Id { get; set; }

        public string FactionId { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Title));
            }
        }

        public bool Roster
        {
            get { return _roster; }
            set
            {
                _roster = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Cost));
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(FormattedCost));
            }
        }

        public int Position { get; set; }

        #endregion Native Properties 

        #region Navigation Properties

        public virtual Faction Faction { get; set; }

        public virtual List<Member> Members { get; set; }

        #endregion Navigation Properties

        #region Calculated Properties

        [JsonIgnore]
        public int Cost
        {
            get
            {
                int points = 0;
                if (Members != null)
                {
                    foreach (Member membre in GetSelectedMembers())
                    {
                        points += membre.Cost;
                    }
                }
                return points;
            }
        }

        [JsonIgnore]
        public string Title
        {
            get
            {
                return Name + " (" + Cost + ")";
            }
        }

        [JsonIgnore]
        public string FormattedCost
        {
            get
            {
                return Cost + " " + Resources.Points;
            }
        }

        [JsonIgnore]
        public List<string> Errors
        {
            get
            {
                List<string> liste = new List<string>();

                if (Cost > 100)
                {
                    liste.Add(Resources.PlusDeCentPoints);
                }
                if (!GetSelectedMembers().Any(m => m.SpecialistId == "L"))
                {
                    liste.Add(Resources.PasDeLeader);
                }
                if (!_roster && Members.Count(m => m.ModelProfile.IsCommander) > 1)
                {
                    liste.Add(Resources.UnSeulCommandant);
                }
                if (GetSelectedMembers().Where(m => !m.ModelProfile.IsCommander && m.ModelProfile.Id != "MEUR" && m.ModelProfile.Id != "AMRR1" && m.ModelProfile.Id != "AMPV" && m.ModelProfile.Id != "ESK" && m.ModelProfile.Id != "ESL" && m.ModelProfile.Id != "ESS").Count(m => m.Specialist != null) > 4)
                {
                    liste.Add(Resources.PlusDeQuatreSpe);
                }
                if (GetSelectedMembers()
                    .Where(m => m.SpecialistId != null)
                    .GroupBy(m => m.SpecialistId)
                    .Any(g => g.Count() > 1))
                {
                    liste.Add(Resources.MemeSpe);
                }
                if (GetSelectedMembers().Count() > 20)
                {
                    liste.Add(Resources.PlusDeQuatreSpe);
                }

                //Verifier les declinaisons limités
                List<string> declinaisonTrop = new List<string>();
                foreach (Member membre in GetSelectedMembers())
                {
                    if (!declinaisonTrop.Contains(membre.ModelProfile.Id) && membre.ModelProfile.MaximumNumber > 0 && membre.ModelProfile.MaximumNumber < GetSelectedMembers().Count(m => m.ModelProfile.Id == membre.ModelProfile.Id))
                    {
                        declinaisonTrop.Add(membre.ModelProfile.Id);
                        liste.Add(String.Format(Resources.TropDeclinaison, membre.ModelProfile.Name, membre.ModelProfile.MaximumNumber));
                    }
                }

                //Verifier les changements limités
                List<string> changementTrop = new List<string>();
                foreach (Member mb in GetSelectedMembers())
                {
                    foreach (MemberWarGearOption mr in mb.MemberWarGearOptions)
                    {
                        WarGearOption remplacement = mr.WarGearOption;
                        if (!changementTrop.Contains(remplacement.Id) && remplacement.MaximumPerTeam > 0 && remplacement.MaximumPerTeam < GetSelectedMembers().Count(m => m.MemberWarGearOptions.Any(mr2 => mr2.WarGearOptionId == remplacement.Id)))
                        {
                            changementTrop.Add(remplacement.Id);

                            string remp = remplacement.Operation;

                            foreach (Match match in Regex.Matches(remp, "([a-z0-9]+)", RegexOptions.IgnoreCase))
                            {
                                Weapon arme = KTContext.Db.Weapons.Find(match.Value);
                                remp = remp.Replace(match.Value, arme.Name);
                            }


                            remp = remp.Replace(":", " " + Resources.RemplacePar + " ");
                            remp = remp.Replace("|", " " + Resources.Or + " ");
                            remp = remp.Replace("&", " " + Resources.Et + " ");

                            liste.Add(String.Format(Resources.TropRemplacement, remp, remplacement.MaximumPerTeam));
                        }
                    }
                }

                return liste;
            }
        }

        [JsonIgnore]
        public string FactionNameAndMembersCount
        {
            get
            {
                int count = GetSelectedMembers().Count();
                return Faction.Name + " - " + count + " " + (count <= 1 ? Resources.Membre : Resources.Membres);
            }
        }
        
        #endregion Calculated Properties

        #region Constructors

        public Team()
        {
            Members = new List<Member>();
        }

        #endregion Constructors

        #region Methods

        public IEnumerable<Member> GetSelectedMembers()
        {
            return Members.Where(m => m.Selected || !Roster);
        }

        public static Team Random(string factionId)
        {
            Faction faction = KTContext.Db.Factions
           .Include(f => f.Models)
           .ThenInclude(f => f.ModelProfiles)
           .Where(f => f.Id == factionId)
           .First();


            Team equipe = new Team() { Name = "Random " + faction.Name, Faction = faction };
            KTContext.Db.Entry(equipe).State = EntityState.Added;
            KTContext.Db.SaveChanges();

            foreach (Model figurine in faction.Models)
                foreach (ModelProfile declinaison in figurine.ModelProfiles)
                {
                    Member mb = Member.CreateFrom(equipe.Id, declinaison.Id);
                    equipe.Members.Add(mb);
                }

            return equipe;
        }

        public static Team DuplicateTeam(string teamId)
        {
            Team baseEquipe = KTContext.Db.Teams
                    .AsNoTracking()
                    .Where(e => e.Id == teamId)
                    .Include(e => e.Faction.Tactics)
                    .Include(e => e.Faction.Abilities)
                    .ThenInclude(a => a.Details)
                    .Include(e => e.Members)
                    .First();

            Team equipe = new Team()
            {
                Faction = baseEquipe.Faction,
                Roster = baseEquipe.Roster
            };

            string equipeNom = baseEquipe.Name;
            int nbSameName = KTContext.Db.Teams.Where(m => m.Name.Contains(equipeNom)).Count();
            if (nbSameName != 0)
            {
                int i = 1;
                while (KTContext.Db.Teams.Where(e => e.Name == equipeNom).Count() >= 1)
                {
                    equipeNom = baseEquipe.Name + " - " + Resources.Copier + " (" + i + ")";
                    i++;
                }
            }
            equipe.Name = equipeNom;
            equipe.Position = KTContext.Db.Teams.Count();
            KTContext.Db.Entry(equipe).State = EntityState.Added;
            KTContext.Db.SaveChanges();

            foreach (Member membre in baseEquipe.Members)
            {
                Member mb = Member.DuplicateFrom(membre.Id, equipe.Id).Result;
                equipe.Members.Add(mb);
            }

            return equipe;
        }

        public List<TactiqueViewModel> GetAllTactics(TactiqueOptionsViewModel options = null)
        {
            if (options == null)
            {
                options = new TactiqueOptionsViewModel
                {
                    Declinaison = true,
                    Faction = true,
                    Specialite = true,
                    Generale = true,
                    ChoosedPhase = new List<string>()
                };
            }

            var membres = GetSelectedMembers();
            var hasCommander = membres.Any(m => m.IsCommander);
            var tactics = new List<TactiqueViewModel>();

            if (options.Generale) LoadGenericTactics(tactics, hasCommander);
            if (options.Faction) LoadFactionTactics(tactics, hasCommander);

            if (options.Specialite || options.Declinaison)
            {
                foreach (Member membre in membres)
                {
                    if (options.Specialite && membre.Specialist != null)
                    {
                        LoadSpecialistTactics(tactics, membre, hasCommander);
                    }

                    if (options.Declinaison)
                    {
                        LoadProfileTactics(tactics, membre);
                    }
                }
            }

            List<string> phases = new List<string>(options.ChoosedPhase);
            if (phases.Contains("4") || phases.Contains("5"))
                phases.Add("7");

            if (options.ChoosedPhase.Count > 0)
                tactics = tactics.Where(t => t.Tactique.Phase == null || phases.Contains(t.Tactique.Phase.Id)).OrderBy(a => a.Tactique.Name).ToList();

            return tactics.Distinct().ToList();
        }

        private void LoadGenericTactics(List<TactiqueViewModel> tactics, bool hasCommander = false)
        {
            var generalTactics = KTContext.Db.Tactics
                .Include(t => t.Phase)
                .Where(t => t.FactionId == null && t.SpecialistId == null && t.ModelProfileId == null && (hasCommander || t.Commander == false))
                .ToList();

            foreach (var t in generalTactics)
            {
                tactics.Add(new TactiqueViewModel
                {
                    Tactique = t,
                    Origine = Resources.General
                });
            }
        }

        private void LoadFactionTactics(List<TactiqueViewModel> tactics, bool hasCommander = false)
        {
            var factionTactics = Faction.Tactics
                .Where(t => hasCommander || t.Commander == false)
                .ToList();

            foreach (var t in factionTactics)
            {
                tactics.Add(new TactiqueViewModel
                {
                    Tactique = t,
                    Origine = Resources.Faction
                });
            }
        }

        private void LoadSpecialistTactics(List<TactiqueViewModel> tactics, Member member, bool hasCommander = false)
        {
            var specialistTactics = member.Specialist.Tactics
                .Where(t => t.Level <= member.Level && (hasCommander || t.Commander == false))
                .ToList();

            foreach (var t in specialistTactics)
            {
                tactics.Add(new TactiqueViewModel
                {
                    Tactique = t,
                    Origine = Resources.Specialite
                });
            }
        }

        private void LoadProfileTactics(List<TactiqueViewModel> tactics, Member member)
        {
            var profileTactics = member.ModelProfile.Tactics
                .Where(t => member.IsCommander || t.Commander == false)
                .ToList();

            foreach (var t in profileTactics)
            {
                tactics.Add(new TactiqueViewModel
                {
                    Tactique = t,
                    Origine = member.ModelProfile.Name
                });
            }
        }

        public string GetSummary()
        {
            string result = Name + " - " + Faction.Name + " - " + Cost + "\n";
            foreach (Member membre in GetSelectedMembers())
            {
                result += "* " + membre.ModelProfile.Name + " - " + membre.Cost;
                if (membre.Specialist != null)
                    result += ", " + membre.Specialist.Name + "\n";
                result += "\n:\t" + String.Join(", ", membre.MemberWeapons.Select(a => a.Weapon.Name));
                result += "\n";
            }
            return result;
        }


        #endregion Methods

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (propertyName == null) return;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
    }
}
