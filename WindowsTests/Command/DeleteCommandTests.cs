using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsPractice.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPractice.Command.Tests
{
    [TestClass()]
    public class DeleteCommandTests
    {
        Model model;
        Dictionary<Shape, int> deleteShapeList;
        DeleteCommand deleteCommand;

        // 初始化
        [TestInitialize()]
        public void Initialize()
        {
            deleteShapeList = new Dictionary<Shape, int>();
            model = new Model();
            model.SelectShapeName = "線";
            model.CreateShapes();
            model.AddShape();
            deleteShapeList.Add(new Line(), 0);
            deleteCommand = new DeleteCommand(model, deleteShapeList);
        }

        // do test
        [TestMethod()]
        public void ExecuteTest()
        {
            deleteCommand.Execute();
        }

        // undo test
        [TestMethod()]
        public void CancelExecuteTest()
        {
            deleteCommand.CancelExecute();
        }
    }
}