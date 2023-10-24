using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Homework2
{
    public class Circle:Shape
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
        public int Width
        {
            get;
            set;
        }
        public int Height
        {
            get;
            set;
        }
        public Circle()
        {
            Name = "圓";
            Random rand = new Random();
            X1 = rand.Next(0, 250);
            Width = rand.Next(0, 250);
            Y1 = rand.Next(0, 250);
            Height = rand.Next(0, 250);
            Location = GetLocation();
        }

        // 回傳圖形座標
        public override string GetLocation()
        {
            return $"({X1}, {Y1}),({X1 + Width}, {Y1 + Height})";
        }

        // 更新座標
        public override void UpdateLocation(Point firstPoint, Point newPoint)
        {
            X1 = Math.Min(firstPoint.X, newPoint.X);
            Y1 = Math.Min(firstPoint.Y, newPoint.Y);
            Width = Math.Abs(newPoint.X - firstPoint.X);
            Height = Math.Abs(newPoint.Y - firstPoint.Y);
            Location = GetLocation();
        }

        // 畫圖
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawCircle(X1, Y1, Width, Height);
        }
    }
}
