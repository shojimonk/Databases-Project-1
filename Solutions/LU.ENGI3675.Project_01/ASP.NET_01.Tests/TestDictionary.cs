// <copyright file="TestDictionary.cs" company="engi">
// The Test Dictionary for both the UITest and Unit Test.
// </copyright>
namespace ASP.NET_01.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class containing the dictionary to be used for all testing.
    /// </summary>
    public class TestDictionary
    {
        /// <summary>
        /// The dictionary used for both the UI Test and Unit Test.
        /// </summary>
        public static Dictionary<string, int> Data = new Dictionary<string, int>()
        {
            { "Red", 3 },
            { "Turquoise", 17 },
            { "Grey", 5 },
            { "Indigo", 6 }
        };
    }
}
