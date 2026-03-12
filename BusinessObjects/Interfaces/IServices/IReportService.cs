using BusinessObjects.Models.DTOs.Report;

namespace BusinessObjects.Interfaces.IServices;
public interface IReportService
{
    Task RejectReportService(Guid id);
    Task<ReportDTO> ResponseReport(Guid id, string response);
    Task<ReportDTO> GetReportByIdService(Guid id);
    Task<ReportDTO?> SaveReportAsync(ReportDTO reportDto, string email);
    Task<List<ReportDTO>> GetAllUserReports(QueryReportDTO query);
}