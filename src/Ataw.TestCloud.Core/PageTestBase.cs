using Ataw.TestCloud.DB;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.TestCloud.Core
{
    //接口还是抽象类
    public abstract class PageTestBase
    {

        protected IWebDriver driver { get; }

        protected DateTime startTime { get; set; }

        protected DateTime endTime { get; set; }

        protected TimeSpan duration { get; set; }

        protected TestCase testCase { get; set; }

        public PageTestBase(IWebDriver driver)
        {
            this.driver = driver;//基类中进行定位
        }

        public virtual void onTest(TestCase testcase)
        {

            if (startTime != null)
            {
                endTime = DateTime.Now;
                duration = startTime - endTime;
            }
            driver.Quit();
        }
    }
}
