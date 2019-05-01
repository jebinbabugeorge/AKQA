using AKQA.Framework;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Routing;

namespace AKQA
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private readonly IWindsorContainer container;

        public WebApiApplication()
        {
            this.container =
                new WindsorContainer().Install(new DependencyInstaller());
        }

        public override void Dispose()
        {
            this.container.Dispose();
            base.Dispose();
        }
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Services.Replace(
                            typeof(IHttpControllerActivator),
                            new WindsorCompositionRoot(this.container));
        }
    }
}
