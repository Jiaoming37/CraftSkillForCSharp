using System.Web.Http;

namespace src
{
    public class Bootstrapper
    {
        public static void Init(HttpConfiguration configration)
        {
            configration.Routes.MapHttpRoute("webapi", "message", new {Controller = "Message"});

            configration.Routes.MapHttpRoute("convension resource", "convention-resource",
                new {Controller = "ConvensionResource"});

            configration.Routes.MapHttpRoute("explicit resource", "explicit-resource",
                new {Controller = "ExplicitResource"});
        }
    }
}