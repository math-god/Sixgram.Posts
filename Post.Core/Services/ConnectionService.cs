using System.Net.Sockets;
using Post.Core.Interfaces.Connection;

namespace Post.Core.Services;

public class ConnectionService : IConnectionService
{
    public bool IsConnected(string server, int port)
    {
        using (var tcpClient = new TcpClient(server, port))
        {
            var a = tcpClient.Client.Connected;
            return tcpClient.Connected;
        }
    }
}