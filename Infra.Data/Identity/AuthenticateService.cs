using Domain.Interfaces;
using Infra.Data.Securities;
namespace Infra.Data.Identity;

public class AuthenticateService
{
    private readonly IUserRepository _userRepository;
    public AuthenticateService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        var passwordHash = CriptografyService.criptografyPassword(password);

        var user = await _userRepository.GetUserByLoginAndPassword(email, password);
        if (user == null)
        {
            return false;
        }

        return true;
    }

    public string generateToken(int id, string email)
    {
        var token = TokenService.GenerateToken(id, email);
        return token;
    }

    public async Task<bool> UserExists(string email)
    {
        var users = await _userRepository.GetAllAsync();
        var user = users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        if (user == null)
        {
            return false;
        }

        return true;
    }
}
