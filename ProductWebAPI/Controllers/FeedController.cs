using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessObjects.Interfaces.IServices;
using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.DTOs.Feed;

namespace ProductWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeedController(IFeedService feedService) : ControllerBase
{
    private readonly IFeedService _feedService = feedService;
    [HttpGet("all"), Authorize]
    public async Task<ActionResult<PaginatedData<FeedDTO>>> GetFeeds([FromQuery] QueryFeedDTO query)
    {
        var username = User.Identity?.Name;
        var feeds = await _feedService.GetFeeds(username!, query);
        return Ok(new Response
        {
            Message = "Get topic successfully",
            Status = ResponseStatus.SUCCESS,
            Data = feeds
        });
    }
    [HttpGet("{name}"), Authorize]
    public async Task<ActionResult<FeedDTO>> GetFeedByName(string name)
    {
        var username = User.Identity?.Name;
        var feed = await _feedService.GetFeed(username!, name);
        return Ok(new Response
        {
            Message = "Get topic successfully",
            Status = ResponseStatus.SUCCESS,
            Data = feed
        });
    }

    [HttpDelete("{name}"), Authorize]
    public async Task<IActionResult> DeleteFeedByName(string name)
    {
        var username = User.Identity?.Name;
        await _feedService.DeleteFeed(username!, name);
        return Ok(new Response
        {
            Message = "Delete feed successfully",
            Status = ResponseStatus.SUCCESS,
        });
    }

    [HttpPost("create"), Authorize]
    public async Task<IActionResult> CreateFeed(CreateFeedDTO createFeedDTO)
    {
        var username = User.Identity?.Name;
        await _feedService.CreateFeed(username!, createFeedDTO);
        return Ok(new Response
        {
            Message = "Create topic successfully",
            Status = ResponseStatus.SUCCESS,
        });
    }

    [HttpPost("add"), Authorize]
    public async Task<IActionResult> AddTopicToFeed(AddFeedDTO addFeedDTO)
    {
        var username = User.Identity?.Name;
        await _feedService.AddTopicToFeed(username!, addFeedDTO);
        return Ok(new Response
        {
            Message = "Get topic successfully",
            Status = ResponseStatus.SUCCESS,
        });
    }

    [HttpPost("remove"), Authorize]
    public async Task<IActionResult> RemoveTopicFromFeed(RemoveFeedDTO removeFeedDTO)
    {
        var username = User.Identity?.Name;
        await _feedService.RemoveTopicFromFeed(username!, removeFeedDTO);
        return Ok(new Response
        {
            Message = "Get topic successfully",
            Status = ResponseStatus.SUCCESS,
        });
    }
}
