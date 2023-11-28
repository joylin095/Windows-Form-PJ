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
    public class PresentationModelTests
    {
        PresentationModel presentationModel;
        Model model;
        PrivateObject privateObject;
        List<string> shapeNameList;

        // 初始化
        [TestInitialize]
        public void Initialize()
        {
            shapeNameList = new List<string>();
            shapeNameList.Add("線");
            shapeNameList.Add("矩形");
            shapeNameList.Add("圓");
        }

        // 測試建構式
        [TestMethod()]
        public void PresentationModelTest()
        {
            model = new Model();
            presentationModel = new PresentationModel(model);
            Assert.IsTrue(model.State is NormalState);
        }

        // 測試儲存的shpae名稱
        [TestMethod()]
        public void RecordAllShapeNameTest()
        {
            model = new Model();
            presentationModel = new PresentationModel(model);
            privateObject = new PrivateObject(presentationModel);
            presentationModel.RecordAllShapeName(shapeNameList);
            Assert.AreEqual(shapeNameList, privateObject.GetFieldOrProperty("_allShapeNameList"));
        }

        // 測試更新狀態
        [TestMethod()]
        public void SetStateTest()
        {
            model = new Model();
            presentationModel = new PresentationModel(model);
            presentationModel.RecordAllShapeName(shapeNameList);

            presentationModel.SetState();
            Assert.IsTrue(model.State is NormalState);
            Assert.AreEqual(null, model.SelectShapeName);
            Assert.IsFalse(model.IsDrawing);

            model.State = new SelectState(false);
            presentationModel.SetState();

            presentationModel.ToolBarCheckedList[0].Value = true;
            presentationModel.SetState();
            Assert.IsTrue(model.State is DrawingState);
            Assert.AreEqual("線", model.SelectShapeName);
            Assert.IsTrue(model.IsDrawing);


        }

        // 測試ToolStripButton更新checked
        [TestMethod()]
        public void ToolStripButtonClickTest()
        {
            model = new Model();
            presentationModel = new PresentationModel(model);
            presentationModel.RecordAllShapeName(shapeNameList);
            presentationModel.ToolStripButtonClick("線");

            Assert.IsTrue(presentationModel.ToolBarCheckedList[0].Value);
        }

        // 測試按下左鍵
        [TestMethod()]
        public void Panel1MouseDownTest()
        {
            Point point = new Point(50, 100);
            model = new Model();
            MockState mockState = new MockState();
            model.State = mockState;
            presentationModel = new PresentationModel(model);
            model.State = mockState;
            presentationModel.Panel1MouseDown(point);
            
            privateObject = new PrivateObject(presentationModel);
            Model privatModel = (Model)privateObject.GetFieldOrProperty("_model");
            bool privateMockMousePressed = privatModel.State.TestMousePressed;
            Assert.IsTrue(privateMockMousePressed);
        }

        // 在畫佈移動滑鼠時
        [TestMethod()]
        public void Panel1MouseMoveTest()
        {
            Point point = new Point(100, 150);
            model = new Model();
            MockState mockState = new MockState();
            presentationModel = new PresentationModel(model);
            model.State = mockState;
            presentationModel.Panel1MouseMove(point);     

            privateObject = new PrivateObject(presentationModel);
            Model privateModel = (Model)privateObject.GetFieldOrProperty("_model");
            Point privateMockStatePoint = privateModel.State.TestPoint;
            Assert.AreEqual(point, privateMockStatePoint);
        }

        // 在畫佈放開左鍵時
        [TestMethod()]
        public void Panel1MouseUpTest()
        {
            Point point = new Point(50, 100);
            model = new Model();
            MockState mockState = new MockState();
            presentationModel = new PresentationModel(model);
            model.State = mockState;

            presentationModel.RecordAllShapeName(shapeNameList);
            presentationModel.Panel1MouseUp(point);

            privateObject = new PrivateObject(presentationModel);
            Model privateModel = (Model)privateObject.GetFieldOrProperty("_model");
            bool privateMockMousePressed = privateModel.State.TestMousePressed;
            Assert.IsFalse(privateMockMousePressed);
            Assert.IsFalse(presentationModel.ToolBarCheckedList[0].Value);
        }
    }
}