using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Quartz;
using Quartz.Impl;

namespace Quarz_Test
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private QuartzService _quartzService;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            // QuartzService 초기화 및 시작
            _quartzService = new QuartzService();
            _quartzService.Start();
            _quartzService.ConfigureJobs();
        }
        
        protected void Application_End(object sender, EventArgs e)
        {
            // QuartzService 종료
            _quartzService.Stop();
        }
    }
}