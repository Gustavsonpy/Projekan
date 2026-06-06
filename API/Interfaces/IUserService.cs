using API.DTO;
using API.Models;

namespace API.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> CreateAsync(UserDTO user);
        Task<List<UserDTO>> FindAllAsync();
    }
}
