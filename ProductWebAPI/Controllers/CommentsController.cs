using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessObjects.Interfaces.IServices;
using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.DTOs.Comment;
using BusinessObjects.Models.DTOs.Search;

namespace ProductWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController(ICommentService commentService) : ControllerBase
{
    private readonly ICommentService _commentService = commentService;

    [HttpGet("comment"), Authorize]
    public async Task<ActionResult<CommentDTO>> GetComment([FromQuery] Guid id)
    {
        var username = User.Identity!.Name;
        var comment = await _commentService.GetCommentByIdAsync(id, username!);
        return Ok(new Response
        {
            Message = "Get Comment successfully",
            Status = ResponseStatus.SUCCESS,
            Data = comment
        });
    }
    [HttpGet("post"), Authorize]
    public async Task<ActionResult<IEnumerable<CommentDTO>>> GetCommentsByPost([FromQuery] QueryCommentDTO query)
    {
        var username = User.Identity?.Name;
        var comments = await _commentService.GetCommentsByPostIdAsync(query, username!);
        return Ok(new Response
        {
            Message = "Create comment successfully",
            Status = ResponseStatus.SUCCESS,
            Data = comments
        });
    }
    [HttpPost("create"), Authorize]
    public async Task<ActionResult<CommentDTO>> AddComment([FromBody] CreateCommentDTO createCommentDTO)
    {
        var username = User.Identity?.Name;
        var comment = await _commentService.AddCommentAsync(createCommentDTO, username!);
        await _commentService.SendCommentNotificationsAsync(comment, username!);
        return Ok(new Response
        {
            Message = "Create comment successfully",
            Status = ResponseStatus.SUCCESS,
            Data = comment
        });
    }

    [HttpGet("attachment"), Authorize]
    public async Task<ActionResult<IEnumerable<CommentDTO>>> GetCommentsByAttachment([FromQuery] QueryCommentDTO query)
    {
        var username = User.Identity?.Name;
        var comments = await _commentService.GetCommentsByAttachmentIdAsync(query, username!);
        return Ok(new Response
        {
            Message = "Create comment successfully",
            Status = ResponseStatus.SUCCESS,
            Data = comments
        });
    }
    [HttpPut("update/{id}"), Authorize]
    public async Task<IActionResult> UpdateComment(Guid id, [FromBody] CommentUpdateDTO commentUpdateDTO)
    {
        await _commentService.UpdateComment(commentUpdateDTO, id);
        return Ok(new Response
        {
            Message = "Update comment successfully",
            Status = ResponseStatus.SUCCESS
        });
    }
    [HttpDelete("delete/{id}"), Authorize]
    public async Task<IActionResult> DeleteComment(Guid id)
    {
        await _commentService.DeleteComment(id);
        return Ok(new Response
        {
            Message = "Delete comment successfully",
            Status = ResponseStatus.SUCCESS
        });
    }
    [HttpGet("search"), Authorize]
    public async Task<ActionResult<IEnumerable<CommentDTO>>> SearchComments([FromQuery] QueryCommentDTO query)
    {
        var username = User.Identity?.Name;
        var comments = await _commentService.SearchCommentAsync(query, username!);
        return Ok(new Response
        {
            Message = "Search comments successfully",
            Status = ResponseStatus.SUCCESS,
            Data = comments
        });
    }
}