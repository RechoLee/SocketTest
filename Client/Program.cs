using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!：Client");
            Connect();
            
        }

        static void Connect()
        {
            //socket
            Socket client=new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            //Connect
            string hostIP="127.0.0.1";
            int hostPort=5555;
            client.Connect(hostIP,hostPort);
            //send
            string sendMess="Hello server";
            byte[] sendBuff=Encoding.UTF8.GetBytes(sendMess);
            client.Send(sendBuff);
            //Receive
            byte[] receiveBuff=new byte[1024];
            int count=client.Receive(receiveBuff);
            string receiveMess=Encoding.UTF8.GetString(receiveBuff,0,count);
            Console.WriteLine("client recieve:"+receiveMess);
            client.Close();
        }
    }
}
