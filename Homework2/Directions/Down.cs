using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Homework2.Directions
{
    public class Down : IDirection
    {
        const int RADIUS = 7;
        const int TWO = 2;
        Point _incrementX1Y1;
        Point _incrementWidthHeight;
        Cursor _cursors = Cursors.SizeNS;
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
            return (x1y1.X + widthHeight.X / TWO + RADIUS) >= clickPoint.X
                && clickPoint.X >= (x1y1.X + widthHeight.X / TWO - RADIUS)
                && (x1y1.Y + widthHeight.Y + RADIUS) >= clickPoint.Y
                && clickPoint.Y >= (x1y1.Y + widthHeight.Y - RADIUS);
        }

        // 設定增量
        public void SetIncrementPoint(Point point)
        {
            _incrementX1Y1 = new Point(0, 0);
            _incrementWidthHeight = new Point(0, point.Y);
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
