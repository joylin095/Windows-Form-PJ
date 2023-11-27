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
    public class CircleTests
    {
        Circle circle;

        // 測試建構式，座標(200,200),(400,400)
        [TestMethod()]
        public void CircleTest()
        {
            circle = new Circle(new MockRandomGenerator());
            Assert.AreEqual("圓", circle.Name);
            Assert.AreEqual(200, circle.X1);
            Assert.AreEqual(200, circle.Width);
            Assert.AreEqual(200, circle.Y1);
            Assert.AreEqual(200, circle.Height);
        }

        // 測試回傳座標格式
        [TestMethod()]
        public void GetLocationTest()
        {
            circle = new Circle(new MockRandomGenerator());
            string expectedLocation = $"(200, 200),(400, 400)";
            string location = circle.GetLocation();

            Assert.AreEqual(expectedLocation, location);
        }

        // 測試first point 跟 second point 的先後
        [TestMethod()]
        public void UpdateLocationTest()
        {
            circle = new Circle(new MockRandomGenerator());
            // first point.x 小
            circle.UpdateLocation(new Point(50, 10), new Point(100, 10));
            Assert.AreEqual(50, circle.X1);

            // new point.x 小
            circle.UpdateLocation(new Point(200, 10), new Point(150, 10));
            Assert.AreEqual(150, circle.X1);

            // first point.y 小
            circle.UpdateLocation(new Point(50, 50), new Point(100, 100));
            Assert.AreEqual(50, circle.Y1);

            // new point.y 小
            circle.UpdateLocation(new Point(200, 200), new Point(150, 150));
            Assert.AreEqual(150, circle.Y1);


            // 測絕對值，first 比 new.x 大
            circle.UpdateLocation(new Point(200, 10), new Point(150, 10));
            Assert.AreEqual(50, circle.Width);

            // 測絕對值，new 比 first.x 大
            circle.UpdateLocation(new Point(50, 10), new Point(100, 10));
            Assert.AreEqual(50, circle.Width);

            // 測絕對值，first 比 new.y 大
            circle.UpdateLocation(new Point(50, 50), new Point(100, 100));
            Assert.AreEqual(50, circle.Height);

            // 測絕對值，new 比 first.y 大
            circle.UpdateLocation(new Point(200, 200), new Point(150, 150));
            Assert.AreEqual(50, circle.Height);

            string expectedLocation = $"(150, 150),(200, 200)";
            Assert.AreEqual(expectedLocation, circle.Location);
        }

        // 測試畫圖
        [TestMethod()]
        public void DrawTest()
        {
            int x = 200;
            int y = 200;
            int width = 200;
            int height = 200;
            int r = 5;
            circle = new Circle(new MockRandomGenerator());
            MockGraphics mockGraphics = new MockGraphics();
            circle.Draw(mockGraphics);
            Assert.AreEqual(x, mockGraphics._x1);
            Assert.AreEqual(y, mockGraphics._y1);
            Assert.AreEqual(width, mockGraphics._width);
            Assert.AreEqual(height, mockGraphics._height);
            Assert.AreEqual(0, mockGraphics._diameter);

            circle.Selected = true;
            circle.Draw(mockGraphics);
            Assert.AreEqual(10, mockGraphics._diameter);
            Assert.AreEqual(x, mockGraphics._x1);
            Assert.AreEqual(y, mockGraphics._y1);
            Assert.AreEqual(width, mockGraphics._width);
            Assert.AreEqual(height, mockGraphics._height);
            //左上
            Assert.AreEqual(x - r, mockGraphics._upLeftX);
            Assert.AreEqual(y - r, mockGraphics._upLeftY);
            //上中
            Assert.AreEqual(x + (width / 2) - r, mockGraphics._upX);
            Assert.AreEqual(y - r, mockGraphics._upY);
            //右上
            Assert.AreEqual(x + width - r, mockGraphics._upRightX);
            Assert.AreEqual(y - r, mockGraphics._upRightY);
            //右中
            Assert.AreEqual(x + width - r, mockGraphics._rightX);
            Assert.AreEqual(y + (height / 2) - r, mockGraphics._rightY);
            //右下
            Assert.AreEqual(x + width - r, mockGraphics._downRightX);
            Assert.AreEqual(y + height - r, mockGraphics._downRightY);
            //中下
            Assert.AreEqual(x + (width / 2) - r, mockGraphics._downX);
            Assert.AreEqual(y + height - r, mockGraphics._downY);
            // 左下
            Assert.AreEqual(x - r, mockGraphics._downLeftX);
            Assert.AreEqual(y + height - r, mockGraphics._downLeftY);
            //左中
            Assert.AreEqual(x - r, mockGraphics._leftX);
            Assert.AreEqual(y + (height / 2) - r, mockGraphics._leftY);
        }

        // 測試選取點
        [TestMethod()]
        public void IsRangeInPointTest()
        {
            circle = new Circle(new MockRandomGenerator());
            Point inside = new Point(300, 300);
            Point outside = new Point(199, 199);
            Assert.IsTrue(circle.IsRangeInPoint(inside));
            Assert.IsFalse(circle.IsRangeInPoint(outside));
        }

        // 測試選取範圍
        [TestMethod()]
        public void IsRangeInAreaTest()
        {
            circle = new Circle(new MockRandomGenerator());
            Point insideFirstPoint = new Point(200, 200);
            Point insideSecondPoint = new Point(400, 400);

            Point overlapFirstPoint = new Point(201, 201);
            Point overlapSecondPoint = new Point(400, 400);

            Point outsideFirstPoint = new Point(50, 50);
            Point outsideSecondPoint = new Point(100, 100);

            Assert.IsTrue(circle.IsRangeInArea(insideFirstPoint, insideSecondPoint));
            Assert.IsFalse(circle.IsRangeInArea(overlapFirstPoint, overlapSecondPoint));
            Assert.IsFalse(circle.IsRangeInArea(outsideFirstPoint, outsideSecondPoint));
        }

        // 移動測試
        [TestMethod()]
        public void MoveTest()
        {
            circle = new Circle(new MockRandomGenerator());
            circle.Move(new Point(50, 10));

            circle.Selected = true;
            circle.Move(new Point(50, 10));
            Assert.AreEqual(250, circle.X1);
            Assert.AreEqual(210, circle.Y1);
        }

        // xy point 測試
        [TestMethod()]
        public void GetXYPointTest()
        {
            circle = new Circle(new MockRandomGenerator());

            Assert.AreEqual(new Point(200, 200), circle.GetX1Y1Point());
        }

        // 寬高point 測試
        [TestMethod()]
        public void GetWidthHeightPointTest()
        {
            circle = new Circle(new MockRandomGenerator());

            Assert.AreEqual(new Point(200, 200), circle.GetWidthHeightPoint());
        }

        // 測試object.Equals()
        [TestMethod()]
        public void EqualsTest()
        {
            circle = new Circle(new MockRandomGenerator());
            Assert.IsFalse(circle.Equals(null));
            Assert.IsTrue(circle.Equals(new Circle(new MockRandomGenerator())));
        }

        // 測試GetHashCode
        [TestMethod()]
        public void GetHashCodeTest()
        {
            circle = new Circle(new MockRandomGenerator());
            Circle circle2 = new Circle(new MockRandomGenerator());
            Assert.AreEqual(circle.GetHashCode(), circle2.GetHashCode());
        }
    }
}