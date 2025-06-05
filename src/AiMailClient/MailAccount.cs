namespace AiMailClient
{
    public class MailAccount
    {
        public string Email { get; }
        public string Password { get; }
        public string Server { get; }

        public MailAccount(string email, string password, string server)
        {
            Email = email;
            Password = password;
            Server = server;
        }
    }
}
