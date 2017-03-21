using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.TestCloud.Service
{
    public class TestDemoService
    {
        public void Test(string url)
        {
            string driverPath = AppDomain.CurrentDomain.BaseDirectory;
            //测试
            ChromeOptions options = new ChromeOptions();
            //options.BinaryLocation = @"C://Program Files (x86)//Google//Chrome//Application//chrome.exe";
            //options.AddArgument("no-sandbox");

            IWebDriver driver = new ChromeDriver(@"D://WebDeriver");
            try
            {

                //先登录
                driver.Navigate().GoToUrl("http://192.168.68.19:6725/rightcloud/auth/index/1");

                IWebElement _login = driver.FindElement(By.Id("inputLoginName"));
                IWebElement _password = driver.FindElement(By.Id("inputPass"));

                _login.SendKeys("ataws");
                _password.SendKeys("ataws");

                //btLogin
                IWebElement _btLogin = driver.FindElement(By.Id("btLogin"));
                _btLogin.Click();

                new WebDriverWait(driver, new TimeSpan(0, 0, 10)).Until(a =>
                {
                    return a.Title == "主页";
                });

                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();

                new WebDriverWait(driver, new TimeSpan(0, 0, 10)).Until(a =>
                {
                    return a.Title == "TestMinPage页面;";
                });

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                driver.Quit();

            }
        }

    }
}

