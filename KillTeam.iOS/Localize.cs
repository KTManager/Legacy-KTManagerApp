using System;
using System.Globalization;
using System.Threading;
using Foundation;
using KillTeam.Services;
using Microsoft.AppCenter.Crashes;

[assembly:Xamarin.Forms.Dependency(typeof(KillTeam.iOS.Localize))]

namespace KillTeam.iOS
{
	public class Localize : ILocalize
	{
        public void SetLocale(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            Console.WriteLine($"Culture set to '{cultureInfo.Name}'");
        }

		public CultureInfo GetCurrentCultureInfo ()
		{
			var netCulture = GetDefaultCultureInfo().ToString();
			if (NSLocale.PreferredLanguages.Length > 0)
			{
				var preferredLanguage = NSLocale.PreferredLanguages[0];
				netCulture = IOSToDotnetLanguage(preferredLanguage);
			}

			// this gets called a lot - try/catch can be expensive so consider caching or something
			CultureInfo cultureInfo;
			try
			{
                cultureInfo = new CultureInfo(netCulture);
            }
            catch (CultureNotFoundException e1)
            {
                Crashes.TrackError(e1);
                // iOS locale not valid .NET culture (eg. "en-ES" : English in Spain)
                // fallback to first characters, in this case "en"
                try
                {
                    var fallback = ToDotnetFallbackLanguage(new PlatformCulture(netCulture));
                    Console.WriteLine($"'{netCulture}' failed to load, trying '{fallback}' ({e1.Message})");
                    cultureInfo = new CultureInfo(fallback);
                }
                catch (CultureNotFoundException e2)
                {
                    Crashes.TrackError(e2);
                    var fallback = GetDefaultCultureInfo();
                    Console.WriteLine($"{netCulture} couldn't be set, using '{fallback}' ({e2.Message})");
                    cultureInfo = fallback;
                }
            }

			return cultureInfo;
		}

		string IOSToDotnetLanguage(string iOsLanguage)
		{
			Console.WriteLine("iOS Language : " + iOsLanguage);
			var netCultureName = iOsLanguage; 

			// certain languages need to be converted to CultureInfo equivalent
			switch (iOsLanguage)
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
		string ToDotnetFallbackLanguage (PlatformCulture platCulture)
		{
			Console.WriteLine(".NET Fallback Language:" + platCulture.LanguageCode);
			var netLanguage = platCulture.LanguageCode; // use the first part of the identifier (two chars, usually);

			switch (platCulture.LanguageCode)
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
