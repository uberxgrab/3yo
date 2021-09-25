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
    public class Chaytheodoi : chucnang
    {
        public void chaytheodoi(int t)
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


            //ChromeDriver facebook = new ChromeDriver();
            //facebook.Navigate().GoToUrl("https://www.facebook.com/");
            //var userface = facebook.FindElementByXPath("/html/body/div[1]/div[2]/div[1]/div/div/div/div[2]/div/div[1]/form/div[1]/div[1]/input");
            //userface.SendKeys("0332468738");
            //var passface = facebook.FindElementByXPath("/html/body/div[1]/div[2]/div[1]/div/div/div/div[2]/div/div[1]/form/div[1]/div[2]/div/input");
            //passface.SendKeys("xidau123");
            //var dangnhap = facebook.FindElementByXPath("/html/body/div[1]/div[2]/div[1]/div/div/div/div[2]/div/div[1]/form/div[2]/button");
            //dangnhap.Click();
            //var cookiesface = facebook.Manage().Cookies.AllCookies;
            //facebook.Close();


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
            var start = chromeDriver.ExecuteScript("var elements = document.getElementsByClassName(\"btn btn-primary btn-sm\")[" + t + "]; elements.click();");
            MessageBox.Show("ưait");
            var kiemxu = chromeDriver.FindElementById("navbarDropdownHome");
            kiemxu.Click();
            var followcheo = chromeDriver.FindElementByCssSelector("#navbarStandard > ul > li:nth-child(2) > div > div > a:nth-child(6)");
            followcheo.Click();
            // Gọi api và xử lý chuỗi Json
            string GetData(string url)
            {
                HttpRequest http = new HttpRequest();
                http.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
                string html = http.Get(url).ToString();
                return html;
            }
            var apo = GetData("https://traodoisub.com/api/?fields=group&access_token=TDSQfiQjclZXZzJiOiIXZ2V2ciwiIzITMuVHbtFmYiojIyV2c1Jye");
            var data = JsonConvert.DeserializeObject<List<Choson>>(apo);
            var Data = data[1];
            // bắt đầu vòng lặp
            for (int i = 1; i < 30; i++)
            {
                waitload("/html/body/main/div/div[1]/div[2]/div[2]/div/div[2]/div/div/div[2]/div/button");
                var leson = chromeDriver.FindElementByClassName("col-2");
                leson.Click();

                // Chuyển tab
                IReadOnlyCollection<string> windowHandles = chromeDriver.WindowHandles;
                string firstTab = windowHandles.First();
                string lastTab = windowHandles.Last();
                chromeDriver.SwitchTo().Window(lastTab);
                ////đăng nhập face
                //var userface = chromeDriver.FindElementByXPath("//*[@id=\"login_form\"]/div[2]/div[1]/label");
                //userface.SendKeys("0332468738");
                //var passface = chromeDriver.FindElementByXPath("//*[@id=\"login_form\"]/div[2]/div[2]/label");
                //passface.SendKeys("xidau123");
                //var dangnhap = chromeDriver.FindElementByXPath("//*[@id=\"login_form\"]/div[2]/div[3]/div/div/div[1]/div");
                //dangnhap.Click();
                ////var ac = chromeDriver.FindElementByXPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[1]/div[1]/div[3]/div/div/div[2]/div[2]/div/div");
                ////ac.Click();
                waitload("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[1]/div[1]/div/div/div[3]/div/div/div/div[2]/div/div/div/div[1]/div/div");
                var ac = chromeDriver.ExecuteScript("var element = document.getElementsByClassName(\"rq0escxv l9j0dhe7 du4w35lb j83agx80 pfnyh3mw taijpn5t bp9cbjyn owycx6da btwxx1t3 kt9q3ron ak7q8e6j isp2s0ed ri5dt5u2 rt8b4zig n8ej3o3l agehan2d sk4xxmp2 d1544ag0 tw6a2znq s1i5eluu tv7at329\")[0]; " +
                    "element.click();");
                Thread.Sleep(2000);
                chromeDriver.Close();
                chromeDriver.SwitchTo().Window(firstTab);
                waitload("/html/body/main/div/div[1]/div[2]/div[2]/div/div[2]/div/div/div[2]/div/button");
                leson.Click();
                Thread.Sleep(2000);
                chromeDriver.Navigate().Refresh();
            }


            ////for (int i=1; i<10; i++)
            ////{
            ////    leson.Click();
            ////    windowHandles = chromeDriver.WindowHandles;
            ////    chromeDriver.SwitchTo().Window(lastTab);
            ////    Thread.Sleep(10000);
            ////    ac.Click();
            ////    chromeDriver.Close();
            ////    chromeDriver.SwitchTo().Window(firstTab);
            ////    leson.Click();
            ////}
        }
    }

}
