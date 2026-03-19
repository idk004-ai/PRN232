using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessObjects.Interfaces.IServices;
using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.DTOs.Vote;

namespace ProductWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VoteController(IVoteService voteService, IProfileService profileService) : ControllerBase
{
    private readonly IVoteService _voteService = voteService;
    private readonly IProfileService _profileService = profileService;
    [HttpPatch("post"), Authorize]
    public async Task<ActionResult<int>> VotePost([FromBody] VoteDTO voteDTO)
    {
        var username = User.Identity?.Name;
        var count = await _voteService.GetVotePost(username!, voteDTO);
        await _voteService.SendVotePostNotificationAsync(username!, voteDTO);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Vote success",
            Data = count
        });
    }

    [HttpPatch("comment"), Authorize]
    public async Task<ActionResult<int>> VoteComment(VoteCommentDTO voteDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var username = User.Identity?.Name;
        var profile = await _profileService.GetByName(username!);
        await _voteService.SendVoteCommentNotificationAsync(username!, voteDTO, profile!.Avatar);
        var count = await _voteService.VoteComment(username!, voteDTO);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Vote success",
            Data = count
        });
    }
    [HttpGet("daily-top-voters")]
    public async Task<ActionResult<DailyVoteStatDTO>> GetDailyTopVoters(
           [FromQuery] DateOnly? fromDate = null,
           [FromQuery] DateOnly? toDate = null)
    {
        var from = fromDate ?? DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-7));
        var to = toDate ?? DateOnly.FromDateTime(DateTime.UtcNow);
        var result = await _voteService.GetDailyTopVotersAsync(from, to);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Get daily top voters successfully",
            Data = result
        });
    }
}