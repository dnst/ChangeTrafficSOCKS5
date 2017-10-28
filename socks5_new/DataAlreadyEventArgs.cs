using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socks5_new
{
    class DataAlreadyEventArgs : EventArgs
    {
        public byte[] SocketBuffer { get; set; }
        public int Length { get; set; }
    }
}
