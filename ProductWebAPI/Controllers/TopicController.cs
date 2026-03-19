using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessObjects.Interfaces.IServices;
using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.DTOs.Search;
using BusinessObjects.Models.DTOs.Topic;

namespace ProductWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TopicController(ITopicService topicService) : ControllerBase
{
    private readonly ITopicService _topicService = topicService;

    [HttpGet("paginated"), Authorize]
    public async Task<ActionResult<PaginatedResponse<TopicDTO>>> GetTopicsPaginated([FromQuery] int page = 1,
     [FromQuery] int pageSize = 10)
    {
        var data = await _topicService.GetTopicsWithPagination(page, pageSize);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Data = data,
            Message = "Topics retrieved successfully"
        });
    }

    [HttpGet("by-major/{majorId}/paginated"), Authorize]
    public async Task<ActionResult<PaginatedResponse<TopicDTO>>> GetTopicsByMajorPaginated(Guid majorId, [FromQuery] int page = 1,
     [FromQuery] int pageSize = 10)
    {
        var data = await _topicService.GetTopicsByMajorWithPagination(majorId, page, pageSize);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Data = data,
            Message = "Topics by major retrieved successfully"
        });
    }

    [HttpGet("active-all"), Authorize]
    public async Task<ActionResult<IEnumerable<TopicDTO>>> GetAllActiveTopics()
    {
        var topics = await _topicService.GetActiveTopics() ?? [];
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Data = topics,
            Message = "Topics retrieved successfully"
        });
    }

    [HttpGet("search"), Authorize]
    public async Task<ActionResult<IEnumerable<TopicDTO>>> SearchTopics([FromQuery] string value, [FromQuery] int size = 10)
    {
        var topics = await _topicService.SearchTopics(value, size);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Data = topics,
            Message = "Topics retrieved successfully"
        });
    }

    [HttpGet("{id}"), Authorize]
    public async Task<ActionResult<TopicDTO>> GetTopicById(Guid id)
    {
        var topic = await _topicService.GetTopicById(id);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Data = topic,
            Message = "Topic retrieved successfully"
        });
    }

    [HttpGet("search/keyword"), Authorize]
    public async Task<ActionResult<IEnumerable<TopicDTO>>> SearchTopicContainKeywordAsync([FromQuery] QuerySearchTopicDTO query)
    {
        var topics = await _topicService.SearchTopicContainKeywordAsync(query);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Data = topics,
            Message = "Topics retrieved successfully"
        });
    }

    [HttpPut("update/{id}"), Authorize]
    public async Task<ActionResult<TopicDTO>> UpdateTopic(Guid id, [FromBody] EditTopicDTO topicDto)
    {
        await _topicService.UpdateTopic(id, topicDto);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Topic updated successfully"
        });
    }

    [HttpGet("monitor/{name}")]
    public async Task<ActionResult<TopicDTO>> MonitorTopic(string name)
    {
        var topic = await _topicService.MonitorTopic(name);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Topic monitored successfully",
            Data = topic
        });
    }

    [HttpPost("ban")]
    public async Task<ActionResult<TopicBanDTO>> BanUser([FromBody] CreateTopicBanDTO topicBanDTO)
    {
        var user = await _topicService.BanUser(topicBanDTO);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "User banned successfully",
            Data = user
        });
    }

    [HttpPost("unban")]
    public async Task<IActionResult> UnbanUser(string username, string topicName)
    {
        await _topicService.UnbanUser(username, topicName);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "User unban successfully",
        });
    }

    [HttpGet("check-banned")]
    public async Task<ActionResult<TopicBanDTO>> CheckBanned([FromQuery] string username, [FromQuery] string topicName)
    {
        var topicBan = await _topicService.CheckBannedUser(username, topicName);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Check user banned successfully",
            Data = topicBan
        });
    }

    [HttpPost("create"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateTopic([FromBody] CreateTopicDTO topicDto)
    {
        await _topicService.CreateTopic(topicDto);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Topic created successfully"
        });
    }

    [HttpPut("delete/{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteTopic(Guid id)
    {
        await _topicService.DeleteTopicToTrash(id);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Topic deleted successfully"
        });
    }
    [HttpPut("restore/{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> RestoreTopic(Guid id)
    {
        await _topicService.RestoreTopic(id);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Topic restored successfully"
        });
    }
    [HttpDelete("delete-permanently/{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteTopicPermanently(Guid id)
    {
        await _topicService.DeleteTopic(id);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Topic deleted permanently"
        });
    }
    [HttpGet("trash"), Authorize(Roles = "Admin")]
    public async Task<ActionResult<PaginatedResponse<TopicTrashDTO>>> GetTopicByTrash([FromQuery] int page = 1,
     [FromQuery] int pageSize = 10)
    {
        var data = await _topicService.GetTopicByTrashWithPaginationAsync(page, pageSize);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Data = data,
            Message = "Topics in trash retrieved successfully"
        });
    }
    [HttpGet("filter"), Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<TopicDTO>>> GetTopicsByMajor([FromQuery] Guid idMajor)
    {
        var topics = await _topicService.GetTopicsByMajot(idMajor);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Data = topics,
            Message = "Topics retrieved successfully"
        });
    }
}
