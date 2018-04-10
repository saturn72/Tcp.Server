using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tcp.Server.Common.Domain;

namespace TcpServer.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CommandAndQueryController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> SendCommand([FromBody] CommandData command)
        {
            throw new System.NotImplementedException();
        }
    }
}
