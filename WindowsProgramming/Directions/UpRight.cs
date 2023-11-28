using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsPractice.Directions
{
    public class UpRight : IDirection
    {
        const int RADIUS = 7;
        Cursor _cursors = Cursors.SizeNESW;

        public Cursor Cursor
        {
            get
            {
                return _cursors;
            }
        }
        public Point IncrementX1Y1
        {
            get;
            set;
        }
        public Point IncrementWidthHeight
        {
            get;
            set;
        }
        // 是否按到外框的圓
        public bool IsClickBorderCircle(Point x1y1, Point widthHeight, Point clickPoint)
        {
            return (x1y1.X + widthHeight.X + RADIUS) >= clickPoint.X
                && clickPoint.X >= (x1y1.X + widthHeight.X - RADIUS)
                && (x1y1.Y + RADIUS) >= clickPoint.Y
                && clickPoint.Y >= (x1y1.Y - RADIUS);
        }

        // 設定增量
        public void SetIncrementPoint(Point point)
        {
            IncrementX1Y1 = new Point(0, point.Y);
            IncrementWidthHeight = new Point(point.X, -point.Y);
        }
    }
}
