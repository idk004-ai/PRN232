using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessObjects.Constants;
using BusinessObjects.Interfaces.IServices;
using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.DTOs.Report;


namespace ProductWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController(IReportService reportService) : ControllerBase
{
    private readonly IReportService _reportService = reportService;
    [HttpGet("all"), Authorize]
    public ActionResult<string[]> GetAllReport()
    {
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Get all report successfully",
            Data = Report.All
        });
    }

    [HttpGet("user-report")]
    public async Task<ActionResult<List<ReportDTO>>> GetUserReport([FromQuery] QueryReportDTO query)
    {
        var reports = await _reportService.GetAllUserReports(query) ?? [];
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Get user report successfully",
            Data = reports
        });
    }
    
    [HttpPost("send")]
    public async Task<ActionResult<ReportDTO>> SendReport([FromBody] ReportDTO reportDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var email = User.FindFirstValue(ClaimTypes.Email);
        var report = await _reportService.SaveReportAsync(reportDto, email!);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Send report successfully",
            Data = report
        });
    }

    [HttpPut("response/{id}")]
    public async Task<ActionResult<ReportDTO>> ResponseReport([FromRoute] Guid id,
    [FromBody] ReportResponseDTO reportResponse)
    {
        var report = await _reportService.ResponseReport(id, reportResponse.ResponseContent);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Response report successfully",
            Data = report
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReportDTO>> GetReportById(Guid id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var report = await _reportService.GetReportByIdService(id);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Get report successfully",
            Data = report
        });
    }

    [HttpGet("reject/{id}")]
    public async Task<IActionResult> RejectReport([FromRoute] Guid id)
    {
        await _reportService.RejectReportService(id);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Reject report successfully"
        });
    }
}