using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessObjects.Interfaces.IServices;
using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.DTOs.Major;

namespace ProductWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MajorController(IMajorService majorService) : ControllerBase
{
    private readonly IMajorService _majorService = majorService; [HttpGet("paginated")]
    public async Task<ActionResult<PaginatedData<MajorDTO>>> GetMajorPaginated([FromQuery] int page = 1,
     [FromQuery] int pageSize = 10)
    {
        var data = await _majorService.GetMajorPaginated(page, pageSize);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Data = data,
            Message = "Major data retrieved successfully"
        });
    }

    [HttpGet("by-topic/{topicId}/paginated")]
    public async Task<ActionResult<PaginatedData<MajorDTO>>> GetMajorsByTopicId(Guid topicId, [FromQuery] int page = 1,
     [FromQuery] int pageSize = 10)
    {
        var data = await _majorService.GetMajorsByTopicId(topicId, page, pageSize);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Data = data,
            Message = "Majors by topic retrieved successfully"
        });
    }
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<MajorDTO>>> GetAllMajor()
    {
        var majors = await _majorService.GetAllMajor();
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Data = majors,
            Message = "Major data retrieved successfully"
        });
    }
    [HttpPost("create")]
    public async Task<IActionResult> CreateMajor([FromBody] CreateMajorDTO createMajorDTO)
    {
        await _majorService.CreateMajor(createMajorDTO);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Major created successfully"
        });
    }
    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateMajor([FromBody] UpdateMajorDTO updateMajorDTO, Guid id)
    {

        await _majorService.UpdateMajor(updateMajorDTO, id);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Major updated successfully"
        });
    }
    [HttpDelete("delete/{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteMajor(Guid id)
    {
        await _majorService.DeleteMajorToTrash(id);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Major deleted successfully"
        });
    }
    [HttpGet("trash"), Authorize(Roles = "Admin")]
    public async Task<ActionResult<PaginatedResponse<MajorTrashDTO>>> GetMajorByTrash([FromQuery] int page = 1,
     [FromQuery] int pageSize = 10)
    {
        var data = await _majorService.GetMajorByTrash(page, pageSize);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Data = data,
            Message = "Major data in trash retrieved successfully"
        });
    }
    [HttpPut("restore/{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> RestoreMajor(Guid id)
    {
        await _majorService.RestoreMajor(id);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Major restored successfully"
        });
    }
    [HttpDelete("delete-permanently/{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteMajorPermanently(Guid id)
    {
        await _majorService.DeleteMajor(id);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Major deleted permanently"
        });
    }
}