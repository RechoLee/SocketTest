using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace SocketTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HelloWorld:Server");

            // Socket 初始化Socket
            Socket server=new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            //设置ip和端口号
            IPAddress ip=IPAddress.Parse("127.0.0.1");
            int port=5555;
            IPEndPoint iPEndPoint=new IPEndPoint(ip,port);
            //绑定ip和端口号
            server.Bind(iPEndPoint);
            //设置监听的数量
            server.Listen(0);

            Console.WriteLine("Server started success");
            
            //接收
            while(true)
            {
                //Accept 
                Socket client=server.Accept();//阻塞等待客户端连接
                Console.WriteLine("Server Accept");
                //Receive
                //初始化一个byte数组用于存储接收到的信息
                byte[] receiveBuff=new byte[1024];
                int count=client.Receive(receiveBuff);//阻塞在这等待接收，返回长度
                //初始化string 用于输出信息
                string receiveMessage=Encoding.UTF8.GetString(receiveBuff,0,count);
                //打印接收到的信息
                Console.WriteLine("Server receive："+receiveMessage);
                //send 将接受到的消息重新编码发送回去
                byte[] sendBuff=Encoding.UTF8.GetBytes("Server:"+receiveMessage);
                client.Send(sendBuff);
            }
        
        }
    }
}
