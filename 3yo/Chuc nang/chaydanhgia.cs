using Newtonsoft.Json;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using xNet;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace _3yo
{
    public class Chaydanhgia : chucnang
    {
        public void chaydanhgia(int t)
        {
            if (chromeDriver != null)
            {
                try
                {
                    chromeDriver.Close();
                    chromeDriver.Quit();
                }
                catch (Exception)
                {
                }
            }

            ChromeOptions options = new ChromeOptions();

            options.AddArguments("user-data-dir=C:/Users/84334/AppData/Local/Google/Chrome/User Data/Profile " + t);
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-notifications");
            options.AddArguments("--disable-application-cache");
            Thread.Sleep(3000);
            chromeDriver = new ChromeDriver(options);
            chromeDriver.Navigate().GoToUrl("https://traodoisub.com/");
            chromeDriver.Manage().Window.Maximize();


            var user = chromeDriver.FindElementByXPath("//*[@id=\"username\"]");
            user.SendKeys("bamlun123");
            var pass = chromeDriver.FindElementByCssSelector("#password");
            pass.SendKeys("gacon123");
            var ig = chromeDriver.FindElementById("loginclick");
            ig.Submit();
            waitload("/html/body/main/div/div[1]/nav/div/ul/li[1]/a");
            var ch = chromeDriver.FindElementByCssSelector("#navbarStandard > ul > li:nth-child(1)");
            ch.Click();
            waitload("/html/body/main/div/div/div[2]/div[3]/div/div[2]/div/table/tbody/tr[1]/td[2]/button");
            var start = chromeDriver.FindElementByXPath("/html/body/main/div/div/div[2]/div[3]/div/div[2]/div/table/tbody/tr[1]/td[2]/button");
            start.Click();

            var kiemxu = chromeDriver.FindElementById("navbarDropdownHome");
            kiemxu.Click();
            var report = chromeDriver.FindElementByCssSelector("#navbarStandard > ul > li:nth-child(2) > div > div > a:nth-child(9)");
            report.Click();

            // bắt đầu vòng lặp
            for (int i = 1; i < 10; i++)
            {
                waitload("/html/body/main/div/div[1]/div[2]/div[2]/div/div[2]/div/div/div[4]/div/div[1]/div/button");
                IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
                var excute = (string)js.ExecuteScript("var elements = document.getElementsByClassName(\"form-control\")[0].innerHTML; return elements;");
                var chondsnhiemvu = chromeDriver.ExecuteScript("var elements = document.getElementsByClassName(\"btn btn-outline-primary mr-3 mb-3\")[0]; elements.click();");


                // Chuyển tab facebook
                IReadOnlyCollection<string> windowHandles = chromeDriver.WindowHandles;
                string firstTab = windowHandles.First();
                string lastTab = windowHandles.Last();
                chromeDriver.SwitchTo().Window(lastTab);


                var wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 3));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("facebook")));
                waitload("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[1]/div[1]/div[4]/div/div/div[1]/div[2]/div/div[3]/div/div/div/div[2]/div[1]/div/div");
                var annutco = chromeDriver.ExecuteScript("var elements = document.getElementsByClassName(\"rq0escxv l9j0dhe7 du4w35lb j83agx80 pfnyh3mw taijpn5t bp9cbjyn owycx6da btwxx1t3 kt9q3ron ak7q8e6j isp2s0ed ri5dt5u2 rt8b4zig n8ej3o3l agehan2d sk4xxmp2 d1544ag0 tw6a2znq tdjehn4e qypqp5cg\")[0]; elements.click();");
                waitload("/html/body/div[1]/div/div[1]/div/div[4]/div/div/div[1]/div/div[2]/div/div/div/div[3]/form/div[2]/div[2]/div/div/div[2]/div/div/div/div");
                var guidanhgia = chromeDriver.FindElementByXPath("/html/body/div[1]/div/div[1]/div/div[4]/div/div/div[1]/div/div[2]/div/div/div/div[3]/form/div[2]/div[2]/div/div/div[2]/div/div/div/div");
                guidanhgia.SendKeys(excute);
                waitload("/html/body/div[1]/div/div[1]/div/div[4]/div/div/div[1]/div/div[2]/div/div/div/div[3]/form/div[5]/div/div/div");
                var dang = chromeDriver.ExecuteScript("var elements = document.getElementsByClassName(\"rq0escxv l9j0dhe7 du4w35lb j83agx80 pfnyh3mw taijpn5t bp9cbjyn owycx6da btwxx1t3 kt9q3ron ak7q8e6j isp2s0ed ri5dt5u2 rt8b4zig n8ej3o3l agehan2d sk4xxmp2 d1544ag0 tw6a2znq s1i5eluu tv7at329\")[0]; elements.click();");
                Thread.Sleep(2000);
                chromeDriver.Close();
                chromeDriver.SwitchTo().Window(firstTab);
                waitload("/html/body/main/div/div[1]/div[2]/div[2]/div/div[2]/div/div/div[4]/div/div[1]/div/button");
                var nhanxu = chromeDriver.ExecuteScript("var elements = document.getElementsByClassName(\"btn btn-outline-primary mr-3 mb-3\")[1]; elements.click();");
                Thread.Sleep(6000);
                chromeDriver.Navigate().Refresh();
            }
        }
    }

}
