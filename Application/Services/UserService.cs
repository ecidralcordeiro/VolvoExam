using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using AutoMapper;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDTO> CreateAsync(UserDTO userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var createdUser = await _userRepository.CreateAsync(user);
        return _mapper.Map<UserDTO>(createdUser);
    }

    public async Task<UserDTO> UpdateAsync(UserDTO userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var updatedUser = await _userRepository.UpdateAsync(user);
        return _mapper.Map<UserDTO>(updatedUser);
    }

    public async Task<UserDTO> DeleteAsync(int id)
    {
        var deletedUser = await _userRepository.DeleteAsync(id);
        return _mapper.Map<UserDTO>(deletedUser);
    }

    public async Task<IEnumerable<UserDTO>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserDTO>>(users);
    }

    public async Task<UserDTO> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> GetUserByLoginAndPassword(string login, string password)
    {
        var user = await _userRepository.GetUserByLoginAndPassword(login, password);
        return _mapper.Map<UserDTO>(user);
    }
}