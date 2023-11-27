using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Homework2.Directions
{
    public class Left : IDirection
    {
        const int RADIUS = 7;
        const int TWO = 2;
        Point _incrementX1Y1;
        Point _incrementWidthHeight;
        Cursor _cursors = Cursors.SizeWE;
        public Cursor Cursor
        {
            get
            {
                return _cursors;
            }
        }
        // 是否按到外框的圓
        public bool IsClickBorderCircle(Point x1y1, Point widthHeight, Point clickPoint)
        {
            return (x1y1.X + RADIUS) >= clickPoint.X
                && clickPoint.X >= (x1y1.X - RADIUS)
                && (x1y1.Y + widthHeight.Y / TWO + RADIUS) >= clickPoint.Y
                && clickPoint.Y >= (x1y1.Y + widthHeight.Y / TWO - RADIUS);
        }

        // 設定增量
        public void SetIncrementPoint(Point point)
        {
            _incrementX1Y1 = new Point(point.X, 0);
            _incrementWidthHeight = new Point(-point.X, 0);
        }

        // XY增量
        public Point GetIncrementX1Y1()
        {
            return _incrementX1Y1;
        }

        // Width Height增量
        public Point GetIncrementWidthHeight()
        {
            return _incrementWidthHeight;
        }
    }
}
