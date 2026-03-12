using BusinessObjects.Models.DTOs.Report;
using BusinessObjects.Models.Entities;

namespace BusinessObjects.Interfaces.IRepositories;

public interface IReportRepository : IBaseRepository<Report>
{
    Task<Report?> GetReportById(Guid id);
    Task<Report?> GetReportByIdAsync(Guid id);
    Task<IEnumerable<Report>> GetAllUserReports(QueryReportDTO query);
}