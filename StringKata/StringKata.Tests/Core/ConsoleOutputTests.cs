namespace StringKata.Tests.Core
{
    using System;
    using System.IO;
    using NUnit.Framework;
    using StringKata.Core;

    [TestFixture]
    public class ConsoleOutputTests
    {
        [Test]
        public void Write_Writes_To_Console_Out()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);

            var output = new ConsoleUserInterface();
            
            const string testMessage = "Test Message";
            
            output.Write(testMessage);
            Assert.AreEqual(testMessage + Environment.NewLine, writer.ToString());
        }

        [TearDown]
        public void Teardown()
        {
            Console.SetOut(Console.Out);
        }
    }
}
