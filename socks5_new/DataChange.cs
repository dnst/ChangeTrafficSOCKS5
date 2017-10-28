using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socks5_new
{
    public class DataChange
    {
        public byte[] Buffer = new byte[8197];
        public int Received;
        public static byte[] ReserveBuffer = new byte[81970];
        public static int Reserve = 0;
        public int Status = 0;
        public int Send = 0;
        public static string Ip = "";
    }
}
