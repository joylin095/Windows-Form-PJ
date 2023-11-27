using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Homework2.Tests
{
    [TestClass]
    public class UpLeftTest
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
            clickPoint = new Point(95, 95);
        }

        // 是否按到外框的圓
        [TestMethod()]
        public void IsClickBorderCircleTest()
        {
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
    }
}
