using System.IO;
using KillTeam.Droid;
using KillTeam.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(PdfIOS))]
namespace KillTeam.Droid
{
    public class PdfIOS : IPdf
    {
        public MemoryStream Pdf(string fileName)
        {
            StreamReader docStream = new StreamReader(fileName);
            MemoryStream memoryStream = new MemoryStream();
            docStream.BaseStream.CopyTo(memoryStream);
            return memoryStream;
        }
    }
}