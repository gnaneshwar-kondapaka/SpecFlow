using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Imaging;
using OpenQA.Selenium.Interactions;
using System.Collections;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Nancy.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

namespace Utils
{
    public class PublicLibrary
    {
        public static IWebDriver Driver = null;
        public static int FluentWaitTime = Constants.FluentWait;
        public static JObject testData = null;
        public static string screenshotPath = null;

        /// <summary>
        /// <para>  <strong> Method Name : </strong> LaunchBrowser </para>
        ///  Method to launch the specified browser
        /// <list>
        /// <item> <strong>Throws :</strong>Exception</item>
        /// <item> <strong> Parameters :</strong> </item>
        /// <item> <strong>string :</strong> Name of the browser to be launched</item>
        /// </list>
        /// </summary>
        public void LaunchBrowser(string browser)
        {
            try
            {
                if (browser.Equals("chrome"))
                {
                    Driver = new ChromeDriver();
                }
                else if (browser.Equals("firefox"))
                {
                    Driver = new FirefoxDriver();
                }
                else
                {
                    Assert.True(false, "No Browser with specifed name : " + browser);
                }
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.ImplicityWait);
                Driver.Manage().Window.Maximize();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                browser = null;
            }
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> NavigateToQualityPoint </para>
        /// Method to Navigate to Quality Point on specified environment
        /// <list>
        /// <item> <strong>Throws :</strong>Exception</item>
        /// <item> <strong> Parameters :</strong> </item>
        /// <item> <strong>string :</strong> environment</item>
        /// </list>
        /// </summary>
        public void NavigateToQualityPoint(string environment)
        {
            try
            {
                if (environment.Equals("QA"))
                {
                    Driver.Navigate().GoToUrl(Constants.QualityPointURL_QA);
                }else
                {
                    Assert.False(true, "Environment : "+ environment+" not found");
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                environment = null;
            }
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> ClickElement </para>
        /// Method to perform click operation on the specified element
        /// <list>
        /// <item> <strong>Throws :</strong>Exception</item>
        /// <item> <strong> Parameters :</strong> </item>
        /// <item> <strong>IWebElement :</strong> WebElement</item>
        /// </list>
        /// </summary>     
        public void ClickElement(IWebElement WebElement)
        {
            try
            {
                Assert.True(IsElementActive(WebElement), "Element is no clickable, Element : "+WebElement);
                WebElement.Click();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                WebElement = null;
            }
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> ClickElement </para>
        /// Method to perform click operation on the specified element
        /// <list>
        /// <item> <strong>Throws :</strong>Exception</item>
        /// <item> <strong> Parameters :</strong> </item>
        /// <item> <strong>IWebElement :</strong> WebElement</item>
        /// </list>
        /// </summary>     
        public void ClickElement(IWebElement WebElement, string Message)
        {
            try
            {
                Assert.True(IsElementActive(WebElement), Message+" Is not clickable");
                WebElement.Click();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                WebElement = null;
                Message = null;
            }

        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> ClickUsingActions </para>
        /// Method to perform click operation using Actions Class
        /// <list>
        /// <item> <strong>Throws :</strong>Exception</item>
        /// <item> <strong> Parameters :</strong> </item>
        /// <item> <strong> WebElement : </strong> Element to be clickable </item>
        /// </list>
        /// </summary>
        public void ClickUsingActions(IWebElement WebElement)
        {
            try
            {

                Assert.True(IsElementActive(WebElement), "Element Not Clickable : "+WebElement);
                Actions actions = new Actions(Driver);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                WebElement = null;
            }
        }

       
        /// <summary>
        /// <para> Method Name : <strong> SetValue </strong> </para>
        /// Method to set value in the input field
        /// <list> 
        /// <item> <strong>Throws :</strong>Exception</item>
        /// <item> <strong> Parameters :</strong> </item>
        /// <item> <strong> WebElement : </strong> WebElement of the input field </item>
        /// </list>
        /// </summary>
        public void SetValue(IWebElement WebElement, String Value)
        {
            try
            {
                Assert.True(IsElementActive(WebElement), "Element is Disabled, Element : "+WebElement);
                WebElement.Clear();
                WebElement.SendKeys(Value);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                WebElement = null;
                Value = null;
            }
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> GetTitle </para>
        /// Method to get current page title
        /// <list>
        /// <item> <strong>Throws :</strong>Exception</item>
        /// <item>  <strong> Returns : </strong> string : Title of the webpage  </item>
        /// </list>
        /// </summary> 
        public string GetTitle()
        {
            try
            {
                return Driver.Title;
            }
            catch (Exception e)
            {
                throw;
            } 
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> QuitBrowser </para>
        ///Method to Quit the browser 
        /// <list>
        /// <item> <strong>Throws :</strong>Exception</item>
        /// </list>
        /// </summary>
        public void QuitBrowser()
        {
            try
            {
                if(Driver != null)
                  Driver.Quit();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> AcceptAlert </para>
        /// Method to Acceept alert
        /// <list>
        /// <item> <strong>Throws :</strong>Exception</item>
        /// </list>
        /// </summary> 
        public void AcceptAlert()
        {
            try
            {
                Driver.SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> CaptureScreenShot </para>
        /// Method to Capture Screenshots
        /// <list>
        /// <item> <strong>Throws :</strong>Exception</item>
        /// </list>
        /// </summary>
        public void CaptureScreenShot()
        {
            try
            {
                if(Driver!=null)
                {
                    String dateTime = DateTime.Now.ToString();
                    String dTime = dateTime.Replace("/", "_").Replace(" ", "_").Replace(":", "_");
                    String target = Constants.projectPath + Constants.Screenshots;
                    screenshotPath = target + "\\Image_" + dTime + ".png";
                    if (!Directory.Exists(target))
                    {
                        Directory.CreateDirectory(target);
                    }
                    ITakesScreenshot takesScreenshot = Driver as ITakesScreenshot;
                    Screenshot screenshot = takesScreenshot.GetScreenshot();
                    screenshot.SaveAsFile(screenshotPath);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// <para>  Method Name : <strong> ClearScreenshots </strong> </para>
        ///  Method to Clear previous screenshots
        /// <list>
        /// <item> <strong> Throws : </strong> Exception </item>
        /// </list>
        ///  </summary>
        public void ClearScreenshots()
        {
            try
            {
                string target = Constants.projectPath + Constants.Screenshots;
                Array.ForEach(Directory.GetFiles(@target), File.Delete);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// <para>  Method Name : <Strong> ReportException </Strong> </para>
        ///  Method to report Exception
        /// <list>
        /// <item> <strong>Message</strong> Message to be reported</item>
        /// </list>
        ///  </summary>
        public void ReportException(string Message)
        {
            CaptureScreenShot();
            QuitBrowser();
            Assert.IsTrue(false, Message);
        }

        /// <summary>
        /// <para>  Method Name : <strong> ReportException </strong> </para>
        ///  Method to report Exception
        /// <list>
        /// <item> <strong>Exception : </strong> Exception to be reported</item>
        /// </list>
        ///  </summary>
        public void ReportException(Exception e)
        {
            CaptureScreenShot();
            QuitBrowser();
            Assert.IsTrue(false, e.ToString());
        }


        /// <summary>
        /// <para>  Method Name : <strong> VerifyPageTitle </strong> </para>
        ///  Method to verify Page Title
        /// <list>
        /// <item> <strong>string :</strong> ExpectedTitle</item>
        /// <item> <strong>Throws :</strong> Exception </item>
        /// </list>
        ///  </summary>
        public void VerifyPageTitle(String ExpectedTitle)
        {
            try
            {
                string PageTitle = Driver.Title;
                Assert.AreEqual(ExpectedTitle, PageTitle);
            }catch(Exception e)
            {
                throw;
            }
            finally
            {
                ExpectedTitle = null;
            }
        }

        /// <summary>
        /// <para>  Method Name : <strong> Escape </strong> </para>
        ///  Method to Press Escape Key in Keyboard
        /// <list>
        /// <item> <strong>Throws :</strong> Exception </item>
        /// </list>
        ///  </summary>
        public void Escape()
        {
            try
            {
                Actions actions = new Actions(Driver);
                actions.SendKeys(Keys.Escape);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// <para>  Method Name : <strong> WaitForElementToBeClickable </strong> </para>
        ///  Method to wait until element is clickable
        /// <list>
        /// <item> <strong>IWebElement :</strong> WebElement</item>
        /// <item> <strong>int :</strong> TimeInSecs </item>
        /// </list>
        ///  </summary>
        [Obsolete]
        public void WaitForElementToBeClickable(IWebElement WebElement, int TimeInSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeInSecs));
                wait.Until(ExpectedConditions.ElementToBeClickable(WebElement));
            }
            catch (Exception e)
            {
                throw;
            }finally
            {
                WebElement = null;
                TimeInSecs = 0;
            }
        }

        /// <summary>
        /// <para>  Method Name : <strong> Delay </strong> </para>
        ///  Method for applying Time Delay
        /// <list>
        /// <item> <strong>int :</strong> Delay time in Milli seconds </item>
        /// </list>
        /// </summary>
        public void Delay(int TimeInMilliSecs)
        {
            Thread.Sleep(TimeInMilliSecs);
        }


        /// <summary>
        /// <para>  <strong> Method Name : </strong> GetText </para>
        ///   Method to get text of the given element
        /// <list>
        /// <item> <strong>Throws :</strong>Exception</item>
        /// <item> <strong> Parameters :</strong> </item>
        /// <item> <strong>IWebElement :</strong> WebElement  </item>
        ///  <item> <strong>Returns :</strong> string : Text of the given element</item>
        /// </list>
        /// </summary>
        public string GetText(IWebElement WebElement)
        {
            try
            {
                return WebElement.Text;
            } 
            catch (Exception e)
            {
                throw;
            }finally
            {
                WebElement = null;
            }
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> SwitchToWindow </para>
        ///  Method to switch window focus from current window to specified window
        /// <list>
        /// <item> <strong>Throws :</strong>Exception</item>
        /// <item> <strong> Parameters :</strong> </item>
        /// <item> <strong>int :</strong> Position of the window to be switched</item>
        /// </list>
        /// </summary>
        public void SwitchToWindow(int WindowPosition)
        { 
            try
            {
                IList<string> WindowHandles = new List<string>(Driver.WindowHandles);
                if (WindowHandles.Count() > 1)
                    Driver.SwitchTo().Window(WindowHandles[WindowPosition - 1]);
                else
                    Assert.True(false, "Unable to switch window focus as no window with specified details");
            } catch (Exception e)
            {
                throw;
            }
        }


        /// <summary>
        /// <para>  <strong> Method Name : </strong> GetAttributeValue </para>
        ///  Method to get attribute value for given WebElement
        /// <list>
        /// <item> <strong>Throws :</strong>Exception</item>
        /// <item> <strong> Parameters :</strong> </item>
        /// <item> <strong>IWebElement :</strong> WebElement</item>
        /// <item> <strong>string :</strong> Attribute value</item>
        /// </list>
        /// </summary>
        public string GetAttributeValue(IWebElement WebElement, string Attribute)
        {
            try
            {
                return WebElement.GetAttribute(Attribute);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                WebElement = null;
                Attribute = null;
            }
        }


        /// <summary>
        /// <para>  <strong> Method Name : </strong> GetElement </para>
        ///  Method to Get WebElement from the WebPage
        /// <list>
        /// <item> <strong>Throws :</strong>Exception</item>
        /// <item> <strong> Parameters :</strong> </item>
        /// <item> <strong>By :</strong> By Locator of the WebElement</item>
        /// <item> <strong>int :</strong> Wait Time in Secs, Ex : 10, 20.</item>
        /// </list>
        /// </summary>
        public IWebElement GetElement(By ByLocator, int TimeInSecs)
        {
            try
            {
                return Driver.FindElement(ByLocator);
            } catch (Exception e)
            {
                throw;
            }finally
            {
                ByLocator = null;
            }
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> FluentWait </para>
        /// Method for FluentWait, Ignores NoSuchElement Exception and StaleElement Reference Exception.
        /// <list>
        /// <item> <strong>Throws :</strong>Exception</item>
        /// <item> <strong> Parameters :</strong> </item>
        /// <item> <strong>By :</strong> By Locator of the WebElement</item>
        /// <item> <strong>int :</strong> Fluent wait in Secs, Ex : 10, 20.</item>
        /// </list>
        /// </summary>
        public void FluentWait(By ByLocator, int TimeInSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeInSecs));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                wait.PollingInterval = TimeSpan.FromMilliseconds(100);
                wait.Until(x => x.FindElement(ByLocator));
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                ByLocator = null;
            }
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> IsElementActive </para>
        ///  Method to Verify element is displayed on the webpage and is Enabled
        /// <list>
        /// <item> <strong>Throws :</strong>Exception</item>
        /// <item> <strong> Parameters :</strong> </item>
        /// <item> <strong>IWebElement :</strong> WebElement</item>
        /// </list>
        /// </summary>
        public bool IsElementActive(IWebElement WebElement)
        {
            try
            { 
                if (!WebElement.Displayed)
                    return false;
                if (!WebElement.Enabled)
                    return false;
                else
                    return true;
            } catch (Exception e)
            {
                throw;
            }
            finally
            {
                WebElement = null;
            }
        }

        /// <summary>
        /// <para>  <strong> Method Name : </strong> SelectByText </para>
        ///  Method to select specified value from the list of Values.
        /// <list>
        /// <item> <strong>Throws : </strong>Exception</item>
        /// <item> <strong> Parameters :</strong> </item>
        /// <item> <strong>IWebElement :</strong> WebElement</item>
        /// <item> <strong>string :</strong> Value to be selected from the list</item>
        /// </list>
        /// </summary>
        public void SelectByText(IWebElement WebElement, string Value)
        {
            try
            {
                Assert.True(IsElementActive(WebElement), Value+" Is no clickable");
                SelectElement List = new SelectElement(WebElement);
                List.SelectByText(Value);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                WebElement = null;
                Value = null;
            }
        }


        /// <summary>
        /// <para>  <strong> Method Name : </strong> LoadJson </para>
        ///  Method to load input data from JSON File to object
        /// <list>
        /// <item> <strong>Throws : </strong>Exception</item>
        /// </list>
        /// </summary>
        public void LoadJson()
        {
            try
            { 
                testData = JObject.Parse(File.ReadAllText(Constants.projectPath + Constants.TestData));
            }catch(Exception e)
            {
                throw;
            }
        }
      
    } 
}
