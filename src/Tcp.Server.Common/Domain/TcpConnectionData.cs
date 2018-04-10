namespace Tcp.Server.Common.Domain
{
    public class TcpConnectionData
    {
        public string ConnectionId { get; set; }
        public string ServerIp { get; set; }
        public ushort ServerPort { get; set; }
    }
}
