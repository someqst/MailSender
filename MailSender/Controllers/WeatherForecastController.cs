using Microsoft.AspNetCore.Mvc;
using MailSender.Models;

namespace MailSender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageSenderController : ControllerBase
    {
        [HttpPost(Name = "SendMessage")]
        public async Task<IActionResult> SendMessage(MailMessage mailMessage)
        {

            return Ok();
        }
    }
}
