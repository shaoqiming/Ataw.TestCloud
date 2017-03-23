using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Ataw.TestCloud.DB;

namespace Ataw.TestCloud.Core
{
    class LoginPageTest : PageTestBase
    {
        public LoginPageTest(IWebDriver driver) : base(driver)
        {
        }

        public override void onTest(TestCase testcase)
        {
            startTime = DateTime.Now;

            driver.Navigate().GoToUrl("http://192.168.68.19:6725/rightcloud/auth/index/1");

            IWebElement _login = driver.FindElement(By.Id("inputLoginName"));
            IWebElement _password = driver.FindElement(By.Id("inputPass"));

            _login.Clear();
            _password.Clear();

            _login.SendKeys("ataws");
            _password.SendKeys("ataws");

            IWebElement _btLogin = driver.FindElement(By.Id("btLogin"));
            _btLogin.Click();

            base.onTest(testcase);//测试完之后 释放资源
        }
    }
}
