namespace TwoFAReader
{
    public interface IMessageSender
    {
        public string Ip { get; set; }
        public void Send(byte[] data);
        public void Send(string data);
    }
}