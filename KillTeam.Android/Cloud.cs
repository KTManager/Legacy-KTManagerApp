using System.Threading.Tasks;
using Android;
using Android.Content.PM;
using KillTeam.Droid;
using KillTeam.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(Cloud))]
namespace KillTeam.Droid
{
    public class Cloud : ICloud
    {
        public bool IsConnected()
        {            
            return GameHelper.Helper.IsConnected();
        }

        public async Task<byte[]> Synchro(byte[] data)
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
                if (Android.App.Application.Context.CheckSelfPermission(Manifest.Permission.Internet) != (int)Permission.Granted
                       || Android.App.Application.Context.CheckSelfPermission(Manifest.Permission.GetAccounts) != (int)Permission.Granted)
            {
                    return null;
            }
            return await GameHelper.Helper.Synchro(data);
        }

        public void SignIn()
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
                if (Android.App.Application.Context.CheckSelfPermission(Manifest.Permission.Internet) != (int)Permission.Granted
                       || Android.App.Application.Context.CheckSelfPermission(Manifest.Permission.GetAccounts) != (int)Permission.Granted)
            {
                    Android.Support.V4.App.ActivityCompat.RequestPermissions(MainActivity.Instance, new string[]
                           {
                                            Manifest.Permission.Internet,
                                            Manifest.Permission.GetAccounts,
                           }, 0);
                    return;
            }
            GameHelper.Helper.SignIn();
        }

        public void SignOut()
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
                if (Android.App.Application.Context.CheckSelfPermission(Manifest.Permission.Internet) != (int)Permission.Granted
                       || Android.App.Application.Context.CheckSelfPermission(Manifest.Permission.GetAccounts) != (int)Permission.Granted)
            {
                return;
            }
            GameHelper.Helper.SignOut();
        }

        public void Save(byte[] data)
        {
            GameHelper.Helper.Save(data);
        }
    }
}