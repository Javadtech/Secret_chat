using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Secret_chat_Client
{
    class Client
    {
        public delegate void Recive(string message);
        public event Recive ReciveEvent;
        Thread t;
        Socket socket;
        Socket socket1;
        public Client(string ip, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            socket.Bind(endPoint);
            socket.Listen();
            socket1 = socket.Accept();
            t = new Thread(() => { ReciveTask(); });
            t.Start();
        }
        public void Send(string message)
        {
            try
            {
                byte[] v = Encoding.ASCII.GetBytes(message);
                socket1.Send(v);
            }
            catch
            {

            }
        }
        void ReciveTask()
        {
            while (true)
            {
                try
                {
                    if (socket1.Available != 0)
                    {
                        byte[] b = new byte[socket1.Available];
                        socket1.Receive(b);
                        string s = Encoding.ASCII.GetString(b);
                        ReciveEvent(s);
                    }
                }
                catch { }
                Thread.Sleep(1);

            }

        }


    }
}
