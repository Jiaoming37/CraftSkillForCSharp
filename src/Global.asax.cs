using System;
using System.Web;
using System.Web.Http;

namespace src
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;

            Bootstrap.Init(config);
        }
    }
}