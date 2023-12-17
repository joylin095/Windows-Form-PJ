using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPractice
{
    public class Factory
    {
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "圓";

        // 創建shape
        public Shape CreateShape(string shapeName, Point x1Y1 = default, Point x2Y2 = default)
        {
            switch (shapeName)
            {
                case RECTANGLE:
                    return new Rectangle(x1Y1, x2Y2);
                case LINE:
                    return new Line(x1Y1, x2Y2);
                case CIRCLE:
                    return new Circle(x1Y1, x2Y2);
                default:
                    return null;
            }
        }
    }
}
