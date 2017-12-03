using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using WebApplication14.Domain.Abstract;
using WebApplication14.Domain.Concrete;

namespace WebApplication14.Infrastructure
{
    public class DI : DefaultControllerFactory
    {
        private IKernel kernel;
        public DI()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        private void AddBindings()
        {
            kernel.Bind<IDisciples>().To<DisciplesDirectory>();
            kernel.Bind<IOsn>().To<Osnova>();
            kernel.Bind<ISpecial>().To<Specal>();
            kernel.Bind<ISpecializations>().To<Napravlenia>();
        }
        protected override IController GetControllerInstance(RequestContext requestContext,
                                                          Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)kernel.Get(controllerType);
        }

    }
}