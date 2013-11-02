using System;
using System.IO;
using System.Linq;
using GameOfLife;
using System.Collections.Generic;
using NUnit.Framework;

namespace GameOfLifeTest
{
    [TestFixture]
    public class GameOfLifeTests
    {
        #region Globals

        private World world;

        #endregion

        #region Setup

        [SetUp]
        public void Setup()
        {
            world = new World(new WorldPrinter());
        }

        #endregion

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
            world.Add(new Cell(1, 1));
            world.Add(new Cell(1, 2));
            world.Add(new Cell(1, 3));
            world.Add(new Cell(2, 1));
            world.Add(new Cell(2, 3));
            world.Add(new Cell(3, 1));
            world.Add(new Cell(3, 2));
            world.Add(new Cell(3, 3));
            world.Add(new Cell(2, 0));
            world.Add(new Cell(2, 2));
            world.Add(new Cell(2, 4));
            world.Add(new Cell(3, 0));
            world.Add(new Cell(3, 4));
            world.Add(new Cell(4, 1));
            world.Add(new Cell(4, 2));
            world.Add(new Cell(4, 3));

            int actualNumberOfNeighbours = world.GetNumberOfNeighbours(cell);
            Assert.AreEqual(8, actualNumberOfNeighbours);
        }

        [Test]
        public void TestThatDeadCellsBecomeAlive()
        {
            world.Add(new Cell(1, 1));
            world.Add(new Cell(1, 2));
            world.Add(new Cell(1, 3));
            world.Add(new Cell(2, 1));
            world.Add(new Cell(2, 3));
            world.Add(new Cell(3, 1));
            world.Add(new Cell(3, 2));
            world.Add(new Cell(3, 3));
            world.Add(new Cell(2, 0));
            world.Add(new Cell(2, 2));
            world.Add(new Cell(2, 4));
            world.Add(new Cell(3, 0));
            world.Add(new Cell(3, 4));
            world.Add(new Cell(4, 1));
            world.Add(new Cell(4, 2));
            world.Add(new Cell(4, 3));

            List<ICell> newCells = world.ListOfNewCells().ToList();
            
            Assert.AreEqual(6, newCells.Count);
        }
    }
}
