using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace KillTeam.Services.RulesProviders
{
    public class FileRulesProvider : RulesProvider
    {
        private string path;

        public FileRulesProvider(string path)
        {
            if (!(
                path.EndsWith(Path.DirectorySeparatorChar.ToString()) ||
                path.EndsWith(Path.AltDirectorySeparatorChar.ToString())
            ))
            {
                path += Path.DirectorySeparatorChar.ToString();
            }
            this.path = path;
        }

        public override string GetVersion()
        {
            return File.ReadAllText(Path.Combine(this.path, "version.txt"));
        }

        protected override string GetReplacementsName()
        {
            return Path.Combine(this.path, "replacements.json");
        }

        protected override IEnumerable<string> GetAllNames()
        {
            // create a list of all the directories with rules in them
            var dirs = new List<string> { this.path };
            var factions = System.IO.Path.Combine(this.path, "factions");
            dirs.AddRange(System.IO.Directory.GetDirectories(factions));

            // then get all the json files in them
            return dirs.SelectMany(dir => System.IO.Directory.GetFiles(dir, "*.json"));
        }

        protected override string GetType(string name)
        {
            Debug.Assert(name.StartsWith(path));
            return System.IO.Path.GetFileNameWithoutExtension(name);
        }

        protected override string GetFaction(string name)
        {
            Debug.Assert(name.StartsWith(path));
            name = name.Replace(path, "");
            return name.StartsWith("faction")
                ? name.Split(new char[] {
                    System.IO.Path.DirectorySeparatorChar,
                    System.IO.Path.AltDirectorySeparatorChar
                  })[1]
                : "";
        }

        protected override string GetJSON(string name)
        {
            Debug.Assert(name.StartsWith(path));
            return File.ReadAllText(name);
        }
    }
}
