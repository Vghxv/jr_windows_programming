using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace DrawingForm.Tests
{
    [TestClass]
    public class ToolStripBindableButtonTests
    {
        [TestMethod]
        public void DataBindings_ShouldNotBeNull()
        {
            ToolStripBindableButton button = new ToolStripBindableButton();
            Assert.IsNotNull(button.DataBindings);
        }

        [TestMethod]
        public void BindingContext_ShouldNotBeNull()
        {
            ToolStripBindableButton button = new ToolStripBindableButton();
            Assert.IsNotNull(button.BindingContext);
        }

        [TestMethod]
        public void SetBindingContext_ShouldSetBindingContext()
        {
            ToolStripBindableButton button = new ToolStripBindableButton();
            BindingContext bindingContext = new BindingContext();

            button.BindingContext = bindingContext;

            Assert.AreEqual(bindingContext, button.BindingContext);
    }
    }

}