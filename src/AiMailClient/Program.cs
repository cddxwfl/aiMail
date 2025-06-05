using System;

namespace AiMailClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MailClient();
            var account = new MailAccount("user@example.com", "password", "imap.example.com");
            client.AddAccount(account);

            var messages = client.ReceiveMessages(account);
            var filter = new AiFilter();
            var filtered = filter.Filter(messages, "important");

            foreach (var msg in filtered)
            {
                Console.WriteLine($"Filtered message: {msg.Subject} - {msg.Body}");
            }
        }
    }
}
