using System;
using System.IO;
using System.Linq;
using GameOfLife;
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
            
            Program.Main();

            Assert.AreEqual(expected, writer.ToString());
        }

        [Test]
        public void TestThatCellDiesWithOneNeighbour()
        {
            const int neighbours = 1;
            const bool expectedIsCellAlive = false;

            bool actualIsCellAlive = World.IsCellAlive(true, neighbours);
            Assert.AreEqual(actualIsCellAlive, expectedIsCellAlive);
        }

        [Test]
        public void TestThatCellDiesWithFourNeighbours()
        {
            const int neighbours = 4;
            const bool expectedIsCellAlive = false;

            bool actualIsCellAlive = World.IsCellAlive(true, neighbours);
            Assert.AreEqual(actualIsCellAlive, expectedIsCellAlive);
        }

        [Test]
        public void TestThatCellStaysAliveWithTwoNeighbours()
        {
            const int neighbours = 2;
            const bool expectedIsCellAlive = true;

            bool actualIsCellAlive = World.IsCellAlive(true, neighbours);
            Assert.AreEqual(actualIsCellAlive, expectedIsCellAlive);
        }

        [Test]
        public void TestThatCellStaysAliveWithThreeNeighbours()
        {
            const int neighbours = 3;
            const bool expectedIsCellAlive = true;

            bool actualIsCellAlive = World.IsCellAlive(true, neighbours);
            Assert.AreEqual(actualIsCellAlive, expectedIsCellAlive);
        }

        [Test]
        public void TestThatCellKnowsItsNeighbours()
        {
            world[1, 1].Live();
            world[1, 2].Live();
            world[1, 3].Live();
            world[2, 1].Live();
            world[2, 3].Live();
            world[3, 1].Live();
            world[3, 2].Live();
            world[3, 3].Live();
            world[2, 0].Live();
            world[2, 2].Live();
            world[2, 4].Live();
            world[3, 0].Live();
            world[3, 4].Live();
            world[4, 1].Live();
            world[4, 2].Live();
            world[4, 3].Live();

            int actualNumberOfNeighbours = world.GetNumberOfNeighbours(3, 2);
            Assert.AreEqual(8, actualNumberOfNeighbours);
        }

        [Test]
        public void OneCellDies()
        {
            world[1, 1].Live();
            var nextWorld = world.NextIteration();
            Assert.AreEqual(0, nextWorld.GetLiveCells().Count());
        }

        [Test]
        public void TwoCellsLive()
        {
            world[1, 1].Live();
            world[1, 2].Live();
            var nextWorld = world.NextIteration();
            Assert.AreEqual(0, nextWorld.GetLiveCells().Count());
        }

        [Test]
        public void ThreeCellsLive()
        {
            world[1, 1].Live();
            world[1, 2].Live();
            world[1, 3].Live();
            var nextWorld = world.NextIteration();
            Assert.AreEqual(3, nextWorld.GetLiveCells().Count());
        }


        [Test]
        public void TestThatDeadCellsBecomeAlive()
        {
            world[1, 1].Live();
            world[1, 2].Live();
            world[1, 3].Live();
            world[2, 1].Live();
            world[2, 3].Live();
            world[3, 1].Live();
            world[3, 2].Live();
            world[3, 3].Live();
            world[2, 0].Live();
            world[2, 2].Live();
            world[2, 4].Live();
            world[3, 0].Live();
            world[3, 4].Live();
            world[4, 1].Live();
            world[4, 2].Live();
            world[4, 3].Live();

            var newWorld = world.NextIteration();
            
            Assert.AreEqual(6, newWorld.GetLiveCells().Count());
        }
    }
}
