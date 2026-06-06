using API.data;
using API.DTO;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.User.AddAsync(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> ExistsByEmail(string email)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<User>> FindAllAsync()
        {
            return await _context.User.ToListAsync();
        }
    }
}