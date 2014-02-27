using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Spring.Data.NHibernate.Support;

namespace Order.Host
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            SessionScope sessionScope = new SessionScope("appSettings", typeof(SessionScope), false);
            sessionScope.Open();
            HttpContext.Current.Session["SessionScope"] = sessionScope;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            SessionScope sessionScope = HttpContext.Current.Session["SessionScope"] as SessionScope;
            if (sessionScope != null)
            {
                sessionScope.Close();
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}