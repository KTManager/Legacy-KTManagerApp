using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using KillTeam.Properties;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KillTeam.Services
{
    // You exclude the 'Extension' suffix when using in XAML
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        const string RESOURCE_ID = "KillTeam.Properties.Resources";

        static readonly Lazy<ResourceManager> _resMgr = new Lazy<ResourceManager>(() => new ResourceManager(RESOURCE_ID, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public string Text { get; set; }

        public static CultureInfo Ci { get; set;}

        public TranslateExtension()
        {
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                if(Ci == null)
                {
                    Ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                }
                try
                {
                    _resMgr.Value.GetString("AddEquipeButton", Ci);
                }
                catch (MissingManifestResourceException  ex)
                {
                    Crashes.TrackError(ex);
                    Ci = DependencyService.Get<ILocalize>().GetDefaultCultureInfo(); ;
                }
                Resources.Culture = Ci;
            }
            /*IServiceProvider serviceProvider;
            ProvideValue(serviceProvider);*/
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return string.Empty;

            string translation = _resMgr.Value.GetString(Text, Ci);
            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    string.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, RESOURCE_ID, Ci.Name),
                    "Text");
#else
				translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }
}