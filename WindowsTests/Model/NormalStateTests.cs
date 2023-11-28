using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsPractice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WindowsPractice.States;

namespace WindowsPractice.Tests
{
    [TestClass()]
    public class NormalStateTests
    {
        NormalState normalState;
        PrivateObject privateObject;
        Model model;
        Point startPoint;
        Point movePoint;
        Point endPoint;

        //建構式
        [TestMethod()]
        public void NormalStateTest()
        {
            normalState = new NormalState(true);
            privateObject = new PrivateObject(normalState);
            Assert.IsTrue((bool)privateObject.GetFieldOrProperty("_mousePressed"));

            normalState = new NormalState(false);
            privateObject = new PrivateObject(normalState);
            Assert.IsFalse((bool)privateObject.GetFieldOrProperty("_mousePressed"));
        }

        // 初始shape的selected
        [TestMethod()]
        public void InitialShapeSelectedTest()
        {
            normalState = new NormalState(false);
            privateObject = new PrivateObject(normalState);
            model = new Model();
            model.SelectShapeName = "線";
            model.CreateShapes();
            model.AddShape();

            normalState.InitialShapeSelected(model);

            Model privateModel = (Model)privateObject.GetFieldOrProperty("_model");
            Assert.IsFalse(privateModel.BindingShapeList[0].Selected);
        }

        // 是否有在選取範圍
        [TestMethod()]
        public void HasSelectedInAreaTest()
        {
            normalState = new NormalState(false);
            Point firstPoint = new Point(20, 20);
            Point secondPoint = new Point(50, 50);
            Point newpoint = new Point(100, 100);
            model = new Model();
            model.FirstPoint = new Point(10, 10);
            model.SelectShapeName = "線";
            model.CreateShapes();
            model.AddShape();
            model.BindingShapeList[0].UpdateLocation(firstPoint, secondPoint);

            Assert.IsTrue(normalState.HasSelectedInArea(model, newpoint));

            newpoint = new Point(30, 30);
            Assert.IsFalse(normalState.HasSelectedInArea(model, newpoint));
        }

        // 在畫布滑鼠按下
        [TestMethod()]
        public void PanelMouseDownTest()
        {
            Point firstPoint = new Point(20, 20);
            Point secondPoint = new Point(50, 50);
            normalState = new NormalState(false);
            privateObject = new PrivateObject(normalState);
            startPoint = new Point(40, 40);
            model = new Model();
            model.SelectShapeName = "線";
            model.CreateShapes();
            model.AddShape();
            model.BindingShapeList[0].UpdateLocation(firstPoint, secondPoint);

            normalState.PanelMouseDown(model, startPoint);
            Model privateModel = (Model)privateObject.GetFieldOrProperty("_model");
            Assert.AreEqual(startPoint, privateModel.FirstPoint);
            Assert.IsTrue((bool)privateObject.GetFieldOrProperty("_mousePressed"));
            Assert.IsTrue(privateModel.BindingShapeList[0].Selected);
            Assert.IsTrue(privateModel.State is SelectState);

            startPoint = new Point(10, 10);
            normalState.PanelMouseDown(model, startPoint);
        }

        // 在畫布滑鼠移動
        [TestMethod()]
        public void PanelMouseMoveTest()
        {
            normalState = new NormalState(false);
            movePoint = new Point(10, 10);
            model = new Model();
            normalState.PanelMouseMove(model, movePoint);
        }

        // 在畫布滑鼠放開
        [TestMethod()]
        public void PanelMouseUpTest()
        {
            Point firstPoint = new Point(50, 50);
            Point secondPoint = new Point(100, 100);
            normalState = new NormalState(true);
            privateObject = new PrivateObject(normalState);
            model = new Model();
            model.FirstPoint = new Point(49, 49);
            model.SelectShapeName = "線";
            model.CreateShapes();
            model.AddShape();
            model.BindingShapeList[0].UpdateLocation(firstPoint, secondPoint);

            endPoint = new Point(100, 100);
            normalState.PanelMouseUp(model, endPoint);
            Model privateModel = (Model)privateObject.GetFieldOrProperty("_model");
            Assert.IsTrue(privateModel.State is SelectState);

            endPoint = new Point(99, 99);
            normalState = new NormalState(true);
            normalState.PanelMouseUp(model, endPoint);

            normalState = new NormalState(false);
            normalState.PanelMouseUp(model, endPoint);
        }
    }
}