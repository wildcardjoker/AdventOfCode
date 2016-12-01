#region Information

// AdventOfCode: TestSanta
// Created: 2015-12-05
// Modified: 2015-12-05 2:01 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using libSanta;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace TestSanta
{
    [TestClass]
    public class TestDay5Part1
    {
        [TestMethod]
        public void ValidateNiceString()
        {
            Santa santa = new Santa();
            bool actual = santa.IsNiceString("ugknbfddgicrmopn");
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ValidateThreeVowels()
        {
            Santa santa = new Santa();
            bool actual = santa.IsNiceString("aaa");
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ValidateNaughtyNoDouble()
        {
            Santa santa = new Santa();
            bool actual = santa.IsNiceString("jchzalrnumimnmhp");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void ValidateNaughtyBadString()
        {
            Santa santa = new Santa();
            bool actual = santa.IsNiceString("haegwjzuvuyypxyu");
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void ValidateNaughtyOneVowel()
        {
            Santa santa = new Santa();
            bool actual = santa.IsNiceString("dvszwmarrgswjxmb");
            Assert.AreEqual(false, actual);
        }
    }
}