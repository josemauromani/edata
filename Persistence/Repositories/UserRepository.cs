using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int userId, CancellationToken cancellationToken = default)
        {
            return await _context.Users.SingleOrDefaultAsync(user => user.Id == userId);
        }

        public async Task<User> Insert(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> Delete(User user)
        {
            _context.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

    }
}
