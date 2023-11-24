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
    public class SelectStateTests
    {
        SelectState selectState;
        PrivateObject privateObject;
        Model model;
        Point startPoint;
        Point movePoint;
        Point endPoint;

        // 建構式
        [TestMethod()]
        public void SelectStateTest()
        {
            selectState = new SelectState(true);
            privateObject = new PrivateObject(selectState);
            Assert.IsTrue((bool)privateObject.GetFieldOrProperty("_mousePressed"));

            selectState = new SelectState(false);
            privateObject = new PrivateObject(selectState);
            Assert.IsFalse((bool)privateObject.GetFieldOrProperty("_mousePressed"));
        }

        // 初始shape的selected
        [TestMethod()]
        public void InitialShapeSelectedTest()
        {
            selectState = new SelectState(false);
            privateObject = new PrivateObject(selectState);
            model = new Model();
            model.SelectShapeName = "線";
            model.CreateShapes();
            model.AddShape();

            selectState.InitialShapeSelected(model);

            model = (Model)privateObject.GetFieldOrProperty("_model");
            Assert.IsFalse(model.BindingShapeList[0].Selected);
        }

        // 判斷shape有被選到 而且 鼠標也指到
        [TestMethod()]
        public void IsSelectedAndInPointTest()
        {
            Point firstPoint = new Point(50, 50);
            Point secondPoint = new Point(100, 100);
            Point newPoint = new Point(70, 70);
            selectState = new SelectState(false);
            model = new Model();
            model.SelectShapeName = "線";
            model.CreateShapes();
            model.AddShape();
            model.BindingShapeList[0].UpdateLocation(firstPoint, secondPoint);
            model.BindingShapeList[0].Selected = true;

            Assert.IsTrue(selectState.IsSelectedAndInPoint(model, newPoint));

            model.BindingShapeList[0].Selected = true;
            newPoint = new Point(49, 50);
            Assert.IsFalse(selectState.IsSelectedAndInPoint(model, newPoint));

            model.BindingShapeList[0].Selected = false;
            newPoint = new Point(50, 50);
            Assert.IsFalse(selectState.IsSelectedAndInPoint(model, newPoint));

            model.BindingShapeList[0].Selected = false;
            newPoint = new Point(101, 100);
            Assert.IsFalse(selectState.IsSelectedAndInPoint(model, newPoint));
        }

        // 判斷shape沒被選到 但是 鼠標有指到
        [TestMethod()]
        public void IsNotSelectedButInPointTest()
        {
            Point firstPoint = new Point(50, 50);
            Point secondPoint = new Point(100, 100);
            Point newPoint = new Point(70, 70);
            selectState = new SelectState(false);
            model = new Model();
            model.SelectShapeName = "線";
            model.CreateShapes();
            model.AddShape();
            model.BindingShapeList[0].UpdateLocation(firstPoint, secondPoint);
            model.BindingShapeList[0].Selected = false;

            Assert.IsTrue(selectState.IsNotSelectedButInPoint(model, newPoint));
            Assert.IsTrue(model.BindingShapeList[0].Selected);

            model.BindingShapeList[0].Selected = false;
            newPoint = new Point(49, 50);
            Assert.IsFalse(selectState.IsNotSelectedButInPoint(model, newPoint));

            model.BindingShapeList[0].Selected = true;
            newPoint = new Point(50, 50);
            Assert.IsFalse(selectState.IsNotSelectedButInPoint(model, newPoint));

            model.BindingShapeList[0].Selected = true;
            newPoint = new Point(101, 100);
            Assert.IsFalse(selectState.IsNotSelectedButInPoint(model, newPoint));
        }

        // 在畫布滑鼠按下
        [TestMethod()]
        public void PanelMouseDownTest()
        {
            Point firstPoint = new Point(50, 50);
            Point secondPoint = new Point(100, 100);
            startPoint = new Point(70, 70);
            selectState = new SelectState(false);
            privateObject = new PrivateObject(selectState);
            model = new Model();
            model.SelectShapeName = "線";
            model.CreateShapes();
            model.AddShape();
            model.BindingShapeList[0].UpdateLocation(firstPoint, secondPoint);

            model.BindingShapeList[0].Selected = true;
            selectState.PanelMouseDown(model, startPoint);
            Model privateModel = (Model)privateObject.GetFieldOrProperty("_model");
            Assert.IsTrue((bool)privateObject.GetFieldOrProperty("_mousePressed"));
            Assert.AreEqual(startPoint, privateModel.FirstPoint);

            model.BindingShapeList[0].Selected = false;
            selectState.PanelMouseDown(model, startPoint);

            model.BindingShapeList[0].Selected = false;
            startPoint = new Point(101, 101);
            selectState.PanelMouseDown(model, startPoint);
            Assert.IsTrue(privateModel.State is NormalState);
        }

        // 在畫布滑鼠移動
        [TestMethod()]
        public void PanelMouseMoveTest()
        {
            Point firstPoint = new Point(50, 50);
            Point secondPoint = new Point(100, 100);
            movePoint = new Point(70, 70);
            selectState = new SelectState(true);
            privateObject = new PrivateObject(selectState);
            model = new Model();
            model.SelectShapeName = "線";
            model.CreateShapes();
            model.AddShape();
            model.BindingShapeList[0].UpdateLocation(firstPoint, secondPoint);
            model.BindingShapeList[0].Selected = true;
            model.FirstPoint = new Point(50, 50);

            selectState.PanelMouseMove(model, movePoint);
            Model privateModel = (Model)privateObject.GetFieldOrProperty("_model");
            Assert.AreEqual(movePoint, privateModel.FirstPoint);

            model.BindingShapeList[0].Selected = false;
            selectState.PanelMouseMove(model, movePoint);
            privateModel = (Model)privateObject.GetFieldOrProperty("_model");
            Assert.AreEqual(movePoint, privateModel.FirstPoint);

            selectState = new SelectState(false);
            selectState.PanelMouseMove(model, movePoint);
        }

        // 在畫布滑鼠放開
        [TestMethod()]
        public void PanelMouseUpTest()
        {
            selectState = new SelectState(true);
            privateObject = new PrivateObject(selectState);
            endPoint = new Point(50, 50);
            model = new Model();
            selectState.PanelMouseUp(model, endPoint);

            Assert.IsFalse((bool)privateObject.GetFieldOrProperty("_mousePressed"));

            selectState = new SelectState(false);
            selectState.PanelMouseUp(model, endPoint);
        }
    }
}