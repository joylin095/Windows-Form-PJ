using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsPractice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsPractice.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        Rectangle rectangle;
        PrivateObject privateObject;

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
            string expectedLocation = "(200, 200),(400, 400)";
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

            string expectedLocation = "(150, 150),(200, 200)";
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
            privateObject = new PrivateObject(mockGraphics);
            rectangle.Draw(mockGraphics);
            Assert.AreEqual(x, privateObject.GetFieldOrProperty("_x1"));
            Assert.AreEqual(y, privateObject.GetFieldOrProperty("_y1"));
            Assert.AreEqual(width, privateObject.GetFieldOrProperty("_width"));
            Assert.AreEqual(height, privateObject.GetFieldOrProperty("_height"));

            rectangle.Selected = true;
            rectangle.Draw(mockGraphics);
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
            rectangle = new Rectangle(new MockRandomGenerator());
            Point inside = new Point(300, 300);
            Assert.IsTrue(rectangle.IsRangeInPoint(inside));

            Point outside = new Point(199, 300);
            Assert.IsFalse(rectangle.IsRangeInPoint(outside));

            outside = new Point(300, 199);
            Assert.IsFalse(rectangle.IsRangeInPoint(outside));

            outside = new Point(401, 300);
            Assert.IsFalse(rectangle.IsRangeInPoint(outside));

            outside = new Point(300, 401);
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

        // 放大縮小測試
        [TestMethod()]
        public void ZoomInOutTest()
        {
            Point incrementX1Y1 = new Point(1, 0);
            Point incrementWidthHeight = new Point(0, 1);
            Point expectedTempX1Y1 = new Point(201, 200);
            Point expectedTempWidthHeight = new Point(200, 201);
            rectangle = new Rectangle(new MockRandomGenerator());
            rectangle.GetX1Y1Point();
            rectangle.GetWidthHeightPoint();
            privateObject = new PrivateObject(rectangle);
            rectangle.ZoomInOut(incrementX1Y1, incrementWidthHeight);

            rectangle.Selected = true;
            rectangle.ZoomInOut(incrementX1Y1, incrementWidthHeight);
            Assert.AreEqual(expectedTempX1Y1, privateObject.GetFieldOrProperty("_tempX1Y1"));
            Assert.AreEqual(expectedTempWidthHeight, privateObject.GetFieldOrProperty("_tempWidthHeight"));
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
    }
}