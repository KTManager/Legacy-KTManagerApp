using System.IO;

namespace KillTeam.Services
{
    public interface ISave
    {

        bool HasRight();

        string Save(string filename, string contentType, string content);

        void OpenPDF(string filename);

    }
}
