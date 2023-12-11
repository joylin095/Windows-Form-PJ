﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsPractice.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPractice.Command.Tests
{
    [TestClass()]
    public class DrawCommandTests
    {
        Model model;
        Shape shape;
        DrawCommand drawCommand;

        // 初始化
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model();
            shape = new Line(new MockRandomGenerator());
            drawCommand = new DrawCommand(model, shape);
        }

        // do test
        [TestMethod()]
        public void ExecuteTest()
        {
            drawCommand.Execute();
        }

        // undo test
        [TestMethod()]
        public void CancelExecuteTest()
        {
            drawCommand.Execute();
            drawCommand.CancelExecute();
        }
    }
}