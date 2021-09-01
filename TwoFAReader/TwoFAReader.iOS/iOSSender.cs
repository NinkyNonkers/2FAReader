using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TwoFAReader.iOS
{
    public class iOSSender : IMessageSender
    {

        private readonly UdpClient _udpClient;
        private readonly IPEndPoint _endPoint;
        
        public iOSSender(string ip)
        {
            _udpClient = new UdpClient();
            _udpClient.EnableBroadcast = true;
            _endPoint = new IPEndPoint(new IPAddress(Convert.ToInt64(ip.Replace(".", ""))), 15437);
        }
        
        public void Send(string data)
        {
            byte[] message = Encoding.ASCII.GetBytes(data);
            _udpClient.Send(message, message.Length, _endPoint);
        }
    }
}