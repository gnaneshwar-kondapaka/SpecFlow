using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
using System.IO;

namespace Utils
{
    public class Constants
    {


        //File Path
        public static string Screenshots = "\\ClassLibraryDotNetFrameWork\\Reports\\Screenshots";
        public static string TestData = "\\ClassLibraryDotNetFrameWork\\Services\\TestData.json";
        public static string HtmlReport = "\\ClassLibraryDotNetFrameWork\\Reports\\index.html";
        public static string projectPath = Directory.GetParent(Directory.GetCurrentDirectory().ToString()).FullName;

        public static string QualityPointURL_QA = "http://qualitypointtech.net/timesheetdemo/index.php";



        //Messages
        public static string LoginFailedMessage = "Please check your username and password";
        public static string LogOutMessage = "You have been logged out. Thank you for using Timesheet.";

        /// <summary>
        /// Method to get excepted page title for the given page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetPageTitle(string page)
        {
            string PageTitle = null;
            try
            {
                if (page.Equals("Login"))
                    PageTitle = "Online Timesheet • Qualitypointtech.com";
                else if (page.Equals("AdminRegistration"))
                    PageTitle = "New Admin Registration Form - Online Timesheet • Qualitypointtech.com";
                else if (page.Equals("Report"))
                    PageTitle = "Report - Online Timesheet • Qualitypointtech.com";
                else if (page.Equals("HelpFiles"))
                    PageTitle = "Help links - Online Timesheet • Qualitypointtech.com";
                else if (page.Equals("QTP"))
                    PageTitle = "Web Based TimeSheet Software (PHP/MySQL Script) - QualityPoint Technologies (QPT)";
                else
                    Assert.True(false, "No Page with name : " + page);
            }catch(Exception e)
            {
                throw;
            }
            return PageTitle;
        }

        /// <summary>
        /// Method to get excepted page title for the given page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetMessage(string messageName)
        {
            string Message = null;
            try
            {
                if (messageName.Equals("LoginFailedMessage"))
                    Message = "Please check your username and password";
                else if (messageName.Equals("LogoutMessage"))
                    Message = "You have been logged out. Thank you for using Timesheet.";
                else
                    Assert.True(false, "No Page with name : " + Message);
            }
            catch (Exception e)
            {
                throw;
            }
            return Message;
        }

        //Locators
        public static string EmpOrProjCode = "//option[text()='";
        public static string ClosingBrace = "']";

        // Attributes
        public static string Value = "value";

        // Time Constants
        public static int VS_Delay = 1000;
        public static int S_Delay = 5000;
        public static int M_Delay = 10000;
        public static int L_Delay = 20000;
        public static int VL_Delay = 500000;

        public static int FluentWait = 15;
        public static int ImplicityWait = 20;


        public static int VS_Wait = 5;
        public static int S_Wait = 10;
        public static int M_Wait = 20;
        public static int L_Wait = 60;
        public static int VL_Wait = 100;



    }
}
