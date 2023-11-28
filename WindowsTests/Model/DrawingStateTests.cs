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
    public class DrawingStateTests
    {
        DrawingState drawingState;
        PrivateObject privateObject;
        Model model;
        Point startPoint;
        Point movePoint;
        Point endPoint;

        // 測試建構式
        [TestMethod()]
        public void DrawingStateTest()
        {
            drawingState = new DrawingState(true);
            privateObject = new PrivateObject(drawingState);
            Assert.IsTrue((bool)privateObject.GetFieldOrProperty("_mousePressed"));

            drawingState = new DrawingState(false);
            privateObject = new PrivateObject(drawingState);
            Assert.IsFalse((bool)privateObject.GetFieldOrProperty("_mousePressed"));
        }

        // 在畫布滑鼠按下
        [TestMethod()]
        public void PanelMouseDownTest()
        {
            drawingState = new DrawingState(false);
            privateObject = new PrivateObject(drawingState);
            startPoint = new Point(50, 100);
            model = new Model();
            model.SelectShapeName = "線";
            model.CreateShapes();
            model.AddShape();
            drawingState.PanelMouseDown(model, startPoint);

            model = (Model)privateObject.GetFieldOrProperty("_model");
            Assert.IsTrue((bool)privateObject.GetFieldOrProperty("_mousePressed"));
            Assert.IsFalse(model.BindingShapeList[0].Selected);
        }
        
        // 在畫布滑鼠移動
        [TestMethod()]
        public void PanelMouseMoveTest()
        {
            drawingState = new DrawingState(true);
            movePoint = new Point(100, 150);
            model = new Model();
            model.FirstPoint = new Point(50, 50);
            model.SelectShapeName = "線";
            model.CreateShapes();
            drawingState.PanelMouseMove(model, movePoint);
        }

        // 在畫布滑鼠放開
        [TestMethod()]
        public void PanelMouseUpTest()
        {
            drawingState = new DrawingState(true);
            privateObject = new PrivateObject(drawingState);
            model = new Model();
            endPoint = new Point(150, 200);
            model.SelectShapeName = "線";
            model.CreateShapes();
            drawingState.PanelMouseUp(model, endPoint);

            model = (Model)privateObject.GetFieldOrProperty("_model");
            Assert.IsFalse(model.IsDrawing);
            Assert.IsFalse((bool)privateObject.GetFieldOrProperty("_mousePressed"));
            Assert.IsTrue(model.State is SelectState);
        }
    }
}