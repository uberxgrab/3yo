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
    public class Sharebai : chucnang
    {
        public void sharebai(int t, string adress)
        {
            List<UserInfo> userList = new List<UserInfo>();
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
            options.AddArguments("user-data-dir=C:/Users/84334/AppData/Local/Google/Chrome/User Data/Profile "+t);
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-notifications");
            options.AddArguments("--disable-application-cache");

            Thread.Sleep(3000);
            chromeDriver = new ChromeDriver(options);
            //cào data facebook
            chromeDriver.Navigate().GoToUrl("https://www.facebook.com/groups/feed/");
            chromeDriver.Manage().Window.Maximize();
            MessageBox.Show("Lăn chuột");
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            List<string> ds = new List<string>();
            var sonhom = Convert.ToInt64(js.ExecuteScript("var elements = document.getElementsByClassName(\"d2edcug0 hpfvmrgz qv66sw1b c1et5uql lr9zc1uh jq4qci2q a3bd9o3v lrazzd5p oo9gr5id\");return elements.length;"));
            string stringsonhom = sonhom.ToString();
            MessageBox.Show(stringsonhom);
            for (int i = 4; i < sonhom; i++)
            {
                var excute = (string)js.ExecuteScript("var elements = document.getElementsByClassName(\"d2edcug0 hpfvmrgz qv66sw1b c1et5uql lr9zc1uh jq4qci2q a3bd9o3v lrazzd5p oo9gr5id\");return elements[" + i + "].innerHTML;");
                ds.Add(excute);
            }
            //datalo.ItemsSource = ds.Select(x => new { Value = x }).ToList();
            chromeDriver.Close();
            chromeDriver.Quit();

            //vòng lặp share

            chromeDriver = new ChromeDriver(options);
            chromeDriver.Navigate().GoToUrl(adress);
            chromeDriver.Manage().Window.Maximize();

            for (int i = 1; i < ds.Count; i++)
            {
                try
                {
                    waitload("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[1]/div[1]/div/div/div/div/div/div/div/div/div/div/div/div/div/div[2]/div/div[4]/div/div/div[1]");
                    var share = chromeDriver.ExecuteScript("var elements = document.getElementsByClassName(\"rq0escxv l9j0dhe7 du4w35lb j83agx80 g5gj957u rj1gh0hx buofh1pr hpfvmrgz taijpn5t bp9cbjyn owycx6da btwxx1t3 d1544ag0 tw6a2znq jb3vyjys dlv3wnog rl04r1d5 mysgfdmx hddg9phg qu8okrzs g0qnabr5\")[2]; elements.click();");
                    try
                    {
                        waitload("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/div/div/div[1]/div/div/div[1]/div/div[4]");
                        var nhom = chromeDriver.ExecuteScript("var nhom = document.getElementsByClassName(\"ow4ym5g4 auili1gw rq0escxv j83agx80 buofh1pr g5gj957u i1fnvgqd oygrvhab cxmmr5t8 hcukyx3x kvgmc6g5 tgvbjcpo hpfvmrgz qt6c0cv9 jb3vyjys l9j0dhe7 du4w35lb bp9cbjyn btwxx1t3 dflh9lhu scb9dxdr\")[3]; nhom.click();");
                        waitload("/html/body/div[1]/div/div[1]/div/div[4]/div/div/div[1]/div/div[2]/div/div/div/div/div[1]/div[2]/div/div/div[1]/div/div/label/input");
                        var timkiem = chromeDriver.FindElementByXPath("/html/body/div[1]/div/div[1]/div/div[4]/div/div/div[1]/div/div[2]/div/div/div/div/div[1]/div[2]/div/div/div[1]/div/div/label/input");
                        timkiem.SendKeys(ds[i]);

                    }
                    catch (Exception)
                    {
                        Thread.Sleep(3000);
                        var tuychon = chromeDriver.ExecuteScript("var elements = document.getElementsByClassName(\"ow4ym5g4 auili1gw rq0escxv j83agx80 buofh1pr g5gj957u i1fnvgqd oygrvhab cxmmr5t8 hcukyx3x kvgmc6g5 tgvbjcpo hpfvmrgz qt6c0cv9 jb3vyjys l9j0dhe7 du4w35lb bp9cbjyn btwxx1t3 dflh9lhu scb9dxdr\")[3]; elements.click();");
                        Thread.Sleep(3000);
                        var nhom = chromeDriver.ExecuteScript("var elements = document.getElementsByClassName(\"ow4ym5g4 auili1gw rq0escxv j83agx80 buofh1pr g5gj957u i1fnvgqd oygrvhab cxmmr5t8 hcukyx3x kvgmc6g5 tgvbjcpo hpfvmrgz qt6c0cv9 jb3vyjys l9j0dhe7 du4w35lb bp9cbjyn btwxx1t3 dflh9lhu scb9dxdr\")[9]; elements.click();");
                        waitload("/html/body/div[1]/div/div[1]/div/div[4]/div/div/div[1]/div/div[2]/div/div/div/div/div[1]/div[2]/div/div/div[1]/div/div/label/input");
                        var timkiem = chromeDriver.FindElementByXPath("/html/body/div[1]/div/div[1]/div/div[4]/div/div/div[1]/div/div[2]/div/div/div/div/div[1]/div[2]/div/div/div[1]/div/div/label/input");
                        timkiem.SendKeys(ds[i]);

                    }
                    try
                    {
                        waitload("/html/body/div[1]/div/div[1]/div/div[4]/div/div/div[1]/div/div[2]/div/div/div/div/div[1]/div[2]/div/div/div[2]/div/div[1]/div/div/div[2]/div/div[1]/div");
                        var dsnhom = chromeDriver.FindElementByXPath("/html/body/div[1]/div/div[1]/div/div[4]/div/div/div[1]/div/div[2]/div/div/div/div/div[1]/div[2]/div/div/div[2]/div/div[1]/div/div/div[2]/div/div[1]/div");
                        dsnhom.Click();
                        Thread.Sleep(3000);
                        var dang = chromeDriver.FindElementByXPath("/html/body/div[1]/div/div[1]/div/div[4]/div/div/div[1]/div/div[2]/div/div/div/div/div[2]/form/div/div[1]/div/div/div[1]/div/div[3]/div[2]/div/div/div");
                        dang.Click();

                    }
                    catch (Exception)
                    {

                    }
                    Thread.Sleep(6000);
                }
                catch (Exception)
                {
                    var share = chromeDriver.ExecuteScript("var elements = document.getElementsByClassName(\"ow4ym5g4 auili1gw rq0escxv j83agx80 buofh1pr g5gj957u i1fnvgqd oygrvhab cxmmr5t8 hcukyx3x kvgmc6g5 tgvbjcpo hpfvmrgz qt6c0cv9 jb3vyjys l9j0dhe7 du4w35lb bp9cbjyn btwxx1t3 dflh9lhu scb9dxdr\")[3]; " +
                        "elements.click();");
                    var tuychonkhac = chromeDriver.ExecuteScript("var elements = document.getElementsByClassName(\"n00je7tq arfg74bv qs9ysxi8 k77z8yql i09qtzwb n7fi1qx3 b5wmifdl hzruof5a pmk7jnqg j9ispegn kr520xx4 c5ndavph art1omkt ot9fgl3s rnr61an3\")[7]; " +
                        "elements.click();");
                    var nhom = chromeDriver.ExecuteScript("var elements = document.getElementsByClassName(\"ow4ym5g4 auili1gw rq0escxv j83agx80 buofh1pr g5gj957u i1fnvgqd oygrvhab cxmmr5t8 hcukyx3x kvgmc6g5 tgvbjcpo hpfvmrgz qt6c0cv9 jb3vyjys l9j0dhe7 du4w35lb bp9cbjyn btwxx1t3 dflh9lhu scb9dxdr\")[9]; " +
                        "elements.click();");
                    waitload("/html/body/div[1]/div/div[1]/div/div[4]/div/div/div[1]/div/div[2]/div/div/div/div/div[1]/div[2]/div/div/div[1]/div/div/label/input");
                    var timkiem = chromeDriver.FindElementByXPath("/html/body/div[1]/div/div[1]/div/div[4]/div/div/div[1]/div/div[2]/div/div/div/div/div[1]/div[2]/div/div/div[1]/div/div/label/input");
                    timkiem.SendKeys(ds[i]);
                    waitload("/html/body/div[1]/div/div[1]/div/div[4]/div/div/div[1]/div/div[2]/div/div/div/div/div[1]/div[2]/div/div/div[2]/div/div[1]/div/div/div[2]/div/div[1]/div");
                    var dsnhom = chromeDriver.FindElementByXPath("/html/body/div[1]/div/div[1]/div/div[4]/div/div/div[1]/div/div[2]/div/div/div/div/div[1]/div[2]/div/div/div[2]/div/div[1]/div/div/div[2]/div/div[1]/div");
                    dsnhom.Click();
                    Thread.Sleep(3000);
                    var dang = chromeDriver.FindElementByXPath("/html/body/div[1]/div/div[1]/div/div[4]/div/div/div[1]/div/div[2]/div/div/div/div/div[2]/form/div/div[1]/div/div/div[1]/div/div[3]/div[2]/div/div/div");
                    dang.Click();
                }
            }

        }

    }
}
