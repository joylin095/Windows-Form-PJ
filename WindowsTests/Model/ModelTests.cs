using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsPractice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using WindowsPractice.States;

namespace WindowsPractice.Tests
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
        Point x1y1 = new Point(200, 200);
        Point x2y2 = new Point(300, 300);

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
            Assert.IsFalse(model.IsRedoEnabled);
            Assert.IsFalse(model.IsUndoEnabled);
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

            model._panelChanged += HandlePanelChanged;
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

            model._cursorToDefault += HandleCursorToDefault;
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
            model._panelChanged += HandlePanelChanged;
            model.FormKeyDown(keys);
            Assert.AreEqual(0, model.BindingShapeList.Count);

            model.SelectShapeName = "線";
            model.CreateShapes();
            model.AddShape();
            keys = System.Windows.Forms.Keys.Delete;
            model.BindingShapeList[0].Selected = true;
            model._panelChanged -= HandlePanelChanged;
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
            model.ChangeCursor(point);
            Assert.AreEqual(Cursors.Cross, model.Cursor);

            model.IsDrawing = false;
            privateObject = new PrivateObject(model);
            Shapes shapes = (Shapes)privateObject.GetFieldOrProperty("_shapes");
            shapes.Direction = -1;

            model.ChangeCursor(point);
            Assert.AreEqual(Cursors.Default, model.Cursor);

            shapes.Direction = 1;
            model.ChangeCursor(point);
            Assert.AreEqual(Cursors.Cross, model.Cursor);
        }

        // scale test
        [TestMethod()]
        public void SetScale()
        {
            model = new Model();
            model.SetScale(2, 2);
        }

        // draw command test
        [TestMethod()]
        public void DrawCommandTest()
        {
            model = new Model();
            model.SelectShapeName = "線";
            model.CreateShapes();
            model.DrawCommand();
        }

        // add command test
        [TestMethod()]
        public void AddCommandTest()
        {
            model = new Model();
            model.AddCommand("線", x1y1, x2y2);
        }

        // delete command test
        [TestMethod()]
        public void DeleteCommandTest()
        {
            Dictionary<Shape, int> deleteShapeList = new Dictionary<Shape, int>();
            deleteShapeList.Add(new Line(), 0);
            model = new Model();
            model.AddCommand("線", x1y1, x2y2);

            model.DeleteCommand(deleteShapeList);
        }

        // move command
        [TestMethod()]
        public void MoveCommandTest()
        {
            Dictionary<int, (Point X1Y1, Point WidthHeight)> beforeMove = new Dictionary<int, (Point X1Y1, Point WidthHeight)>();
            beforeMove.Add(0, (new Point(50, 50), new Point(100, 100)));
            model = new Model();
            model.AddCommand("線", x1y1, x2y2);
            model.BindingShapeList[0].Selected = true;
            privateObject = new PrivateObject(model);
            privateObject.SetFieldOrProperty("_beforeMove", beforeMove);

            model.MoveCommand();

            beforeMove[0] = (new Point(200, 200), new Point(400, 400));
            model.BindingShapeList[0].SetX1Y1WidthHeightTuple(new Point(200, 200), new Point(400, 400));
            model.MoveCommand();

            model.BindingShapeList[0].Selected = false;
            model.MoveCommand();
        }

        // move before test
        [TestMethod()]
        public void MoveBeforeTest()
        {
            model = new Model();
            model.AddCommand("線", x1y1, x2y2);
            model.BindingShapeList[0].Selected = true;

            model.MoveBefore();

            model.BindingShapeList[0].Selected = false;
            model.MoveBefore();
        }

        // undo test
        [TestMethod()]
        public void UndoTest()
        {
            model = new Model();
            model.AddCommand("線", x1y1, x2y2);
            model.Undo();
        }

        // redo test
        [TestMethod()]
        public void RedoTest()
        {
            model = new Model();
            model.AddCommand("線", x1y1, x2y2);
            model.Undo();
            model.Redo();
        }
    }
}