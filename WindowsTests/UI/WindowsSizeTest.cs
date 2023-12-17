using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading;

namespace WindowsPractice.Ui.Tests
{
    [TestClass]
    public class WindowsSizeTest
    {
        private Robot _robot;
        private string targetAppPath;
        private const string FORM_CONTROL = "Form1";
        private const string BUTTON1_CONTROL = "_button1";
        private const string PANEL_CONTROL = "_panel1";
        private const int X = 2;
        private const int Y = 2;
        private const int DX = 100;
        private const int DY = 100;
        float ratio = 16.0f / 9.0f;

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

        // windows resize test
        [TestMethod]
        public void WindowsResizeTest()
        {
            _robot.MouseDownHoldMoveReleaseTheControl(FORM_CONTROL, X, Y, DX, DY);
            Thread.Sleep(500);

            _robot.AssertRatio(PANEL_CONTROL, ratio);
            _robot.AssertRatio(BUTTON1_CONTROL, ratio);
        }
    }
}
