using OpenQA.Selenium;
using Utils;

namespace Pages
{
    public class LoginPage : PublicLibrary
    {
        public IWebElement UserName() 
        {
            return Driver.FindElement(By.Id("username"));
        }

        public IWebElement PassWord()
        {
            return Driver.FindElement(By.CssSelector("input[name='password']"));
        }

        public IWebElement LoginButton()
        {
            return Driver.FindElement(By.CssSelector("input[name='login']"));
        }

        public IWebElement LoginErrorMessage()
        {
            return Driver.FindElement(By.Id("logerror"));
        }

        public IWebElement AdminRegistration()
        {
            return Driver.FindElement(By.LinkText("Admin Registration"));
        }

        public IWebElement HelpFiles()
        {
            return Driver.FindElement(By.LinkText("Help Files"));
        }

        public IWebElement BuyNow()
        {
            return Driver.FindElement(By.XPath("//td/a/img"));
        }
    }
}
