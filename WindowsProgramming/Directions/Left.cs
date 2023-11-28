using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsPractice.Directions
{
    public class Left : IDirection
    {
        const int RADIUS = 7;
        const int TWO = 2;
        Cursor _cursors = Cursors.SizeWE;

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
            return (x1y1.X + RADIUS) >= clickPoint.X
                && clickPoint.X >= (x1y1.X - RADIUS)
                && (x1y1.Y + widthHeight.Y / TWO + RADIUS) >= clickPoint.Y
                && clickPoint.Y >= (x1y1.Y + widthHeight.Y / TWO - RADIUS);
        }

        // 設定增量
        public void SetIncrementPoint(Point point)
        {
            IncrementX1Y1 = new Point(point.X, 0);
            IncrementWidthHeight = new Point(-point.X, 0);
        }
    }
}
