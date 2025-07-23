namespace MailSender.Models
{
    public class MailMessage
    {
        public required string SenderEmail { get; set; }
        public required string ReceiverEmail { get; set; }
        public string Title { get; set; }
        public required string Body { get; set; }
    }
}
