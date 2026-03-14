namespace BusinessObjects.Models.DTOs.Vote;
public class DailyVoteStatDTO
{
    public DateOnly Date { get; set; }
    public string VoterUsername { get; set; } = string.Empty;
    public int VoteCount { get; set; }
}