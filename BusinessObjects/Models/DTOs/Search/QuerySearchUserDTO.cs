namespace BusinessObjects.Models.DTOs.Search
{
    public class QuerySearchUserDTO : QueryParameters
    {
        public string Keyword { get; set; } = string.Empty;
        public QuerySearchUserDTO()
        {
            OrderBy = "CreatedAt";
        }
    }
}