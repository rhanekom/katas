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

        #endregion
    }
}
