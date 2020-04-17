using System;
using KillTeam.iOS;
using KillTeam.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ApplePrintService))]
namespace KillTeam.iOS
{
    public class ApplePrintService : IPrintService
    {
        public void Print(WebView viewToPrint)
        {
            if (viewToPrint == null) throw new ArgumentNullException(nameof(viewToPrint));
            var appleViewToPrint = Xamarin.Forms.Platform.iOS.Platform.CreateRenderer(viewToPrint).NativeView;
 
            var printInfo = UIPrintInfo.PrintInfo;
 
            printInfo.OutputType = UIPrintInfoOutputType.General;
            printInfo.JobName = "Forms EZ-Print";
            printInfo.Orientation = UIPrintInfoOrientation.Portrait;
            printInfo.Duplex = UIPrintInfoDuplex.None;

            var printController = UIPrintInteractionController.SharedPrintController;
 
            printController.PrintInfo = printInfo;
            printController.ShowsPageRange = true;
            printController.PrintFormatter = appleViewToPrint.ViewPrintFormatter;
 
            printController.Present(true, (printInteractionController, completed, error) => { });        
        }
    }
}