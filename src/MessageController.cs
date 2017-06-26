using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace src
{
    public class MessageController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new {Message = "Hello"});
        }
    }
}