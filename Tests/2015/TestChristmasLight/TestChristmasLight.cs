#region Information

// AdventOfCode: TestChristmasLight
// Created: 2015-12-06
// Modified: 2015-12-06 6:00 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using libChristmasLight;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace TestChristmasLight
{
    [TestClass]
    public class TestChristmasLight
    {
        #region  Fields
        private readonly ChristmasLight _light = new ChristmasLight();
        #endregion

        [TestMethod]
        public void TestPosition()
        {
            Assert.AreEqual(0, _light.PosX);
            Assert.AreEqual(0, _light.PosY);
        }

        [TestMethod]
        public void TestCustomPosition()
        {
            ChristmasLight light = new ChristmasLight(5, 9);
            Assert.AreEqual(5, light.PosX);
            Assert.AreEqual(9, light.PosY);
        }

        [TestMethod]
        public void TestLightOff()
        {
            Assert.AreEqual(false, _light.Lit);
        }

        [TestMethod]
        public void TestLightOn()
        {
            Assert.AreNotEqual(true, _light.Lit);
            _light.TurnOn();
            Assert.AreEqual(true, _light.Lit);
        }

        [TestMethod]
        public void TestLitLightOff()
        {
            Assert.AreNotEqual(true, _light.Lit);
            _light.TurnOn();
            Assert.AreEqual(true, _light.Lit);
            _light.TurnOff();
            Assert.AreEqual(false, _light.Lit);
        }

        public void TestLightToggled()
        {
            Assert.AreEqual(false, _light.Lit);
            _light.TurnOn();
            Assert.AreEqual(true, _light.Lit);
            _light.Toggle();
            Assert.AreEqual(false, _light.Lit);
        }
    }
}