using System.Collections.Generic;
using System.Threading.Tasks;
using Engage.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Engage.API.Data
{
    public class EngageRepository : IEngageRepository
    {
        public EngageRepository(DataContext context)
        {
            _context = context;
        }

        public DataContext _context { get; }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Detete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}