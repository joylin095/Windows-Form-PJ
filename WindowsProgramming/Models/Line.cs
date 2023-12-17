using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace WindowsPractice
{
    public class Line : Shape
    {
        const string FORMAT = "({0}, {1}),({2}, {3})";
        const string LINE = "線";
        const int SIZE_X1 = 600;
        const int SIZE_Y1 = 300;
        const int SIZE_X2 = 600;
        const int SIZE_Y2 = 300;
        Point _tempX1Y1;
        Point _tempWidthHeight;
        bool _isDownLeftUpRight;
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
        public Line(Point x1Y1 = default, Point x2Y2 = default)
        {
            Name = LINE;
            Selected = false;
            UpdateLocation(new Point(x1Y1.X, x1Y1.Y), new Point(x2Y2.X, x2Y2.Y));
        }

        // 回傳圖形座標
        public override string GetLocation()
        {
            return String.Format(FORMAT, (int)(X1 * _scaleWidth), (int)(Y1 * _scaleHeight), (int)(X2 * _scaleWidth), (int)(Y2 * _scaleHeight));
        }

        // 更新座標
        public override void UpdateLocation(Point firstPoint, Point newPoint)
        {
            if (firstPoint.X <= newPoint.X)
            {
                X1 = firstPoint.X;
                Y1 = firstPoint.Y;
                X2 = newPoint.X;
                Y2 = newPoint.Y;
            }
            else
            {
                X1 = newPoint.X;
                Y1 = newPoint.Y;
                X2 = firstPoint.X;
                Y2 = firstPoint.Y;
            }
            Location = GetLocation();
        }

        // 畫圖
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(X1, Y1, X2, Y2);
            if (Selected)
            {
                graphics.DrawSelectionBorder(Math.Min(X1, X2), Math.Min(Y1, Y2), Math.Max(X1, X2) - Math.Min(X1, X2), Math.Max(Y1, Y2) - Math.Min(Y1, Y2));
            }
        }

        // 判斷點是否在範圍內
        public override bool IsRangeInPoint(Point point)
        {
            return Math.Max(X1, X2) >= point.X && point.X >= Math.Min(X1, X2) && Math.Max(Y1, Y2) >= point.Y && point.Y >= Math.Min(Y1, Y2);
        }

        //判斷選取範圍是否在範圍內
        public override bool IsRangeInArea(Point firstPoint, Point secondPoint2)
        {
            return Math.Max(firstPoint.X, secondPoint2.X) >= Math.Max(X1, X2)
                && Math.Min(X1, X2) >= Math.Min(firstPoint.X, secondPoint2.X)
                && Math.Max(firstPoint.Y, secondPoint2.Y) >= Math.Max(Y1, Y2)
                && Math.Min(Y1, Y2) >= Math.Min(firstPoint.Y, secondPoint2.Y);
        }

        // 移動圖形
        public override void Move(Point point)
        {
            if (Selected)
            {
                X1 += point.X;
                X2 += point.X;
                Y1 += point.Y;
                Y2 += point.Y;
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
                if (_isDownLeftUpRight)
                {
                    UpdateLocation(new Point(_tempX1Y1.X, _tempX1Y1.Y + _tempWidthHeight.Y), new Point(_tempX1Y1.X + _tempWidthHeight.X, _tempX1Y1.Y));
                }
                else
                {
                    UpdateLocation(_tempX1Y1, new Point(_tempX1Y1.X + _tempWidthHeight.X, _tempX1Y1.Y + _tempWidthHeight.Y));
                }
            }
        }

        //xy point
        public override Point GetX1Y1Point()
        {
            if (Y1 > Y2)
            {
                _isDownLeftUpRight = true;
            }
            else
            {
                _isDownLeftUpRight = false;
            }
            _tempX1Y1 = new Point(Math.Min(X1, X2), Math.Min(Y1, Y2));
            return new Point(Math.Min(X1, X2), Math.Min(Y1, Y2));
        }

        // 寬高point
        public override Point GetWidthHeightPoint()
        {
            _tempWidthHeight = new Point(Math.Max(X1, X2) - Math.Min(X1, X2), Math.Max(Y1, Y2) - Math.Min(Y1, Y2));
            return new Point(Math.Max(X1,X2) - Math.Min(X1,X2), Math.Max(Y1, Y2) - Math.Min(Y1, Y2));
        }

        // scale point
        public override void SetScale(float scaleWidth, float scaleHeight)
        {
            _scaleWidth = scaleWidth;
            _scaleHeight = scaleHeight;
            Location = GetLocation();
        }

        // set寬高(tuple)
        public override void SetX1Y1WidthHeightTuple(Point x1Y1, Point x2Y2)
        {
            X1 = x1Y1.X;
            Y1 = x1Y1.Y;
            X2 = x2Y2.X;
            Y2 = x2Y2.Y;
            Location = GetLocation();
        }

        // get寬高(tuple)
        public override (Point x1Y1, Point widthHeight) GetX1Y1WidthHeightTuple()
        {
            return (new Point(X1, Y1), new Point(X2, Y2));
        }
    }
}
