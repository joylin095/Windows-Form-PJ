using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading;

namespace WindowsPractice.Ui.Tests
{
    [TestClass]
    public class AllTest
    {
        private Robot _robot;
        private string targetAppPath;
        private string _controlName = "線";
        private const string CONTROL_PANEL = "_panel1";
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
        private const int X = 150;
        private const int Y = 150;
        private const int DX = 150;
        private const int DY = 150;
        private const int SMALL_DX = 30;
        private const int SMALL_DY = 30;
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

        // add shape test
        [TestMethod]
        public void AddShape()
        {
            RunAddShape("矩形", 0);

            RunScriptDrawShape("圓", X, Y, DX, DY);

            RunScriptDrawShape("矩形", X + SMALL_DX, Y - SMALL_DY, DX, DY);
            RunScriptZoomShape(DX - SMALL_DX, DY - SMALL_DY);
            Thread.Sleep(500);
            RunScriptMoveShape(SMALL_DX, SMALL_DY, DX, 0);
            Thread.Sleep(500);
            RunScriptClickUndo();
            RunScriptClickRedo();
            RunScriptDataGridViewDeleteShape(CONTROL_DATAGRIDVIEW, 2);
            Thread.Sleep(500);

            RunAddPage();

            RunAddShape("線", 0);

            RunScriptDrawShape("圓", X, Y, DX, DY);

            Thread.Sleep(500);
            RunScriptClickUndo();

            Thread.Sleep(500);
            RunScriptClickUndo();

            Thread.Sleep(500);
            RunScriptClickUndo();

            Thread.Sleep(500);
        }

        // run add page
        private void RunAddPage()
        {
            _robot.ClickButton("新增頁面");
            _robot.ClickAccessibilityIdButton("_button1");
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
        }

        // run draw
        private void RunScriptDrawShape(string controlName, int x, int y, int dx, int dy)
        {
            _robot.ClickButton(controlName);
            _robot.MouseDownHoldMoveReleaseTheControl(CONTROL_PANEL, x, y, dx, dy);
        }

        // run zoom
        private void RunScriptZoomShape(int dx, int dy)
        {
            _robot.ZoomShape(dx, dy);
        }

        // run move
        private void RunScriptMoveShape(int smallDx, int smallDy, int dx, int dy)
        {
            _robot.MoveShape(smallDx, smallDy, dx, dy);
        }

        // click undo
        private void RunScriptClickUndo()
        {
            _robot.ClickButton("Undo");
        }

        // click redo
        private void RunScriptClickRedo()
        {
            _robot.ClickButton("Redo");
        }

        // run delete
        private void RunScriptDataGridViewDeleteShape(string name, int row)
        {
            _robot.ClickDataGridViewDelete(name, row);
        }
    }
}
