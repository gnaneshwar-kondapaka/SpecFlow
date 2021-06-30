using System;
using TechTalk.SpecFlow; 
using System.Configuration;
using Utils;
using TechTalk.SpecFlow.Assist;
using Pages;
using System.IO;
using NUnit.Framework;
using MongoDB.Bson.IO;
using System.Collections.Generic;
using Momentum.Pm.Api.Schema.DataContracts;
using Nancy.Json;

namespace StepDefinations
{



    [Binding]
    public class LoginSteps : LoginPage 
    {

        private Constants Const = new Constants();
        LogoutPage logOut = new LogoutPage();

        /// <summary>
        /// <para>  <strong> Method Name : </strong> GivenBrowserIsLaunced </para>
        ///  Method to Launch the browser 
        /// </summary>
        [Given(@"Browser is launced")]
        public void GivenBrowserIsLaunced()
        {
            try
            {
                LaunchBrowser(ConfigurationManager.AppSettings["BrowserName"]);
            }
            catch (Exception e)
            {
                ReportException("Exception while launching the browser : " + e);
            }
        }


        /// <summary>
        /// <para>  <strong> Method Name : </strong> GivenNavigatedToQualityPointApplication </para>
        /// Method to Navigate to QualityPoint Application and verify whether navigated appropriately or not 
        /// </summary>
        [Given(@"Navigated to QualityPoint Application")]
        public void GivenNavigatedToQualityPointApplication()
        {
            try
            {
                NavigateToQualityPoint(ConfigurationManager.AppSettings["Environment"]);
                VerifyPageTitle(Const.GetPageTitle("Login"));
            }catch(Exception e)
            {
                ReportException("Exception while navigating to Qualitypoint, Exception : " + e);
            }
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> WhenIEnterInUserNameAndInPassword </para>
        /// Method to fill the Login fields with given data
        /// <list>
        /// <item> <strong>Parameters :</strong></item>
        /// <item> <strong>string :</strong>userName</item>
        /// <item> <strong>string :</strong>passWord</item>
        /// </list>
        /// </summary>
        [When(@"Enter ""(.*)"" in UserName field and ""(.*)"" in Password field")]
        [Given(@"Enter ""(.*)"" in UserName field and ""(.*)"" in Password field")]
        public void WhenIEnterInUserNameAndInPassword(string userName, string passWord)
        {
            try
            {
                SetValue(UserName(), testData[userName].ToString());
                SetValue(PassWord(), testData[passWord].ToString());
            }catch(Exception e)
            {
                ReportException("Exception while Entering username and password, Exception : " + e);
            }
        }


        /// <summary>
        /// <para>  <strong> Method Name : </strong> WhenClickOnLoginButton </para>
        /// Method to Click on Login button
        /// </summary>
        [When(@"Click on login button")]
        [Given(@"Click on login button")]
        public void WhenClickOnLoginButton()
        {
            try
            {
                ClickElement(LoginButton());
            }
            catch (Exception e)
            {
                ReportException("Exception while clicking on login button, Exception : " + e);
            }
        }


        /// <summary>
        /// <para>  <strong> Method Name : </strong> ThenClosetheApplication </para>
        /// Method to Close the Application
        /// </summary>
        [Then(@"Close the Application")]
        public void ThenClosetheApplication()
        {
            try
            {
                QuitBrowser();
            }catch(Exception e)
            {
                ReportException("Exception while closing the browser : " + e);
            }
        }

        [Then(@"Logout from the Application")]
        public void ThenLogoutFromTheApplication()
        {
            try
            {
                ClickElement(logOut.Logout());
                VerifyPageTitle(Const.GetPageTitle("Login"));
                Assert.AreEqual(Const.GetMessage("LogoutMessage"), GetText(logOut.LogoutMessage()));
                QuitBrowser();
            }
            catch (Exception e)
            {
                ReportException("Exception while closing the browser : " + e);
            }
        }



        /// <summary>
        /// <para>  <strong> Method Name : </strong> ThenShouldBeNavigatedToPage </para>
        /// Method to verify whether navigated to the specified page or not
        /// <list>
        /// <item> <strong>Parameters :</strong></item>
        /// <item> <strong>string :</strong> Expected page name</item>
        /// </list>
        /// </summary>
        [Then(@"Should be Navigated to ""(.*)"" Page")]
        [Given(@"Should be Navigated to ""(.*)"" Page")]
        public void ThenShouldBeNavigatedToPage(string page)
        {
            try
            {
                VerifyPageTitle(Const.GetPageTitle(page));
            }
            catch (Exception e)
            {
                ReportException("Exception in Verifying Error Message " + e);
            }
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> ThenErrorMessageShouldBeDisplayedInLoginPage </para>
        /// Method to verify whether Error message in login page is displayed appropriately or not
        /// <list>
        /// <item> <strong>Parameters :</strong></item>
        /// <item> <strong>string :</strong> Expected error message</item>
        /// </list>
        /// </summary>
        [Then(@"""(.*)"" error message should be displayed in Login Page")]
        public void ThenErrorMessageShouldBeDisplayedInLoginPage(string ErrorMessage)
        {
            try
            {
                Assert.AreEqual(Const.GetMessage(ErrorMessage), GetText(LoginErrorMessage()));
            }
            catch (Exception e)
            {
                ReportException("Exception in Verifying Error Message " + e);
            }
        }


    }
}
