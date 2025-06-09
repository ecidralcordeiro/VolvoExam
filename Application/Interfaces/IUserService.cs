using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IUserService
{
    Task<UserDTO> CreateAsync(UserDTO userDto);
    Task<UserDTO> UpdateAsync(UserDTO userDto);
    Task<UserDTO> DeleteAsync(int id);
    Task<UserDTO> GetByIdAsync(int id);
    Task<UserDTO> GetUserByLoginAndPassword(string login, string password);
    Task<IEnumerable<UserDTO>> GetAllAsync();
}
