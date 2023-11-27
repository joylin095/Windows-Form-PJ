using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Tests
{
    [TestClass()]
    public class FactoryTests
    {
        Factory factory;
        Shape expectedShape;

        //  測試創建shape
        [TestMethod()]
        public void CreateShapeTest()
        {
            factory = new Factory();
            // 測試創矩形
            Shape shape = factory.CreateShape("矩形");
            expectedShape = new Rectangle(new RandomGenerator());
            Assert.AreEqual(expectedShape, shape);

            // 測試創線
            shape = factory.CreateShape("線");
            expectedShape = new Line(new RandomGenerator());
            Assert.AreEqual(expectedShape, shape);

            // 測試創圓形
            shape = factory.CreateShape("圓");
            expectedShape = new Circle(new RandomGenerator());
            Assert.AreEqual(expectedShape, shape);

            // 測試null
            shape = factory.CreateShape("??");
            expectedShape = null;
            Assert.AreEqual(expectedShape, shape);
        }
    }
}