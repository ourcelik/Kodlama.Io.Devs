using Core.Security.Entities;
using Core.Security.JWT;

public interface IAuthRepository
{
    Task<User> Register(User user, string password);
    Task<User> Login(string username, string password);
    Task<bool> UserExists(string username);
    Task<AccessToken> CreateAccessToken(User user);
}