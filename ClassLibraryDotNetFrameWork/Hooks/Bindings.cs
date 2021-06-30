using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;
using Utils;

namespace ClassLibraryDotNetFrameWork.Hooks
{
    [Binding]
    public sealed class Bindings
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private static PublicLibrary lib = new PublicLibrary();
        private static ExtentHtmlReporter extentHtmlReporter = null;
        private static ExtentReports extentReports = null;
        private static ExtentTest feature = null;
        private static ExtentTest scenario = null;


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            lib.LoadJson();
            lib.ClearScreenshots();
            extentHtmlReporter = new ExtentHtmlReporter(Constants.projectPath +Constants.HtmlReport);
            extentReports = new ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);
        }

        [BeforeFeature]
        [Obsolete]
        public static void BeforeFeature()
        {
            feature = extentReports.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        [Obsolete]
        public static void BeforeScenario()
        {
            scenario = feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterStep]
        [Obsolete]
        public static void AfterStep()
        {
            string stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if(ScenarioContext.Current.TestError == null)
            {
                if (stepType.Equals("Given"))
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType.Equals("When"))
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType.Equals("Then"))
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else
            {
                if (stepType.Equals("Given"))
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(PublicLibrary.screenshotPath).Build());
                }
                else if (stepType.Equals("When"))
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(PublicLibrary.screenshotPath).Build());
                }
                else if (stepType.Equals("Then"))
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(PublicLibrary.screenshotPath).Build());
                }
            }
        }


        [AfterTestRun]
        public static void AfterTestRun()
        {
            extentReports.Flush();
        }
    }
}
