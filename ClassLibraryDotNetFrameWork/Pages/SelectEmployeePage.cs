using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Utils;

namespace Pages
{
    public class SelectEmployeePage : PublicLibrary
    {
        
        public IWebElement EmpDropDown()
        {
            return Driver.FindElement(By.CssSelector("input[onclick*='selEmployeeId']"));
        }
        public IWebElement ListOfEmployees()
        {
            return Driver.FindElement(By.Id("selEmployeeId"));
        }
        public IWebElement SelectedEmployee()
        {
            return Driver.FindElement(By.Id("empid"));
        }
        public IWebElement EmployeeCode(string EmployeeName)
        {
            return Driver.FindElement(By.XPath(Constants.EmpOrProjCode + EmployeeName + Constants.ClosingBrace));
        }


        /// <summary>
        /// <para>  <strong> Method Name : </strong> GetEmployeeCode </para>
        /// Method to get Employee code for the given employee name.
        /// <list>
        /// <item> <strong>Throws :</strong> Exception </item>
        /// <item> <strong>Parameters :</strong></item>
        /// <item> <strong>string :</strong> Name of the employee</item>
        /// <item> <strong>Returns :</strong> string - employee code for the given employee name</item>
        /// </list>
        /// </summary> 
        public string GetEmployeeCode(string EmployeeName)
        {
            try
            {
                return GetAttributeValue(EmployeeCode(EmployeeName), Constants.Value);
            }catch(Exception e)
            {
                throw;
            }
        }
    }
}
