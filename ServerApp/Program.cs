using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 9999);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(ip);
            socket.Listen(10);
            Console.WriteLine("Waiting for a client...");
            Socket client = socket.Accept();
            IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;
            Console.WriteLine("Connected with {0} at port {1}", clientep.Address, clientep.Port);

            string welcome = "Hi, this a message from server";
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(welcome);
            client.Send(data, data.Length, SocketFlags.None);

            Console.WriteLine("Disconnected from {0}", clientep.Address);
            client.Close();
            socket.Close();
        }
    }
}
