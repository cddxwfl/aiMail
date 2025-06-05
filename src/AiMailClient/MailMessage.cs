namespace AiMailClient
{
    public class MailMessage
    {
        public string Subject { get; }
        public string Body { get; }

        public MailMessage(string subject, string body)
        {
            Subject = subject;
            Body = body;
        }
    }
}
