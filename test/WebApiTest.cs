using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace test
{
    public class WebApiTest : ResourceTestBase
    {
        [Theory]
        [InlineData("Get", "Convension Resource Get")]
        [InlineData("Put", "Convension Resource Put")]
        [InlineData("Post", "Convension Resource Post")]
        [InlineData("Delete", "Convension Resource Delete")]
        public async Task should_dispath_to_correct_http_method(string method, string expect)
        {
            HttpResponseMessage request = await Client.SendAsync(new HttpRequestMessage(new HttpMethod(method), "convention-resource"));
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);

            var result = await ReadAsJsonAsync(request, new { Message = default(string) });
            Assert.Equal(expect, result.Message);

        }

        [Fact]
        public async Task should_dispath_to_explicit_get_menthod()
        {
            HttpResponseMessage response = await Client.GetAsync("explicit-resource");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("Put", "Explicit Resource Put")]
        [InlineData("Post", "Explicit Resource Post")]
        public async Task should_dispath_to_post_or_post_to_one_explicit_method(string method, string expect)
        {
            HttpResponseMessage request = await Client.SendAsync(new HttpRequestMessage(new HttpMethod(method), "explicit-resource"));
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);

            var result = await ReadAsJsonAsync(request, new { Message = default(string)});
            Assert.Equal(expect, result.Message);
        }
    }
}