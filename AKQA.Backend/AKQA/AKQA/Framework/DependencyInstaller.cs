using AKQA.BusinessLayer;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace AKQA.Framework
{
    internal sealed class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                            .BasedOn<IHttpController>()
                            .LifestyleTransient());

            container.Register(Component.For<IConvertNumberToWord>().ImplementedBy<ConvertNumberToWord>().LifestyleTransient());
        }
    }
}