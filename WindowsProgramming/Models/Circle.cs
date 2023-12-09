using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsPractice
{
    public class Circle : Shape
    {
        const string FORMAT = "({0}, {1}),({2}, {3})";
        const string CIRCLE = "圓";
        const int SIZE_X = 450;
        const int SIZE_Y = 250;
        const int SIZE_WIDTH = 150;
        const int SIZE_HEIGHT = 150;
        Point _tempX1Y1;
        Point _tempWidthHeight;
        float _scaleWidth = 1;
        float _scaleHeight = 1;

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
            return String.Format(FORMAT, (int)(X1 * _scaleWidth), (int)(Y1 * _scaleHeight), (int)((X1 + Width) * _scaleWidth), (int)((Y1 + Height) * _scaleHeight));
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
            if (Selected)
            {
                X1 += point.X;
                Y1 += point.Y;
                Location = GetLocation();
            }
        }

        // 放大縮小
        public override void ZoomInOut(Point incrementX1Y1, Point incrementWidthHeight)
        {
            if (Selected)
            {
                _tempX1Y1.X += incrementX1Y1.X;
                _tempX1Y1.Y += incrementX1Y1.Y;
                _tempWidthHeight.X += incrementWidthHeight.X;
                _tempWidthHeight.Y += incrementWidthHeight.Y;
                UpdateLocation(_tempX1Y1, new Point(_tempX1Y1.X + _tempWidthHeight.X, _tempX1Y1.Y + _tempWidthHeight.Y));
            }
        }

        //xy point
        public override Point GetX1Y1Point()
        {
            _tempX1Y1 = new Point(X1, Y1);
            return new Point(X1, Y1);
        }

        // 寬高point
        public override Point GetWidthHeightPoint()
        {
            _tempWidthHeight = new Point(Width, Height);
            return new Point(Width, Height);
        }

        // scale point
        public override void SetScale(float scaleWidth, float scaleHeight)
        {
            _scaleWidth =  scaleWidth;
            _scaleHeight = scaleHeight;
            Location = GetLocation();
        }

        // set寬高(tuple)
        public override void SetX1Y1WidthHeightTuple(Point x1Y1, Point widthHeight)
        {
            X1 = x1Y1.X;
            Y1 = x1Y1.Y;
            Width = widthHeight.X;
            Height = widthHeight.Y;
            Location = GetLocation();
        }

        // get寬高(tuple)
        public override (Point x1Y1, Point widthHeight) GetX1Y1WidthHeightTuple()
        {
            return (new Point(X1, Y1), new Point(Width, Height));
        }
    }
}
