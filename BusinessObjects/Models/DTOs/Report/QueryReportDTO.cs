namespace BusinessObjects.Models.DTOs.Report;
public class QueryReportDTO : QueryParameters
{
    public QueryReportDTO()
    {
        OrderBy = "CreatedAt";
    }
}
