namespace StringKata.Tests.Console
{
    using Moq;
    using NUnit.Framework;
    using StringKata.Console;
    using StringKata.Core;

    [TestFixture]
    public class ProgramTests
    {
        #region Globals

        private Mock<IOutput> output;

        #endregion
        
        #region Setup

        [SetUp]
        public void Setup()
        {
            output = new Mock<IOutput>();
            Program.Output = output.Object;
        }

        #endregion

        #region Tests
        
        [Test]
        public void Main_Writes_Usage_If_No_Parameters_Specified()
        {
            output.Setup(x => x.Write(It.Is((string s) => s.Contains("Usage"))));
            
            Program.Main(new string[0]);
            output.VerifyAll();
        }

        #endregion
    }
}
