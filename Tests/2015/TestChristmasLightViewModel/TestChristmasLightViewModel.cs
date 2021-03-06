﻿#region Information

// AdventOfCode: TestChristmasLightViewModel
// Created: 2015-12-06
// Modified: 2015-12-07 6:27 AM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.AreEqual(columns * rows, grid.Lights.Count, "Grid cell count do not match.");
        }

        [TestMethod]
        public void TestTurnOnAllLights()
        {
            ChristmasLightsGrid grid = new ChristmasLightsGrid();
            int columns = 1000;
            int rows = columns;
            List<string> instructionsList = new List<string> {"turn on 0,0 through 999,999"};
            grid.Columns = columns;
            grid.Rows = rows;
            grid.Instructions = instructionsList;
            grid.GenerateGridCommand.Execute(null);
            grid.FollowInstructionsCommand.Execute(null);
            int actual = grid.Lights.Count(x => x.Lit);
            Assert.AreEqual(columns * rows, actual, $"Some lights failed to turn on. Total lights on: {actual}.");
        }

        [TestMethod]
        public void TestTurnOffAllLights()
        {
            ChristmasLightsGrid grid = new ChristmasLightsGrid();
            int columns = 1000;
            int rows = columns;
            List<string> instructionsList = new List<string>
                                            {
                                                "turn on 0,0 through 999,999",
                                                "turn off 0,0 through 999,999"
                                            };
            grid.Columns = columns;
            grid.Rows = rows;
            grid.Instructions = instructionsList;
            grid.GenerateGridCommand.Execute(null);
            grid.FollowInstructionsCommand.Execute(null);
            int actual = grid.Lights.Count(x => x.Lit);
            Assert.AreEqual(0, actual, $"Some lights failed to turn off. Total lights on: {actual}.");
        }

        [TestMethod]
        public void TestToggleLights()
        {
            ChristmasLightsGrid grid = new ChristmasLightsGrid();
            int columns = 1000;
            int rows = columns;
            List<string> instructionsList = new List<string>
                                            {
                                                "turn on 0,0 through 999,999",
                                                "toggle 0,0 through 499,499"
                                            };
            grid.Columns = columns;
            grid.Rows = rows;
            grid.Instructions = instructionsList;
            grid.GenerateGridCommand.Execute(null);
            grid.FollowInstructionsCommand.Execute(null);
            int actual = grid.Lights.Count(x => x.Lit);
            Assert.AreEqual(750000, actual, $"Some lights failed to toggle. Total lights on: {actual}.");
        }

        [TestMethod]
        public void TestToggle1000Lights()
        {
            ChristmasLightsGrid grid = new ChristmasLightsGrid();
            int columns = 1000;
            int rows = columns;
            List<string> instructionsList = new List<string> { "toggle 0,0 through 999,0" };
            grid.Columns = columns;
            grid.Rows = rows;
            grid.Instructions = instructionsList;
            grid.GenerateGridCommand.Execute(null);
            grid.FollowInstructionsCommand.Execute(null);
            int actual = grid.Lights.Count(x => x.Lit);
            Assert.AreEqual(1000, actual, $"Some lights failed to turn on. Total lights on: {actual}.");
        }

    }
}