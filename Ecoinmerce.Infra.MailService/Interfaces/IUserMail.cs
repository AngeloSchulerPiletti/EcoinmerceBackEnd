using System.Net.Mail;

namespace Ecoinmerce.Infra.MailService.Interfaces;

public interface IUserMail
{
    /// <summary>
    /// Send email for a single user
    /// </summary>
    /// <param name="addressee">The email address of the target</param>
    /// <param name="subject">The email subject</param>
    /// <returns>True, if success. False, if error</returns>
    public bool SendMail(MailMessage mail);
    public void SendMailAsync(MailMessage mail);

}
