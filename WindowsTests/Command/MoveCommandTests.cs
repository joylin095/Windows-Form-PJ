using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsPractice.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsPractice.Command.Tests
{
    [TestClass()]
    public class MoveCommandTests
    {
        Model model;
        Dictionary<(Point X1Y1, Point WidthHeight), int> beforeMove;
        Dictionary<(Point X1Y1, Point WidthHeight), int> afterMove;
        MoveCommand moveCommand;

        // 初始化
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model();
            model.SelectShapeName = "線";
            model.CreateShapes();
            model.AddShape();
            beforeMove = new Dictionary<(Point X1Y1, Point WidthHeight), int>();
            beforeMove.Add((new Point(100, 100), new Point(200, 200)), 0);
            afterMove = new Dictionary<(Point X1Y1, Point WidthHeight), int>();
            afterMove.Add((new Point(200, 200), new Point(400, 400)), 0);
            moveCommand = new MoveCommand(model, beforeMove, afterMove);
        }

        // do test
        [TestMethod()]
        public void ExecuteTest()
        {
            moveCommand.Execute();
        }

        // undo test
        [TestMethod()]
        public void CancelExecuteTest()
        {
            moveCommand.CancelExecute();
        }
    }
}