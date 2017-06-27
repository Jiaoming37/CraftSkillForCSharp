using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace test
{
    public class TestMessage : ResourceTestBase
    {
        [Fact]
        public async Task should_be_ok_to_get_message()
        {
            HttpResponseMessage request = await Client.GetAsync(webApiUri + "message");

            Assert.Equal(HttpStatusCode.OK, request.StatusCode);
        }

        [Fact]
        public async Task should_get_correct_message()
        {
            HttpResponseMessage request = await Client.GetAsync(webApiUri + "message");

            var response = await request.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeAnonymousType(response, new { Message = default(string) });
            Assert.Equal("Hello", result.Message);
        }
    }
}
