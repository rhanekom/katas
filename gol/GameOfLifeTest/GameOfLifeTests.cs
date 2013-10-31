using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GameOfLifeTest
{
    [TestClass]
    public class GameOfLifeTests
    {
        [TestMethod]
        public void TestThatCellDiesWithOneNeighbour()
        {
            const int neighbours = 1;
            const bool expectedIsCellAlive = false;

            Cell cell = new Cell(1, 1);
            bool actualIsCellAlive = cell.IsCellAlive(neighbours);
            Assert.AreEqual(actualIsCellAlive, expectedIsCellAlive);
        }

        [TestMethod]
        public void TestThatCellDiesWithFourNeighbours()
        {
            const int neighbours = 4;
            const bool expectedIsCellAlive = false;

            Cell cell = new Cell(1, 1);
            bool actualIsCellAlive = cell.IsCellAlive(neighbours);
            Assert.AreEqual(actualIsCellAlive, expectedIsCellAlive);
        }

        [TestMethod]
        public void TestThatCellStaysAliveWithTwoNeighbours()
        {
            const int neighbours = 2;
            const bool expectedIsCellAlive = true;

            Cell cell = new Cell(1, 1);
            bool actualIsCellAlive = cell.IsCellAlive(neighbours);
            Assert.AreEqual(actualIsCellAlive, expectedIsCellAlive);
        }

        [TestMethod]
        public void TestThatCellStaysAliveWithThreeNeighbours()
        {
            const int neighbours = 3;
            const bool expectedIsCellAlive = true;

            Cell cell = new Cell(1, 1);
            bool actualIsCellAlive = cell.IsCellAlive(neighbours);
            Assert.AreEqual(actualIsCellAlive, expectedIsCellAlive);
        }

        [TestMethod]
        public void TestThatCellKnowsItsNeighbours()
        {
            Cell cell = new Cell(3, 2);
            Cell.Add(new Cell(1, 1));
            Cell.Add(new Cell(1, 2));
            Cell.Add(new Cell(1, 3));
            Cell.Add(new Cell(2, 1));
            Cell.Add(new Cell(2, 3));
            Cell.Add(new Cell(3, 1));
            Cell.Add(new Cell(3, 2));
            Cell.Add(new Cell(3, 3));
            Cell.Add(new Cell(2, 0));
            Cell.Add(new Cell(2, 2));
            Cell.Add(new Cell(2, 4));
            Cell.Add(new Cell(3, 0));
            Cell.Add(new Cell(3, 4));
            Cell.Add(new Cell(4, 1));
            Cell.Add(new Cell(4, 2));
            Cell.Add(new Cell(4, 3));

            int actualNumberOfNeighbours = cell.DetermineNumberOfNeighbours();
            Assert.AreEqual(8, actualNumberOfNeighbours);
        }

        [TestMethod]
        public void TestThatDeadCellsBecomeAlive()
        {
            Cell.Add(new Cell(1, 1));
            Cell.Add(new Cell(1, 2));
            Cell.Add(new Cell(1, 3));

            List<Cell> newCells = Cell.ListOfNewCells();
            
            Assert.AreEqual(6, newCells.Count);
        }
    }
}
