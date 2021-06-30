using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Utils;

namespace Pages
{
    public class SelectProjectPage : PublicLibrary
    {
        public IWebElement ListOfProjects()
        {
            return Driver.FindElement(By.Id("selProjectId"));
        }

        public IWebElement ProjectDropDown()
        {
            return Driver.FindElement(By.CssSelector("input[onclick*='selProjectId']"));
        }
        public IWebElement SelectedProject()
        {
            return Driver.FindElement(By.Id("prjid"));
        }
        public IWebElement ProjectCode(string ProjectName)
        {
            return Driver.FindElement(By.XPath(Constants.EmpOrProjCode + ProjectName + Constants.ClosingBrace));
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> GetProjectCode </para>
        /// Method to get Project code for the given project name
        /// <list>
        /// <item> <strong>Throws :</strong> Exception </item>
        /// <item> <strong>Parameters :</strong></item>
        /// <item> <strong>string :</strong> Name of the project</item>
        /// <item> <strong>Returns :</strong> string - Project code for the given project name</item>
        /// </list>
        /// </summary>
        public string GetProjectCode(string ProjectName)
        {
            return GetAttributeValue(ProjectCode(ProjectName), Constants.Value);
        }


    }
}
