using API.Models;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);

        Task<User?> ExistsByEmail(string email);

        Task<List<User>> FindAllAsync();
    }
}   
