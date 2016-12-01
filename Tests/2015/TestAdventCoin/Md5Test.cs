#region Information

// AdventOfCode: TestAdventCoin
// Created: 2015-12-04
// Modified: 2015-12-04 11:01 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using libAdventCoin;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace TestAdventCoin
{
    [TestClass]
    public class Md5Test
    {
        [TestMethod]
        public void Validate_abcdef609043()
        {
            AdventCoin coin = new AdventCoin("abcdef", 609043);
            const string expected = "000001DBBFA3A5C83A2D506429C7B00E";
            string actual = coin.Md5Hash;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Validate_pqrstuv1048970()
        {
            AdventCoin coin = new AdventCoin("pqrstuv", 1048970);
            const string expected = "000006136EF2FF3B291C85725F17325C";
            string actual = coin.Md5Hash;
            Assert.AreEqual(actual, expected);
        }
    }
}