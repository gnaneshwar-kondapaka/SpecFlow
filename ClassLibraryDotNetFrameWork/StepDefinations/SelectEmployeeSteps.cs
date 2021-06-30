using System;
using OpenQA.Selenium; 
using TechTalk.SpecFlow;
using Pages;
using Utils;
using NUnit.Framework;

namespace ClassLibraryDotNetFrameWork.StepDefinations
{
    [Binding]
    public class SelectEmployeeSteps : SelectEmployeePage
    {


        /// <summary>
        /// <para>  <strong> Method Name : </strong> WhenIClickOnEmployeeDropDown </para>
        ///Method to click on Employee drop down
        /// </summary>
        [When(@"Click on employee drop down")]
        public void WhenIClickOnEmployeeDropDown()
        {
            try
            {
                ClickElement(EmpDropDown());
            }
            catch(Exception e )
            {
                ReportException(e);
            }
        }


        /// <summary>
        /// <para>  <strong> Method Name : </strong> WhenISelectEmployee </para>
        /// Method to select given employee from the list of employees displayed
        /// <list>
        /// <item> <strong>Parameters :</strong></item>
        /// <item> <strong>string :</strong> Name of the Employee to be selected</item>
        /// </list>
        /// </summary>
        [When(@"Select employee ""(.*)""")]
        public void WhenISelectEmployee(string EmployeeName)
        {
            try
            {
                SelectByText(ListOfEmployees(), testData[EmployeeName].ToString());
            }catch(Exception e)
            {
                ReportException(e);
            }
            
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> ThenEmployeeFieldShouldBePopulatedWithValue </para>
        /// Method to verify whether employee field is populated with appropriate value or not
        /// <list>
        /// <item> <strong>Parameters :</strong></item>
        /// <item> <strong>string :</strong> Expected employee name</item>
        /// </list>
        /// </summary>
        [Then(@"Employee field should be populated with value ""(.*)""")]
        public void ThenEmployeeFieldShouldBePopulatedWithValue(string EmployeeName)
        {
            try
            {
                string ExceptedEmployeeCode = GetEmployeeCode(testData[EmployeeName].ToString());
                string ActualEmployeeCode = GetAttributeValue(SelectedEmployee(), Constants.Value);
                if (testData[EmployeeName].ToString().Equals("All"))
                    Assert.IsEmpty(ActualEmployeeCode);
                else
                    Assert.AreEqual(ExceptedEmployeeCode, ActualEmployeeCode);
            }
            catch (Exception e)
            {
                ReportException(e);
            }
        }
    }
}
