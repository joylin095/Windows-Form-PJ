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
        PrivateObject privateObject;
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
            privateObject = new PrivateObject(mockGraphics);
            circle.Draw(mockGraphics);
            Assert.AreEqual(x, privateObject.GetFieldOrProperty("_x1"));
            Assert.AreEqual(y, privateObject.GetFieldOrProperty("_y1"));
            Assert.AreEqual(width, privateObject.GetFieldOrProperty("_width"));
            Assert.AreEqual(height, privateObject.GetFieldOrProperty("_height"));

            circle.Selected = true;
            circle.Draw(mockGraphics);
            Assert.AreEqual(x, privateObject.GetFieldOrProperty("_x1"));
            Assert.AreEqual(y, privateObject.GetFieldOrProperty("_y1"));
            Assert.AreEqual(width, privateObject.GetFieldOrProperty("_width"));
            Assert.AreEqual(height, privateObject.GetFieldOrProperty("_height"));
            //左上
            Assert.AreEqual(x - r, privateObject.GetFieldOrProperty("_upLeftX"));
            Assert.AreEqual(y - r, privateObject.GetFieldOrProperty("_upLeftY"));
            //上中
            Assert.AreEqual(x + (width / 2) - r, privateObject.GetFieldOrProperty("_upX"));
            Assert.AreEqual(y - r, privateObject.GetFieldOrProperty("_upY"));
            //右上
            Assert.AreEqual(x + width - r, privateObject.GetFieldOrProperty("_upRightX"));
            Assert.AreEqual(y - r, privateObject.GetFieldOrProperty("_upRightY"));
            //右中
            Assert.AreEqual(x + width - r, privateObject.GetFieldOrProperty("_rightX"));
            Assert.AreEqual(y + (height / 2) - r, privateObject.GetFieldOrProperty("_rightY"));
            //右下
            Assert.AreEqual(x + width - r, privateObject.GetFieldOrProperty("_downRightX"));
            Assert.AreEqual(y + height - r, privateObject.GetFieldOrProperty("_downRightY"));
            //中下
            Assert.AreEqual(x + (width / 2) - r, privateObject.GetFieldOrProperty("_downX"));
            Assert.AreEqual(y + height - r, privateObject.GetFieldOrProperty("_downY"));
            // 左下
            Assert.AreEqual(x - r, privateObject.GetFieldOrProperty("_downLeftX"));
            Assert.AreEqual(y + height - r, privateObject.GetFieldOrProperty("_downLeftY"));
            //左中
            Assert.AreEqual(x - r, privateObject.GetFieldOrProperty("_leftX"));
            Assert.AreEqual(y + (height / 2) - r, privateObject.GetFieldOrProperty("_leftY"));
        }

        // 測試選取點
        [TestMethod()]
        public void IsRangeInPointTest()
        {
            circle = new Circle(new MockRandomGenerator());
            Point inside = new Point(300, 300);
            Assert.IsTrue(circle.IsRangeInPoint(inside));

            Point outside = new Point(199, 300);
            Assert.IsFalse(circle.IsRangeInPoint(outside));

            outside = new Point(300, 199);
            Assert.IsFalse(circle.IsRangeInPoint(outside));

            outside = new Point(401, 300);
            Assert.IsFalse(circle.IsRangeInPoint(outside));

            outside = new Point(300, 401);
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

        // 放大縮小測試
        [TestMethod()]
        public void ZoomInOutTest()
        {
            Point incrementX1Y1 = new Point(1, 0);
            Point incrementWidthHeight = new Point(0, 1);
            Point expectedTempX1Y1 = new Point(201, 200);
            Point expectedTempWidthHeight = new Point(200, 201);
            circle = new Circle(new MockRandomGenerator());
            circle.GetX1Y1Point();
            circle.GetWidthHeightPoint();
            privateObject = new PrivateObject(circle);
            circle.ZoomInOut(incrementX1Y1, incrementWidthHeight);

            circle.Selected = true;
            circle.ZoomInOut(incrementX1Y1, incrementWidthHeight);
            Assert.AreEqual(expectedTempX1Y1, privateObject.GetFieldOrProperty("TempX1Y1"));
            Assert.AreEqual(expectedTempWidthHeight, privateObject.GetFieldOrProperty("TempWidthHeight"));
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