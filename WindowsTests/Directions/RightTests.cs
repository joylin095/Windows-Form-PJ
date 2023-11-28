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
    public class RightTests
    {
        Right right;
        Point xy;
        Point WidthHeight;
        Point clickPoint;

        // 初始化
        [TestInitialize()]
        public void init()
        {
            right = new Right();
            xy = new Point(100, 100);
            WidthHeight = new Point(50, 50);
            clickPoint = new Point(150, 125);
        }

        // 是否按到外框的圓
        [TestMethod()]
        public void IsClickBorderCircleTest()
        {
            Assert.AreEqual(Cursors.SizeWE, right.Cursor);

            Assert.IsTrue(right.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(142, 125);
            Assert.IsFalse(right.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(150, 117);
            Assert.IsFalse(right.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(158, 125);
            Assert.IsFalse(right.IsClickBorderCircle(xy, WidthHeight, clickPoint));

            clickPoint = new Point(150, 133);
            Assert.IsFalse(right.IsClickBorderCircle(xy, WidthHeight, clickPoint));
        }

        // 設定增量 測試
        [TestMethod()]
        public void SetIncrementPointTest()
        {
            Point expectedIncrementXY = new Point(0, 0);
            Point expectedIncrementWidthHeight = new Point(1, 0);
            right.SetIncrementPoint(new Point(1, -1));

            Assert.AreEqual(expectedIncrementXY, right.IncrementX1Y1);
            Assert.AreEqual(expectedIncrementWidthHeight, right.IncrementWidthHeight);
        }
    }
}