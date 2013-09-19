namespace StringKata.Tests.Core
{
    using System;
    using Moq;
    using NUnit.Framework;
    using StringKata.Core;

    [TestFixture]
    public class CalculatorTests
    {
        #region Globals

        private Mock<IOutput> output;
        private Calculator subject;

        #endregion

        #region Setup

        [SetUp]
        public void Setup()
        {
            output = new Mock<IOutput>();
            subject = new Calculator(output.Object);
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
            AssertArgumentException("-5,3", ex => StringAssert.Contains("negatives not allowed", ex.Message));
        }

        [Test]
        public void Add_Throws_For_Negative_Numbers_Includes_Number()
        {
            AssertArgumentException("-5,3", ex => StringAssert.Contains("-5", ex.Message));
        }

        [Test]
        public void Add_Throws_For_Negative_Numbers_Includes_Multiple_Numbers()
        {
            AssertArgumentException(
                "-5,3,-2", 
                ex =>
                {
                    StringAssert.Contains("-5", ex.Message);
                    StringAssert.Contains("-2", ex.Message);
                });
        }

        [Test]
        public void Add_Should_Ignore_Numbers_Larger_Than_Thousand()
        {
            Assert.That(subject.Add("2,1001"), Is.EqualTo(2));
            Assert.That(subject.Add("2,1000"), Is.EqualTo(1002));
        }

        [Test]
        public void Add_Delimiters_Can_Be_Of_Any_Length()
        {
            Assert.That(subject.Add("//[***]\n1***2***3"), Is.EqualTo(6));
        }

        [Test]
        public void Add_Can_Specify_Multiple_Custom_Delimiters()
        {
            Assert.That(subject.Add("//[*][%]\n1*2%4"), Is.EqualTo(7));
        }

        [Test]
        public void Add_Can_Specify_Multiple_Custom_Delimiters_With_Length_Longer_Than_One()
        {
            Assert.That(subject.Add("//[*(][%][**]\n1*(2%4**6"), Is.EqualTo(13));
        }

        [Test]
        public void Add_Outputs_Result_To_Console()
        {
            output.Setup(x => x.Write("The result is 7"));
            
            subject.Add("3,4");

            output.VerifyAll();
        }

        #endregion

        #region Private Members

        private void AssertArgumentException(string numbers, Action<ArgumentException> asserts)
        {
            try
            {
                subject.Add(numbers);
                Assert.Fail("Exception not thrown for negative numbers.");
            }
            catch (ArgumentException ex)
            {
                asserts(ex);
            } 
        }

        #endregion
    }
}
