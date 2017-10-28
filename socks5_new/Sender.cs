using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace socks5_new
{
    class Sender : BasicSocketWorker
    {
        public bool Connect(string /*host*/ ip, int port)
        {
            IPEndPoint endPoint;
            try
            {
                //endPoint = GetEndPoint(host, port);
                endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            }
            catch (Exception)
            {
                return false;
            }

            WorkSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                WorkSocket.Connect(endPoint);
            }
            catch (SocketException)
            {
                return false;
            }
            return true;
        }



        private IPEndPoint GetEndPoint(string host, int port)
        {
            IPAddress address;
            if (IPAddress.TryParse(host, out address))
                return new IPEndPoint(address, port);
            IPAddress[] addresses = Dns.GetHostEntry(host).AddressList;
            if (addresses.Length < 1)
                throw new Exception();
            return new IPEndPoint(addresses[0], port);
        }
    }
}
