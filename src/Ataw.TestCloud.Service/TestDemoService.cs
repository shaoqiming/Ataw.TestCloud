using Ataw.Framework.Core;
using Ataw.TestCloud.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.TestCloud.Service
{
    public class TestDemoService
    {

        public void Test(string url)
        {
            string _userID = "ataws";
            Task task = new Task(() =>
            {
                IWebDriver driver = new ChromeDriver(@"D:\\WebDeriver");
                try
                {

                    TestCloudUtil.SendCommandFun(_userID, "连接成功(可有可无)");
                    //先登录
                    driver.Navigate().GoToUrl("http://192.168.68.19:6725/rightcloud/auth/index/1");

                    IWebElement _login = driver.FindElement(By.Id("inputLoginName"));
                    IWebElement _password = driver.FindElement(By.Id("inputPass"));

                    _login.SendKeys("ataws");
                    _password.SendKeys("ataws");

                    IWebElement _btLogin = driver.FindElement(By.Id("btLogin"));
                    _btLogin.Click();

                    TestCloudUtil.SendCommandFun(_userID, "登录中，加载中。。。。");
                    ScreenGFile(driver, "主页");

                    new WebDriverWait(driver, new TimeSpan(0, 0, 60)).Until(a =>
                    {
                        return a.Title == "主页";
                    });
                   
                    ScreenGFile(driver, "主页");
                    TestCloudUtil.SendCommandFun(_userID, "登录成功");

                    driver.Navigate().GoToUrl(url);
                    driver.Manage().Window.Maximize();

                    ScreenGFile(driver, "页面跳转");
                    TestCloudUtil.SendCommandFun(_userID, "页面跳转");


                    new WebDriverWait(driver, new TimeSpan(0, 0, 10)).Until(a =>
                    {
                        return a.Title == "TestMinPage页面;";
                    });

                    driver.Manage().Window.Maximize();
                    IWebElement Text = driver.FindElement(By.Id("text"));
                    IWebElement btn = driver.FindElement(By.Id("btn"));
                    Text.SendKeys("这个Selenium真的能折腾人");
                    btn.Click();
                    //获得弹出框
                    var alert = driver.SwitchTo().Alert();
                    //点击确定
                    alert.Accept();
                    //span
                    IWebElement span = driver.FindElement(By.Id("span"));

                    if (span.Text.Contains("这个Selenium真的能折腾人"))
                    {
                        ScreenGFile(driver, "测试成功");
                        TestCloudUtil.SendCommandFun(_userID, "测试成功");
                    }

                }
                catch (Exception e)
                {
                    ScreenGFile(driver, e.Message + "+异常");
                    TestCloudUtil.SendCommandFun(_userID, e.Message);
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    driver.Quit();
                }
            });

            task.Start();
        }


        public static void ScreenGFile(IWebDriver driver, string name)
        {
            Screenshot screenShotFile = ((ITakesScreenshot)driver).GetScreenshot();
            string dataStr = DateTime.Now.ToString("yyyyMMddhhmmsssss");
            screenShotFile.SaveAsFile("D:\\shaoqi\\" + dataStr + "+" + name + ".jpg", ImageFormat.Jpeg);
        }

    }
}

