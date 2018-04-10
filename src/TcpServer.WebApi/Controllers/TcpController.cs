using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tcp.Server.Common.Domain;
using Tcp.Server.Common.Services;

namespace TcpServer.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TcpController : Controller
    {
        private readonly ITcpService _tcpService;

        public TcpController(ITcpService tcpService)
        {
            _tcpService = tcpService;
        }

        /// <summary>
        /// Gets all TCP connection data
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(TcpConnectionData), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var tcpConnections = await _tcpService.GetAll();
            return Ok(tcpConnections);
        }

        /// <summary>
        /// Gets TCP connection data by Id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TcpConnectionData), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(string id)
        {
            var tcpConnection = await _tcpService.GetById(id);
            return tcpConnection == null
                ? new NotFoundObjectResult(new
                {
                    message = "The provided id was not found",
                    id = id
                })
                : Ok(tcpConnection) as IActionResult;
        }

        [HttpPost]
        public async Task<IActionResult> StartListening([FromBody]TcpConnectionData tcpData)
        {
            throw new System.NotImplementedException();
        }

        [HttpDelete]
        public async Task<IActionResult> StopListening([FromBody]TcpConnectionData tcpData)
        {
            throw new System.NotImplementedException();
        }
    }
}
