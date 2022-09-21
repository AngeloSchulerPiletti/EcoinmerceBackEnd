using Ecoinmerce.Application.BusinessInterfaces.Auth;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTO.EcommerceDTO;
using Ecoinmerce.Domain.Objects.VO.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace Ecoinmerce.InternalApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/auth/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISignupBusiness _signupBusiness;

        public AuthController(ISignupBusiness signupBusiness)
        {
            _signupBusiness = signupBusiness;
        }

        [HttpPost]
        [Route("signup")]
        public IActionResult SignupUserWithEcommerce([FromBody] NewUserAndEcommerceDTO newUserAndEcommerceDTO)
        {
            MessageBagVO result = _signupBusiness.CheckIfUserNameAndEmailIsBeingUsed(newUserAndEcommerceDTO.User);
            if (result.IsError) return BadRequest(result);

            MessageBagSingleEntityVO<User> userMessageBag = _signupBusiness.MapToEntityHashingPassword(newUserAndEcommerceDTO.User);
            MessageBagSingleEntityVO<Ecommerce> ecommerceMessageBag = _signupBusiness.MapToEntity(newUserAndEcommerceDTO.Ecommerce);

            if(userMessageBag.IsError) return BadRequest(userMessageBag);
            if(ecommerceMessageBag.IsError) return BadRequest(ecommerceMessageBag);

            MessageBagSingleEntityVO<PublicUserDTO> savedUserMessageBag = _signupBusiness.SaveConfiableNewUserAndEcommerce(userMessageBag.Entity, ecommerceMessageBag.Entity);
            if (savedUserMessageBag.IsError) return BadRequest(savedUserMessageBag);
            savedUserMessageBag.Messages.Add($"Por favor, verifique sua conta a partir do email que lhe enviamos para: {savedUserMessageBag.Entity.Email}");

            // Set access and refresh token in cookies MAYBE

            // Send email to confirm user ASSÍNCRONOUS (with authenticated link)
            // Use messagery system?

            //MailMessage mail = new();
            //mail.To.Add("angelopiletti@gmail.com");
            //mail.From = new MailAddress("angelopiletti@gmail.com");
            //mail.Subject = "Email from C# api";

            //string Body = "Hi, this mail is to test sending mail" +
            //              "using Gmail in ASP.NET";
            //mail.Body = Body;

            //mail.IsBodyHtml = true;

            //SmtpClient smtp = new("smtp.gmail.com", 587);

            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp.Credentials = new System.Net.NetworkCredential
            //     ("barterhash@gmail.com", "!08975G,6;4231l5");

            //smtp.EnableSsl = true;
            //smtp.Send(mail);

            return Ok(savedUserMessageBag); 
        }

        //TODO: Rota para reenviar email de confirmação

        [HttpGet]
        [Route("/verify-email/{token}")]
        public IActionResult VerifyEmail(string token)
        {
            // Verify the email in User
            // Return the User data
            return Ok();
        }

        // login

        // delete-account (confirm with email send). the can delete its account (and the eccomerce), but have 1 month until it really delete

        // token validation verifier

        // signup using invite (link)

        // update access token (only the manager can do it)

        // update ecommerce profile (only the manager can do it)
    }
}
