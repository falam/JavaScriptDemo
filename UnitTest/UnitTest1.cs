using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace UnitTest
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            // Create a new instance of the Firefox driver.

            // Notice that the remainder of the code relies on the interface, 
            // not the implementation.

            // Further note that other drivers (InternetExplorerDriver,
            // ChromeDriver, etc.) will require further configuration 
            // before this example will work. See the wiki pages for the
            // individual drivers at http://code.google.com/p/selenium/wiki
            // for further information.
            IWebDriver driver = new FirefoxDriver();

            //Notice navigation is slightly different than the Java version
            //This is because 'get' is a keyword in C#
            driver.Navigate().GoToUrl("http://localhost:59521/Demo/FormDemo");

            // Find the text input element by its name
            IWebElement query = driver.FindElement(By.Name("temp"));

            // Enter something to search for
            query.SendKeys("36");

            // Now submit the form. WebDriver will find the form for us from the element
            //query.Submit();

            IWebElement button = driver.FindElement(By.Id("convert"));
            button.Click();

            IWebElement tempResult = driver.FindElement(By.Id("tempResult"));
            string result = tempResult.Text;
            
            // Google's search is rendered dynamically with JavaScript.
            // Wait for the page to load, timeout after 10 seconds
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until((d) => { return d.Title.ToLower().StartsWith("cheese"); });

            // Should see: "Cheese - Google Search"
            System.Console.WriteLine("Page title is: " + driver.Title);

            //Close the browser
            driver.Quit();
            Assert.IsTrue(result == "96.8", "Expecting 96.8 as result");
        }
    }
}
