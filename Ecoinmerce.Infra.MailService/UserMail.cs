using Ecoinmerce.Infra.MailService.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace Ecoinmerce.Infra.MailService
{
    ///<summary>
    /// Contém toda a lógica e regra de envio de email. Ou seja:
    ///<br/>
    /// acesso às credencias de email, criação de MailClient para
    /// user.
    ///</summary>
    public class UserMail : IUserMail
    {
        private readonly string _password;
        private readonly string _access;
        private readonly SmtpClient _mailClient;

        private MailMessage GetNewMailMessage(string from = null, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.From = new MailAddress(from == null ? from : _access);
            mail.IsBodyHtml = isBodyHtml;
            return mail;
        }

        public UserMail(IConfiguration configuration)
        {
            IConfigurationSection credentialsSection = configuration.GetSection("MailConfig").GetSection("MailCredentials");
            _password = credentialsSection.GetSection("Password").Value;
            _access = credentialsSection.GetSection("User").Value;

            IConfigurationSection hostSection = configuration.GetSection("MailConfig").GetSection("MailHost");
            _mailClient = new(hostSection.GetSection("Domain").Value, int.Parse(hostSection.GetSection("Port").Value));
            _mailClient.EnableSsl = true;
        }

        public bool SendUserMail(string addressee, string subject)
        {
            try
            {
                MailMessage mail = GetNewMailMessage();
                mail.To.Add(addressee);
                mail.Subject = subject;

                //TODO: Isso tá mockado e precisa ser substituído por um VO ou DTO com HTML agradável e legal com imagens e gifs
                string Body = "Hi, this mail is to test sending mail" +
                              "using Gmail in ASP.NET";
                mail.Body = Body;

                _mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                _mailClient.Credentials = new System.Net.NetworkCredential(_access, _password);
                _mailClient.Send(mail);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //TODO: Send mail for a list of users

        //TODO: Send mail for all user

    }
}