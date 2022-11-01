using Ecoinmerce.Infra.MailService.Interfaces;
using System.Net.Mail;

namespace Ecoinmerce.Infra.MailService;

///<summary>
/// Contém toda a lógica e regra de envio de email. Ou seja:
///<br/>
/// acesso às credencias de email, criação de MailClient para
/// user.
///</summary>
public class UserMail : IUserMail
{
    private readonly EmailConfiguration _emailConfiguration;
    private readonly SmtpClient _smtpClient;

    public UserMail(EmailConfiguration emailConfiguration)
    {
        _emailConfiguration = emailConfiguration;
        _smtpClient = new SmtpClient()
        {
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Credentials = new System.Net.NetworkCredential(_emailConfiguration.User, _emailConfiguration.Password)
        };
    }

    public bool SendMail(MailMessage mail)
    {
        try
        {
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            _smtpClient.Credentials = new System.Net.NetworkCredential(_emailConfiguration.User, _emailConfiguration.Password);
            _smtpClient.Send(mail);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void SendMailAsync(MailMessage mail)
    {
         _smtpClient.SendAsync(mail, null);
    }

    //TODO: Send mail for a list of users

    //TODO: Send mail for all user

}