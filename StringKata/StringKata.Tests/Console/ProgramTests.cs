namespace StringKata.Tests.Console
{
    using Extensions;
    using Moq;
    using NUnit.Framework;
    using StringKata.Console;
    using StringKata.Core;

    [TestFixture]
    public class ProgramTests
    {
        #region Globals

        private Mock<IUserInterface> ui;

        #endregion
        
        #region Setup

        [SetUp]
        public void Setup()
        {
            ui = new Mock<IUserInterface>();
            Program.UI = ui.Object;
        }

        #endregion

        #region Tests
        
        [Test]
        public void Main_Writes_Usage_If_No_Parameters_Specified()
        {
            ui.Setup(x => x.Write(It.Is((string s) => s.Contains("Usage"))));
            
            Program.Main(new string[0]);
            ui.VerifyAll();
        }

        [Test]
        public void Main_Writes_Result_If_String_Specified()
        {
            ui.Setup(x => x.Write("The result is 6"));
            
            Program.Main(new[] { "1,2,3" });
            ui.VerifyAll();
        }

        [Test]
        public void Main_Quits_If_No_More_Input()
        {
            string returnValue;
            
            ui.Setup(x => x.GetNextUserInput(out returnValue)).Returns(false);

            Program.Main(new[] { "1,2,3" });

            ui.Verify(x => x.Write("Another input please"), Times.Once);
        }

        [Test]
        public void Main_Asks_Again_If_More_Input_Received()
        {
            // ReSharper disable RedundantAssignment
            string returnValue = "4,5,6";
            // ReSharper restore RedundantAssignment
            ui.Setup(x => x.GetNextUserInput(out returnValue)).ReturnsInOrder(new[] { true, true, false });

            Program.Main(new[] { "1,2,3" });

            ui.Verify(x => x.Write("Another input please"), Times.Exactly(3));
        }

        #endregion
    }
}
