using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessObjects.Interfaces.IServices;
using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.DTOs.Notification;

namespace ProductWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationController(INotificationService notificationService) : ControllerBase
{
    private readonly INotificationService _notificationService = notificationService;

    [HttpPost("send"), Authorize]
    public async Task<IActionResult> SendNotifications(NotificationDTO notification)
    {
        await _notificationService.Create(notification);
        return Ok(new Response
        {
            Message = "Send Notification successfully",
            Status = ResponseStatus.SUCCESS
        });
    }

    [HttpGet("all"), Authorize]
    public async Task<ActionResult<PaginatedData<NotificationDTO>>> GetNotifications([FromQuery] QueryNotificationDTO query)
    {
        var username = User.Identity?.Name;
        var notifications = await _notificationService.GetAll(username!, query);
        return Ok(new Response
        {
            Message = "Get Notification successfully",
            Status = ResponseStatus.SUCCESS,
            Data = notifications
        });
    }


    [HttpPost("read/{id}"), Authorize]
    public async Task<IActionResult> MaskAsRead([FromRoute] Guid id)
    {
        await _notificationService.MaskAsRead(id);
        return Ok(new Response
        {
            Message = "Read notification successfully",
            Status = ResponseStatus.SUCCESS,
        });
    }

    [HttpGet("check-unread"), Authorize]
    public async Task<ActionResult<int>> GetUnreadCount()
    {

        var username = User.Identity?.Name;
        var count = await _notificationService.GetUnreadCount(username!);
        return Ok(new Response
        {
            Message = "Check unread notification successfully",
            Status = ResponseStatus.SUCCESS,
            Data = count
        });
    }


    [HttpPost("read-all"), Authorize]
    public async Task<IActionResult> MaskAsReadAll()
    {
        var username = User.Identity?.Name;
        await _notificationService.MaskAsReadAll(username!);
        return Ok(new Response
        {
            Message = "Read all notifications successfully",
            Status = ResponseStatus.SUCCESS,
        });
    }


    [HttpPost("clean-all"), Authorize]
    public async Task<IActionResult> Clean()
    {
        var username = User.Identity?.Name;
        await _notificationService.DeleteAll(username!);
        return Ok(new Response
        {
            Message = "Clean all notifications successfully",
            Status = ResponseStatus.SUCCESS,
        });
    }
}
