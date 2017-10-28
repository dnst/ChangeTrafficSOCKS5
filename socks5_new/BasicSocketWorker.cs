using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace socks5_new
{
    abstract class BasicSocketWorker/* : Socks*/
    {
        protected Socket WorkSocket;
        protected bool _socketIsWorking = true;

        protected BasicSocketWorker(Socket workSocket)
        {
            WorkSocket = workSocket;
        }

        protected BasicSocketWorker()
        {
        }



        public event EventHandler<DataAlreadyEventArgs> DataAlready;
        protected void OnDataAlready(byte[] buffer, int length)
        {
            DataAlreadyEventArgs dataAlreadyEventAgrs = new DataAlreadyEventArgs { SocketBuffer = buffer, Length = length };
            if (DataAlready != null)
                DataAlready(this, dataAlreadyEventAgrs);
        }

        public event EventHandler TransmissionError;

        protected void OnTransmissionError()
        {
            if (TransmissionError != null)
                TransmissionError(this, EventArgs.Empty);
        }

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

        public void SubscribeToEvents(BasicSocketWorker basicSocketWorker)
        {
            DataAlready += basicSocketWorker.OnDataAlreadyAction;
            TransmissionError += basicSocketWorker.OnTransmissionErrorAction;
        }



        private void Received(IAsyncResult ar)
        {
            if (!_socketIsWorking)
                return;
            byte[] incomingBuffer = (byte[])ar.AsyncState;
            int received = 0;
            try
            {
                received = WorkSocket.EndReceive(ar);
            }
            catch (Exception)
            {
                ShutdownSocket();
                OnTransmissionError();
            }
            if (received == 0)
            {
                ShutdownSocket();
                OnTransmissionError();
                return;
            }
            try
            {
                OnDataAlready(incomingBuffer, received);
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

        private void Sent(IAsyncResult ar)
        {
            if (!_socketIsWorking)
                return;
            //int i = WorkSocket.EndSend(ar);
            //Control.CheckForIllegalCrossThreadCalls = false;
            //Socks.ipLabel.Text = i.ToString();
        }

        private void OnDataAlreadyAction(object sender, DataAlreadyEventArgs eventArgs)
        {
            WorkSocket.BeginSend(eventArgs.SocketBuffer, 5, eventArgs.Length, SocketFlags.None, Sent, eventArgs.SocketBuffer);
        }

        private void OnTransmissionErrorAction(object sender, EventArgs eventArgs)
        {
            ShutdownSocket();
        }

        protected void ShutdownSocket()
        {
            if (!_socketIsWorking)
                return;
            _socketIsWorking = false;
            WorkSocket.Shutdown(SocketShutdown.Both);
            WorkSocket.Close();
        }
    }
}
