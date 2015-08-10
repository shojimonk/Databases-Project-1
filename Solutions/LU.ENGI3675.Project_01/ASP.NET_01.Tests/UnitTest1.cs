// <copyright file="UnitTest1.cs" company="engi">
// The Unit Test for the project.
// </copyright>
namespace APP.NET_01.Tests
{
    using System;
    using System.Collections.Generic;
    using ASP.NET_01.Tests;
    using LU.ENGI3675.Databases1;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit Test class for our database.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// The test method for the Unit Test.  Compares the values from our dictionary against the results from the Database.
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            List<Paints> table = DataIn.Import();
            int temp;

            foreach (Paints paint in table)
            {
                Assert.IsTrue(TestDictionary.Data.TryGetValue(paint.Colour, out temp), "Color {0} failed.", paint.Colour);
                Assert.IsTrue(paint.Amount == temp, "This is not true.", null);
            }
        }
    }
}
