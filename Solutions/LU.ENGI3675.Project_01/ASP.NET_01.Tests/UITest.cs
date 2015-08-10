// <copyright file="UITest.cs" company="engi">
// UI Test for the project.
// </copyright>
namespace ASP.NET_01.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APP.NET_01.Tests;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;

    /// <summary>
    /// UI Testing class.
    /// Checks the table results for IE, Chrome, and Firefox.
    /// </summary>
    [TestClass]
    public class UITest
    {
        /// <summary>
        /// Common UI testing component for each of the browsers to be tested.
        /// Checks each of the table rows, and compares the results against the dictionary. 
        /// </summary>
        /// <param name="driver">
        /// Current browser test driver we're running the UI test on.
        /// </param>
        public static void RunUITest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://localhost/ASP.NET_01/Default.aspx");

            ReadOnlyCollection<IWebElement> rows = driver.FindElements(By.TagName("tr"));

            char[] splitter = { ' ' };
            string[] cells;
            
            int temp;

            // Cycle threw all the rows of our table.
            foreach (IWebElement iwe in rows)
            {
                cells = iwe.Text.Split(splitter);

                // Make sure we're not dealing with the column headings
                if (cells[0] == "Colour")
                { 
                    continue; 
                }

                // Test current row against dictionary
                Assert.IsTrue(TestDictionary.Data.TryGetValue(cells[0], out temp), "Cannot find color {0}", cells[0]);
                Assert.IsTrue(int.Parse(cells[1]) == temp, "Amount of liters is incorrect, found {0}, expected {1}", int.Parse(cells[1]), temp);
            }
        }

        /// <summary>
        /// Method to start the Firefox test
        /// </summary>
        [TestMethod]
        public void FireFoxTest()
        {
            FirefoxDriver fox = new FirefoxDriver();
            RunUITest(fox);
        }

        /// <summary>
        /// Method to start the Chrome test
        /// </summary>
        [TestMethod]
        public void ChromeTest()
        {
            ChromeDriver chrome = new ChromeDriver();
            RunUITest(chrome);
        }

        /// <summary>
        /// Method to start the Internet Explorer test
        /// </summary>
        [TestMethod]
        public void IETest()
        {
            InternetExplorerDriver ie = new InternetExplorerDriver();
            RunUITest(ie);
        }
    }
}