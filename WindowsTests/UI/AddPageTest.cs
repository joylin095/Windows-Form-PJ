using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading;

namespace WindowsPractice.Ui.Tests
{
    [TestClass]
    public class AddPageTest
    {
        private Robot _robot;
        private string targetAppPath;
        private string _controlName = "新增頁面";

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

        // create test
        [TestMethod]
        public void AddShape()
        {
            RunAddPage();
        }

        // create
        private void RunAddPage()
        {
            _robot.ClickButton(_controlName);
        }
    }
}
