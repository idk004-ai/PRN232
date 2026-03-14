using Newtonsoft.Json;

namespace BusinessObjects.Models.DTOs.Report;
public class ReportContent
{
    [JsonProperty(nameof(Content))]
    public string Content { get; set; } = string.Empty;
    [JsonProperty(nameof(ReportedPostId))]
    public Guid ReportedPostId { get; set; }
    [JsonProperty(nameof(ReportedTopicname))]
    public string ReportedTopicname { get; set; } = string.Empty;
    [JsonProperty(nameof(ReportedUsername))]
    public string ReportedUsername { get; set; } = string.Empty;
}
