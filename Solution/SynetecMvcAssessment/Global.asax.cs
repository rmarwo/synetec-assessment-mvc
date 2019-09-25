using InterviewTestTemplatev2.Repository;
using Ninject;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace InterviewTestTemplatev2
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        private void RegisterServices(StandardKernel kernel)
        {
            kernel.Bind<IHrEmployeeRepository>().To<HrEmployeeRepository>();
        }
    }
}
