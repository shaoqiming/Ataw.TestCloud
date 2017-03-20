using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ataw.TestCloud.Web
{
    public class TestCloudAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "TestCloud";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              "TestCloud_default",
              "RightCloud/{controller}/{action}/{id}",
              new { controller = "UI", action = "Home", id = UrlParameter.Optional },
                new[] { "Ataw.RightCloud.Web", "Ataw.RightCloud.Web.Controllers" }

          );
        }
    }
}