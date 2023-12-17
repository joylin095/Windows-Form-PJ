using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace WindowsPractice.Ui.Tests
{
    [TestClass]
    public class MoveTest
    {
        private Robot _robot;
        private string targetAppPath;
        private string _controlName = "線";
        private const string CONTROL_PANEL = "_panel1";
        private const string CONTROL_DATAGRIDVIEW = "_recordDataGridView";
        private const int X = 50;
        private const int Y = 50;
        private const int DX = 150;
        private const int DY = 150;
        private const int SMALL_DX = 30;
        private const int SMALL_DY = 30;
        private string MOVE_NEW_LOCATION = "(160, 160),(280, 280)";

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

        // MoveLineRedoUndo
        [TestMethod]
        public void MoveLineRedoUndo()
        {
            _controlName = "線";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            RunScriptMoveShape(SMALL_DX, SMALL_DY, DX, DY);
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, MOVE_NEW_LOCATION);
        }

        // MoveRectangleRedoUndo
        [TestMethod]
        public void MoveRectangleRedoUndo()
        {
            _controlName = "矩形";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            RunScriptMoveShape(SMALL_DX, SMALL_DY, DX, DY);
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, MOVE_NEW_LOCATION);
        }

        // MoveCircleRedoUndo
        [TestMethod]
        public void MoveCircleRedoUndo()
        {
            _controlName = "圓";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            RunScriptMoveShape(SMALL_DX, SMALL_DY, DX, DY);
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, MOVE_NEW_LOCATION);
        }

        // run draw
        private void RunScriptDrawShape(string controlName, int x, int y, int dx, int dy)
        {
            _robot.ClickButton(controlName);
            _robot.MouseDownHoldMoveReleaseTheControl(CONTROL_PANEL, x, y, dx, dy);
        }

        // run move
        private void RunScriptMoveShape(int smallDx, int smallDy, int dx, int dy)
        {
            _robot.MoveShape(smallDx, smallDy, dx, dy);
        }
    }
}
