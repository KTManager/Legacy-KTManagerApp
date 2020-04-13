using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AppCenter.Crashes;

namespace KillTeam.Services
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }


        public static string Traduction(this object input, string property)
        {
            string[] Available = new string[] { "En", "Fr", "De" };
            string ret = null;
            string lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.FirstCharToUpper();

            try
            {
                if (Available.Contains(lang))
                {
                    ret = (input.GetType().GetProperty(property + lang)
                        .GetValue(input, null) ?? "").ToString();
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);

            }

            
            if(String.IsNullOrWhiteSpace(ret))
            {
                ret = (input.GetType().GetProperty(property + "En")
                    .GetValue(input, null) ?? "").ToString();
            }
            ret = ret.Replace("\r", "").Replace("\n", " ");
            ret = Regex.Replace(ret, @"\s+", " ").Replace("’","'");
            return ret;
        }
    }
}
