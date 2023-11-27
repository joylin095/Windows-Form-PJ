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
    public class DownTest
    {
        Down down;
        Point xy;
        Point WidthHeight;
        Point clickPoint;
        PrivateObject privateObject;

        // 初始化
        [TestInitialize()]
        public void init()
        {
            down = new Down();
            privateObject = new PrivateObject(down);
            xy = new Point(100, 100);
            WidthHeight = new Point(50, 50);
            clickPoint = new Point(125, 150);
        }

        // 是否按到外框的圓
        [TestMethod()]
        public void IsClickBorderCircleTest()
        {
            Assert.AreEqual(Cursors.SizeNS, down.Cursor);

            Assert.IsTrue(down.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(117, 150);
            Assert.IsFalse(down.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(125, 142);
            Assert.IsFalse(down.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(133, 150);
            Assert.IsFalse(down.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(125, 158);
            Assert.IsFalse(down.IsClickBorderCircle(xy, WidthHeight, clickPoint));
        }

        // 設定增量 測試
        [TestMethod()]
        public void SetIncrementPointTest()
        {
            Point expectedIncrementXY = new Point(0, 0);
            Point expectedIncrementWidthHeight = new Point(0, -1);
            down.SetIncrementPoint(new Point(1, -1));

            Assert.AreEqual(expectedIncrementXY, privateObject.GetFieldOrProperty("_incrementX1Y1"));
            Assert.AreEqual(expectedIncrementWidthHeight, privateObject.GetFieldOrProperty("_incrementWidthHeight"));
        }

        // Get XY增量
        [TestMethod()]
        public void GetIncrementX1Y1Test()
        {
            Point expectedIncrementXY = new Point(0, 0);
            down.SetIncrementPoint(new Point(1, -1));

            Assert.AreEqual(expectedIncrementXY, down.GetIncrementX1Y1());
        }

        // Get Width Height增量
        [TestMethod()]
        public void GetIncrementWidthHeightTest()
        {
            Point expectedIncrementWidthHeight = new Point(0, -1);
            down.SetIncrementPoint(new Point(1, -1));

            Assert.AreEqual(expectedIncrementWidthHeight, down.GetIncrementWidthHeight());
        }
    }
}