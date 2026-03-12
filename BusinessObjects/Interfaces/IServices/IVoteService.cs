using BusinessObjects.Models.DTOs.Vote;

namespace BusinessObjects.Interfaces.IServices
{
    public interface IVoteService
    {
        Task<int> GetVotePost(string username, VoteDTO voteDTO);
        Task<int> VoteComment(string username, VoteCommentDTO voteDTO);
        Task<IEnumerable<DailyVoteStatDTO>> GetDailyTopVotersAsync(DateOnly fromDate, DateOnly toDate);
        Task SendVoteCommentNotificationAsync(string voter, VoteCommentDTO vote, string avatar);
        Task SendVotePostNotificationAsync(string voter, VoteDTO vote);
    }
}