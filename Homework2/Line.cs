using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Homework2
{
    class Line:Shape
    {
        
        public int X1
        {
            get;
            set;
        }
        public int Y1
        {
            get;
            set;
        }
        public int X2
        {
            get;
            set;
        }
        public int Y2
        {
            get;
            set;
        }
        public Line()
        {
            Name = "線";
            Random rand = new Random();
            X1 = rand.Next(0, 250);
            Y1 = rand.Next(0, 250);
            X2 = rand.Next(0, 250);
            Y2 = rand.Next(0, 250);
            Location = GetLocation();
        }

        // 回傳圖形座標
        public override string GetLocation()
        {
            return $"({X1}, {Y1}),({X2}, {Y2})";
        }

        // 更新座標
        public override void UpdateLocation(Point firstPoint, Point newPoint)
        {
            X1 = firstPoint.X;
            Y1 = firstPoint.Y;
            X2 = newPoint.X;
            Y2 = newPoint.Y;
            Location = GetLocation();
        }

        // 畫圖
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(X1, Y1, X2, Y2);
        }
    }
}
