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
    public class CommandManagerTests
    {
        Stack<ICommand> undo;
        Stack<ICommand> redo;
        CommandManager commandManager;
        ICommand command;
        Model model;
        Shape shape;
        PrivateObject privateObject;

        //初始化
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model();
            shape = new Line();
            command = new AddCommand(model, shape);
            undo = new Stack<ICommand>();
            redo = new Stack<ICommand>();
            commandManager = new CommandManager();
            privateObject = new PrivateObject(commandManager);
        }

        // do test
        [TestMethod()]
        public void ExecuteTest()
        {
            commandManager.Execute(command);
            undo = (Stack<ICommand>)privateObject.GetFieldOrProperty("_undo");
            redo = (Stack<ICommand>)privateObject.GetFieldOrProperty("_redo");

            Assert.AreEqual(1, undo.Count);
            Assert.AreEqual(0, redo.Count);
            Assert.IsTrue(commandManager.IsUndoEnabled);
            Assert.IsFalse(commandManager.IsRedoEnabled);
        }

        // undo test
        [TestMethod()]
        public void UndoTest()
        {
            commandManager.Execute(command);
            commandManager.Undo();
            undo = (Stack<ICommand>)privateObject.GetFieldOrProperty("_undo");
            redo = (Stack<ICommand>)privateObject.GetFieldOrProperty("_redo");

            Assert.AreEqual(1, redo.Count);
            Assert.IsTrue(commandManager.IsRedoEnabled);
        }

        // redo test
        [TestMethod()]
        public void RedoTest()
        {
            commandManager.Execute(command);
            commandManager.Undo();
            commandManager.Redo();
            undo = (Stack<ICommand>)privateObject.GetFieldOrProperty("_undo");
            redo = (Stack<ICommand>)privateObject.GetFieldOrProperty("_redo");

            Assert.AreEqual(1, undo.Count);
            Assert.IsTrue(commandManager.IsUndoEnabled);
        }
    }
}