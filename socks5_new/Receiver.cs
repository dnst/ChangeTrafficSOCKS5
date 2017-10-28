using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace socks5_new
{
    class Receiver : BasicSocketWorker
    {

        public Receiver(Socket workSocket)
            //: base(workSocket)
        {
            WorkSocket = workSocket;
            WorkSocket.NoDelay = true;
            WorkSocket.SendBufferSize = 4096;
            WorkSocket.ReceiveBufferSize = 4096;
        }

        DataChange data = new DataChange();

        public void StartWorking()
        {
            byte[] buffer = new byte[8197];
            try
            {
                WorkSocket.BeginReceive(buffer, 5, 8192, SocketFlags.None, Received, buffer);
            }
            catch (ObjectDisposedException)
            {
                ShutdownSocket();
                OnTransmissionError();
            }
        }



        public string ByteToHex(byte[] Bytes, int length)
        {
            string pack = "\nlen = " + length.ToString() + "\n";
            for (int i = 5; i < length + 5; i++)
            {
                pack += Bytes[i].ToString("X2");
                pack += " ";
            }
                //pack += Convert.ToChar(Bytes[i]);
            return pack;
        }


        private void Received(IAsyncResult ar)
        {
            if (!_socketIsWorking)
                return;
            byte[] incomingBuffer = (byte[])ar.AsyncState;
            int received = WorkSocket.EndReceive(ar);
            if (received == 0)
            {
                ShutdownSocket();
                OnTransmissionError();
                return;
            }
            try
            {
                /*if (InvokeRequired)
                {*/
                    //Invoke(new Action(() => Socks.ipLabel.Text = DataChange.Ip));
                   // Invoke(new Action(() => Socks.Out(DataChange.Ip)));
                //}
                //Control.CheckForIllegalCrossThreadCalls = false;
                //Socks.ipLabel.Text = WorkSocket.RemoteEndPoint.ToString();
                //MessageBox.Show(WorkSocket.RemoteEndPoint.ToString());
                if (Socks.key && (DataChange.Ip == "" || DataChange.Ip == WorkSocket.RemoteEndPoint.ToString()))
                {
                    string _data = ByteToHex(incomingBuffer, received);
                    //File.AppendAllText("data.txt", _data + "\r\n");
                    Array.Copy(incomingBuffer, 5, data.Buffer, 5, received);
                    data.Received = received;
                    DataChange.Ip = WorkSocket.RemoteEndPoint.ToString();

                    
                    /*ChangePackage.ChangePack(ref data);
                    Control.CheckForIllegalCrossThreadCalls = false;
                    Socks.ipLabel.Text = DataChange.Reserve.ToString();
                    if (data.Send == 1)
                    {
                        data.Send = 0;
                        /*switch (data.Status)
                        {
                            case 0:
                                Thread.Sleep(80); 
                                break;
                            case 1:
                                Thread.Sleep(120); 
                                break;
                            case 2:
                                Thread.Sleep(100); 
                                break;
                        }*
                        Thread.Sleep(300); 
                        OnDataAlready(data.Buffer, data.Received);
                    }*/



                    ChangePackage.ChangePack(ref data);
                    Control.CheckForIllegalCrossThreadCalls = false;
                    Socks.ipLabel.Text = DataChange.Reserve.ToString();
                    if (data.Send == 1)
                    {
                        data.Send = 0;
                        switch (data.Status)
                        {
                            case 0:
                                Thread.Sleep(50); 
                                break;
                            case 1:
                                Thread.Sleep(200); 
                                break;
                            case 2:
                                Thread.Sleep(150); 
                                break;
                        }
                        //Thread.Sleep(150);
                        OnDataAlready(data.Buffer, data.Received);
                    }


                    
                    /*ChangePackage.ChangePack1(ref data);
                    if (data.Send == 1)
                    {
                        data.Send = 0;
                        Thread.Sleep(30);
                        OnDataAlready(data.Buffer, data.Received);
                    }*/
                    


                }
                else
                {
                    OnDataAlready(incomingBuffer, received);
                }
                byte[] buffer = new byte[8197];
                WorkSocket.BeginReceive(buffer, 5, 8192, SocketFlags.None, Received, buffer);
            }
            catch (SocketException)
            {
                ShutdownSocket();
                OnTransmissionError();
            }
            catch (ObjectDisposedException)
            {
                ShutdownSocket();
                OnTransmissionError();
            }
        }

    }
}
