using BusinessObjects.Constants;

namespace BusinessObjects.Models.DTOs.Vote
{
    public class VoteDTO
    {
        public Guid PostId { get; set; }
        public VoteType Type { get; set; }
    }
}