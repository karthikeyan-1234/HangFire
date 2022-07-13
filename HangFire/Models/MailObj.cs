namespace HangFire.Models
{
    public class MailObj
    {
        public void SendWelcomeMail(string username)
        {
            Console.WriteLine($"SendWelcomeMail: {username}");
        }

        public void SendDelayedWelcomeMail(string username)
        {
            Console.WriteLine($"SendDelayedWelcomeMail : {username}");
        }

        public void SendInvoiceMail(string username)
        {
            Console.WriteLine($"SendInvoiceMail : {username}");
        }

        public void UnSubscribeUser(string username)
        {
            Console.WriteLine($"UnSubscribeUser : {username}");
        }
    }
}
