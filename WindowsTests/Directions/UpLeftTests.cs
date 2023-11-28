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
    public class UpLeftTests
    {
        UpLeft upLeft;
        Point xy;
        Point WidthHeight;
        Point clickPoint;

        // 初始化
        [TestInitialize()]
        public void init()
        {
            upLeft = new UpLeft();
            xy = new Point(100, 100);
            WidthHeight = new Point(50, 50);
            clickPoint = new Point(100, 100);
        }

        // 是否按到外框的圓
        [TestMethod()]
        public void IsClickBorderCircleTest()
        {
            Assert.AreEqual(Cursors.SizeNWSE, upLeft.Cursor);

            Assert.IsTrue(upLeft.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(92, 100);
            Assert.IsFalse(upLeft.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(100, 92);
            Assert.IsFalse(upLeft.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(108, 100);
            Assert.IsFalse(upLeft.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(100, 108);
            Assert.IsFalse(upLeft.IsClickBorderCircle(xy, WidthHeight, clickPoint));
        }

        // 設定增量 測試
        [TestMethod()]
        public void SetIncrementPointTest()
        {
            Point expectedIncrementXY = new Point(1, -1);
            Point expectedIncrementWidthHeight = new Point(-1, 1);
            upLeft.SetIncrementPoint(new Point(1, -1));

            Assert.AreEqual(expectedIncrementXY, upLeft.IncrementX1Y1);
            Assert.AreEqual(expectedIncrementWidthHeight, upLeft.IncrementWidthHeight);
        }
    }
}