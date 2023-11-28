using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsPractice.Directions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsPractice.Directions.Tests
{
    [TestClass()]
    public class DownRightTests
    {
        DownRight downRight;
        Point xy;
        Point WidthHeight;
        Point clickPoint;

        // 初始化
        [TestInitialize()]
        public void Init()
        {
            downRight = new DownRight();
            xy = new Point(100, 100);
            WidthHeight = new Point(50, 50);
            clickPoint = new Point(150, 150);
        }

        // 是否按到外框的圓
        [TestMethod()]
        public void IsClickBorderCircleTest()
        {
            Assert.AreEqual(Cursors.SizeNWSE, downRight.Cursor);

            Assert.IsTrue(downRight.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(142, 150);
            Assert.IsFalse(downRight.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(150, 142);
            Assert.IsFalse(downRight.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(158, 150);
            Assert.IsFalse(downRight.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(150, 158);
            Assert.IsFalse(downRight.IsClickBorderCircle(xy, WidthHeight, clickPoint));
        }

        // 設定增量 測試
        [TestMethod()]
        public void SetIncrementPointTest()
        {
            Point expectedIncrementXY = new Point(0, 0);
            Point expectedIncrementWidthHeight = new Point(1, -1);
            downRight.SetIncrementPoint(new Point(1, -1));

            Assert.AreEqual(expectedIncrementXY, downRight.IncrementX1Y1);
            Assert.AreEqual(expectedIncrementWidthHeight, downRight.IncrementWidthHeight);
        }
    }
}