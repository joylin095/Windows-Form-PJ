using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace WindowsPractice.Ui.Tests
{
    [TestClass]
    public class UndoRedoTest
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
        private string LOCATION = "(40, 40),(160, 160)";
        private string ZOOM_NEW_LOCATION = "(40, 40),(280, 280)";
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

        // DrawLineRedoUndo
        [TestMethod]
        public void DrawLineRedoUndo()
        {
            _controlName = "線";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            RunScriptClickUndo();
            _robot.AssertDataGridViewCount(CONTROL_DATAGRIDVIEW, "0");
            RunScriptClickRedo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, LOCATION);
        }

        // DrawRectangleRedoUndo
        [TestMethod]
        public void DrawRectangleRedoUndo()
        {
            _controlName = "矩形";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            RunScriptClickUndo();
            _robot.AssertDataGridViewCount(CONTROL_DATAGRIDVIEW, "0");
            RunScriptClickRedo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, LOCATION);
        }

        // DrawCircleRedoUndo
        [TestMethod]
        public void DrawCircleRedoUndo()
        {
            _controlName = "圓";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            RunScriptClickUndo();
            _robot.AssertDataGridViewCount(CONTROL_DATAGRIDVIEW, "0");
            RunScriptClickRedo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, LOCATION);
        }

        // ZoomLineRedoUndo
        [TestMethod]
        public void ZoomLineRedoUndo()
        {
            _controlName = "線";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            RunScriptZoomShape(DX, DY);
            RunScriptClickUndo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, LOCATION);
            RunScriptClickRedo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, ZOOM_NEW_LOCATION);
        }

        // ZoomRectangleRedoUndo
        [TestMethod]
        public void ZoomRectangleRedoUndo()
        {
            _controlName = "矩形";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            RunScriptZoomShape(DX, DY);
            RunScriptClickUndo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, LOCATION);
            RunScriptClickRedo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, ZOOM_NEW_LOCATION);
        }

        // ZoomCircleRedoUndo
        [TestMethod]
        public void ZoomCircleRedoUndo()
        {
            _controlName = "圓";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            RunScriptZoomShape(DX, DY);
            RunScriptClickUndo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, LOCATION);
            RunScriptClickRedo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, ZOOM_NEW_LOCATION);
        }

        // MoveLineRedoUndo
        [TestMethod]
        public void MoveLineRedoUndo()
        {
            _controlName = "線";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            RunScriptMoveShape(SMALL_DX, SMALL_DY, DX, DY);
            RunScriptClickUndo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, LOCATION);
            RunScriptClickRedo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, MOVE_NEW_LOCATION);
        }

        // MoveRectangleRedoUndo
        [TestMethod]
        public void MoveRectangleRedoUndo()
        {
            _controlName = "矩形";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            RunScriptMoveShape(SMALL_DX, SMALL_DY, DX, DY);
            RunScriptClickUndo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, LOCATION);
            RunScriptClickRedo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, MOVE_NEW_LOCATION);
        }

        // MoveCircleRedoUndo
        [TestMethod]
        public void MoveCircleRedoUndo()
        {
            _controlName = "圓";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            RunScriptMoveShape(SMALL_DX, SMALL_DY, DX, DY);
            RunScriptClickUndo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, LOCATION);
            RunScriptClickRedo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, MOVE_NEW_LOCATION);
        }

        // DataGridViewLineRedoUndo
        [TestMethod]
        public void DataGridViewLineRedoUndo()
        {
            _controlName = "線";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            RunScriptDataGridViewDeleteShape(CONTROL_DATAGRIDVIEW, 0);
            RunScriptClickUndo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, LOCATION);
            RunScriptClickRedo();
            _robot.AssertDataGridViewCount(CONTROL_DATAGRIDVIEW, "0");
        }

        // DataGridViewRectangleRedoUndo
        [TestMethod]
        public void DataGridViewRectangleRedoUndo()
        {
            _controlName = "矩形";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            RunScriptDataGridViewDeleteShape(CONTROL_DATAGRIDVIEW, 0);
            RunScriptClickUndo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, LOCATION);
            RunScriptClickRedo();
            _robot.AssertDataGridViewCount(CONTROL_DATAGRIDVIEW, "0");
        }

        // DataGridViewCircleRedoUndo
        [TestMethod]
        public void DataGridViewCircleRedoUndo()
        {
            _controlName = "圓";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            RunScriptDataGridViewDeleteShape(CONTROL_DATAGRIDVIEW, 0);
            RunScriptClickUndo();
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, LOCATION);
            RunScriptClickRedo();
            _robot.AssertDataGridViewCount(CONTROL_DATAGRIDVIEW, "0");
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

        // run delete
        private void RunScriptDataGridViewDeleteShape(string name, int row)
        {
            _robot.ClickDataGridViewDelete(name, row);
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
    }
}
