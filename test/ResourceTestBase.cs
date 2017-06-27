using System;
using System.Net.Http;
using System.Web.Http;
using src;

namespace test
{
    public class ResourceTestBase : IDisposable
    {
        protected readonly HttpServer Server;
        protected HttpClient Client { get; }
        protected static readonly Uri webApiUri = new Uri("http://www.baidu.com");

        public ResourceTestBase()
        {
            Server = CreateHttpServer();
            Client = CreateHttpClient(Server);
        }

        /*httpServer : DelegatingHandler : HttpMessageHandler*/
        protected static HttpClient CreateHttpClient(HttpServer server)
        {
            return new HttpClient(server)
            {
                BaseAddress = webApiUri
            };
        }

        protected static HttpServer CreateHttpServer()
        {
            var config = new HttpConfiguration();
            Bootstrap.Init(config);

            var server = new HttpServer(config);
            return server;
        }

        public void Dispose()
        {
            Server? .Dispose();
            Client? .Dispose();
        }
    }
}