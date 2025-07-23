using Microsoft.AspNetCore.Mvc;
using MailSender.Models;
using MailSender.Services;

namespace MailSender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageSenderController : ControllerBase
    {
        private readonly IMailsService _mailsService;

        public MessageSenderController(IMailsService mailsService)
        {
            _mailsService = mailsService;
        }

        [HttpPost("sendMessage")]
        public async Task<IActionResult> SendMessage(MailMessageDto mailMessageInput)
        {
            var mailMessage = new MailMessageDto
            {
                SenderEmail = mailMessageInput.SenderEmail,
                ReceiverEmail = mailMessageInput.ReceiverEmail,
                Title = mailMessageInput.Title,
                Body = mailMessageInput.Body,
            };

            await _mailsService.SendAsync(mailMessage);

            return Ok(mailMessage);
        }
    }
}
