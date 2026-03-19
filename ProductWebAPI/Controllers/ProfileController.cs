using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessObjects.Interfaces.IServices;
using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.DTOs.Profile;

namespace ProductWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileController(IProfileService profileService) : ControllerBase
{
    private readonly IProfileService _profileService = profileService;
    [HttpGet("{username}"), Authorize]
    public async Task<ActionResult<ProfileDTO>> GetProfile(string username)
    {
        var profile = await _profileService.GetByName(username);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Data = profile,
            Message = "Profile retrieved successfully"
        });
    }

    [HttpPut("edit/{username}"), Authorize]
    public async Task<IActionResult> EditProfile(string username, [FromBody] ProfileDTO profileDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _profileService.UpdateProfile(username, profileDTO);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Profile updated successfully"
        });
    }

    [HttpPost("create"), Authorize]
    public async Task<IActionResult> CreateProfile([FromBody] ProfileDTO profile)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var username = User.FindFirstValue(ClaimTypes.Name);
        await _profileService.InsertProfile(profile, username!);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Profile created successfully",
        });
    }
}