using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Pages;
using Utils;
using NUnit.Framework;

namespace ClassLibraryDotNetFrameWork.StepDefinations
{
    [Binding]
    public class SelectProjectSteps : SelectProjectPage
    {

        /// <summary>
        /// <para>  <strong> Method Name : </strong> WhenIClickOnProjectDropDown </para>
        /// Method to click on Project drop down
        /// </summary>
        [When(@"Click on Project drop down")]
        public void WhenIClickOnProjectDropDown()
        {
            try
            { 
                ClickElement(ProjectDropDown(),"Project Drop down");
            }
            catch (Exception e)
            {
                ReportException(e);
            }
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> WhenISelectProject </para>
        /// Method to select the given project from list of projects displayed
        /// <list>
        /// <item> <strong>Parameters :</strong></item>
        /// <item> <strong>string :</strong> Name of the Project to be selected</item>
        /// </list>
        /// </summary>
        [When(@"Select Project ""(.*)""")]
        public void WhenISelectProject(string ProjectName)
        {
            try
            {
                SelectByText(ListOfProjects(), testData[ProjectName].ToString());
            }
            catch (Exception e)
            {
                ReportException(e);
            }
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> WhenISelecThenProjectFieldShouldBePopulatedWithValuetEmployee </para>
        /// Method to verify whether ProjectName field is populated with appropriate value or not
        /// <list>
        /// <item> <strong>Parameters :</strong></item>
        /// <item> <strong>string :</strong> Expected project name</item>
        /// </list>
        /// </summary>
        [Then(@"Project field should be populated with value ""(.*)""")]
        public void ThenProjectFieldShouldBePopulatedWithValue(string ProjectName)
        {
            try
            {
                string ExceptedProjectCode = GetProjectCode(testData[ProjectName].ToString());
                string ActualProjectCode = GetAttributeValue(SelectedProject(), Constants.Value);
                if (testData[ProjectName].ToString().Equals("All"))
                    Assert.IsEmpty(ActualProjectCode);
                else
                    Assert.AreEqual(ExceptedProjectCode, ActualProjectCode);
            }catch(Exception e)
            {
                ReportException(e);
            }
        }
    }
}
