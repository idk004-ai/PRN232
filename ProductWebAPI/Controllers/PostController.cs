using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessObjects.Interfaces.IServices;
using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.DTOs.Post;
using BusinessObjects.Models.DTOs.Search;

namespace ProductWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController(IPostService postService) : ControllerBase
{
    private readonly IPostService _postService = postService;
    [HttpPost("create"), Authorize]
    public async Task<ActionResult<PostDTO>> CreatePost([FromBody] CreatePostDTO postDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var username = User.FindFirst(ClaimTypes.Name)?.Value;
        var post = await _postService.CreatePost(postDTO, username!) ?? throw new Exception("Post not created");
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Data = post,
            Message = "Post created successfully"
        });
    }

    [HttpGet("all"), Authorize]
    public async Task<ActionResult<IEnumerable<PostDTO>>> GetPosts([FromQuery] QueryPostDTO query)
    {
        var username = User.Identity?.Name;
        var posts = await _postService.GetPostsAsync(query, username!) ?? [];
        return Ok(new Response
        {
            Message = "Get Posts successfully",
            Status = ResponseStatus.SUCCESS,
            Data = posts
        });
    }

    [HttpPost("save/{postId}"), Authorize]
    public async Task<IActionResult> SavePost(Guid postId)
    {
        var username = User.Identity?.Name;
        await _postService.SavePostByUser(postId, username!);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Post saved successfully"
        });
    }
    [HttpDelete("remove-save/{postId}"), Authorize]
    public async Task<IActionResult> RemoveSavePost(Guid postId)
    {
        var username = User.Identity?.Name;
        await _postService.RemoveSavePostByUser(postId, username!);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Post removed from saved successfully"
        });
    }

    [HttpGet("saved-all"), Authorize]
    public async Task<ActionResult<IEnumerable<PostDTO>>> GetSavedPosts([FromQuery] QueryPostDTO query)
    {
        var username = User.Identity?.Name;
        var posts = await _postService.GetPostSaveByUser(query, username!) ?? [];
        return Ok(new Response
        {
            Message = "Get Saved Posts successfully",
            Status = ResponseStatus.SUCCESS,
            Data = posts
        });
    }
    [HttpPost("move-trash/{postId}"), Authorize]
    public async Task<IActionResult> MoveToTrash(Guid postId)
    {
        var username = User.Identity?.Name;
        await _postService.MovePostToTrash(postId, username!);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Post moved to trash successfully"
        });
    }

    [HttpPost("restore-trash/{postId}"), Authorize]
    public async Task<IActionResult> RestoreFromTrash(Guid postId)
    {
        var username = User.Identity?.Name;
        await _postService.RestorePostFromTrash(postId, username!);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Post restored from trash successfully"
        });
    }

    [HttpGet("{id}"), Authorize]
    public async Task<ActionResult<PostDTO>> GetPost([FromRoute] Guid id)
    {
        var userName = User.Identity?.Name;
        var post = await _postService.GetPostById(id, userName!);
        return Ok(new Response
        {
            Message = "Get Post successfully",
            Status = ResponseStatus.SUCCESS,
            Data = post
        });
    }

    [HttpPost("recent/{postID}"), Authorize]
    public async Task<ActionResult<RecentPostDTO>> AddRecentPost([FromRoute] Guid postID)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var userName = User.FindFirstValue(ClaimTypes.Name);
        var recentPost = await _postService.AddRecentPostByUser(new() { PostId = postID, UserName = userName! });
        return Ok(new Response
        {
            Data = recentPost,
            Message = "Post added to recent",
            Status = (int)HttpStatusCode.OK + "",
        });
    }

    [HttpPut("edit/{id}"), Authorize]
    public async Task<IActionResult> EditPost([FromRoute] Guid id, [FromBody] EditPostDTO editPostDTO)
    {
        await _postService.EditPost(id, editPostDTO);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Post edited successfully"
        });
    }

    [HttpGet("search"), Authorize]
    public async Task<ActionResult<IEnumerable<PostDTO>>> SearchPost([FromQuery] QuerySearchPostDTO query)
    {
        var username = User.Identity?.Name;
        var posts = await _postService.SearchPost(query, username!) ?? [];
        return Ok(new Response
        {
            Message = "Search Posts successfully",
            Status = ResponseStatus.SUCCESS,
            Data = posts
        });
    }

    [HttpGet("approve/{id}"), Authorize]
    public async Task<ActionResult<PostDTO>> ApprovePost([FromRoute] Guid id)
    {
        var postDto = await _postService.ApprovePost(id);
        return Ok(new Response
        {
            Message = "Approve Post successfully",
            Status = ResponseStatus.SUCCESS,
            Data = postDto
        });
    }

    [HttpGet("feed/{feedName}"), Authorize]
    public async Task<ActionResult<IEnumerable<PostDTO>>> GetPostInFeed([FromQuery] QueryPostDTO query,
     [FromRoute] string feedName)
    {
        var userName = User.FindFirstValue(ClaimTypes.Name);
        var posts = await _postService.GetPostsInFeed(userName!, feedName, query);
        return Ok(new Response
        {
            Message = "Get Posts successfully",
            Status = ResponseStatus.SUCCESS,
            Data = posts
        });
    }

    [HttpGet("recent"), Authorize]
    public async Task<ActionResult<IEnumerable<PostDTO>>> GetAllRecentPosts()
    {
        var userName = User.FindFirstValue(ClaimTypes.Name);
        var posts = await _postService.GetRecentPostsByUser(userName!);
        return Ok(new Response
        {
            Message = "Get Posts successfully",
            Status = ResponseStatus.SUCCESS,
            Data = posts ?? []
        });
    }

    [HttpDelete("clear-recent"), Authorize]
    public async Task<IActionResult> ClearRecentPosts()
    {
        var userName = User.FindFirstValue(ClaimTypes.Name);
        await _postService.ClearRecentPostsByUser(userName!);
        return Ok(new Response
        {
            Message = "Get Posts successfully",
            Status = ResponseStatus.SUCCESS,
        });
    }

    [HttpDelete("delete/{id}"), Authorize]
    public async Task<IActionResult> DeletePost([FromRoute] Guid id)
    {
        await _postService.DeletePost(id);
        return Ok(new Response
        {
            Message = "Delete Post successfully",
            Status = ResponseStatus.SUCCESS,
        });
    }
    [HttpGet("suit")]
    public async Task<ActionResult<IEnumerable<PostDTO>>> GetPostMajor([FromQuery] QueryPostDTO query, string username)
    {
        var posts = await _postService.GetSuitPosts(username, query);
        return Ok(new Response
        {
            Message = "Get Posts successfully",
            Status = ResponseStatus.SUCCESS,
            Data = posts
        });
    }

    [HttpDelete("decline/{id}"), Authorize]
    public async Task<IActionResult> DeclinePost([FromRoute] Guid id)
    {
        await _postService.DeclinePost(id);
        return Ok(new Response
        {
            Message = "Decline Post successfully",
            Status = ResponseStatus.SUCCESS,
        });
    }

    [HttpGet("statistics={action}&date={date}"), Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<PostStatisticsDTO>>> GetPostStatics(string action, int date)
    {
        var postStatistics = await _postService.GetPostStatistics(action, date);
        return Ok(new Response
        {
            Data = postStatistics,
            Message = "Get post statistics successfully",
            Status = ResponseStatus.SUCCESS
        });
    }
}