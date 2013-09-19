﻿namespace StringKata.Tests
{
    using System;
    using System.IO;
    using NUnit.Framework;

    [TestFixture]
    public class ConsoleOutputTests
    {
        [Test]
        public void Write_Writes_To_Console_Out()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);

            var output = new ConsoleOutput();
            
            const string testMessage = "Test Message";
            
            output.Write(testMessage);
            Assert.AreEqual(testMessage + Environment.NewLine, writer.ToString());
        }

    }
}
