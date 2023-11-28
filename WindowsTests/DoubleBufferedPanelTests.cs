using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsPractice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPractice.Tests
{
    [TestClass()]
    public class DoubleBufferedPanelTests
    {
        // 建構式
        [TestMethod()]
        public void DoubleBufferedPanelTest()
        {
            DoubleBufferedPanel doubleBufferedPanel = new DoubleBufferedPanel();
            PrivateObject privateObject = new PrivateObject(doubleBufferedPanel);
            Assert.IsTrue((bool)privateObject.GetFieldOrProperty("DoubleBuffered"));
        }
    }
}