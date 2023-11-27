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
    public class LineTests
    {
        Line line;

        // 測試建構式
        [TestMethod()]
        public void LineTest()
        {
            line = new Line(new MockRandomGenerator());
            Assert.AreEqual("線", line.Name);
            Assert.AreEqual(200, line.X1);
            Assert.AreEqual(200, line.Y1);
            Assert.AreEqual(200, line.X2);
            Assert.AreEqual(200, line.Y2);
        }

        // 測試回傳座標格式
        [TestMethod()]
        public void GetLocationTest()
        {
            line = new Line(new MockRandomGenerator());
            line.X2 = 400;
            line.Y2 = 400;
            string expectedLocation = $"(200, 200),(400, 400)";
            string location = line.GetLocation();

            Assert.AreEqual(expectedLocation, location);
        }

        // 測試first point 跟 second point 的先後
        [TestMethod()]
        public void UpdateLocationTest()
        {
            line = new Line(new MockRandomGenerator());

            // 測試 firstPoint.X <= newPoint.X
            Point firstPoint = new Point(50, 100);
            Point secondPoint = new Point(150, 200);
            line.UpdateLocation(firstPoint, secondPoint);
            Assert.AreEqual(50, line.X1);
            Assert.AreEqual(100, line.Y1);
            Assert.AreEqual(150, line.X2);
            Assert.AreEqual(200, line.Y2);
            string expectedLocation = $"(50, 100),(150, 200)";
            Assert.AreEqual(expectedLocation, line.Location);

            // 測試 firstPoint.X > newPoint.X
            firstPoint = new Point(40, 30);
            secondPoint = new Point(20, 10);
            line.UpdateLocation(firstPoint, secondPoint);
            Assert.AreEqual(20, line.X1);
            Assert.AreEqual(10, line.Y1);
            Assert.AreEqual(40, line.X2);
            Assert.AreEqual(30, line.Y2);
            expectedLocation = $"(20, 10),(40, 30)";
            Assert.AreEqual(expectedLocation, line.Location);
        }

        // 測試畫圖
        [TestMethod()]
        public void DrawTest()
        {
            int x1 = 200;
            int y1 = 200;
            int x2 = 400;
            int y2 = 400;
            int width = 200;
            int height = 200;
            int r = 5;
            line = new Line(new MockRandomGenerator());
            line.X2 = 400;
            line.Y2 = 400;
            MockGraphics mockGraphics = new MockGraphics();
            line.Draw(mockGraphics);
            Assert.AreEqual(x1, mockGraphics._x1);
            Assert.AreEqual(y1, mockGraphics._y1);
            Assert.AreEqual(x2, mockGraphics._x2);
            Assert.AreEqual(y2, mockGraphics._y2);
            Assert.AreEqual(0, mockGraphics._diameter);

            line.Selected = true;
            line.Draw(mockGraphics);
            Assert.AreEqual(10, mockGraphics._diameter);
            Assert.AreEqual(x1, mockGraphics._x1);
            Assert.AreEqual(y1, mockGraphics._y1);
            Assert.AreEqual(x2, mockGraphics._x2);
            Assert.AreEqual(y2, mockGraphics._y2);
            //左上
            Assert.AreEqual(x1 - r, mockGraphics._upLeftX);
            Assert.AreEqual(y1 - r, mockGraphics._upLeftY);
            //上中
            Assert.AreEqual(x1 + (width / 2) - r, mockGraphics._upX);
            Assert.AreEqual(y1 - r, mockGraphics._upY);
            //右上
            Assert.AreEqual(x1 + width - r, mockGraphics._upRightX);
            Assert.AreEqual(y1 - r, mockGraphics._upRightY);
            //右中
            Assert.AreEqual(x1 + width - r, mockGraphics._rightX);
            Assert.AreEqual(y1 + (height / 2) - r, mockGraphics._rightY);
            //右下
            Assert.AreEqual(x1 + width - r, mockGraphics._downRightX);
            Assert.AreEqual(y1 + height - r, mockGraphics._downRightY);
            //中下
            Assert.AreEqual(x1 + (width / 2) - r, mockGraphics._downX);
            Assert.AreEqual(y1 + height - r, mockGraphics._downY);
            // 左下
            Assert.AreEqual(x1 - r, mockGraphics._downLeftX);
            Assert.AreEqual(y1 + height - r, mockGraphics._downLeftY);
            //左中
            Assert.AreEqual(x1 - r, mockGraphics._leftX);
            Assert.AreEqual(y1 + (height / 2) - r, mockGraphics._leftY);
        }

        // 判斷點是否在範圍內
        [TestMethod()]
        public void IsRangeInPointTest()
        {
            line = new Line(new MockRandomGenerator());
            line.X2 = 400;
            line.Y2 = 400;
            Point inside = new Point(300, 300);
            Point outside = new Point(199, 199);
            Assert.IsTrue(line.IsRangeInPoint(inside));
            Assert.IsFalse(line.IsRangeInPoint(outside));
        }

        // 測試選取範圍
        [TestMethod()]
        public void IsRangeInAreaTest()
        {
            line = new Line(new MockRandomGenerator());
            line.X2 = 400;
            line.Y2 = 400;
            Point insideFirstPoint = new Point(200, 200);
            Point insideSecondPoint = new Point(400, 400);

            Point overlapFirstPoint = new Point(201, 201);
            Point overlapSecondPoint = new Point(400, 400);

            Point outsideFirstPoint = new Point(50, 50);
            Point outsideSecondPoint = new Point(100, 100);

            Assert.IsTrue(line.IsRangeInArea(insideFirstPoint, insideSecondPoint));
            Assert.IsFalse(line.IsRangeInArea(overlapFirstPoint, overlapSecondPoint));
            Assert.IsFalse(line.IsRangeInArea(outsideFirstPoint, outsideSecondPoint));
        }

        // 移動測試
        [TestMethod()]
        public void MoveTest()
        {
            line = new Line(new MockRandomGenerator());
            line.X2 = 400;
            line.Y2 = 400;
            line.Move(new Point(50, 10));

            line.Selected = true;
            line.Move(new Point(50, 10));
            Assert.AreEqual(250, line.X1);
            Assert.AreEqual(210, line.Y1);
            Assert.AreEqual(450, line.X2);
            Assert.AreEqual(410, line.Y2);
        }

        // xy point 測試
        [TestMethod()]
        public void GetXYPointTest()
        {
            line = new Line(new MockRandomGenerator());

            Assert.AreEqual(new Point(200, 200), line.GetX1Y1Point());
        }

        // 寬高point 測試
        [TestMethod()]
        public void GetWidthHeightPointTest()
        {
            line = new Line(new MockRandomGenerator());
            line.X2 = 400;
            line.Y2 = 400;

            Assert.AreEqual(new Point(200, 200), line.GetWidthHeightPoint());
        }

        // 測試object.Equals()
        [TestMethod()]
        public void EqualsTest()
        {
            line = new Line(new MockRandomGenerator());
            Assert.IsFalse(line.Equals(null));
            Assert.IsTrue(line.Equals(new Line(new MockRandomGenerator())));
        }

        // 測試GetHashCode
        [TestMethod()]
        public void GetHashCodeTest()
        {
            line = new Line(new MockRandomGenerator());
            Line line2 = new Line(new MockRandomGenerator());
            Assert.AreEqual(line.GetHashCode(), line2.GetHashCode());
        }
    }
}