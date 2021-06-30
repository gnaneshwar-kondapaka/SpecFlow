using System;
using TechTalk.SpecFlow;
using Pages;
using OpenQA.Selenium;
using System.Collections.Generic;
using NUnit.Framework;
using Utils;

namespace ClassLibraryDotNetFrameWork.StepDefinations
{
    [Binding]
    public class ViewReportSteps : ViewReportPage
    {

        /// <summary>
        /// <para>  <strong> Method Name : </strong> WhenIClickOnViewReportOption </para>
        ///  Method to click on the View Report option in report page
        /// </summary>
        [When(@"Click on View Report option")]
        public void WhenClickOnViewReportOption()
        {
            try
            {
                ClickElement(ViewReportElement(), "View report");
            }catch(Exception e)
            {
                ReportException("Exception in Method : WhenIClickOnViewReportOption, Exception : " + e);
            }
                                                         
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> WhenISetStartingDateAs </para>
        ///  Method to set starting date field in report page
        /// </summary>
        [When(@"Enter starting date as ""(.*)""")]
        public void WhenIEnterStartingDateAs(string StartDate)
        {
            try
            {
                SetValue(StartDateElement(), testData[StartDate].ToString());
            }catch(Exception e)
            {
                ReportException("Exception in Method : WhenIEnterStartingDateAs, Exception : "+e);
            }
            
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> WhenISetEndingDateAs </para>
        ///  Method to set ending date field in report page
        /// </summary>
        [When(@"Enter ending date as ""(.*)""")]
        public void WhenIEnterEndingDateAs(string EndDate)
        {
            try
            {
                SetValue(EndDateElement(), testData[EndDate].ToString());
            }catch(Exception e)
            {
                ReportException("Exception in WhenIEnterEndingDateAs" + e);
            }
            
        }


        /// <summary>
        /// <para>  <strong> Method Name : </strong> ThenReportsShouldBeDisplayedWithInTheDefaultTimeFrame </para>
        ///  Method to verify whether reports are generated only for the given time frame
        /// </summary>
        [Then(@"Reports should be displayed with in the default time frame")]
        [Then(@"Reports should be displayed with in the specified time frame")]
        public void ThenReportsShouldBeDisplayedWithInTheDefaultTimeFrame()
        {
            DateTime ActualWorkingDate ;
            IReadOnlyCollection<IWebElement> ActualWorkingDates = null;
            try
            {
                DateTime StartDate = Convert.ToDateTime(GetAttributeValue(StartDateElement(), Constants.Value));
                DateTime EndDate = Convert.ToDateTime(GetAttributeValue(EndDateElement(), Constants.Value));
                
                ActualWorkingDates = WorkingDatesElements();

                foreach (IWebElement WorkingDate in ActualWorkingDates)
                {
                    ActualWorkingDate = Convert.ToDateTime(GetText(WorkingDate));
                    if (ActualWorkingDate < StartDate || ActualWorkingDate > EndDate)
                    {
                        Assert.True(false, "Working dates are not in the specified dates");
                    }
                }

            }catch(Exception e)
            {
                ReportException("Exception while verifying the displayed reports" + e);
            }
        }
        
    }
}
