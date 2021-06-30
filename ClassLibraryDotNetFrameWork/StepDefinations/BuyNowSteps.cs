using System;
using TechTalk.SpecFlow;
using Pages;
using Utils;
using NUnit.Framework;

namespace ClassLibraryDotNetFrameWork.StepDefinations
{
    [Binding]
    public class BuyNowSteps : BuyNowPage
    {
        
        private LoginPage loginPage = new LoginPage();

        /// <summary>
        /// <para>  <strong> Method Name : </strong> WhenClickedOnBuyNowButton </para>
        /// Method to click on Buy Now option
        /// </summary>
        [When(@"Clicked on Buy Now button")]
        public void WhenClickedOnBuyNowButton()
        {
            try
            {
                ClickElement(loginPage.BuyNow());
            }
            catch(Exception e)
            {
                ReportException(e);
            }
        }

    }
}
