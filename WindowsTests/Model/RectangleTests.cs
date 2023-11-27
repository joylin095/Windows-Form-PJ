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
    public class RectangleTests
    {
        Rectangle rectangle;

        // 測試建構式，座標(200,200),(400,400)
        [TestMethod()]
        public void RectangleTest()
        {

            rectangle = new Rectangle(new MockRandomGenerator());
            Assert.AreEqual("矩形", rectangle.Name);
            Assert.AreEqual(200, rectangle.X1);
            Assert.AreEqual(200, rectangle.Width);
            Assert.AreEqual(200, rectangle.Y1);
            Assert.AreEqual(200, rectangle.Height);
        }

        // 測試回傳座標格式
        [TestMethod()]
        public void GetLocationTest()
        {
            rectangle = new Rectangle(new MockRandomGenerator());
            string expectedLocation = $"(200, 200),(400, 400)";
            string location = rectangle.GetLocation();

            Assert.AreEqual(expectedLocation, location);
        }

        // 測試first point 跟 second point 的先後
        [TestMethod()]
        public void UpdateLocationTest()
        {
            rectangle = new Rectangle(new MockRandomGenerator());
            // first point.x 小
            rectangle.UpdateLocation(new Point(50, 10), new Point(100, 10));
            Assert.AreEqual(50, rectangle.X1);

            // new point.x 小
            rectangle.UpdateLocation(new Point(200, 10), new Point(150, 10));
            Assert.AreEqual(150, rectangle.X1);

            // first point.y 小
            rectangle.UpdateLocation(new Point(50, 50), new Point(100, 100));
            Assert.AreEqual(50, rectangle.Y1);

            // new point.y 小
            rectangle.UpdateLocation(new Point(200, 200), new Point(150, 150));
            Assert.AreEqual(150, rectangle.Y1);

            // 測絕對值，first 比 new.x 大
            rectangle.UpdateLocation(new Point(200, 10), new Point(150, 10));
            Assert.AreEqual(50, rectangle.Width);

            // 測絕對值，new 比 first.x 大
            rectangle.UpdateLocation(new Point(50, 10), new Point(100, 10));
            Assert.AreEqual(50, rectangle.Width);

            // 測絕對值，first 比 new.y 大
            rectangle.UpdateLocation(new Point(50, 50), new Point(100, 100));
            Assert.AreEqual(50, rectangle.Height);

            // 測絕對值，new 比 first.y 大
            rectangle.UpdateLocation(new Point(200, 200), new Point(150, 150));
            Assert.AreEqual(50, rectangle.Height);

            string expectedLocation = $"(150, 150),(200, 200)";
            Assert.AreEqual(expectedLocation, rectangle.Location);
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
            rectangle = new Rectangle(new MockRandomGenerator());
            MockGraphics mockGraphics = new MockGraphics();
            rectangle.Draw(mockGraphics);
            Assert.AreEqual(x, mockGraphics._x1);
            Assert.AreEqual(y, mockGraphics._y1);
            Assert.AreEqual(width, mockGraphics._width);
            Assert.AreEqual(height, mockGraphics._height);
            Assert.AreEqual(0, mockGraphics._diameter);

            rectangle.Selected = true;
            rectangle.Draw(mockGraphics);
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
            rectangle = new Rectangle(new MockRandomGenerator());
            Point inside = new Point(300, 300);
            Point outside = new Point(199, 199);
            Assert.IsTrue(rectangle.IsRangeInPoint(inside));
            Assert.IsFalse(rectangle.IsRangeInPoint(outside));
        }

        // 測試選取範圍
        [TestMethod()]
        public void IsRangeInAreaTest()
        {
            rectangle = new Rectangle(new MockRandomGenerator());
            Point insideFirstPoint = new Point(200, 200);
            Point insideSecondPoint = new Point(400, 400);

            Point overlapFirstPoint = new Point(201, 201);
            Point overlapSecondPoint = new Point(400, 400);

            Point outsideFirstPoint = new Point(50, 50);
            Point outsideSecondPoint = new Point(100, 100);

            Assert.IsTrue(rectangle.IsRangeInArea(insideFirstPoint, insideSecondPoint));
            Assert.IsFalse(rectangle.IsRangeInArea(overlapFirstPoint, overlapSecondPoint));
            Assert.IsFalse(rectangle.IsRangeInArea(outsideFirstPoint, outsideSecondPoint));
        }

        // 移動測試
        [TestMethod()]
        public void MoveTest()
        {
            rectangle = new Rectangle(new MockRandomGenerator());
            rectangle.Move(new Point(50, 10));

            rectangle.Selected = true;
            rectangle.Move(new Point(50, 10));
            Assert.AreEqual(250, rectangle.X1);
            Assert.AreEqual(210, rectangle.Y1);
        }

        [TestMethod()]
        public void ZoomInOutTest()
        {
            Point incrementX1Y1 = new Point(0, 0);
            Point incrementWidthHeight = new Point(-5, 0);
            rectangle = new Rectangle(new MockRandomGenerator());
            rectangle.Selected = true;
            rectangle.Width = 1;
            rectangle.ZoomInOut(incrementX1Y1, incrementWidthHeight);

            Assert.AreEqual(196, rectangle.X1);
            Assert.AreEqual(200, rectangle.Y1);
            Assert.AreEqual(4, rectangle.Width);
            Assert.AreEqual(200, rectangle.Height);
            Assert.AreEqual(-4, rectangle.testwidth);

            rectangle.ZoomInOut(incrementX1Y1, incrementWidthHeight);

            Assert.AreEqual(-9, rectangle.testwidth);
            Assert.AreEqual(195, rectangle.X1);
            Assert.AreEqual(200, rectangle.Y1);
            Assert.AreEqual(4, rectangle.Width);
            Assert.AreEqual(200, rectangle.Height);
            
        }

        // xy point 測試
        [TestMethod()]
        public void GetXYPointTest()
        {
            rectangle = new Rectangle(new MockRandomGenerator());

            Assert.AreEqual(new Point(200, 200), rectangle.GetX1Y1Point());
        }

        // 寬高point 測試
        [TestMethod()]
        public void GetWidthHeightPointTest()
        {
            rectangle = new Rectangle(new MockRandomGenerator());

            Assert.AreEqual(new Point(200, 200), rectangle.GetWidthHeightPoint());
        }

        // 測試object.Equals()
        [TestMethod()]
        public void EqualsTest()
        {
            rectangle = new Rectangle(new MockRandomGenerator());
            Assert.IsFalse(rectangle.Equals(null));
            Assert.IsTrue(rectangle.Equals(new Rectangle(new MockRandomGenerator())));
        }

        // 測試GetHashCode
        [TestMethod()]
        public void GetHashCodeTest()
        {
            rectangle = new Rectangle(new MockRandomGenerator());
            Rectangle rectangle2 = new Rectangle(new MockRandomGenerator());
            Assert.AreEqual(rectangle.GetHashCode(), rectangle2.GetHashCode());
        }
    }
}