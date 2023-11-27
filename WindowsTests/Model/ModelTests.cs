using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Homework2.States;

namespace Homework2.Tests
{
    public class MockState : IState
    {
        // 在畫布滑鼠按下 
        public override void PanelMouseDown(Model model, Point point)
        {
            TestMousePressed = true;
            TestPoint = point;
        }

        // 在畫布滑鼠移動
        public override void PanelMouseMove(Model model, Point point)
        {
            TestPoint = point;
        }

        // 在畫布滑鼠放開
        public override void PanelMouseUp(Model model, Point point)
        {
            TestMousePressed = false;
            TestPoint = point;
        }
    }
    [TestClass()]
    public class ModelTests
    {
        Model model;
        PrivateObject privateObject;

        // 建構式
        [TestMethod()]
        public void ModelTest()
        {
            model = new Model();
            Assert.IsFalse(model.IsDrawing);
        }

        // 創建shape測試
        [TestMethod()]
        public void CreateShapesTest()
        {
            model = new Model();
            model.SelectShapeName = "線";
            model.CreateShapes();
            Assert.AreEqual("線", model.SelectShapeName);
        }

        // 加shape到list測試
        [TestMethod()]
        public void AddShapeTest()
        {
            model = new Model();
            model.SelectShapeName = "線";

            model.CreateShapes();
            model.AddShape();
            Assert.AreEqual(1, model.BindingShapeList.Count);

        }

        // 刪除shape測試
        [TestMethod()]
        public void DeleteDataTest()
        {
            model = new Model();
            model.SelectShapeName = "線";
            model.CreateShapes();
            model.AddShape();

            model.DeleteData(0);
            Assert.AreEqual(0, model.BindingShapeList.Count);
        }

        // 畫圖測試
        [TestMethod()]
        public void DrawTest()
        {
            model = new Model();
            privateObject = new PrivateObject(model);
            Shapes shapes = (Shapes)privateObject.GetFieldOrProperty("_shapes");

            model.IsDrawing = true;
            model.Draw(new MockGraphics());
            Assert.IsTrue(shapes.IsDrawing);

            model.IsDrawing = false;
            model.Draw(new MockGraphics());
            Assert.IsFalse(shapes.IsDrawing);
        }

        //第一個案下去的點測試
        [TestMethod()]
        public void SetShapeFirstPointTest()
        {
            model = new Model();
            Point point = new Point(50, 100);
            model.SetShapeFirstPoint(point);
            Assert.AreEqual(point, model.FirstPoint);
        }

        // 更新座標測試
        [TestMethod()]
        public void UpdateLocationTest()
        {
            model = new Model();
            model.SelectShapeName = "線";
            model.CreateShapes();
            Point point = new Point(50, 100);
            Point point1 = new Point(100, 150);
            model.SetShapeFirstPoint(point);
            model.UpdateLocation(point1);
        }

        // 在畫布滑鼠按下
        [TestMethod()]
        public void PanelMouseDownTest()
        {
            model = new Model();
            Point point = new Point(50, 100);
            model.State = new DrawingState(false);
            model.PanelMouseDown(point);
        }

        // 在畫布滑鼠移動
        [TestMethod()]
        public void PanelMouseMoveTest()
        {
            model = new Model();
            Point point = new Point(50, 100);
            model.State = new DrawingState(false);
            model.PanelMouseMove(point);

            model.PanelChanged += HandlePanelChanged;
            model.PanelMouseMove(point);
        }

        // HandlePanelChanged
        private void HandlePanelChanged(object sender)
        {
            
        }

        //HandleCursorToDefault
        private void HandleCursorToDefault(object sender)
        {
            
        }

        // 在畫布滑鼠放開
        [TestMethod()]
        public void PanelMouseUpTest()
        {
            model = new Model();
            Point point = new Point(50, 100);
            model.State = new DrawingState(false);

            model.CursorToDefault += HandleCursorToDefault;
            model.PanelMouseUp(point);
        }

        // 鍵盤按下按鍵測試
        [TestMethod()]
        public void FormKeyDownTest()
        {
            model = new Model();
            model.SelectShapeName = "線";
            model.CreateShapes();
            model.AddShape();

            model.BindingShapeList[0].Selected = true;
            System.Windows.Forms.Keys keys = System.Windows.Forms.Keys.Space;
            model.FormKeyDown(keys);
            Assert.AreEqual(1, model.BindingShapeList.Count);

            model.BindingShapeList[0].Selected = false;
            model.FormKeyDown(keys);
            Assert.AreEqual(1, model.BindingShapeList.Count);

            keys = System.Windows.Forms.Keys.Delete;
            model.BindingShapeList[0].Selected = false;
            model.FormKeyDown(keys);
            Assert.AreEqual(1, model.BindingShapeList.Count);

            model.BindingShapeList[0].Selected = true;
            model.PanelChanged += HandlePanelChanged;
            model.FormKeyDown(keys);
            Assert.AreEqual(0, model.BindingShapeList.Count);

            model.SelectShapeName = "線";
            model.CreateShapes();
            model.AddShape();
            keys = System.Windows.Forms.Keys.Delete;
            model.BindingShapeList[0].Selected = true;
            model.PanelChanged -= HandlePanelChanged;
            model.FormKeyDown(keys);
        }

        // 在畫布移動滑鼠時的cursor
        [TestMethod()]
        public void CursorChangedTest()
        {
            Point point = new Point(200, 200);
            model = new Model();
            model.SelectShapeName = "矩形";
            model.CreateShapes();
            model.AddShape();
            model.IsDrawing = true;
            model.CursorChanged(point);
            Assert.AreEqual(Cursors.Cross, model.Cursor);

            model.IsDrawing = false;
            privateObject = new PrivateObject(model);
            Shapes shapes = (Shapes)privateObject.GetFieldOrProperty("_shapes");
            shapes.Direction = -1;

            model.CursorChanged(point);
            Assert.AreEqual(Cursors.Default, model.Cursor);

            shapes.Direction = 1;
            model.CursorChanged(point);
            Assert.AreEqual(Cursors.Cross, model.Cursor);
        }
    }
}