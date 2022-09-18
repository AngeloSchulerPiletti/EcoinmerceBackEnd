using Ecoinmerce.Application.BusinessInterfaces.Mail;

namespace Ecoinmerce.Application.Business.Mail
{
    ///<summary>
    /// The email's body is created according to its necessities. 
    /// Then sent using Ecoinmerce.Infra.MailService
    ///<br/>
    /// The email's body is created above a DTO/VO specialized in 
    /// handling HTML, GIFs and Pictures, increasing the UX
    ///</summary>
    public class MailBusiness : IMailBusiness
    {
    }
}
