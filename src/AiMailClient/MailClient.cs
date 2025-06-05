using System.Collections.Generic;

namespace AiMailClient
{
    public class MailClient
    {
        private readonly List<MailAccount> _accounts = new();

        public void AddAccount(MailAccount account)
        {
            _accounts.Add(account);
        }

        public IEnumerable<MailMessage> ReceiveMessages(MailAccount account)
        {
            // Placeholder: In real code this would connect to the server and fetch emails
            return new List<MailMessage>
            {
                new MailMessage("Welcome", $"Fake message for {account.Email}")
            };
        }

        public void SendMessage(MailAccount account, string to, string subject, string body)
        {
            // Placeholder: In real code this would send the email via SMTP
            System.Diagnostics.Debug.WriteLine($"Send '{subject}' to {to} from {account.Email}");
        }
    }
}
