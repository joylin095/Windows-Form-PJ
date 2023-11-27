using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace Homework2.Tests
{
    [TestClass()]
    public class ShapesTests
    {
        Shapes shapes;
        PrivateObject _shapesPrivate;

        // 測試建構式
        [TestMethod()]
        public void ShapesTest()
        {
            shapes = new Shapes();
            Assert.IsNotNull(shapes.ShapeList);
        }

        // 創建shape測試
        [TestMethod()]
        public void CreateShapeTest()
        {
            shapes = new Shapes();
            _shapesPrivate = new PrivateObject(shapes);

            shapes.CreateShape("線");
            Shape expectedShape = new Line(new RandomGenerator());
            Assert.AreEqual(expectedShape, _shapesPrivate.GetFieldOrProperty("_shape"));

            shapes.CreateShape("矩形");
            expectedShape = new Rectangle(new RandomGenerator());
            Assert.AreEqual(expectedShape, _shapesPrivate.GetFieldOrProperty("_shape"));

            shapes.CreateShape("圓");
            expectedShape = new Circle(new RandomGenerator());
            Assert.AreEqual(expectedShape, _shapesPrivate.GetFieldOrProperty("_shape"));

            shapes.CreateShape("??");
            expectedShape = null;
            Assert.AreEqual(expectedShape, _shapesPrivate.GetFieldOrProperty("_shape"));
        }

        // 測試把shape加入shpaelist
        [TestMethod()]
        public void AddShapeTest()
        {
            shapes = new Shapes();
            _shapesPrivate = new PrivateObject(shapes);
            shapes.CreateShape("線");
            shapes.AddShape();
            Assert.AreEqual(1, shapes.ShapeList.Count);
            Assert.IsNull(_shapesPrivate.GetFieldOrProperty("_shape"));
        }

        // 測試shapelist刪除
        [TestMethod()]
        public void DeleteDataTest()
        {
            shapes = new Shapes();
            _shapesPrivate = new PrivateObject(shapes);
            shapes.CreateShape("線");
            shapes.AddShape();
            shapes.DeleteData(0);
            Assert.AreEqual(0, shapes.ShapeList.Count);
        }

        // 測試畫圖
        [TestMethod()]
        public void DrawAllTest()
        {
            shapes = new Shapes();
            shapes.CreateShape("線");
            shapes.AddShape();
            shapes.DrawAll(new MockGraphics());

            shapes.CreateShape("線");
            shapes.IsDrawing = true;
            shapes.DrawAll(new MockGraphics());
        }

        // 測試更新座標
        [TestMethod()]
        public void UpdateLocationTest()
        {
            shapes = new Shapes();
            shapes.CreateShape("線");
            shapes.UpdateLocation(new Point(50, 50), new Point(100, 100));
        }

        // 初始shape的selected 測試
        [TestMethod()]
        public void InitialShapeSelectedTest()
        {
            shapes = new Shapes();
            shapes.CreateShape("線");
            shapes.AddShape();
            Shape shape = shapes.ShapeList[0];
            shape.Selected = true;

            shapes.InitialShapeSelected(shape);
            Assert.IsTrue(shapes.ShapeList[0].Selected);

            shapes.InitialShapeSelected();
            Assert.IsFalse(shapes.ShapeList[0].Selected);
        }

        // 判斷shape有被選到 而且 鼠標也指到
        [TestMethod()]
        public void IsSelectedAndInPointTest()
        {
            Point firstPoint = new Point(50, 50);
            Point secondPoint = new Point(100, 100);
            Point newPoint = new Point(70, 70);
            shapes = new Shapes();
            shapes.CreateShape("線");
            shapes.AddShape();

            shapes.ShapeList[0].UpdateLocation(firstPoint, secondPoint);
            shapes.ShapeList[0].Selected = true;

            Assert.IsTrue(shapes.IsSelectedAndInPoint(newPoint));

            shapes.ShapeList[0].Selected = true;
            newPoint = new Point(49, 50);
            Assert.IsFalse(shapes.IsSelectedAndInPoint(newPoint));

            shapes.ShapeList[0].Selected = false;
            newPoint = new Point(50, 50);
            Assert.IsFalse(shapes.IsSelectedAndInPoint(newPoint));

            shapes.ShapeList[0].Selected = false;
            newPoint = new Point(101, 100);
            Assert.IsFalse(shapes.IsSelectedAndInPoint(newPoint));
        }

        // 判斷shape沒被選到 但是 鼠標有指到 測試
        [TestMethod()]
        public void IsNotSelectedButInPoint()
        {
            Point firstPoint = new Point(50, 50);
            Point secondPoint = new Point(100, 100);
            Point newPoint = new Point(70, 70);
            shapes = new Shapes();
            shapes.CreateShape("線");
            shapes.AddShape();

            shapes.ShapeList[0].UpdateLocation(firstPoint, secondPoint);
            shapes.ShapeList[0].Selected = false;

            Assert.IsTrue(shapes.IsNotSelectedButInPoint(newPoint));
            Assert.IsTrue(shapes.ShapeList[0].Selected);

            shapes.ShapeList[0].Selected = false;
            newPoint = new Point(49, 50);
            Assert.IsFalse(shapes.IsNotSelectedButInPoint(newPoint));

            shapes.ShapeList[0].Selected = true;
            newPoint = new Point(50, 50);
            Assert.IsFalse(shapes.IsNotSelectedButInPoint(newPoint));

            shapes.ShapeList[0].Selected = true;
            newPoint = new Point(101, 100);
            Assert.IsFalse(shapes.IsNotSelectedButInPoint(newPoint));
        }
    }
}