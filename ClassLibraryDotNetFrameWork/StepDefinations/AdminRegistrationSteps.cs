using System;
using TechTalk.SpecFlow;
using Pages;
using Utils;
using NUnit.Framework;

namespace StepDefinations
{
    [Binding]
    public class AdminRegistrationSteps : AdminRegistrationPage
    {
        
        private LoginPage Login = new LoginPage();


        /// <summary>
        /// <para>  <strong> Method Name : </strong> ThenErrorMessageShouldBeDisplayedInLoginPage </para>
        /// Method to Click on Registration button
        /// </summary>
        [When(@"Click on Admin Registration button")]
        public void WhenClickedOnAdminRegistrationButton()
        {
            try
            {
                ClickElement(Login.AdminRegistration());
            }catch(Exception e)
            {
                ReportException(e);
            }
        }
    }
}
