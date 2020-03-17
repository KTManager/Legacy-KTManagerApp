using System;

using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using AuditApp.Android;
using Xamarin.Forms;
using Android.Content;
using Sharpnado.Presentation.Forms.Droid;

namespace KillTeam.Droid
{
    [Activity(Label = "KillTeam", Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Instance = this;
            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build());
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Forms.SetFlags("SwipeView_Experimental");
            Forms.Init(this, savedInstanceState);

            SharpnadoInitializer.Initialize();

            LoadApplication(new KTApp());
            var ci = DependencyService.Get<Localize>().GetCurrentCultureInfo();            
            AndroidPlaystoreAudit.Instance.UsesUntilPrompt = 1;
            AndroidPlaystoreAudit.Instance.TimeUntilPrompt = new TimeSpan(2, 0, 0, 0);

            if(ci.TwoLetterISOLanguageName == "fr")
            {
                AndroidPlaystoreAudit.Instance.DontRemindButtonText = "Ne plus afficher";
                AndroidPlaystoreAudit.Instance.RemindLaterButtonText = "Me rappeler plus tard";
                AndroidPlaystoreAudit.Instance.ReviewAppStoreButtonText = "Noter l'application";
                AndroidPlaystoreAudit.Instance.PromptTitle = "Pourriez-vous prendre une minute pour noter cette application?";
            }
            AndroidPlaystoreAudit.Instance.Run(this);

            GameHelper.Helper = new GameHelper(this);
            GameHelper.Helper.GravityForPopups = (GravityFlags.Bottom | GravityFlags.Center);
            GameHelper.Helper.ViewForPopups = FindViewById<Android.Views.View>(Resource.Id.container);
           
            GameHelper.Helper.Initialize();
        }

        protected override void OnStart()
        {
            base.OnStart();
            if (GameHelper.Helper != null)
                GameHelper.Helper.Start();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (GameHelper.Helper != null)
                GameHelper.Helper.OnActivityResult(requestCode, resultCode, data);
            base.OnActivityResult(requestCode, resultCode, data);
        }

        protected override void OnStop()
        {
            if (GameHelper.Helper != null)
                GameHelper.Helper.Stop();
            base.OnStop();
        }

    }
}