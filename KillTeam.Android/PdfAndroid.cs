using System.IO;
using KillTeam.Droid;
using KillTeam.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(PdfAndroid))]
namespace KillTeam.Droid
{
    public class PdfAndroid : IPdf
    {
        public MemoryStream Pdf(string fileName)
        {
            Stream docStream = Android.App.Application.Context.Assets.Open(fileName);
            MemoryStream memoryStream = new MemoryStream();
            docStream.CopyTo(memoryStream);
            return memoryStream;
        }
    }
}