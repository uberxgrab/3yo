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
    public class chucnang
    {
        public ChromeDriver chromeDriver;
        public void waitload(string waitConditionLocator)
        {
            var wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 20));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(waitConditionLocator)));
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ChromeDriver chromeDriver;
        public void waitload(string waitConditionLocator)
        {
            var wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 20));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(waitConditionLocator)));
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 2; i <= 2; i++)
            {
                int val = i;
                Chaytheodoi a = new Chaytheodoi();
                Thread t = new Thread(() => { a.chaytheodoi(val); });
                t.IsBackground = true;
                t.Start();
            }
      
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            for (int i = 2; i <= 2; i++)
            {
                int val = i;
                string urlshare = box.Text;
                Sharebai a = new Sharebai();
                Thread t = new Thread(() => { a.sharebai(val, urlshare); });
                t.IsBackground = true;
                t.Start();
            }
        }
    }
}
