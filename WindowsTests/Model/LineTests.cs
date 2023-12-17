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
    public class LineTests
    {
        Line line;
        PrivateObject privateObject;
        Point x1y1 = new Point(200, 200);
        Point x2y2 = new Point(400, 400);

        // 測試建構式
        [TestMethod()]
        public void LineTest()
        {
            line = new Line();
            Assert.AreEqual("線", line.Name);
            Assert.AreEqual(0, line.X1);
            Assert.AreEqual(0, line.Y1);
            Assert.AreEqual(0, line.X2);
            Assert.AreEqual(0, line.Y2);
        }

        // 測試回傳座標格式
        [TestMethod()]
        public void GetLocationTest()
        {
            line = new Line(x1y1, x2y2);
            string expectedLocation = "(200, 200),(400, 400)";
            string location = line.GetLocation();

            Assert.AreEqual(expectedLocation, location);
        }

        // 測試first point 跟 second point 的先後
        [TestMethod()]
        public void UpdateLocationTest()
        {
            line = new Line();

            // 測試 firstPoint.X <= newPoint.X
            Point firstPoint = new Point(50, 100);
            Point secondPoint = new Point(150, 200);
            line.UpdateLocation(firstPoint, secondPoint);
            Assert.AreEqual(50, line.X1);
            Assert.AreEqual(100, line.Y1);
            Assert.AreEqual(150, line.X2);
            Assert.AreEqual(200, line.Y2);
            string expectedLocation = "(50, 100),(150, 200)";
            Assert.AreEqual(expectedLocation, line.Location);

            // 測試 firstPoint.X > newPoint.X
            firstPoint = new Point(40, 30);
            secondPoint = new Point(20, 10);
            line.UpdateLocation(firstPoint, secondPoint);
            Assert.AreEqual(20, line.X1);
            Assert.AreEqual(10, line.Y1);
            Assert.AreEqual(40, line.X2);
            Assert.AreEqual(30, line.Y2);
            expectedLocation = "(20, 10),(40, 30)";
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
            line = new Line(x1y1, x2y2);
            MockGraphics mockGraphics = new MockGraphics();
            privateObject = new PrivateObject(mockGraphics);
            line.Draw(mockGraphics);
            Assert.AreEqual(x1, privateObject.GetFieldOrProperty("_x1"));
            Assert.AreEqual(y1, privateObject.GetFieldOrProperty("_y1"));
            Assert.AreEqual(x2, privateObject.GetFieldOrProperty("_x2"));
            Assert.AreEqual(y2, privateObject.GetFieldOrProperty("_y2"));

            line.Selected = true;
            line.Draw(mockGraphics);
            Assert.AreEqual(x1, privateObject.GetFieldOrProperty("_x1"));
            Assert.AreEqual(y1, privateObject.GetFieldOrProperty("_y1"));
            Assert.AreEqual(x2, privateObject.GetFieldOrProperty("_x2"));
            Assert.AreEqual(y2, privateObject.GetFieldOrProperty("_y2"));
            //左上
            Assert.AreEqual(x1 - r, privateObject.GetFieldOrProperty("_upLeftX"));
            Assert.AreEqual(y1 - r, privateObject.GetFieldOrProperty("_upLeftY"));
            //上中
            Assert.AreEqual(x1 + (width / 2) - r, privateObject.GetFieldOrProperty("_upX"));
            Assert.AreEqual(y1 - r, privateObject.GetFieldOrProperty("_upY"));
            //右上
            Assert.AreEqual(x1 + width - r, privateObject.GetFieldOrProperty("_upRightX"));
            Assert.AreEqual(y1 - r, privateObject.GetFieldOrProperty("_upRightY"));
            //右中
            Assert.AreEqual(x1 + width - r, privateObject.GetFieldOrProperty("_rightX"));
            Assert.AreEqual(y1 + (height / 2) - r, privateObject.GetFieldOrProperty("_rightY"));
            //右下
            Assert.AreEqual(x1 + width - r, privateObject.GetFieldOrProperty("_downRightX"));
            Assert.AreEqual(y1 + height - r, privateObject.GetFieldOrProperty("_downRightY"));
            //中下
            Assert.AreEqual(x1 + (width / 2) - r, privateObject.GetFieldOrProperty("_downX"));
            Assert.AreEqual(y1 + height - r, privateObject.GetFieldOrProperty("_downY"));
            // 左下
            Assert.AreEqual(x1 - r, privateObject.GetFieldOrProperty("_downLeftX"));
            Assert.AreEqual(y1 + height - r, privateObject.GetFieldOrProperty("_downLeftY"));
            //左中
            Assert.AreEqual(x1 - r, privateObject.GetFieldOrProperty("_leftX"));
            Assert.AreEqual(y1 + (height / 2) - r, privateObject.GetFieldOrProperty("_leftY"));
        }

        // 判斷點是否在範圍內
        [TestMethod()]
        public void IsRangeInPointTest()
        {
            line = new Line(x1y1, x2y2);
            Point inside = new Point(300, 300);
            Point outside = new Point(199, 199);
            Assert.IsTrue(line.IsRangeInPoint(inside));
            Assert.IsFalse(line.IsRangeInPoint(outside));
        }

        // 測試選取範圍
        [TestMethod()]
        public void IsRangeInAreaTest()
        {
            line = new Line(x1y1, x2y2);
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
            line = new Line(x1y1, x2y2);
            line.Move(new Point(50, 10));

            line.Selected = true;
            line.Move(new Point(50, 10));
            Assert.AreEqual(250, line.X1);
            Assert.AreEqual(210, line.Y1);
            Assert.AreEqual(450, line.X2);
            Assert.AreEqual(410, line.Y2);
        }

        // 放大縮小
        [TestMethod()]
        public void ZoomInOutTest()
        {
            Point incrementX1Y1 = new Point(1, 0);
            Point incrementWidthHeight = new Point(0, 1);
            Point expectedTempX1Y1 = new Point(201, 200);
            Point expectedTempWidthHeight = new Point(200, 201);
            line = new Line(x1y1, x2y2);
            line.Selected = true;
            line.GetX1Y1Point();
            line.GetWidthHeightPoint();
            privateObject = new PrivateObject(line);

            line.ZoomInOut(incrementX1Y1, incrementWidthHeight);
            Assert.AreEqual(expectedTempX1Y1, privateObject.GetFieldOrProperty("_tempX1Y1"));
            Assert.AreEqual(expectedTempWidthHeight, privateObject.GetFieldOrProperty("_tempWidthHeight"));

            line.Y1 = 500;
            line.GetX1Y1Point();
            line.ZoomInOut(incrementX1Y1, incrementWidthHeight);

            line.Selected = false;
        }

        // xy point 測試
        [TestMethod()]
        public void GetXYPointTest()
        {
            line = new Line(x1y1, x2y2);
            privateObject = new PrivateObject(line);
            Assert.AreEqual(new Point(200, 200), line.GetX1Y1Point());

            line.GetX1Y1Point();
            Assert.IsFalse((bool)privateObject.GetFieldOrProperty("_isDownLeftUpRight"));

            line.Y1 = 500;
            line.GetX1Y1Point();
            Assert.IsTrue((bool)privateObject.GetFieldOrProperty("_isDownLeftUpRight"));
        }

        // 寬高point 測試
        [TestMethod()]
        public void GetWidthHeightPointTest()
        {
            line = new Line(x1y1, x2y2);

            Assert.AreEqual(new Point(200, 200), line.GetWidthHeightPoint());
        }

        // scale point
        [TestMethod()]
        public void SetScaleTest()
        {
            float expectedScaleWidth = 2;
            float expectedScaleHeight = 2;
            string expectedLocation = "(400, 400),(800, 800)";
            line = new Line(x1y1, x2y2);

            line.SetScale(2, 2);
            privateObject = new PrivateObject(line);

            Assert.AreEqual(expectedScaleWidth, privateObject.GetFieldOrProperty("_scaleWidth"));
            Assert.AreEqual(expectedScaleHeight, privateObject.GetFieldOrProperty("_scaleHeight"));
            Assert.AreEqual(expectedLocation, line.GetLocation());
        }

        // set寬高(tuple)
        [TestMethod()]
        public void SetX1Y1WidthHeightTupleTest()
        {
            Point x1Y1 = new Point(500, 500);
            Point x2Y2 = new Point(600, 600);
            string expectedLocation = "(500, 500),(600, 600)";
            line = new Line();

            line.SetX1Y1WidthHeightTuple(x1Y1, x2Y2);

            Assert.AreEqual(x1Y1.X, line.X1);
            Assert.AreEqual(x1Y1.Y, line.Y1);
            Assert.AreEqual(x2Y2.X, line.X2);
            Assert.AreEqual(x2Y2.Y, line.Y2);
            Assert.AreEqual(expectedLocation, line.GetLocation());
        }

        // get寬高(tuple)
        [TestMethod()]
        public void GetX1Y1WidthHeightTupleTest()
        {
            (Point x1Y1, Point widthHeight) expectedTurple = (new Point(200, 200), new Point(400, 400));
            line = new Line(x1y1, x2y2);

            Assert.AreEqual(expectedTurple, line.GetX1Y1WidthHeightTuple());
        }
    }
}