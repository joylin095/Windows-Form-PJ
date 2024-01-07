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
    public class AddPageCommandTests
    {
        Model model;
        Shapes shapes;
        AddPageCommand addCommand;

        // 初始化
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model();
            shapes = new Shapes();
            addCommand = new AddPageCommand(model, shapes, 0);
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