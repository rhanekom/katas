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
            World.Clear();
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

            bool actualIsCellAlive = World.IsCellAlive(neighbours);
            Assert.AreEqual(actualIsCellAlive, expectedIsCellAlive);
        }

        [Test]
        public void TestThatCellDiesWithFourNeighbours()
        {
            const int neighbours = 4;
            const bool expectedIsCellAlive = false;

            bool actualIsCellAlive = World.IsCellAlive(neighbours);
            Assert.AreEqual(actualIsCellAlive, expectedIsCellAlive);
        }

        [Test]
        public void TestThatCellStaysAliveWithTwoNeighbours()
        {
            const int neighbours = 2;
            const bool expectedIsCellAlive = true;

            bool actualIsCellAlive = World.IsCellAlive(neighbours);
            Assert.AreEqual(actualIsCellAlive, expectedIsCellAlive);
        }

        [Test]
        public void TestThatCellStaysAliveWithThreeNeighbours()
        {
            const int neighbours = 3;
            const bool expectedIsCellAlive = true;

            bool actualIsCellAlive = World.IsCellAlive(neighbours);
            Assert.AreEqual(actualIsCellAlive, expectedIsCellAlive);
        }

        [Test]
        public void TestThatCellKnowsItsNeighbours()
        {
            var cell = new Cell(3, 2);
            World.Add(new Cell(1, 1));
            World.Add(new Cell(1, 2));
            World.Add(new Cell(1, 3));
            World.Add(new Cell(2, 1));
            World.Add(new Cell(2, 3));
            World.Add(new Cell(3, 1));
            World.Add(new Cell(3, 2));
            World.Add(new Cell(3, 3));
            World.Add(new Cell(2, 0));
            World.Add(new Cell(2, 2));
            World.Add(new Cell(2, 4));
            World.Add(new Cell(3, 0));
            World.Add(new Cell(3, 4));
            World.Add(new Cell(4, 1));
            World.Add(new Cell(4, 2));
            World.Add(new Cell(4, 3));

            int actualNumberOfNeighbours = World.GetNumberOfNeighbours(cell);
            Assert.AreEqual(8, actualNumberOfNeighbours);
        }

        [Test]
        public void TestThatDeadCellsBecomeAlive()
        {
            World.Add(new Cell(1, 1));
            World.Add(new Cell(1, 2));
            World.Add(new Cell(1, 3));
            World.Add(new Cell(2, 1));
            World.Add(new Cell(2, 3));
            World.Add(new Cell(3, 1));
            World.Add(new Cell(3, 2));
            World.Add(new Cell(3, 3));
            World.Add(new Cell(2, 0));
            World.Add(new Cell(2, 2));
            World.Add(new Cell(2, 4));
            World.Add(new Cell(3, 0));
            World.Add(new Cell(3, 4));
            World.Add(new Cell(4, 1));
            World.Add(new Cell(4, 2));
            World.Add(new Cell(4, 3));

            List<Cell> newCells = World.ListOfNewCells();
            
            Assert.AreEqual(6, newCells.Count);
        }
    }
}
