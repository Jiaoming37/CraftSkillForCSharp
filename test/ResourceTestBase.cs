using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
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
            Bootstrapper.Init(config);

            var server = new HttpServer(config);
            return server;
        }

        public void Dispose()
        {
            Server? .Dispose();
            Client? .Dispose();
        }

        protected static async Task<T> ReadAsJsonAsync<T>(HttpResponseMessage request, T template)
        {
            var response = await request.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeAnonymousType(response, template);
        }
    }
}