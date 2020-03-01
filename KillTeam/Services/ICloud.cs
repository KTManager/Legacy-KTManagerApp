using System.Threading.Tasks;

namespace KillTeam.Services
{
    public interface ICloud
    {
        void SignIn();

        void SignOut();

        Task<byte[]> Synchro(byte[] data);
        
        bool IsConnected();

        void Save(byte[] data);
    }
}
