using System.Threading.Tasks;
using KillTeam.iOS;
using KillTeam.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(Cloud))]
namespace KillTeam.iOS
{
    public class Cloud : ICloud
    {
        public bool IsConnected()
        {
            return false;
        }

        public async Task<byte[]> Synchro(byte[] data)
        {
            return null;
        }

        public void SignIn()
        {

        }

        public void SignOut()
        {

        }

        public void Save(byte[] data)
        {

        }
    }
}