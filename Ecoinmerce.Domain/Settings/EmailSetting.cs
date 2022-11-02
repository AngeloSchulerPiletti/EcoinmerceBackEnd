namespace Ecoinmerce.Domain.Settings;

public class EmailSetting
{
    public bool ShouldUseSsl { get; set; }
    public string From { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public string SmtpServer { get; set; }
    public int Port { get; set; }
}
