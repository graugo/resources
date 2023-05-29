using System;
using WCFHttpClient.Extensions;

namespace WCFHttpClient
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterServices.Register();
        }
    }
}