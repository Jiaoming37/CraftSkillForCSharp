using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace src
{
    public class ConvensionResourceController : ApiController
    {
        /*
        [AcceptVerbs("GET", "PUT", "POST", "DELETE")]
        public HttpResponseMessage Handle()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new {Message = $"method is {Request.Method.Method}"});
        }
        */

        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new {Message = "Convension Resource Get" });
        }

        [HttpPost]
        public HttpResponseMessage Post()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Convension Resource Post" });
        }

        [HttpPut]
        public HttpResponseMessage Put()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Convension Resource Put" });
        }

        [HttpDelete]
        public HttpResponseMessage Delete()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Convension Resource Delete" });
        }
    }
}