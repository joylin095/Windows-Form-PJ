using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Homework2.States;

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

            selectState.PanelMouseDown(model, new Point(50, 50));


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