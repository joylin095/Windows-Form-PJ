using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Homework2.Tests
{
    [TestClass()]
    public class DrawingStateTests
    {
        DrawingState drawingState;
        PrivateObject privateObject;
        Model model;
        Shapes shapes;
        Point startPoint;
        Point movePoint;
        Point endPoint;

        // 測試建構式
        [TestMethod()]
        public void DrawingStateTest()
        {
            drawingState = new DrawingState(true);
            privateObject = new PrivateObject(drawingState);
            Assert.IsTrue((bool)privateObject.GetFieldOrProperty("_mousePressed"));

            drawingState = new DrawingState(false);
            privateObject = new PrivateObject(drawingState);
            Assert.IsFalse((bool)privateObject.GetFieldOrProperty("_mousePressed"));

        }

        [TestMethod()]
        public void PanelMouseDownTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PanelMouseMoveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PanelMouseUpTest()
        {
            Assert.Fail();
        }
    }
}