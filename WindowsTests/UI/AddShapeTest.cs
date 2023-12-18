using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading;

namespace WindowsPractice.Ui.Tests
{
    [TestClass]
    public class AddShapeTest
    {
        private Robot _robot;
        private string targetAppPath;
        private string _controlName = "線";
        private const string CONTROL_DATAGRIDVIEW = "_recordDataGridView";
        private const string CONTROL_SELECT_SHAPE_BOX = "_selectShapeBox";
        private const string CONTROL_ADD_DATA_BUTTON = "新增";
        private const string CONTROL_INPUT_FORM = "inputForm";
        private const string CONTROL_INPUT_FORM_TOP_LEFT_X = "_topLeftInputX";
        private const string CONTROL_INPUT_FORM_TOP_LEFT_Y = "_topLeftInputY";
        private const string CONTROL_INPUT_FORM_BOTTOM_RIGHT_X = "_bottomRightInputX";
        private const string CONTROL_INPUT_FORM_BOTTOM_RIGHT_Y = "_bottomRightInputY";
        private const string TOP_LEFT_X = "50";
        private const string TOP_LEFT_Y = "50";
        private const string BOTTOM_RIGHT_X = "150";
        private const string BOTTOM_RIGHT_Y = "150";
        private const string LOCATION = "(50, 50),(150, 150)";
        private const string CONTROL_OK_BUTTON = "確定";
        // init
        [TestInitialize()]
        public void Initialize()
        {
            var projectName = "WindowsProgramming";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "WindowsProgramming.exe");
            _robot = new Robot(targetAppPath, projectName);
        }

        //clean
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        [TestMethod]
        public void AddShape()
        {
            RunAddShape("線", 0);
            RunAddShape("矩形", 1);
            RunAddShape("圓", 2);
        }

        // run script add line
        private void RunAddShape(string controlShapeName, int row)
        {
            _controlName = controlShapeName;
            _robot.SelectShape(CONTROL_SELECT_SHAPE_BOX, _controlName);
            _robot.ClickButton(CONTROL_ADD_DATA_BUTTON);
            Thread.Sleep(500);
            _robot.InputShapePoint(CONTROL_INPUT_FORM, CONTROL_INPUT_FORM_TOP_LEFT_X, TOP_LEFT_X);
            _robot.InputShapePoint(CONTROL_INPUT_FORM, CONTROL_INPUT_FORM_TOP_LEFT_Y, TOP_LEFT_Y);
            _robot.InputShapePoint(CONTROL_INPUT_FORM, CONTROL_INPUT_FORM_BOTTOM_RIGHT_X, BOTTOM_RIGHT_X);
            _robot.InputShapePoint(CONTROL_INPUT_FORM, CONTROL_INPUT_FORM_BOTTOM_RIGHT_Y, BOTTOM_RIGHT_Y);
            _robot.ClickButton(CONTROL_OK_BUTTON);

            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, row, controlShapeName, LOCATION);
        }
    }
}
