using System;
using System.IO;
using GameOfLife;
using System.Collections.Generic;
using NUnit.Framework;

namespace GameOfLifeTest
{
    [TestFixture]
    public class GameOfLifeTests
    {
        [SetUp]
        public void Setup()
        {
            Cell.Clear();
        }

        [Test]
        public void GoldenMasterTest()
        {
            string expected = File.ReadAllText("..\\..\\output.txt");

            var writer = new StringWriter();
            Console.SetOut(writer);
            
            Program.Main(null);

            Assert.AreEqual(expected, writer.ToString());
        }

        [Test]
        public void TestThatCellDiesWithOneNeighbour()
        {
            const int neighbours = 1;
            const bool expectedIsCellAlive = false;

            Cell cell = new Cell(1, 1);
            bool actualIsCellAlive = cell.IsCellAlive(neighbours);
            Assert.AreEqual(actualIsCellAlive, expectedIsCellAlive);
        }

        [Test]
        public void TestThatCellDiesWithFourNeighbours()
        {
            const int neighbours = 4;
            const bool expectedIsCellAlive = false;

            Cell cell = new Cell(1, 1);
            bool actualIsCellAlive = cell.IsCellAlive(neighbours);
            Assert.AreEqual(actualIsCellAlive, expectedIsCellAlive);
        }

        [Test]
        public void TestThatCellStaysAliveWithTwoNeighbours()
        {
            const int neighbours = 2;
            const bool expectedIsCellAlive = true;

            Cell cell = new Cell(1, 1);
            bool actualIsCellAlive = cell.IsCellAlive(neighbours);
            Assert.AreEqual(actualIsCellAlive, expectedIsCellAlive);
        }

        [Test]
        public void TestThatCellStaysAliveWithThreeNeighbours()
        {
            const int neighbours = 3;
            const bool expectedIsCellAlive = true;

            Cell cell = new Cell(1, 1);
            bool actualIsCellAlive = cell.IsCellAlive(neighbours);
            Assert.AreEqual(actualIsCellAlive, expectedIsCellAlive);
        }

        [Test]
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

        [Test]
        public void TestThatDeadCellsBecomeAlive()
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

            List<Cell> newCells = Cell.ListOfNewCells();
            
            Assert.AreEqual(6, newCells.Count);
        }
    }
}
