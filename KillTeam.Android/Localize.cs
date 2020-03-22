using System;
using Xamarin.Forms;
using System.Threading;
using System.Globalization;
using Java.Interop;
using Java.Util;
using KillTeam.Services;
using Microsoft.AppCenter.Crashes;

[assembly:Dependency(typeof(KillTeam.Droid.Localize))]

namespace KillTeam.Droid
{
    public class Localize : ILocalize
    {
        public void SetLocale(CultureInfo cultureInfo)
		{
			Thread.CurrentThread.CurrentCulture = cultureInfo;
			Thread.CurrentThread.CurrentUICulture = cultureInfo;

			Console.WriteLine($"Culture set to '{cultureInfo.Name}'");
		}

		public CultureInfo GetCurrentCultureInfo()
		{
			var androidLocale = Locale.Default;
			var netLanguage = AndroidToDotnetLanguage(androidLocale);

			// this gets called a lot - try/catch can be expensive so consider caching or something
			CultureInfo cultureInfo;
			try
            {
                cultureInfo = new CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException e1)
            {
                Crashes.TrackError(e1);
                // iOS locale not valid .NET culture (eg. "en-ES" : English in Spain)
                // fallback to first characters, in this case "en"
                try
                {
                    var fallback = ToDotnetFallbackLanguage(new PlatformCulture(netLanguage));
                    Console.WriteLine($"'{netLanguage}' failed to load, trying '{fallback}' ({e1.Message})");
                    cultureInfo = new CultureInfo(fallback);
                }
                catch (CultureNotFoundException e2)
                {
                    Crashes.TrackError(e2);
                    var fallback = GetDefaultCultureInfo();
					Console.WriteLine($"{netLanguage} couldn't be set, using '{fallback}' ({e2.Message})");
                    cultureInfo = fallback;
                }
            }

            return cultureInfo;
		}

        private string AndroidToDotnetLanguage(IJavaPeerable locale)
        {
            var androidCultureName = locale.ToString().Replace("_", "-");

			Console.WriteLine("Android Culture :" + androidCultureName);
			var netCultureName = androidCultureName;

			//certain languages need to be converted to CultureInfo equivalent
			switch (androidCultureName)
			{
				case "in-ID":  // "Indonesian (Indonesia)" has different code in  .NET 
					netCultureName = "id-ID"; // correct code for .NET
					break;
                case "gsw-CH":  // "Schwiizertüütsch (Swiss German)" not supported .NET culture
                    netCultureName = "de-CH"; // closest supported
                    break;
					// add more application-specific cases here (if required)
					// ONLY use cultures that have been tested and known to work
			}

			Console.WriteLine(".NET Culture : " + netCultureName);
			return netCultureName;
		}

        private string ToDotnetFallbackLanguage(PlatformCulture platformCulture)
		{
			Console.WriteLine(".NET Fallback Language:" + platformCulture.LanguageCode);
			var netLanguage = platformCulture.LanguageCode; // use the first part of the identifier (two chars, usually);

			switch (platformCulture.LanguageCode)
			{
                // force different 'fallback' behavior for some language codes
                case "pt":
                    netLanguage = "pt-PT"; // fallback to Portuguese (Portugal)
                    break;
                case "in":  // "Indonesian (Indonesia)" has different code in  .NET 
                    netLanguage = "id-ID"; // correct code for .NET
                    break;
				case "gsw":
					netLanguage = "de-CH"; // equivalent to German (Switzerland) for this app
					break;
					// add more application-specific cases here (if required)
					// ONLY use cultures that have been tested and known to work
			}

			Console.WriteLine(".NET Fallback Language/Locale:" + netLanguage + " (application-specific)");
			return netLanguage;
		}

        public CultureInfo GetDefaultCultureInfo()
        {
            return new CultureInfo("en-US");
        }
    }
}

