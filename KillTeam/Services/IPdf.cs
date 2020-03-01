using System.IO;

namespace KillTeam.Services
{
    public interface IPdf
    {
        MemoryStream Pdf(string filename);
    }
}
