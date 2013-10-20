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
        public void GoldenMasterTest()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            
            Program.Main(null);

            Assert.That(writer.ToString(), Is.EqualTo(File.ReadAllText("..\\..\\output.txt")));
        }

        [Test]
        public void SellIn_And_Quality_Decreases()
        {
            ExpectVariableChange(5, 6, 4, 5);
        }

        [Test]
        public void Once_The_Selldate_Has_Passed_Quality_Degrades_Twice_As_Fast()
        {
            ExpectVariableChange(0, 6, -1, 4);
        }

        [Test]
        public void Quality_Can_Never_Be_Negative()
        {
            ExpectVariableChange(1, 0, 0, 0);
        }

        [Test]
        public void Quality_Is_Never_More_Than_50()
        {
            ExpectVariableChange(5, 50, 4, 50, SpecialProducts.AgedBrie);
        }

        //"Aged Brie"

        [Test]
        public void Aged_Brie_Quality_Increases_With_Age()
        {
            ExpectVariableChange(4, 2, 3, 3, SpecialProducts.AgedBrie);
        }

        [Test]
        public void Sulfaras_Is_A_Legendary_Item()
        {
            Assert.That(new Item { Name = SpecialProducts.Sulfuras }.IsLegendaryProduct);
        }

        [Test]
        public void Aged_Brie_Is_Not_A_Legendary_Item()
        {
            Assert.That(!new Item { Name = SpecialProducts.AgedBrie }.IsLegendaryProduct);
        }

        [Test]
        public void Legendary_Items_Do_Not_Have_To_Be_Sold_Or_Decrease_In_Quality()
        {
            ExpectVariableChange(4, 2, 4, 2, SpecialProducts.Sulfuras);
        }

        [Test]
        public void BackStage_Passes_Quality_Increases_By_2_When_There_Are_Between_6_And_10_Days_Left()
        {
            for (int i = 6; i <= 10; i++)
            {
                ExpectVariableChange(i, 6, i-1, 8, SpecialProducts.BackstagePasses);
            }
        }

        [Test]
        public void BackStage_Passes_Quality_Increases_By_3_When_There_Are_Between_1_And_5_Days_Left()
        {
            for (int i = 1; i <= 5; i++)
            {
                ExpectVariableChange(i, 6, i-1, 9, SpecialProducts.BackstagePasses);
            }
        }

        [Test]
        public void BackStage_Passes_Quality_Drop_Down_to_Zero()
        {
           ExpectVariableChange(0, 6, -1, 0, SpecialProducts.BackstagePasses);
        }

        [Test]
        public void Conjured_Items_Degrade_In_Quality_Twice_As_Fast_As_Normal_Items()
        {
            ExpectVariableChange(4, 6, 3, 4, SpecialProducts.Conjured);
        }

        #endregion

        #region Private Members

        private void ExpectVariableChange(int originalSellIn, int originalQuality, int newSellIn,
            int newQuality, string itemName = null)
        {
            var item = new Item
            {
                Name = itemName,
                SellIn = originalSellIn,
                Quality = originalQuality
            };

            ExpectProducts(item);

            subject.UpdateQuality();

            Assert.That(item.SellIn, Is.EqualTo(newSellIn), "Sellin differs from expected value.  Original Sellin : " + originalSellIn);
            Assert.That(item.Quality, Is.EqualTo(newQuality), "Quality differs from expected value.  Original Quality : " + originalQuality);
        }

        private void ExpectProducts(params Item[] items)
        {
            webService.Setup(x => x.GetInventory()).Returns(new List<Item>(items));
        }

        #endregion
    }
}
