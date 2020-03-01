using System;
using System.IO;
using CarouselView.FormsPlugin.iOS;
using Foundation;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfNumericUpDown.XForms.iOS;
using UIKit;

namespace KillTeam.iOS
{


    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            SQLitePCL.Batteries_V2.Init(); // TODO(jakemco): do we even need this?
            global::Xamarin.Forms.Forms.Init();
            SfListViewRenderer.Init();
            CarouselViewRenderer.Init();
            
            new Syncfusion.SfNavigationDrawer.XForms.iOS.SfNavigationDrawerRenderer();
            
            SfNumericUpDownRenderer.Init();

            // Old verions of the app stored the DB in a different spot, fix it up here
            MoveLegacyDB();

            Console.WriteLine("START");

            LoadApplication(new KTApp());

            return base.FinishedLaunching(app, options);
        }

        // DB used to be stored under a different name
        private const string LegacyDBName = "KTDatabseProd.db";
        private void MoveLegacyDB()
        {
            string newDBPath = KillTeam.Services.KTContext.DBPath;
            string LegacyDBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), LegacyDBName);
            if (File.Exists(LegacyDBPath))
            {
                if (File.Exists(newDBPath))
                {
                    // backup in case we fucked everything up, we can release an update that fixes it
                    string backupPath = newDBPath + $".backup.{new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds()}";
                    File.Move(newDBPath, backupPath);
                }
                File.Move(LegacyDBPath, newDBPath);
            }
        }
    }
}
