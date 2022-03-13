namespace Post.Core.Interfaces.Connection;

public interface IConnectionService
{
    public bool IsConnected(string server, int port);
}