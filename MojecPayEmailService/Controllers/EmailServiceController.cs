using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MojecPayEmailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailServiceController : ControllerBase
    {
        [HttpPost]
        [Route("SendEmail")]
        public async Task<IActionResult> SendEmailAsync(MailContent mail)
        {
            string Message = "Correct Details";
            string Failed = "Failed Details";
            MailjetClient client = new MailjetClient("53d910dda9a6ee9f26e372e646f330c3", "e1292d6ff4492159cdbab9f62c5a5a03");
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "mojecrandd@mojec.com")
            .Property(Send.FromName, "Mojec International Limited")
            .Property(Send.To, mail.To)
            .Property(Send.Subject, mail.Subject)
            .Property(Send.TextPart, mail.Body);
            MailjetResponse response = await client.PostAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Message.ToString();
                return Ok(Message);
            }
            else
            {
                Failed.ToString();
                return BadRequest(Failed);
            }

        }
    }
}
