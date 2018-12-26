using System.Collections.Generic;
using System.Threading.Tasks;
using Engage.API.Models;

namespace Engage.API.Data
{
    public interface IEngageRepository
    {
         void Add<T>(T entity) where T: class;
         void Detete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
    }
}