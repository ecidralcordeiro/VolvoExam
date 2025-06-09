using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync(UserDTO userDTO)
    {

        var createdUserDTO = await _userService.CreateAsync(userDTO);
        if (createdUserDTO == null)
        {
            return BadRequest("");
        }
        return Ok(createdUserDTO);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync(UserDTO userDTO)
    {
        var updatedUserDTO = await _userService.UpdateAsync(userDTO);
        if (updatedUserDTO == null)
        {
            return BadRequest("");
        }
        return Ok(updatedUserDTO);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var deletedUserDTO = await _userService.DeleteAsync(id);
        if (deletedUserDTO == null)
        {
            return BadRequest("");
        }
        return Ok();
    }
    [HttpGet]
    public async Task<ActionResult> GetAllAsync()
    {
        var usersDTO = await _userService.GetAllAsync();

        return Ok(usersDTO);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetByIdAsync(int id)
    {
        var userDTO = await _userService.GetByIdAsync(id);
        if (userDTO == null)
        {
            return NotFound();
        }
        return Ok(userDTO);
    }
}

