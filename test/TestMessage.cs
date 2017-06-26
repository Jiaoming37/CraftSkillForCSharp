using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using src;
using Xunit;

namespace test
{
    public class TestMessage
    {
        [Fact]
        public async Task should_get_correct_message()
        {
            var config = new HttpConfiguration();
            Bootstrap.Init(config);

            var server = new HttpServer(config);
            var client = new HttpClient(server);

            HttpResponseMessage request = await client.GetAsync("http://webapi/message");
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);

            var response = await request.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeAnonymousType(response, new {Message = default(string)});
            Assert.Equal("Hello", result.Message);
        }
    }
}
