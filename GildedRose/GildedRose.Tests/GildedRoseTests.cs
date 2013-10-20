using System;
using System.Collections.Generic;
using Moq;

namespace GildedRose.Tests
{
    using System.IO;
    using NUnit.Framework;

    [TestFixture]
    public class GildedRoseTests
    {
        #region Globals

        private Mock<IGildedRoseWebService> webService;
        private GildedRose subject;

        #endregion

        #region Setup

        [SetUp]
        public void Setup()
        {
            webService = new Mock<IGildedRoseWebService>();
            subject = new GildedRose(webService.Object);
        }

        #endregion


        #region Tests

        [Test]
        [Ignore("Test coverage with new tests")]
        public void GoldenMasterTest()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            
            Program.Main(null);

            Assert.That(writer.ToString(), Is.EqualTo(File.ReadAllText("output.txt")));
        }

        [Test]
        public void SellIn_And_Quality_Decreases()
        {
            var item = new Item
            {
                SellIn = 5,
                Quality = 6 
            };

            ExpectProducts(item);

            subject.UpdateQuality();

            Assert.That(item.SellIn, Is.EqualTo(4));
            Assert.That(item.Quality, Is.EqualTo(5));
        }


        #endregion

        #region Private Members

        private void ExpectProducts(params Item[] items)
        {
            webService.Setup(x => x.GetInventory()).Returns(new List<Item>(items));
        }

        #endregion
    }
}
