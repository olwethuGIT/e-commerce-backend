using api.Dto;
using api.Models;

namespace api.IData
{
    public interface IAuthenticationRepository
    {
        Task<User> Login(AuthDto authDto);
        Task<User> Register(User authDto, string password);
        Task<bool> UserExists(string username);
    }
}
