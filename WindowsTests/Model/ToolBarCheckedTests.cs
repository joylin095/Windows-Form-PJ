using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Homework2.Tests
{
    [TestClass()]
    public class ToolBarCheckedTests
    {
        ToolBarChecked toolBarChecked;

        // 測試建構式
        [TestMethod()]
        public void ToolBarCheckedTest()
        {
            toolBarChecked = new ToolBarChecked("線", true);
            Assert.AreEqual("線", toolBarChecked.Key);
            Assert.IsTrue(toolBarChecked.Value);
        }

        // 測試更改checked值
        [TestMethod()]
        public void SetCheckedValueTest()
        {
            toolBarChecked = new ToolBarChecked("線", true);

            toolBarChecked.SetCheckedValue("線");
            Assert.IsFalse(toolBarChecked.Value);
            toolBarChecked.SetCheckedValue("線");
            Assert.IsTrue(toolBarChecked.Value);

            toolBarChecked.SetCheckedValue("矩形");
            Assert.IsFalse(toolBarChecked.Value);
        }

        // 測試變換drawing state
        [TestMethod()]
        public void IsDrawingStateTest()
        {
            toolBarChecked = new ToolBarChecked("線", true);
            Assert.IsTrue(toolBarChecked.IsDrawingState());

            toolBarChecked.Value = false;
            Assert.IsFalse(toolBarChecked.IsDrawingState());

            toolBarChecked = new ToolBarChecked("選取", true);
            Assert.IsFalse(toolBarChecked.IsDrawingState());
        }

        [TestMethod()]
        public void NotifyPropertyChangedTest()
        {
            Assert.Fail();
        }
    }
}