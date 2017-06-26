using System.Web.Http;

namespace src
{
    public class Bootstrap
    {
        public static void Init(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("webapi", "message", new { Controller = "Message" });
        }
    }
}