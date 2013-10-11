using System;

namespace GildedRose.Tests
{
    using System.IO;
    using NUnit.Framework;

    [TestFixture]
    public class GildedRoseTests
    {
        [Test]
        public void GoldenMasterTest()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            
            Program.Main(null);

            Assert.That(writer.ToString(), Is.EqualTo(File.ReadAllText("output.txt")));
        }
    }
}
