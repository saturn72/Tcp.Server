using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Shouldly;
using Tcp.Server.Common.Domain;
using Tcp.Server.Common.Services;
using TcpServer.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Xunit;

namespace TcpServer.WebApi.Tests.Controllers
{
    public class TcpControllerTests
    {
        [Theory]
        [MemberData(nameof(TcpController_GetById_Data))]
        public async Task TcpController_GetById(TcpConnectionData connData, Type expResponseType)
        {
            var tcpSrv = new Mock<ITcpService>();
            tcpSrv.Setup(t => t.GetById(It.IsAny<string>())).ReturnsAsync(connData);

            var ctrl = new TcpController(tcpSrv.Object);

            var response = await ctrl.GetById("some-id");
            response.ShouldBeOfType(expResponseType);
            var content = (response as ObjectResult);
            (content.Value as TcpConnectionData).ShouldBe(connData);
        }

        [Theory]
        [MemberData(nameof(TcpController_GetAll_Data))]
        public async Task TcpController_GetAll(IEnumerable<TcpConnectionData> connData)
        {
            var tcpSrv = new Mock<ITcpService>();
            tcpSrv.Setup(t => t.GetAll()).ReturnsAsync(connData);

            var ctrl = new TcpController(tcpSrv.Object);

            var response = await ctrl.GetAll();
            var content = response.ShouldBeOfType<OkObjectResult>();
            (content.Value as IEnumerable<TcpConnectionData>).ShouldBe(connData);
        }

        public static IEnumerable<object[]> TcpController_GetAll_Data => new[]
        {
            new object[] {null},
            new object[] {new TcpConnectionData[] { }},
            new object[] {new []
            {
                new TcpConnectionData{ConnectionId = "1"},
                new TcpConnectionData{ConnectionId = "2"},
                new TcpConnectionData{ConnectionId = "3"},
            }}
        };

        public static IEnumerable<object[]> TcpController_GetById_Data => new[]
        {
            new object[] {null, typeof(NotFoundObjectResult)},
            new object[] {new TcpConnectionData { ConnectionId = "123" }, typeof(OkObjectResult)},
        };
    }
}