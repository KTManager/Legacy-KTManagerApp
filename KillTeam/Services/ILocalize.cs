using System;
using System.Globalization;

namespace KillTeam.Services
{
	/// <summary>
	/// Implementations of this interface MUST convert iOS and Android
	/// platform-specific locales to a value supported in .NET because
	/// ONLY valid .NET cultures can have their RESX resources loaded and used.
	/// </summary>
	/// <remarks>
	/// Lists of valid .NET cultures can be found here:
	///   http://www.localeplanet.com/dotnet/
	///   http://www.csharp-examples.net/culture-names/
	/// You should always test all the locales implemented in your application.
	/// </remarks>
	public interface ILocalize
	{
        ///	<summary>
        /// This method must evaluate platform-specific locale settings
        /// and convert them (when necessary) to a valid .NET locale.
        /// </summary>
        CultureInfo GetCurrentCultureInfo();

        CultureInfo GetDefaultCultureInfo();

        /// <summary>
        /// CurrentCulture and CurrentUICulture must be set in the platform project, 
        /// because the Thread object can't be accessed in a PCL.
        /// </summary>
        void SetLocale (CultureInfo ci);
	}

	/// <summary>
	/// Helper class for splitting locales like
	///   iOS: ms_MY, gsw_CH
	///   Android: in-ID
	/// into parts so we can create a .NET culture (or fallback culture)
	/// </summary>
	public class PlatformCulture
	{
        public string FullCultureName { get; }

        public string LanguageCode { get; }

        public string LocaleCode { get; }

		public PlatformCulture (string platformCultureString)
		{
			if (string.IsNullOrEmpty(platformCultureString)) throw new ArgumentException("Expected culture identifier", nameof(platformCultureString));

			FullCultureName = platformCultureString.Replace("_", "-"); // .NET expects dash, not underscore
			var dashIndex = FullCultureName.IndexOf("-", StringComparison.Ordinal);
			if (dashIndex > 0)
			{
				var parts = FullCultureName.Split('-');
				LanguageCode = parts[0];
				LocaleCode = parts[1];
			}
			else
			{ 
				LanguageCode = FullCultureName;
				LocaleCode = string.Empty;
			}
		}

		public override string ToString()
		{
			return FullCultureName;
		}
	}
}

