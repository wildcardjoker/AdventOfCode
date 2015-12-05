#region Information

// AdventOfCode: TestSanta
// Created: 2015-12-05
// Modified: 2015-12-05 9:48 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System.Collections.Generic;
using libSanta;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace TestSanta
{
    [TestClass]
    public class TestDay5Part2
    {
        [TestMethod]
        public void TestTwoMatchingCharacters()
        {
            List<string> inputs = new List<string> {"xyxy", "aabcdefgaa"};
            Santa santa = new Santa();
            foreach (string input in inputs)
            {
                Assert.AreEqual(true, santa.MatchTwoLetters(input), input);
            }
            Assert.AreNotEqual(true, santa.MatchTwoLetters("aaa"), "aaa");
        }

        [TestMethod]
        public void TestTwoRepeatingCharacterPattern()
        {
            Santa santa = new Santa();
            Assert.AreEqual(true, santa.MatchRepeatingCharacter("abcdefeghi"));
            Assert.AreEqual(true, santa.MatchRepeatingCharacter("aaa"));
        }

        [TestMethod]
        public void TestIsNiceString2()
        {
            Santa santa = new Santa();
            List<string> equalList = new List<string> {"qjhvhtzxzqqjkmpb", "xxyxx"};
            List<string> unequalList = new List<string> {"uurcxstgmygtbstg", "ieodomkazucvgmuy"};
            foreach (string s in equalList)
            {
                Assert.AreEqual(true, santa.IsNiceString2(s), s);
            }
            foreach (string s in unequalList)
            {
                Assert.AreNotEqual(true, santa.IsNiceString2(s), s);
            }
        }
    }
}