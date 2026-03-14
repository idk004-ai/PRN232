namespace BusinessObjects.Models.DTOs.Notification;
public class QueryNotificationDTO : QueryParameters
{
    public QueryNotificationDTO()
    {
        OrderBy = "CreatedAt_desc";
    }
}
