using KillTeam.Models;
using KillTeam.Resx;
using KillTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace KillTeam.Services
{
    public class PdfGeneration
    {
        public static string Generate(String equipeId, PdfConfiguration config)
        {
            Team equipe = KTContext.Db.Teams
                    .AsNoTracking()
                    .Where(e => e.Id == equipeId)
                    .Include(e => e.Faction.Tactics)
                    .Include(e => e.Faction.Abilities)
                    .ThenInclude(a => a.Details)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.MemberPowers)
                    .ThenInclude(e => e.Power)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.Specialist.Tactics)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.Specialist.Powers)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.MemberWeapons)
                    .ThenInclude(e => e.Weapon.WeaponProfiles)
                    .ThenInclude(e => e.WeaponType)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.ModelProfile)
                    .ThenInclude(e => e.Abilities)
                    .ThenInclude(a => a.Details)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.ModelProfile.Model)
                    .ThenInclude(e => e.Abilities)
                    .ThenInclude(a => a.Details)
                    .Include(e => e.Members)
                    .ThenInclude(e => e.ModelProfile.Tactics)
                    .Include(e => e.Faction.Models)
                    .ThenInclude(e => e.Abilities)
                    .ThenInclude(a => a.Details)
                    .Include(e => e.Faction.Models)
                    .ThenInclude(d => d.ModelWeapons)
                    .ThenInclude(d => d.Weapon.WeaponProfiles)
                    .ThenInclude(d => d.WeaponType)
                    .Include(e => e.Faction.Models)
                    .ThenInclude(f => f.ModelProfiles)
                    .ThenInclude(d => d.ModelProfileWeapons)
                    .ThenInclude(d => d.Weapon.WeaponProfiles)
                    .ThenInclude(d => d.WeaponType)
                    .Include(f => f.Faction.Models)
                    .ThenInclude(f => f.ModelProfiles)
                    .ThenInclude(f => f.Abilities)
                    .ThenInclude(a => a.Details)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.MemberTraits)
                    .ThenInclude(ma => ma.Trait)
                    .Include(e => e.Members)
                    .ThenInclude(m => m.MemberPsychics)
                    .ThenInclude(ma => ma.Psychic)
                    .First();

            equipe.Members = equipe.Members.OrderBy(o => o.Position).ToList();

            PdfDocument pdfDocument = new PdfDocument();

            if (config.OfficialPdf)
            {
                FeuilleOrdre(equipe, pdfDocument);

                List<List<Member>> members = SplitList(equipe.GetSelectedMembers().ToList());

                foreach (var m in members)
                {
                    FeuilleMembres(pdfDocument, m);
                }
            }
            else
            {
                WordDocument wordDocument = new WordDocument();
                wordDocument.DefaultTabWidth = 1000;
                //Adding a new section to the document.
                WSection section = wordDocument.AddSection() as WSection;
                section.Document.DefaultTabWidth = 1000;
                section.PageSetup.Margins.All = 0;
                int NbColumn = config.Compact ? 2 : 1;
                WTable table = section.AddTable() as WTable;
                table.TableFormat.IsBreakAcrossPages = false;
                table.ResetCells(equipe.GetSelectedMembers().Count() / NbColumn + 1, NbColumn);
                //table.TableFormat.Paddings.Bottom = 20;
                table.TableFormat.Paddings.Right = -5;
                AddHeader(table[0, 0], equipe);
                int cpt = 0;

                if (config.Tactics)
                {
                    AddTactique(equipe.GetAllTactics(), table[0, 0], table);
                }

                List<Member> membres = new List<Member>();
                if (config.GroupIdenticalMembers)
                {
                    foreach (var membre in equipe.GetSelectedMembers())
                    {
                        var membresIdentiques = equipe.GetSelectedMembers().Where(m => m.Identical(membre)).ToList();
                        if (!membres.Any(m => m.Identical(membre)))
                        {
                            //On ajoute le nom des membres indentiques au premier membre de la liste
                            membresIdentiques[0].Name = string.Join(", ", membresIdentiques.Select(m => m.Name)) + " x" + membresIdentiques.Count();
                            membres.Add(membresIdentiques[0]);
                        }
                    }
                }
                else
                {
                    membres.AddRange(equipe.GetSelectedMembers());
                }

                if (equipe.Faction.Abilities.Count() != 0 || config.GroupAbilities)
                {
                    List<Ability> aptitudes = equipe.Faction.Abilities.ToList();
                    if (config.GroupAbilities)
                    {
                        foreach (Member membre in equipe.Members)
                        {
                            aptitudes.AddRange(membre.Abilities.Where(apt => !membre.Team.Faction.Abilities.Any(a => a.Id == apt.Id)));
                        }
                        aptitudes = aptitudes.GroupBy(a => a.Name).Select(a => a.FirstOrDefault()).ToList();
                    }
                    AddFactionAptitude(table[0, 0], aptitudes, config);
                }

                int i = 0;
                foreach (Member membre in membres.OrderBy(o => o.Position))
                {
                    AddMembre(table[cpt / NbColumn, cpt % NbColumn], membre, i, config);
                    cpt++;
                    i++;
                }
                wordDocument.FontSettings.SubstituteFont += new SubstituteFontEventHandler(SubstituteFont);
                //Instantiation of DocIORenderer for Word to PDF conversion
                DocIORenderer render = new DocIORenderer();
                //Converts Word document into PDF document
                pdfDocument = render.ConvertToPDF(wordDocument);
                //Releases all resources used by the Word document and DocIO Renderer objects
                render.Dispose();
                wordDocument.Dispose();
            }
             
            //Save the document into memory stream
            MemoryStream stream = new MemoryStream();
            pdfDocument.Save(stream);
            stream.Position = 0;
            //Close the document 
            pdfDocument.Close();

            return Xamarin.Forms.DependencyService.Get<ISave>().Save(equipe.Faction.Name + ".pdf", "application/pdf", stream);

        }

        public static List<List<Member>> SplitList(List<Member> locations, int nSize = 8)
        {
            List<List<Member>> list = new List<List<Member>>();

            for (int i = 0; i < locations.Count; i += nSize)
            {
                list.Add(locations.GetRange(i, Math.Min(nSize, locations.Count - i)));
            }

            return list;
        }

        private static void SubstituteFont(object sender, SubstituteFontEventArgs args)
        {
            args.AlternateFontName = "Arial";
            args.AlternateFontStream = typeof(PdfGeneration).Assembly.GetManifestResourceStream("KillTeam.SharedAssets.Arial.ttf");
        }

        private static void AddHeader(WTableCell section, Team equipe)
        {
            WTable table = section.AddTable() as WTable;
            table.TableFormat.Paddings.All = 2;
            table.ApplyStyle(BuiltinTableStyle.MediumShading1Accent2);
            table.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.None;
            table.ResetCells(1, 14);
            table[0, 0].CellFormat.HorizontalMerge = CellMerge.Start;
            for (int i = 1; i <= 3; i++)
            {
                table[0, i].CellFormat.HorizontalMerge = CellMerge.Continue;
            }
            IWParagraph paragraph = table[0, 0].AddParagraph();
            IWTextRange textRange = paragraph.AppendText(equipe.Faction.Name);
            textRange.CharacterFormat.FontSize = 14;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";

            table[0, 4].CellFormat.HorizontalMerge = CellMerge.Start;
            for (int i = 5; i <= 8; i++)
            {
                table[0, i].CellFormat.HorizontalMerge = CellMerge.Continue;
            }
            paragraph = table[0, 4].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(equipe.Name);
            textRange.CharacterFormat.FontSize = 14;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";

            table[0, 9].CellFormat.HorizontalMerge = CellMerge.Start;
            for (int i = 10; i <= 13; i++)
            {
                table[0, i].CellFormat.HorizontalMerge = CellMerge.Continue;
            }
            paragraph = table[0, 9].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Right;
            textRange = paragraph.AppendText(equipe.Cost + " "+Resx.Translate.Points);

            textRange.CharacterFormat.FontSize = 14;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
        }

        private static void AddFactionAptitude(WTableCell section, ICollection<Ability> aptitudes, PdfConfiguration config)
        {
            WTable table = section.AddTable() as WTable;
            table.TableFormat.Paddings.All = 2;
            table.ApplyStyle(BuiltinTableStyle.MediumShading1Accent6);
            table.TableFormat.Borders.BorderType = BorderStyle.Single;
            table.ResetCells(1, 14);
            table[0, 0].CellFormat.HorizontalMerge = CellMerge.Start;
            for (int i = 1; i <= 13; i++)
            {
                table[0, i].CellFormat.HorizontalMerge = CellMerge.Continue;
            }
            IWParagraph paragraph = table[0, 0].AddParagraph();
            IWTextRange textRange = paragraph.AppendText(Translate.AptitudesCommunes);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";

            if (config.AbilityDetails)
            {
                // Inserting rows to the table.
                foreach (Ability aptitude in aptitudes)
                {
                    WTableRow row = table.AddRow();
                    row.Cells[0].CellFormat.HorizontalMerge = CellMerge.Start;
                    for (int i = 1; i <= 13; i++)
                    {
                        row.Cells[i].CellFormat.HorizontalMerge = CellMerge.Continue;
                    }
                    paragraph = row.Cells[0].AddParagraph();
                    textRange = paragraph.AppendText(aptitude.Name + " : ");
                    textRange.CharacterFormat.FontSize = 8;
                    textRange.CharacterFormat.FontName = "Arial.ttf#Arial";

                    textRange = paragraph.AppendText(aptitude.Description);
                    textRange.CharacterFormat.Bold = false;
                    textRange.CharacterFormat.FontSize = 8;
                    textRange.CharacterFormat.FontName = "Arial.ttf#Arial";

                    if (aptitude.Details != null && aptitude.Details.Count > 0)
                    {
                        AddTableAptitudeDetails(aptitude, row);
                    }
                }
            } else
            {
                WTableRow row = table.AddRow();
                row.Cells[0].CellFormat.HorizontalMerge = CellMerge.Start;
                for (int i = 1; i <= 13; i++)
                {
                    row.Cells[i].CellFormat.HorizontalMerge = CellMerge.Continue;
                }
                paragraph = row.Cells[0].AddParagraph();
                textRange = paragraph.AppendText(string.Join(", ", aptitudes.Select(a => a.Name)));
                textRange.CharacterFormat.FontSize = 8;
                textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            }
            WTextBody body = table.Owner as WTextBody;
            body.AddParagraph().AppendBreak(BreakType.LineBreak);
        }

        private static void AddTableAptitudeDetails(Ability aptitude, WTableRow row)
        {
            int colonne = aptitude.Details.Max(d => d.Column);
            int ligne = aptitude.Details.Max(d => d.Row);

            WTable table = row.Cells[0].AddTable() as WTable;
            table.TableFormat.Paddings.All = 2;
            table.ApplyStyle(BuiltinTableStyle.MediumShading1Accent6);
            table.TableFormat.Borders.BorderType = BorderStyle.Single;
            table.ResetCells(ligne, colonne);
            WTableRow rowDetails = table.AddRow();

            for (int i = 0; i < ligne; i++)
            {
                //
            }

            foreach (var aDetails in aptitude.Details)
            {
                var paragraph = table[aDetails.Row, aDetails.Column - 1].AddParagraph();
                var textRange = paragraph.AppendText(aDetails.Content);
                textRange.CharacterFormat.FontSize = 8;
                textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            }
        }

        private static void AddTactique(List<TactiqueViewModel> tactiques, WTableCell section, WTable oldTable)
        {
            WTable table = section.AddTable() as WTable;
            table.TableFormat.Paddings.All = 2;
            table.ApplyStyle(BuiltinTableStyle.MediumShading1Accent2);
            table.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
            table.ResetCells(1, 14);
            table[0, 0].CellFormat.HorizontalMerge = CellMerge.Start;
            for (int i = 1; i <= 13; i++)
            {
                table[0, i].CellFormat.HorizontalMerge = CellMerge.Continue;
            }
            IWParagraph paragraph = table[0, 0].AddParagraph();
            IWTextRange textRange = paragraph.AppendText(Translate.Tactiques);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            // Inserting rows to the table.
            foreach (TactiqueViewModel tactiqueViewModel in tactiques)
            {
                WTableRow row = table.AddRow();
                row.Cells[0].CellFormat.HorizontalMerge = CellMerge.Start;
                for (int i = 1; i <= 13; i++)
                {
                    row.Cells[i].CellFormat.HorizontalMerge = CellMerge.Continue;
                }
                paragraph = row.Cells[0].AddParagraph();
                textRange = paragraph.AppendText(tactiqueViewModel.Tactique.Name + " (" + tactiqueViewModel.Origine + ": " + tactiqueViewModel.Tactique.Cost + Resx.Translate.Points + ") ");
                textRange.CharacterFormat.FontSize = 8;
                textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
                textRange = paragraph.AppendText(tactiqueViewModel.Tactique.Description);
                textRange.CharacterFormat.Bold = false;
                textRange.CharacterFormat.FontSize = 8;
                textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            }
            WTextBody body = table.Owner as WTextBody;
            body.AddParagraph().AppendBreak(Syncfusion.DocIO.DLS.BreakType.LineBreak);
        }

        private static void AddMembre(WTableCell section, Member membre, int i, PdfConfiguration config)
        {
            // Adding a new Table
            WTable table = section.AddTable() as WTable;
            table.TableFormat.Paddings.All = 2;
            table.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
            table.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;

            // Inserting rows to the table.
            table.ResetCells(3, 14);

            CaracMembre(table, membre);
            TitreArme(table);

            List< MemberWeapon> mbl = membre.MemberWeapons.ToList();
            mbl.Sort();

            foreach (MemberWeapon arme in mbl)
            {
                AddArme(table, arme.Weapon);
            }
            Pyschers(table, membre, config);
            Aptitude(table, membre, config);
            if (config.XpRecruitConvalescence)
            {
                XPRecrueConvalescence(table, membre);
            }

            //Apply built-in table style to the table.
            table.ApplyStyle(i % 2 == 0 ? BuiltinTableStyle.MediumShading1Accent2 : BuiltinTableStyle.MediumShading1Accent6);
            WTextBody body = table.Owner as WTextBody;
            body.AddParagraph().AppendBreak(Syncfusion.DocIO.DLS.BreakType.LineBreak);
        }

        private static void XPRecrueConvalescence(WTable table, Member membre)
        {
            WTableRow row = table.AddRow();
            row.Cells[0].CellFormat.HorizontalMerge = CellMerge.Start;
            row.Cells[1].CellFormat.HorizontalMerge = CellMerge.Continue;
            row.Cells[2].CellFormat.HorizontalMerge = CellMerge.Continue;
            row.Cells[3].CellFormat.HorizontalMerge = CellMerge.Continue;

            IWParagraph paragraph = row.Cells[0].AddParagraph();
            IWTextRange textRange = paragraph.AppendText(Translate.Experience);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Times New Roman";
            textRange.CharacterFormat.Bold = true;

            row.Cells[4].CellFormat.HorizontalMerge = CellMerge.Start;

            paragraph = row.Cells[4].AddParagraph();
            textRange = paragraph.AppendText(membre.Xp.ToString());
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Times New Roman";

            row.Cells[5].CellFormat.HorizontalMerge = CellMerge.Start;
            row.Cells[6].CellFormat.HorizontalMerge = CellMerge.Continue;
            row.Cells[7].CellFormat.HorizontalMerge = CellMerge.Continue;

            paragraph = row.Cells[5].AddParagraph();
            textRange = paragraph.AppendText(Translate.Recrue);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Times New Roman";
            textRange.CharacterFormat.Bold = true;

            row.Cells[8].CellFormat.HorizontalMerge = CellMerge.Start;

            paragraph = row.Cells[8].AddParagraph();
            textRange = paragraph.AppendText(membre.Recruit ? "X" : "O");
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Times New Roman";

            row.Cells[9].CellFormat.HorizontalMerge = CellMerge.Start;
            row.Cells[10].CellFormat.HorizontalMerge = CellMerge.Continue;
            row.Cells[11].CellFormat.HorizontalMerge = CellMerge.Continue;
            row.Cells[12].CellFormat.HorizontalMerge = CellMerge.Continue;

            paragraph = row.Cells[9].AddParagraph();
            textRange = paragraph.AppendText(Translate.Convalescence);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Times New Roman";
            textRange.CharacterFormat.Bold = true;

            row.Cells[13].CellFormat.HorizontalMerge = CellMerge.Start;
            paragraph = row.Cells[13].AddParagraph();
            textRange = paragraph.AppendText(membre.Convalescence ? "X" : "O");
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Times New Roman";
        }

        private static void Pyschers(WTable table, Member membre, PdfConfiguration config)
        {
            if (membre.IsPsyker)
            {
                WTableRow row2 = table.AddRow();
                row2.Cells[0].CellFormat.HorizontalMerge = CellMerge.Start;
                for (int i = 1; i <= 13; i++)
                {
                    row2.Cells[i].CellFormat.HorizontalMerge = CellMerge.Continue;
                }
                IWParagraph paragraph2 = row2.Cells[0].AddParagraph();
                IWTextRange textRange2 = paragraph2.AppendText(Resx.Translate.Psyker + " : ");
                textRange2.CharacterFormat.FontSize = 8;
                textRange2.CharacterFormat.FontName = "Arial.ttf#Arial";
                textRange2 = paragraph2.AppendText(membre.PsykerDesc);
                textRange2.CharacterFormat.Bold = false;
                textRange2.CharacterFormat.FontSize = 8;
                textRange2.CharacterFormat.FontName = "Arial.ttf#Arial";

                List<Psychic> psys = new List<Psychic>();
               if (membre.MemberPsychics.Count == 0)
                    {
                        Psychic psybolt = KTContext.Db.Psychics.Find("1");
                        psys.Add(psybolt);
                    }
                else
                {
                    psys = membre.MemberPsychics.Select(p => p.Psychic).ToList();
                }

                if (config.AbilityDetails)
                {
                    foreach (Psychic psy in psys)
                    {
                        WTableRow row = table.AddRow();
                        row.Cells[0].CellFormat.HorizontalMerge = CellMerge.Start;
                        for (int i = 1; i <= 13; i++)
                        {
                            row.Cells[i].CellFormat.HorizontalMerge = CellMerge.Continue;
                        }
                        IWParagraph paragraph = row.Cells[0].AddParagraph();
                        IWTextRange textRange = paragraph.AppendText("        "+psy.Name + " (" + psy.WarpCharge + "): ");
                        textRange.CharacterFormat.FontSize = 8;
                        textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
                        textRange = paragraph.AppendText(psy.Description);
                        textRange.CharacterFormat.Bold = false;
                        textRange.CharacterFormat.FontSize = 8;
                        textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
                    }
                }
                else
                {
                    WTableRow row = table.AddRow();
                    row.Cells[0].CellFormat.HorizontalMerge = CellMerge.Start;
                    for (int i = 1; i <= 13; i++)
                    {
                        row.Cells[i].CellFormat.HorizontalMerge = CellMerge.Continue;
                    }
                    IWParagraph paragraph = row.Cells[0].AddParagraph();
                    IWTextRange textRange = paragraph.AppendText("        " + Translate.Psyker + " : " + string.Join(", ", psys.Select(a => a.Name)));
                    textRange.CharacterFormat.FontSize = 8;
                    textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
                }
            }
        }

        private static void Aptitude(WTable table, Member membre, PdfConfiguration config)
        {
            var aptitudes = membre.Abilities.Where(apt => !membre.Team.Faction.Abilities.Any(a => a.Id == apt.Id));
            if (config.AbilityDetails && !config.GroupAbilities)
            {
                foreach (Ability aptitude in aptitudes)
                {
                    WTableRow row = table.AddRow();
                    row.Cells[0].CellFormat.HorizontalMerge = CellMerge.Start;
                    for (int i = 1; i <= 13; i++)
                    {
                        row.Cells[i].CellFormat.HorizontalMerge = CellMerge.Continue;
                    }
                    IWParagraph paragraph = row.Cells[0].AddParagraph();
                    IWTextRange textRange = paragraph.AppendText(aptitude.Name + " : ");
                    textRange.CharacterFormat.FontSize = 8;
                    textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
                    textRange = paragraph.AppendText(aptitude.Description);
                    textRange.CharacterFormat.Bold = false;
                    textRange.CharacterFormat.FontSize = 8;
                    textRange.CharacterFormat.FontName = "Arial.ttf#Arial";

                    if (aptitude.Details != null && aptitude.Details.Count > 0)
                    {
                        AddTableAptitudeDetails(aptitude, row);
                    }
                }
            } else
            {
                WTableRow row = table.AddRow();
                row.Cells[0].CellFormat.HorizontalMerge = CellMerge.Start;
                for (int i = 1; i <= 13; i++)
                {
                    row.Cells[i].CellFormat.HorizontalMerge = CellMerge.Continue;
                }
                IWParagraph paragraph = row.Cells[0].AddParagraph();
                IWTextRange textRange = paragraph.AppendText(Translate.Aptitudes + " : " + string.Join(", ", aptitudes.Select(a => a.Name)));
                textRange.CharacterFormat.FontSize = 8;
                textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            }
            
        }

        private static void AddArme(WTable table, Weapon arme)
        {
            if (!arme.IsEquipement())
            {
                WTableRow row = table.AddRow();
                if (arme.IsMultiWeapons())
                {
                    AddEnteteProfile(row, arme);
                    foreach (WeaponProfile profArme in arme.WeaponProfiles)
                    {
                        row = table.AddRow();
                        AddProfile(row, profArme);
                    }
                }
                else
                {
                    WeaponProfile profilArme = arme.WeaponProfiles.ToList()[0];
                    AddProfile(row, profilArme);
                }

            }
        }

        private static void AddEnteteProfile(WTableRow row, Weapon Arme)
        {
            row.Cells[0].CellFormat.HorizontalMerge = CellMerge.Start;
            for (int i = 1; i <= 2; i++)
            {
                row.Cells[i].CellFormat.HorizontalMerge = CellMerge.Continue;
            }
            IWParagraph paragraph = row.Cells[0].AddParagraph();
            IWTextRange textRange = paragraph.AppendText(Arme.Name);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";

            row.Cells[3].CellFormat.HorizontalMerge = CellMerge.Start;
            for (int i = 4; i <= 13; i++)
            {
                row.Cells[i].CellFormat.HorizontalMerge = CellMerge.Continue;
            }
            paragraph = row.Cells[3].AddParagraph();
            textRange = paragraph.AppendText(Arme.Description);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";

        }

        private static void AddProfile(WTableRow row, WeaponProfile profilArme/*, WTable table*/)
        {
            row.Cells[0].CellFormat.HorizontalMerge = CellMerge.Start;
            for (int i = 1; i <= 2; i++)
            {
                row.Cells[i].CellFormat.HorizontalMerge = CellMerge.Continue;
            }
            IWParagraph paragraph = row.Cells[0].AddParagraph();
            IWTextRange textRange = paragraph.AppendText((profilArme.Weapon.IsMultiWeapons() ? " -" : "") + profilArme.Name);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = row.Cells[3].AddParagraph();
            textRange = paragraph.AppendText(profilArme.Range > 0 ? (profilArme.Range + "\"") : "");
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";

            row.Cells[4].CellFormat.HorizontalMerge = CellMerge.Start;
            row.Cells[5].CellFormat.HorizontalMerge = CellMerge.Continue;
            row.Cells[6].CellFormat.HorizontalMerge = CellMerge.Continue;
            row.Cells[7].CellFormat.HorizontalMerge = CellMerge.Start;
            row.Cells[8].CellFormat.HorizontalMerge = CellMerge.Start;
            row.Cells[9].CellFormat.HorizontalMerge = CellMerge.Start;
            paragraph = row.Cells[4].AddParagraph();
            textRange = paragraph.AppendText(profilArme.WeaponType.Name + (profilArme.WeaponType.Id != "M" ? (" " + profilArme.ShotNumber) : ""));
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";

            paragraph = row.Cells[7].AddParagraph();
            textRange = paragraph.AppendText(profilArme.Strength);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = row.Cells[8].AddParagraph();
            textRange = paragraph.AppendText(profilArme.ArmourPenetration);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = row.Cells[9].AddParagraph();
            textRange = paragraph.AppendText(profilArme.Damages);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";


            row.Cells[10].CellFormat.HorizontalMerge = CellMerge.Start;
            row.Cells[11].CellFormat.HorizontalMerge = CellMerge.Continue;
            row.Cells[12].CellFormat.HorizontalMerge = CellMerge.Continue;
            row.Cells[13].CellFormat.HorizontalMerge = CellMerge.Continue;
            paragraph = row.Cells[10].AddParagraph();
            textRange = paragraph.AppendText(profilArme.Description??"");
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
        }

        private static void TitreArme(WTable table)
        {
            table[2, 0].CellFormat.HorizontalMerge = CellMerge.Start;
            for (int i = 1; i <= 2; i++)
            {
                table[2, i].CellFormat.HorizontalMerge = CellMerge.Continue;
            }
            IWParagraph paragraph = table[2, 0].AddParagraph();
            IWTextRange textRange = paragraph.AppendText(Translate.Arme);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[2, 3].AddParagraph();
            textRange = paragraph.AppendText(Translate.Portee);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            table[2, 4].CellFormat.HorizontalMerge = CellMerge.Start;
            table[2, 5].CellFormat.HorizontalMerge = CellMerge.Continue;
            table[2, 6].CellFormat.HorizontalMerge = CellMerge.Continue;
            paragraph = table[2, 4].AddParagraph();
            textRange = paragraph.AppendText(Translate.Type);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[2, 7].AddParagraph();
            textRange = paragraph.AppendText(Translate.F);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[2, 8].AddParagraph();
            textRange = paragraph.AppendText(Translate.PA);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[2, 9].AddParagraph();
            textRange = paragraph.AppendText(Translate.D);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            table[2, 10].CellFormat.HorizontalMerge = CellMerge.Start;
            table[2, 11].CellFormat.HorizontalMerge = CellMerge.Continue;
            table[2, 12].CellFormat.HorizontalMerge = CellMerge.Continue;
            table[2, 13].CellFormat.HorizontalMerge = CellMerge.Continue;
            paragraph = table[2, 10].AddParagraph();
            textRange = paragraph.AppendText(Translate.Aptitudes);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";


        }

        private static void CaracMembre(WTable table, Member membre)
        {
            // Table formatting with cell merging.
            table[0, 0].CellFormat.HorizontalMerge = CellMerge.Start;
            for (int i = 1; i <= 2; i++)
            {
                table[0, i].CellFormat.HorizontalMerge = CellMerge.Continue;
            }
            IWParagraph paragraph = table[0, 0].AddParagraph();
            IWTextRange textRange = paragraph.AppendText(membre.SpecialistLevel);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";

            table[0, 3].CellFormat.HorizontalMerge = CellMerge.Start;
            table[0, 4].CellFormat.HorizontalMerge = CellMerge.Continue;
            paragraph = table[0, 3].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Right;
            textRange = paragraph.AppendText(membre.Cost + " "+ Translate.Points);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[0, 5].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(Translate.M);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[0, 6].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(Translate.CC);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[0, 7].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(Translate.CT);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[0, 8].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(Translate.F);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[0, 9].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(Translate.E);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[0, 10].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(Translate.PV);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[0, 11].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(Translate.A);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[0, 12].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(Translate.Cd);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[0, 13].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(Translate.Sv);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";

            //Valeurs membre
            table[1, 0].CellFormat.HorizontalMerge = CellMerge.Start;
            for (int i = 1; i <= 4; i++)
            {
                table[1, i].CellFormat.HorizontalMerge = CellMerge.Continue;
            }
            paragraph = table[1, 0].AddParagraph();
            textRange = paragraph.AppendText(membre.Name);
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[1, 5].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(membre.ModelProfile.Movement + "\"");
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[1, 6].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(membre.ModelProfile.WeaponSkill + "+");
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[1, 7].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(membre.ModelProfile.BallisticSkill + "+");
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[1, 8].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(membre.ModelProfile.Strength.ToString());
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[1, 9].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(membre.ModelProfile.Toughness.ToString());
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[1, 10].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(membre.ModelProfile.Wounds.ToString());
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[1, 11].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(membre.ModelProfile.Attacks.ToString());
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[1, 12].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(membre.ModelProfile.Leadership.ToString());
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
            paragraph = table[1, 13].AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText(membre.ModelProfile.Save + "+");
            textRange.CharacterFormat.FontSize = 8;
            textRange.CharacterFormat.FontName = "Arial.ttf#Arial";
        }

        public static void FeuilleOrdre(Team equipe, PdfDocument pdfDocument)
        {
            string langage = TranslateExtension.Ci.TwoLetterISOLanguageName.ToLower();
            string name = "FeuilleOrdre_" + langage + ".pdf";
            MemoryStream memoryStream;
            try
            {
                memoryStream = Xamarin.Forms.DependencyService.Get<IPdf>().Pdf(name);
            } catch (Exception ex)
            {
                Crashes.TrackError(ex);
                memoryStream = Xamarin.Forms.DependencyService.Get<IPdf>().Pdf("FeuilleOrdre_en.pdf");
            }
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(memoryStream);

            bool getField = loadedDocument.Form.Fields.TryGetField("Name_1.0", out PdfLoadedField fd);
            bool formatFr = fd != null;

            getField = loadedDocument.Form.Fields.TryGetField("Faction", out fd);
            PdfLoadedTextBoxField field = fd as PdfLoadedTextBoxField;
            field.Text = equipe.Faction.Name;

            getField = loadedDocument.Form.Fields.TryGetField("Points", out fd);
            field = fd as PdfLoadedTextBoxField;
            field.Text = equipe.Cost.ToString();

            getField = loadedDocument.Form.Fields.TryGetField("KT Name", out fd);
            field = fd as PdfLoadedTextBoxField;
            field.Text = equipe.Name;

            List<Member> membres = equipe.GetSelectedMembers().ToList();
            int compteur = membres.Count() - 1 > 25 ? 25 : membres.Count() - 1;
            for (int i = 0; i <= compteur; i++)
            {
                Member membre = membres[i];

                getField = loadedDocument.Form.Fields.TryGetField((formatFr ? "Name_1." + i:"Name"+(i+1)), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = membre.Name;

                getField = loadedDocument.Form.Fields.TryGetField((formatFr ? "Model_Type_1." + i : "ModelType" + (i + 1)), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = membre.ModelProfile.Model.Name;

                List<MemberWeapon> armements = membre.MemberWeapons.ToList();
                armements.Sort();
                List<string> armes = armements.Where(a => !a.Weapon.IsEquipement()).OrderBy(a =>a.Weapon.WeaponProfiles.FirstOrDefault().WeaponType.Index).Select(a => a.Weapon.Name).ToList();
                armes.AddRange(membre.MemberWeapons.Where(a => a.Weapon.IsEquipement()).Select(a => a.Weapon.Name));

                getField = loadedDocument.Form.Fields.TryGetField((formatFr ? "Wargear_1." + i : "Wargear" + (i + 1)), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = string.Join(", ", armes);

                getField = loadedDocument.Form.Fields.TryGetField((formatFr ? "Exp_1." + i : "EXP" + (i + 1)), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = membre.Xp.ToString();

                getField = loadedDocument.Form.Fields.TryGetField((formatFr ? "Specialism_1." + i : "Specialism/Abilities" + (i + 1)), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = membre.Specialist != null ? membre.Specialist.Name : "";

                getField = loadedDocument.Form.Fields.TryGetField((formatFr ? "Pts_1." + i : "Pts" + (i + 1)), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = membre.Cost.ToString();
            }

            pdfDocument.ImportPageRange(loadedDocument, 0, 0);

            loadedDocument.Save(memoryStream);
            memoryStream.Position = 0;
        }

        public static void FeuilleMembres(PdfDocument pdfDocument, List<Member> membres)
        {
            string langage = TranslateExtension.Ci.TwoLetterISOLanguageName.ToLower();
            string name = "Equipe_" + langage + ".pdf";
            MemoryStream memoryStream;
            try
            {
                memoryStream = Xamarin.Forms.DependencyService.Get<IPdf>().Pdf(name);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                memoryStream = Xamarin.Forms.DependencyService.Get<IPdf>().Pdf("Equipe_en.pdf");
            }
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(memoryStream);
            
            bool getField = loadedDocument.Form.Fields.TryGetField("DC_Name1", out PdfLoadedField fd);
            bool formatFr = fd != null;

            for (int i = 0; i <= membres.Count()-1; i++)
            {
                Member membre = membres[i];

                getField = loadedDocument.Form.Fields.TryGetField("DC_Pts1." + i, out fd);
                PdfLoadedTextBoxField field = fd as PdfLoadedTextBoxField;
                field.Text = membre.Cost.ToString();

                getField = loadedDocument.Form.Fields.TryGetField((formatFr ? "DC_":"")+"Name" + (i+1), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = membre.Name;

                getField = loadedDocument.Form.Fields.TryGetField((formatFr ? "DC_":"")+"M" + (i + 1), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = membre.ModelProfile.Movement.ToString() + "\"";

                getField = loadedDocument.Form.Fields.TryGetField((formatFr ? "DC_":"")+"WS" + (i + 1), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = membre.ModelProfile.WeaponSkill.ToString() + "+";

                getField = loadedDocument.Form.Fields.TryGetField((formatFr?"DC_":"")+"BS" + (i + 1), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = membre.ModelProfile.BallisticSkill.ToString() + "+";

                getField = loadedDocument.Form.Fields.TryGetField((formatFr?"DC_":"")+"S" + (i + 1), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = membre.ModelProfile.Strength.ToString();

                getField = loadedDocument.Form.Fields.TryGetField((formatFr?"DC_":"")+"T" + (i + 1), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = membre.ModelProfile.Toughness.ToString();

                getField = loadedDocument.Form.Fields.TryGetField((formatFr?"DC_":"")+"W" + (i + 1), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = membre.ModelProfile.Wounds.ToString();

                getField = loadedDocument.Form.Fields.TryGetField((formatFr?"DC_":"")+"A" + (i + 1), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = membre.ModelProfile.Attacks.ToString();

                getField = loadedDocument.Form.Fields.TryGetField((formatFr?"DC_":"")+"Ld" + (i + 1), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = membre.ModelProfile.Leadership.ToString();

                getField = loadedDocument.Form.Fields.TryGetField((formatFr?"DC_":"")+"Sv" + (i + 1), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = membre.ModelProfile.Save.ToString() + "+";


                List<WeaponProfile> profileArmes = new List<WeaponProfile>();
                List<MemberWeapon> armements = membre.MemberWeapons.ToList();
                armements.Sort();

                foreach(MemberWeapon membreArme in armements)
                {
                    profileArmes.AddRange(membreArme.Weapon.WeaponProfiles);
                }

                int compteurArme = profileArmes.Count() > 4 ? 4 : profileArmes.Count();
                for(int j = 1; j <= compteurArme; j++)
                {
                    WeaponProfile profilArme = profileArmes[j-1];
                    getField = loadedDocument.Form.Fields.TryGetField(formatFr?("DC_Weapon_" + j + (i + 1)):"WPN"+(i+1)+(char)('a'+j-1), out fd);
                    field = fd as PdfLoadedTextBoxField;
                    field.Text = profilArme.Name;

                    getField = loadedDocument.Form.Fields.TryGetField(formatFr ? ("DC_Range_" + j + (i + 1)) : "RNG" + (i + 1) + (char)('a' + j-1 ), out fd);
                    field = fd as PdfLoadedTextBoxField;
                    field.Text = profilArme.Range.ToString() + "\"";

                    getField = loadedDocument.Form.Fields.TryGetField(formatFr ? ("DC_Type_" + j + (i + 1)) : "TYPE" + (i + 1) + (char)('a' + j-1 ), out fd);
                    field = fd as PdfLoadedTextBoxField;
                    field.Text = profilArme.Type;

                    getField = loadedDocument.Form.Fields.TryGetField(formatFr ? ("DC_Weapon_S_" + j + (i + 1)) : "S" + (i + 1) + (char)('a' + j-1 ), out fd);
                    field = fd as PdfLoadedTextBoxField;
                    field.Text = profilArme.Strength;

                    getField = loadedDocument.Form.Fields.TryGetField(formatFr ? ("DC_AP_" + j + (i + 1)) : "AP" + (i + 1) + (char)('a' + j-1 ), out fd);
                    field = fd as PdfLoadedTextBoxField;
                    field.Text = profilArme.ArmourPenetration;

                    getField = loadedDocument.Form.Fields.TryGetField(formatFr ? ("DC_D_" + j + (i + 1)) : "D" + (i + 1) + (char)('a' + j-1 ), out fd);
                    field = fd as PdfLoadedTextBoxField;
                    field.Text = profilArme.Damages;

                    getField = loadedDocument.Form.Fields.TryGetField(formatFr ? ("DC_Abilities_" + j + (i + 1)) : "Abil" + (i + 1) + (char)('a' + j-1 ), out fd);
                    field = fd as PdfLoadedTextBoxField;
                    field.Text = profilArme.Description;

                }

                getField = loadedDocument.Form.Fields.TryGetField((formatFr?"DC_Model_Abilities_1" + (i + 1):"Abilities"+(i+1)), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = membre.Abilities.Count() >= 1 ? string.Join(", ", membre.Abilities.Select(a => a.Name)) : "";

                getField = loadedDocument.Form.Fields.TryGetField((formatFr?"DC_Specialism_1" + (i + 1):"Specialism"+(i+1)), out fd);
                field = fd as PdfLoadedTextBoxField;
                field.Text = membre.Specialist != null ? membre.Specialist.Name : "";
                

                for(int x = 1; x <= membre.Xp && x<=12; x++)
                {
                    getField = loadedDocument.Form.Fields.TryGetField((formatFr?("DC_EXP" + (i == 0 ? "" : (i+1).ToString()) + x):(x<10?((i+1)+""+x):((i+1)+""+(char)('a'+(x-10))))), out fd);
                    PdfLoadedCheckBoxField boxField = fd as PdfLoadedCheckBoxField;
                    boxField.Checked = true;
                }

                if (membre.Convalescence)
                {
                    getField = loadedDocument.Form.Fields.TryGetField((formatFr?"DC_Convalescence" + (i + 1):(i+1)+"g"), out fd);
                    PdfLoadedCheckBoxField boxField = fd as PdfLoadedCheckBoxField;
                    boxField.Checked = true;
                }

                if (membre.Recruit)
                {
                    getField = loadedDocument.Form.Fields.TryGetField((formatFr?"DC_New_Recruit" + (i + 1):(i + 1) + "h"), out fd);
                    PdfLoadedCheckBoxField boxField = fd as PdfLoadedCheckBoxField;
                    boxField.Checked = true;
                }
            }

            pdfDocument.ImportPageRange(loadedDocument, 0, 0);

            loadedDocument.Save(memoryStream);
            memoryStream.Position = 0;
        }

    }
}
