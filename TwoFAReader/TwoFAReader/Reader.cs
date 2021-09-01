namespace TwoFAReader
{
    public class Reader
    {

        private readonly IMessageSender _sender;
        
        public Reader(IMessageSender sender)
        {
            _sender = sender;
        }

        public void HandleNotification(string content)
        {
            string contentLower = content.ToLower();
            if (!contentLower.Contains("steam"))
                return;
            string code = content[25..];
            _sender.Send(code);
        }
        
    }
}