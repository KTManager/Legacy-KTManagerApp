using System;
using System.IO;
using Android;
using Android.Content;
using Android.Content.PM;
using Java.IO;
using KillTeam.Droid;
using KillTeam.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndroid))]
namespace KillTeam.Droid
{
    public class SaveAndroid : ISave
    {
        public bool HasRight()
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
                if (Android.App.Application.Context.CheckSelfPermission(Manifest.Permission.WriteExternalStorage) != (int)Permission.Granted)
                {
                    Android.Support.V4.App.ActivityCompat.RequestPermissions(MainActivity.Instance, new string[]
                    {
                        Manifest.Permission.WriteExternalStorage
                    }, 0);
                    return false;
                }
            return true;
         
        }

        public void OpenPDF(string filename)
        {
            if (filename != null)
            {
                Java.IO.File file = new Java.IO.File(filename);
                Android.Net.Uri path = Android.Net.Uri.FromFile(file);
                string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);

                Intent intent = new Intent(Intent.ActionView);
                intent.SetDataAndType(path, mimeType);
                intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);

                Android.App.Application.Context.StartActivity(intent);
            }
        }

        public string Save(string fileName, String contentType, MemoryStream stream)
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
                if (Android.App.Application.Context.CheckSelfPermission(Manifest.Permission.WriteExternalStorage) != (int)Permission.Granted)
            {
                return null;
            }

            string root = null;

            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
            {
                root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            }

            root += "/KillTeam/";
            
            Directory.CreateDirectory(root);
            Java.IO.File file = new Java.IO.File(root, fileName);

            if (file.Exists())
                file.Delete();

            FileOutputStream outs = new FileOutputStream(file);
            outs.Write(stream.ToArray());
            outs.Flush();
            outs.Close();
            return file.AbsolutePath;
        }
    }
}