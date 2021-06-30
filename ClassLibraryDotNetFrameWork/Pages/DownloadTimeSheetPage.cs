using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Utils;

namespace Pages
{
    public class DownloadTimeSheetPage : PublicLibrary
    {
        public IWebElement DownloadTimeSheetOption()
        {
            return Driver.FindElement(By.LinkText("Download Pdf"));
        }

        public IWebElement DownloadTimeSheetImage()
        {
            return Driver.FindElement(By.XPath("//a[text()='Download Pdf']/parent::td//img"));
        }

    }
}
