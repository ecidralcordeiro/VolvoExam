using Domain.Interfaces;
using Domain.Models;
using Infra.Data.Securities;

public class UserRepository : IUserRepository
{
    private List<User> users = new List<User>();

    public async Task<User> CreateAsync(User user)
    {
        user.Password = CriptografyService.criptografyPassword(user.Password);
        users.Add(user);
        return user;
    }

    public Task<User> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return users.ToList();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
        if (existingUser != null)
        {
            users.Remove(existingUser);
            users.Add(user);
        }
        return user;
    }

    public async Task<User> GetUserByLoginAndPassword(string email, string password)
    {
        var user = users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Password == password);
        return user;
    }
}
