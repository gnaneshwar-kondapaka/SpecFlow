using System;
using StepDefinations;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Utils;
using Pages;

namespace ClassLibraryDotNetFrameWork.StepDefinations
{
    [Binding]
    public class DownloadTimeSheetSteps : DownloadTimeSheetPage
    {
        private LoginPage loginPage = new LoginPage();

        /// <summary>
        /// <para>  <strong> Method Name : </strong> WhenClickedOnDownloadPdfOption </para>
        /// Method to click on download time sheet option in report page
        /// </summary>
        [When(@"Click on download Time sheet option")]
        public void WhenClickedOnDownloadPdfOption()
        {
            try
            {
                ClickElement(DownloadTimeSheetOption());
            }catch(Exception e)
            {
                ReportException(e);
            }
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> ThenReportShouldBeDownloaded </para>
        /// Method to verify whether report is downloaded or not
        /// </summary>
        [Then(@"Report should be downloaded")]
        public void ThenReportShouldBeDownloaded()
        {
            try
            {
                SwitchToWindow(2);
                SwitchToWindow(1);
            }
            catch(Exception e)
            {
                ReportException(e);
            }
        }
    }
}
