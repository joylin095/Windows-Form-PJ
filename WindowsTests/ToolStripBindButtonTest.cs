using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsPractice.Tests
{
    /// <summary>
    /// ToolStripBindButtonTest 的摘要說明
    /// </summary>
    [TestClass]
    public class ToolStripBindButtonTest
    {
        // 測試
        [TestMethod()]
        public void BindButtonTest()
        {
            ToolStripBindButton toolStripBindButton = new ToolStripBindButton();
            Assert.IsNotNull(toolStripBindButton.DataBindings);
            Assert.IsNotNull(toolStripBindButton.DataBindings);

            Assert.IsNotNull(toolStripBindButton.BindingContext);
            Assert.IsNotNull(toolStripBindButton.BindingContext);

            BindingContext bindingContext = new BindingContext();
            toolStripBindButton.BindingContext = bindingContext;

            Assert.AreEqual(bindingContext, toolStripBindButton.BindingContext);
        }
    }
}
