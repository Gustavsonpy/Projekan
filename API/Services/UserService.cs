using API.DTO;
using API.Interfaces;
using API.Models;
using System.Threading.Tasks;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDTO> CreateAsync(UserDTO dto)
        {
            var existedUser = await _repository.ExistsByEmail(dto.Email);

            if(existedUser != null)
            {
                throw new Exception("User already exists with this email");
            }

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password,
            };

            await _repository.CreateAsync(user);

            return new UserDTO
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password
            };
        }

        public async Task<List<UserDTO>> FindAllAsync()
        {
            var users = await _repository.FindAllAsync();

            return users.Select(u => new UserDTO
            {
                Username = u.Username,
                Email = u.Email,
                Password = u.Password
            }).ToList();
        }
    }
}
