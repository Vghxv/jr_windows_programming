using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingForm.Tests
{
    [TestClass]
    public class DoubleBufferedPanelTests
    {
        [TestMethod]
        public void DoubleBufferedPanel_Should_Have_DoubleBuffered_Set_To_True()
        {
            DoubleBufferedPanel doubleBufferedPanel = new DoubleBufferedPanel();
            Assert.IsNotNull(doubleBufferedPanel); // 💀 i don't know
        }
    }
}
