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
    public class AddCommandTests
    {
        Model model;
        Shape shape;
        AddCommand addCommand;

        // 初始化
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model();
            shape = new Line(new MockRandomGenerator());
            addCommand = new AddCommand(model, shape);
        }

        // do test
        [TestMethod()]
        public void ExecuteTest()
        {
            addCommand.Execute();
        }

        // undo test
        [TestMethod()]
        public void CancelExecuteTest()
        {
            addCommand.Execute();
            addCommand.CancelExecute();
        }
    }
}