using BusinessObjects.Constants;
using BusinessObjects.Models.Entities;

namespace BusinessObjects.Interfaces.IRepositories
{
    public interface IVoteRepository : IBaseRepository<Vote>
    {
        Task<Vote?> FindVote(string username, Guid postId);
        Task<VoteType> GetVotedType(string username, Guid postId);
        Task<int> GetVoteCountPost(Guid id);
        Task<bool> IsSaved(string userName, Guid postId);
        Task<VoteType> GetVotedCommentType(string username, Guid commentId);
        Task<Vote?> FindeVoteComment(string username, Guid commentId);
        Task<int> GetVoteCountComment(Guid id);
        Task<IEnumerable<(DateTime Date, string VoterUsername, int VoteCount)>>
        GetVoteStatsByDateRangeAsync(DateTime fromDate, DateTime toDate);
    }
}