using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace socks5_new
{
    public partial class Socks : Form
    {
        public Socks()
        {
            InitializeComponent();
            //ipLabel.Text = "123";
        }

        public static bool key = false;

        private static void ListenerAccept(IAsyncResult ar)
        {
            //получение данных
            Socket listener = (Socket)ar.AsyncState;
            listener.BeginAccept(ListenerAccept, listener);
            Socket local = listener.EndAccept(ar);
            byte[] buffer = new byte[260];

            //авторизация прокси
            local.Receive(buffer, 0, buffer.Length, SocketFlags.None);
            if (buffer[0] != 5)
            {
                local.Shutdown(SocketShutdown.Both);
                local.Close();
                return;
            }
            buffer[1] = 0;
            local.Send(buffer, 0, 2, SocketFlags.None);

            //проверка данных соединения
            int received;
            try
            {
                received = local.Receive(buffer, 0, buffer.Length, SocketFlags.None);
            }
            catch (SocketException)
            {
                local.Shutdown(SocketShutdown.Both);
                local.Close();
                return;
            }
            if (buffer[1] != 1)
            {
                local.Shutdown(SocketShutdown.Both);
                local.Close();
                return;
            }
            if (buffer[3] != 1 && buffer[3] != 3)
            {
                local.Shutdown(SocketShutdown.Both);
                local.Close();
                return;
            }

            //инстанцирование воркеров
            Receiver receiver = new Receiver(local);
            Sender sender = new Sender();
            receiver.SubscribeToEvents(sender);
            sender.SubscribeToEvents(receiver);

            //коннект к удаленному хосту

            /*string host = Encoding.ASCII.GetString(buffer, 5, buffer[4]);
            int port = buffer[buffer[4] + 5] * 256 + buffer[buffer[4] + 6];*/


            string ip = buffer[4] + "." + buffer[5] + "." + buffer[6] + "." + buffer[7];
            int port = buffer[8] * 256 + buffer[9];

            if (!sender.Connect(/*host*/ip, port))
            {
                buffer[1] = 4;
                local.Send(buffer, 0, received, SocketFlags.None);
                local.Shutdown(SocketShutdown.Both);
                local.Close();
                return;
            }

            //сообщение об успехе и запуск на прием
            buffer[1] = 0;
            local.Send(buffer, 0, received, SocketFlags.None);
            receiver.StartWorking();
            sender.StartWorking();
        }


        private void startButton_Click(object sender, EventArgs e)
        {
            File.Delete("data.txt");
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Any, 1080));
            listener.Listen(1000);
            listener.BeginAccept(ListenerAccept, listener);
            startButton.Enabled = false;
            //Console.ReadKey();
        }

        private void changePackageButton_Click(object sender, EventArgs e)
        {
            key = true;
            changePackageButton.Visible = false;
            notChangePackageButton.Visible = true;

        }

        private void notChangePackageButton_Click(object sender, EventArgs e)
        {
            key = false;
            changePackageButton.Visible = true;
            notChangePackageButton.Visible = false;
            
        }

        public static void Out(string str)
        {
            ipTextBox.Text = str;
        }
       

        private void resetIpButton_Click(object sender, EventArgs e)
        {
            //Array.Clear(DataChange.ReserveBuffer, 0, DataChange.ReserveBuffer.Length);
            DataChange.Reserve = 0;
            File.Delete("data.txt");
            DataChange.Ip = "";
        }
    }
}
