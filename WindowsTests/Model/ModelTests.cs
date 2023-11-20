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
    public class MockState : IState
    {
        // 在畫布滑鼠按下 
        public override void PanelMouseDown(Model model, Point point)
        {
            _testmousePressed = true;
            _testPoint = point;
        }

        // 在畫布滑鼠移動
        public override void PanelMouseMove(Model model, Point point)
        {
            _testPoint = point;
        }

        // 在畫布滑鼠放開
        public override void PanelMouseUp(Model model, Point point)
        {
            _testmousePressed = false;
            _testPoint = point;
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

        [TestMethod()]
        public void DrawTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetShapeFirstPointTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateLocationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PanelMouseDownTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PanelMouseMoveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PanelMouseUpTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FormKeyDownTest()
        {
            Assert.Fail();
        }
    }
}