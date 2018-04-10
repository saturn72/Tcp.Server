using System.Collections.Generic;
using System.Threading.Tasks;
using Tcp.Server.Common.Domain;

namespace Tcp.Server.Common.Services
{
    public interface ITcpService
    {
        Task<IEnumerable<TcpConnectionData>> GetAll();
        Task<TcpConnectionData> GetById(string id);
    }
}
