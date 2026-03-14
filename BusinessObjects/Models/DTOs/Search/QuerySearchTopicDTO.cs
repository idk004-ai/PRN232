namespace BusinessObjects.Models.DTOs.Search;

public class QuerySearchTopicDTO : QueryParameters
{
    public string Keyword { get; set; } = string.Empty;
    public QuerySearchTopicDTO()
    {
        OrderBy = "CreatedAt";
    }
}