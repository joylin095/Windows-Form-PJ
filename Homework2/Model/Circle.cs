using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Homework2
{
    public class Circle : Shape
    {
        const string CIRCLE = "圓";
        const int SIZE_X = 450;
        const int SIZE_Y = 350;
        const int SIZE_WIDTH = 200;
        const int SIZE_HEIGHT = 200;
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
        public Circle(IRandom random)
        {
            Name = CIRCLE;
            Selected = false;
            X1 = random.GetNext(0, SIZE_X);
            Width = random.GetNext(0, SIZE_WIDTH);
            Y1 = random.GetNext(0, SIZE_Y);
            Height = random.GetNext(0, SIZE_HEIGHT);
            UpdateLocation(new Point(X1, Y1), new Point(X1 + Width, Y1 + Height));
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
            if (Selected)
            {
                graphics.DrawSelectionBorder(X1, Y1, Width, Height);
            }
        }

        // 判斷點是否在範圍內
        public override bool IsRangeInPoint(Point point)
        {
            return (X1 + Width) >= point.X && point.X >= X1 && (Y1 + Height) >= point.Y && point.Y >= Y1;
        }

        // 判斷選取範圍是否在範圍內
        public override bool IsRangeInArea(Point firstPoint, Point secondPoint2)
        {
            return Math.Max(firstPoint.X, secondPoint2.X) >= X1 + Width
                && X1 >= Math.Min(firstPoint.X, secondPoint2.X)
                && Math.Max(firstPoint.Y, secondPoint2.Y) >= Y1 + Height
                && Y1 >= Math.Min(firstPoint.Y, secondPoint2.Y);
        }

        // 移動圖形
        public override void Move(Point point)
        {
            X1 += point.X;
            Y1 += point.Y;
            Location = GetLocation();
        }

        // 覆寫object.Equals()
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Circle otherRectangle = (Circle)obj;
            return Name == otherRectangle.Name;
        }

        //  覆寫 GetHashCode()
        public override int GetHashCode()
        {
            return new { Name }.GetHashCode();
        }
    }
}
