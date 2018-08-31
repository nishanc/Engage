using System.Threading.Tasks;
using Engage.API.Models;

namespace Engage.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password); 
         Task<User> Login(string username, string pasword);
         Task<bool> UserExists(string username);
    }
}