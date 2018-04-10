using System.Collections.Generic;

namespace Tcp.Server.Common.Domain
{
    public class CommandData
    {
        public string TcpConnectionId { get; set; }
        public IEnumerable<byte> Bytes { get; set; }
    }
}
