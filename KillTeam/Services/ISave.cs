using System.IO;

namespace KillTeam.Services
{
    public interface ISave
    {

        bool HasRight();

        string Save(string filename, string contentType, MemoryStream stream);

        void OpenPDF(string filename);

    }
}
