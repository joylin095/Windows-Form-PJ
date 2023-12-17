using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using WindowsPractice.Tests;

namespace WindowsPractice.Ui.Tests
{
    /// <summary>
    /// Summary description for MainFormUITest
    /// </summary>
    [TestClass()]
    public class DrawTest
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
        private string LOCATION = "(40, 40),(160, 160)";

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

        // run ButtonChecked
        private void RunScriptToolStripButtonChecked(string controlName)
        {
            _robot.ClickButton(controlName);
        }

        // run draw
        private void RunScriptDrawShape(string controlName, int x, int y, int dx, int dy)
        {
            _robot.ClickButton(controlName);
            _robot.MouseDownHoldMoveReleaseTheControl(CONTROL_PANEL, x, y, dx, dy);
        }

        // line button checked
        [TestMethod]
        public void TestToolStripButtonLineChecked()
        {
            _controlName = "線";
            RunScriptToolStripButtonChecked(_controlName);
            _robot.AssertToolStritButtonChecked(_controlName);
        }

        // line button checked
        [TestMethod]
        public void TestToolStripButtonRectangleChecked()
        {
            _controlName = "矩形";
            RunScriptToolStripButtonChecked(_controlName);
            _robot.AssertToolStritButtonChecked(_controlName);
        }

        // line button checked
        [TestMethod]
        public void TestToolStripButtonCircleChecked()
        {
            _controlName = "圓";
            RunScriptToolStripButtonChecked(_controlName);
            _robot.AssertToolStritButtonChecked(_controlName);
        }

        // draw line
        [TestMethod]
        public void TestDrawLine()
        {
            _controlName = "線";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, LOCATION);
        }

        // draw rectangle
        [TestMethod]
        public void TestDrawRectangle()
        {
            _controlName = "矩形";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, LOCATION);
        }

        // draw line
        [TestMethod]
        public void TestDrawCircle()
        {
            _controlName = "圓";
            RunScriptDrawShape(_controlName, X, Y, DX, DY);
            _robot.AssertDataGridViewShapeAndLocationCell(CONTROL_DATAGRIDVIEW, 0, _controlName, LOCATION);
        }
    }
}

