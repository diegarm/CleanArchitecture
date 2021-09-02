using Clean.API;
using Clean.Infrastructure.Data.EntityFramework.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Tests.Integration.Fixture
{
    public class IntegrationTestContext
    {
        public HttpClient Client { get; set; }
        public TestServer _server;
        public CleanContext DBContext;

        public IntegrationTestContext()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("IntegrationTest")
                .UseStartup<Startup>();

            _server = new TestServer(builder);
            DBContext = _server.Host.Services.GetService(typeof(CleanContext)) as CleanContext;
            Client = _server.CreateClient();
            
        }   
    }
}
