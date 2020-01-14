using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class Program
    {
        const int TIME_OUT = 100;
        public List<int> Ports { get; set; } = new List<int>();
        public Socket ServerSocket { get; set; } = new Socket(
            AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Socket ClientSocket { get; set; }
        public IPAddress LocalIp { get; set; } = IPAddress.Parse("127.0.0.1");
        public int Port { get; set; } = 3231;
        public IPEndPoint EndPoint { get; set; } = new IPEndPoint(LocalIp, Port);


        static async Task Main(string[] args)
        {
            using (var context = new Context())
            using (ServerSocket)
            {
                await SaveMessage(ServerSocket);
                while (true)
                {
                    ClientSocket = await ServerSocket.AcceptAsync();
                    var builder = new StringBuilder();
                    while (ClientSocket.Available > 0)
                    {
                        var buffer = new byte[ClientSocket.Available];

                        ClientSocket.Receive(buffer);
                        builder.Append(Encoding.UTF8.GetString(builder, 0, buffer.Length));
                        var message = JsonConvert.DeserializeObject<Message>(builder.ToString());
                   
                        context.Messages.Add(message);
                        await context.SaveChangesAsync();

                        await SendMessage();
                    }
                    ClientSocket.Close();
                }
            }

        }
    }
}
