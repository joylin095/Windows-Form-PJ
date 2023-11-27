using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Homework2
{
    public class Line : Shape
    {
        const string LINE = "線";
        const int SIZE_X1 = 600;
        const int SIZE_Y1 = 500;
        const int SIZE_X2 = 600;
        const int SIZE_Y2 = 500;
        Point TempX1Y1;
        Point TempWidthHeight;
        bool _isDownLeftUpRight;
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
        public Line(IRandom random)
        {
            Name = LINE;
            Selected = false;
            X1 = random.GetNext(0, SIZE_X1);
            Y1 = random.GetNext(0, SIZE_Y1);
            X2 = random.GetNext(0, SIZE_X2);
            Y2 = random.GetNext(0, SIZE_Y2);
            UpdateLocation(new Point(X1, Y1), new Point(X2, Y2));
        }

        // 回傳圖形座標
        public override string GetLocation()
        {
            return $"({X1}, {Y1}),({X2}, {Y2})";
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
                TempX1Y1.X += incrementX1Y1.X;
                TempX1Y1.Y += incrementX1Y1.Y;
                TempWidthHeight.X += incrementWidthHeight.X;
                TempWidthHeight.Y += incrementWidthHeight.Y;
                if (_isDownLeftUpRight)
                {
                    UpdateLocation(new Point(TempX1Y1.X, TempX1Y1.Y + TempWidthHeight.Y), new Point(TempX1Y1.X + TempWidthHeight.X, TempX1Y1.Y));
                }
                else
                {
                    UpdateLocation(TempX1Y1, new Point(TempX1Y1.X + TempWidthHeight.X, TempX1Y1.Y + TempWidthHeight.Y));
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
            TempX1Y1 = new Point(Math.Min(X1, X2), Math.Min(Y1, Y2));
            return new Point(Math.Min(X1, X2), Math.Min(Y1, Y2));
        }

        // 寬高point
        public override Point GetWidthHeightPoint()
        {
            TempWidthHeight = new Point(Math.Max(X1, X2) - Math.Min(X1, X2), Math.Max(Y1, Y2) - Math.Min(Y1, Y2));
            return new Point(Math.Max(X1,X2) - Math.Min(X1,X2), Math.Max(Y1, Y2) - Math.Min(Y1, Y2));
        }

        // 覆寫object.Equals()
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Line otherRectangle = (Line)obj;
            return Name == otherRectangle.Name;
        }

        //  覆寫 GetHashCode()
        public override int GetHashCode()
        {
            return new { Name }.GetHashCode();
        }
    }
}
