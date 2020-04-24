using System;
using System.Drawing;
using System.IO;
using Foundation;
using KillTeam.iOS;
using KillTeam.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveIOS))]
namespace KillTeam.iOS
{
    public class SaveIOS : ISave
    {

        public bool HasRight()
        {
            return true;
        }

        public void OpenPDF(string filename)
        {
            var viewer = UIDocumentInteractionController.FromUrl(NSUrl.FromFilename(filename));
            viewer.PresentOpenInMenu(new RectangleF(0, -260, 320, 320), GetVisibleViewController().View, true);
        }

        public string Save(string fileName, String contentType, string content)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            
            File.WriteAllText(filePath, content);
            
            return filePath;
        }

        private UIViewController GetVisibleViewController(UIViewController controller = null)
        {
            controller = controller ?? UIApplication.SharedApplication.KeyWindow.RootViewController;

            if (controller.PresentedViewController == null)
                return controller;

            if (controller.PresentedViewController is UINavigationController)
            {
                return ((UINavigationController)controller.PresentedViewController).VisibleViewController;
            }

            if (controller.PresentedViewController is UITabBarController)
            {
                return ((UITabBarController)controller.PresentedViewController).SelectedViewController;
            }

            return GetVisibleViewController(controller.PresentedViewController);
        }
    }
}