using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Data.NHibernate.Support;
using System.Web;

namespace Res.Core
{
    public class ResOpenSessionInViewModule : SessionScope, IHttpModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenSessionInViewModule"/> class.  Creates a SessionScope,
        /// but does not yet associate a session with a thread, that is left to the lifecycle of the request.
        /// </summary>
        public ResOpenSessionInViewModule()
            : base("appSettings", typeof(ResOpenSessionInViewModule), false)
        {

        }

        #region IHttpModule Members

        /// <summary>
        /// Register context handler and look up SessionFactoryObjectName under the application configuration key,
        /// Spring.Data.NHibernate.Support.OpenSessionInViewModule.SessionFactoryObjectName if not using the default value
        /// (i.e. sessionFactory) and look up the SingleSession setting under the application configuration key,
        /// Spring.Data.NHibernate.Support.OpenSessionInViewModule.SingleSession if not using the default value of true.
        /// </summary>
        /// <param name="context">The standard HTTP application context</param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.EndRequest += new EventHandler(context_EndRequest);
        }
        /// <summary>
        /// A do nothing dispose method.
        /// </summary>
        public override void Dispose()
        {
        }

        #endregion

        private void context_BeginRequest(object sender, EventArgs e)
        {
            Open();
        }

        private void context_EndRequest(object sender, EventArgs e)
        {
            Close();
        }
    }
}
