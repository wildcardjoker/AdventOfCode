#region Information

// AdventOfCode: TestChristmasLightViewModel
// Created: 2015-12-06
// Modified: 2015-12-06 9:11 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System;
using libChristmasLightsGrid.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace TestChristmasLightViewModel
{
    [TestClass]
    public class TestChristmasLightViewModel
    {
        [TestMethod]
        public void TestSetGrid()
        {
            ChristmasLightsGrid grid = new ChristmasLightsGrid();
            int expectedRows = 10;
            int expectedColumns = 20;
            Assert.AreEqual(0, grid.Columns);
            Assert.AreEqual(0, grid.Rows);
            grid.Columns = expectedColumns;
            grid.Rows = expectedRows;
            Assert.AreEqual(expectedColumns, grid.Columns, "Column test failed");
            Assert.AreEqual(expectedRows, grid.Rows, "Row test failed");
        }

        [TestMethod]
        public void TestSetGridDimensions()
        {
            ChristmasLightsGrid grid = new ChristmasLightsGrid();
            int columns = 10;
            int rows = 10;
            grid.Columns = columns;
            grid.Rows = rows;
            Assert.AreEqual(columns, grid.Columns, "Columns do not match");
            Assert.AreEqual(rows, grid.Rows, "Rows do not match");
            try
            {
                columns = -1;
                rows = -1;
                grid.Columns = columns;
                grid.Rows = rows;
                Assert.AreEqual(columns, grid.Columns);
                Assert.AreEqual(rows, grid.Rows);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, ChristmasLightsGrid.ArgumentOutOfRangeMessage);
            }
        }

        [TestMethod]
        public void TestCreateGrid()
        {
            ChristmasLightsGrid grid = new ChristmasLightsGrid();
            int columns = 10;
            int rows = 10;
            grid.Columns = columns;
            grid.Rows = rows;
            grid.GenerateGridCommand.Execute(null);
            Assert.AreEqual(columns*rows, grid.Lights.Count, "Grid cell count do not match.");

        }
    }
}