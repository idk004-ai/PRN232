namespace BusinessObjects.Models.DTOs.Search;
public class QuerySearchPostDTO : QueryParameters
{
    public string Filter { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
    public string Keyword { get; set; } = string.Empty;
    public QuerySearchPostDTO()
    {
        OrderBy = "CreatedAt";
    }
}
