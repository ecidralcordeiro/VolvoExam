using Domain.Models;
namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);
    Task<User> DeleteAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task<User> UpdateAsync(User user);
    Task<User> GetUserByLoginAndPassword(string email, string password);
  
}
