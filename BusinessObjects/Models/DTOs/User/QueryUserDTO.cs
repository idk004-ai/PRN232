namespace BusinessObjects.Models.DTOs.User;
public class QueryUserDTO : QueryParameters
{
    public string? Search { get; set; }
    public QueryUserDTO()
    {
        OrderBy = "UserName";
    }
}