namespace StringKata.Tests.Core
{
    using System;
    using System.IO;
    using NUnit.Framework;
    using StringKata.Core;

    [TestFixture]
    public class ConsoleOutputTests
    {
        #region Globals

        private StringWriter writer;
        private ConsoleUserInterface subject;

        #endregion

        #region Setup
        
        [SetUp]
        public void Setup()
        {
            writer = new StringWriter();
            subject = new ConsoleUserInterface();
            
            Console.SetOut(writer);
        }

        #endregion

        #region Teardown
        
        [TearDown]
        public void Teardown()
        {
            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);
        }
        
        #endregion
        
        #region Tests

        [Test]
        public void Write_Writes_To_Console_Out()
        {
            const string testMessage = "Test Message";
            
            subject.Write(testMessage);
            Assert.AreEqual(testMessage + Environment.NewLine, writer.ToString());
        }

        [Test]
        public void Read_Returns_True_For_NonEmpty_Input()
        {
           const string expected = "asdasdass";
           string actual;

           Console.SetIn(new StringReader(expected));
           Assert.IsTrue(subject.GetNextUserInput(out actual));
           Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Read_Returns_False_For_Empty_Input()
        {
            string expected = string.Empty;
            string actual;

            Console.SetIn(new StringReader(expected));
            Assert.IsFalse(subject.GetNextUserInput(out actual));
        }

        #endregion
    }
}
