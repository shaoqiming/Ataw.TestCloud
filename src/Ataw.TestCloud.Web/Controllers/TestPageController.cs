using Ataw.Framework.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ataw.TestCloud.Service;

namespace Ataw.TestCloud.Web.Controllers
{   
    public class TestPageController : AtawBaseController
    {
        public string TestDemoPage(string url)
        {
            TestDemoService service = new TestDemoService();
            service.Test(url);
            return ReturnJson("");
        }

        public string Demo()
        {
            return "dddd";
        }
    }
}