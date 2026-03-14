namespace BusinessObjects.Models.Configs;

public class EmailConfig
{
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool EnableSsl { get; set; }
    public bool UseDefaultCredentials { get; set; }
    public string DeliveryMethod { get; set; } = string.Empty;
    public string DefaultEncoding { get; set; } = string.Empty;
}