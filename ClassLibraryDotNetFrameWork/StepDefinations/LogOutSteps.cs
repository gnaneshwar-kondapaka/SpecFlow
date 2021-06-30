using System;
using TechTalk.SpecFlow;
using Pages;
using Utils;
using NUnit.Framework;

namespace ClassLibraryDotNetFrameWork.StepDefinations
{
    [Binding]
    public class LogOutSteps : LogoutPage
    {
        private Constants Const = new Constants();

        /// <summary>
        /// <para>  <strong> Method Name : </strong> WhenClickedOnLogoutOption </para>
        /// Method to click on logout button in login page
        /// </summary>
        [When(@"Clicked on Logout option")]
        public void WhenClickedOnLogoutOption()
        {
            try
            {
                ClickElement(Logout());
            }catch(Exception e)
            {
                ReportException(e);
            }
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> ThenlogoutMessageShouldBeDisplayed </para>
        ///  Method to to verify logout message in login page
        ///  <list>
        /// <item> <strong>Parameters :</strong></item>
        /// <item> <strong>string :</strong> Expected logout message</item>
        /// </list>
        /// </summary>
        [Then(@"""(.*)"" logout message should be displayed")]
        public void ThenlogoutMessageShouldBeDisplayed(string logoutMessage)
        {
            try
            { 
                string Actual = GetText(LogoutMessage());
                Assert.AreEqual(Const.GetMessage(logoutMessage), Actual);
            }
            catch (Exception e)
            {
                ReportException(e);
            }
        }
    }
}
