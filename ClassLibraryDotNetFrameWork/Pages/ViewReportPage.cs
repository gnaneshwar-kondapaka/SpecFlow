using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Utils;

namespace Pages
{
    public class ViewReportPage : PublicLibrary
    {
        public IWebElement ViewReportElement()
        {
            return Driver.FindElement(By.CssSelector("input[value='View Report']"));
        }

        public IWebElement StartDateElement()
        {
            return Driver.FindElement(By.CssSelector("input[name='startDate']"));
        }

        public IWebElement EndDateElement()
        {
            return Driver.FindElement(By.CssSelector("input[name='endDate']"));
        }

        public IReadOnlyCollection<IWebElement> WorkingDatesElements()
        {
            return Driver.FindElements(By.CssSelector("table[class='stylized']>tbody>tr[class*='Row'] :nth-child(4)"));
        }

    }

}
