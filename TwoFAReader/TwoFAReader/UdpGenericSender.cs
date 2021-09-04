using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TwoFAReader
{
    public class UdpGenericSender : IMessageSender
    {
        private readonly UdpClient _udpClient;
        private readonly IPEndPoint _endPoint;
        
        public UdpGenericSender(string ip)
        {
            _udpClient = new UdpClient();
            _udpClient.EnableBroadcast = true;
            _endPoint = new IPEndPoint(IPAddress.Parse(ip), 15437);
            _ip = ip;
        }

        public string Ip
        {
            get => _ip;
            set
            {
                _endPoint.Address = IPAddress.Parse(value);
                _ip = value;
            }
        }

        private string _ip;

        public void Send(byte[] data)
        {
            _udpClient.Send(data, data.Length, _endPoint);
        }

        public void Send(string data)
        {
            byte[] message = Encoding.ASCII.GetBytes(data);
            Send(message);
        }
    }
}