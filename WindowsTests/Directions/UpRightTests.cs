using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework2.Directions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Homework2.Directions.Tests
{
    [TestClass()]
    public class UpRightTests
    {
        UpRight upRight;
        Point xy;
        Point WidthHeight;
        Point clickPoint;
        PrivateObject privateObject;

        // 初始化
        [TestInitialize()]
        public void init()
        {
            upRight = new UpRight();
            privateObject = new PrivateObject(upRight);
            xy = new Point(100, 100);
            WidthHeight = new Point(50, 50);
            clickPoint = new Point(150, 100);
        }

        // 是否按到外框的圓
        [TestMethod()]
        public void IsClickBorderCircleTest()
        {
            Assert.AreEqual(Cursors.SizeNESW, upRight.Cursor);

            Assert.IsTrue(upRight.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(142, 100);
            Assert.IsFalse(upRight.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(150, 92);
            Assert.IsFalse(upRight.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(158, 100);
            Assert.IsFalse(upRight.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(150, 108);
            Assert.IsFalse(upRight.IsClickBorderCircle(xy, WidthHeight, clickPoint));
        }

        // 設定增量 測試
        [TestMethod()]
        public void SetIncrementPointTest()
        {
            Point expectedIncrementXY = new Point(0, -1);
            Point expectedIncrementWidthHeight = new Point(1, 1);
            upRight.SetIncrementPoint(new Point(1, -1));

            Assert.AreEqual(expectedIncrementXY, privateObject.GetFieldOrProperty("_incrementX1Y1"));
            Assert.AreEqual(expectedIncrementWidthHeight, privateObject.GetFieldOrProperty("_incrementWidthHeight"));
        }

        // Get XY增量
        [TestMethod()]
        public void GetIncrementX1Y1Test()
        {
            Point expectedIncrementXY = new Point(0, -1);
            upRight.SetIncrementPoint(new Point(1, -1));

            Assert.AreEqual(expectedIncrementXY, upRight.GetIncrementX1Y1());
        }

        // Get Width Height增量
        [TestMethod()]
        public void GetIncrementWidthHeightTest()
        {
            Point expectedIncrementWidthHeight = new Point(1, 1);
            upRight.SetIncrementPoint(new Point(1, -1));

            Assert.AreEqual(expectedIncrementWidthHeight, upRight.GetIncrementWidthHeight());
        }
    }
}