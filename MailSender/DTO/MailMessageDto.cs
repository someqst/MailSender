namespace MailSender.Models
{
    public class MailMessageDto
    {
        public required string SenderEmail { get; set; }
        public required string ReceiverEmail { get; set; }
        public string Title { get; set; }
        public required string Body { get; set; }
    }
}
