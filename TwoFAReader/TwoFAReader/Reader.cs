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

        public void SetCode(string code)
        {
            _sender.Ip = IpFromCode(code);
        } 

        public static string IpFromCode(string code)
        {

            string ending = "";
            int i = 0;
            foreach (char c in code)
            {
                if (i > 3)
                {
                    i = 0;
                    ending += ".";
                }
                ending += c;
                i++;
            }

            return "192.168." + ending;
        }
        
    }
}