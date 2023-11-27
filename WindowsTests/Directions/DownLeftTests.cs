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
    public class DownLeftTests
    {
        DownLeft downLeft;
        Point xy;
        Point WidthHeight;
        Point clickPoint;
        PrivateObject privateObject;

        // 初始化
        [TestInitialize()]
        public void init()
        {
            downLeft = new DownLeft();
            privateObject = new PrivateObject(downLeft);
            xy = new Point(100, 100);
            WidthHeight = new Point(50, 50);
            clickPoint = new Point(100, 150);
        }

        // 是否按到外框的圓
        [TestMethod()]
        public void IsClickBorderCircleTest()
        {
            Assert.AreEqual(Cursors.SizeNESW, downLeft.Cursor);

            Assert.IsTrue(downLeft.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(92, 150);
            Assert.IsFalse(downLeft.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(100, 142);
            Assert.IsFalse(downLeft.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(108, 150);
            Assert.IsFalse(downLeft.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(100, 158);
            Assert.IsFalse(downLeft.IsClickBorderCircle(xy, WidthHeight, clickPoint));
        }

        // 設定增量 測試
        [TestMethod()]
        public void SetIncrementPointTest()
        {
            Point expectedIncrementXY = new Point(1, 0);
            Point expectedIncrementWidthHeight = new Point(-1, -1);
            downLeft.SetIncrementPoint(new Point(1, -1));

            Assert.AreEqual(expectedIncrementXY, privateObject.GetFieldOrProperty("_incrementX1Y1"));
            Assert.AreEqual(expectedIncrementWidthHeight, privateObject.GetFieldOrProperty("_incrementWidthHeight"));
        }

        // Get XY增量
        [TestMethod()]
        public void GetIncrementX1Y1Test()
        {
            Point expectedIncrementXY = new Point(1, 0);
            downLeft.SetIncrementPoint(new Point(1, -1));

            Assert.AreEqual(expectedIncrementXY, downLeft.GetIncrementX1Y1());
        }

        // Get Width Height增量
        [TestMethod()]
        public void GetIncrementWidthHeightTest()
        {
            Point expectedIncrementWidthHeight = new Point(-1, -1);
            downLeft.SetIncrementPoint(new Point(1, -1));

            Assert.AreEqual(expectedIncrementWidthHeight, downLeft.GetIncrementWidthHeight());
        }
    }
}