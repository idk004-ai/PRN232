using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessObjects.Interfaces.IServices;
using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.DTOs.Search;
using BusinessObjects.Models.DTOs.User;

namespace ProductWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;
    [HttpGet("all")]
    public async Task<ActionResult<PaginatedData<UserDTO>>> GetAll([FromQuery] QueryUserDTO query)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var users = await _userService.GetAll(query);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Get users successfully!",
            Data = users
        });
    }

    [HttpPost("edit"), Authorize]
    public async Task<IActionResult> EditUser([FromBody] EditUserDTO editUserDTO)
    {
        await _userService.EditUser(editUserDTO);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Update user successfully!",
        });
    }

    [HttpGet("profile"), Authorize]
    public async Task<ActionResult<UserDTO>> GetProfileByUser()
    {
        var username = User.FindFirstValue(ClaimTypes.Name);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Data = await _userService.GetProfileByName(username!),
            Message = "Profile retrieved successfully"
        });
    }

    [HttpGet("search"), Authorize]
    public async Task<ActionResult<UserDTO>> SearchUserByName([FromQuery] QuerySearchUserDTO querySearchUserDTO)
    {
        var users = await _userService.SearchUserByName(querySearchUserDTO);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Data = users,
            Message = "Users retrieved successfully"
        });
    }

    [HttpPost("banned-user"), Authorize]
    public async Task<ActionResult<UserDTO>> BannedUser([FromBody] LockUserDTO lockUserDTO)
    {
        var userBan = await _userService.BanUser(lockUserDTO);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Banned User successfully",
            Data = userBan
        });
    }

    [HttpGet("unban-user/{username}"), Authorize]
    public async Task<ActionResult<UserDTO>> UnlockUser(string username)
    {
        var user = await _userService.UnlockUser(username);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "UnBan user successfully",
            Data = user
        });
    }
    [HttpGet("user-top")]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUserTop([FromQuery] int type)
    {
        var users = await _userService.GetUserVoteTop(type);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Data = users,
            Message = "Top users retrieved successfully"
        });
    }
}