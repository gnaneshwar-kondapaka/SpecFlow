using System;
using TechTalk.SpecFlow;
using Pages;
using Utils;
using NUnit.Framework;

namespace ClassLibraryDotNetFrameWork.StepDefinations
{
    [Binding]
    public class HelpFilesSteps : HelpFilesPage
    {
        private LoginPage loginPage = new LoginPage();

        /// <summary>
        /// <para>  <strong> Method Name : </strong> WhenClickedOnHelpFilesButton </para>
        /// Method to to click on Help Files button
        /// </summary>
        [When(@"Clicked on Help Files button")]
        public void WhenClickedOnHelpFilesButton()
        {
            try
            {
                ClickElement(loginPage.HelpFiles());
            }catch(Exception e)
            {
                ReportException(e);
            }
        }
         
    }
}
