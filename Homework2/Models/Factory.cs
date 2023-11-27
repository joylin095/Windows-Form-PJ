using Homework2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public class Factory
    {
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "圓";

        // 創建shape
        public Shape CreateShape(string shapeName)
        {
            switch (shapeName)
            {
                case RECTANGLE:
                    return new Rectangle(new RandomGenerator());
                case LINE:
                    return new Line(new RandomGenerator());
                case CIRCLE:
                    return new Circle(new RandomGenerator());
                default:
                    return null;
            }
        }
    }
}
