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
        Dictionary<int, (Point X1Y1, Point WidthHeight)> beforeMove;
        Dictionary<int, (Point X1Y1, Point WidthHeight)> afterMove;
        MoveCommand moveCommand;

        // 初始化
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model();
            model.SelectShapeName = "線";
            model.CreateShapes();
            model.AddShape();
            beforeMove = new Dictionary<int, (Point X1Y1, Point WidthHeight)>();
            beforeMove.Add(0, (new Point(100, 100), new Point(200, 200)));
            afterMove = new Dictionary<int, (Point X1Y1, Point WidthHeight)>();
            afterMove.Add(0, (new Point(200, 200), new Point(400, 400)));
            moveCommand = new MoveCommand(model, beforeMove, afterMove, 0);
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