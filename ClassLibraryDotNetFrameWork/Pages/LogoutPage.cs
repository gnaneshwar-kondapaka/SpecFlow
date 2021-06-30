using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Utils;

namespace Pages
{
    public class LogoutPage : PublicLibrary
    {
        public IWebElement Logout()
        {
            return Driver.FindElement(By.LinkText("Logout"));
        }
        
        public IWebElement LogoutMessage()
        {
            return Driver.FindElement(By.Id("logoutstatus"));
        }

    }

}
