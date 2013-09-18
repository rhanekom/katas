using System;
using System.Diagnostics;
using NUnit.Framework;

namespace StringKata
{
    [TestFixture]
    public class CalculatorTests
    {
        #region Globals

        private Calculator subject;

        #endregion

        #region Setup

        [SetUp]
        public void Setup()
        {
            subject = new Calculator();
        }

        #endregion

        #region Tests

        [Test]
        public void Add_Returns_0_For_Empty_String()
        {
            Assert.That(subject.Add(string.Empty), Is.EqualTo(0));
        }

        [Test]
        public void Add_Returns_Number_For_Single_Number()
        {
            Assert.That(subject.Add("5"), Is.EqualTo(5));
        }

        [Test]
        public void Add_Returns_Sum_Of_Numbers_For_Multiple_Numbers()
        {
            Assert.That(subject.Add("5,3"), Is.EqualTo(8));
            Assert.That(subject.Add("5,3,6"), Is.EqualTo(14));
        }

        [Test]
        public void Add_Can_Use_Newline_As_Delimiter_Instead_Of_Comma()
        {
            Assert.That(subject.Add("1\n2,3"), Is.EqualTo(6));
        }

        [Test]
        public void Add_Can_Take_Custom_Delimiter()
        {
            Assert.That(subject.Add("//;\n1;2"), Is.EqualTo(3));
        }

        [Test]
        public void Add_Throws_For_Negative_Numbers()
        {
            Assert.Throws<ArgumentException>(() => subject.Add("-5,3"), "negatives not allowed");
        }

        #endregion
    }
}
