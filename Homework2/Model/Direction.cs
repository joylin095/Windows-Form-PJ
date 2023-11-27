using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Homework2
{
    public class UpLeft : IDirection
    {
        const int RADIUS = 7;
        Point _incrementX1Y1;
        Point _incrementWidthHeight;
        Cursor _cursors = Cursors.SizeNWSE;
        public Cursor Cursor
        {
            get { return _cursors; }
        }

        // 是否按到外框的圓
        public bool IsClickBorderCircle(Point xy, Point widthHeight, Point clickPoint)
        {
            return (xy.X + RADIUS) >= clickPoint.X 
                && clickPoint.X >= (xy.X - RADIUS) 
                && (xy.Y + RADIUS) >= clickPoint.Y 
                && clickPoint.Y >= (xy.Y - RADIUS); 
        }

        // 設定增量
        public void SetIncrementPoint(Point point)
        {
            _incrementX1Y1 = new Point(point.X, point.Y);
            _incrementWidthHeight = new Point(-point.X, -point.Y);
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

    public class Up : IDirection
    {
        const int RADIUS = 7;
        const int TWO = 2;
        Point _incrementX1Y1;
        Point _incrementWidthHeight;
        Cursor _cursors = Cursors.SizeNS;
        public Cursor Cursor
        {
            get { return _cursors; }
        }
        // 是否按到外框的圓
        public bool IsClickBorderCircle(Point xy, Point widthHeight, Point clickPoint)
        {
            return (xy.X + widthHeight.X / TWO + RADIUS) >= clickPoint.X
                && clickPoint.X >= (xy.X + widthHeight.X / TWO - RADIUS)
                && (xy.Y + RADIUS) >= clickPoint.Y
                && clickPoint.Y >= (xy.Y - RADIUS);
        }

        // 設定增量
        public void SetIncrementPoint(Point point)
        {
            _incrementX1Y1 = new Point(0, point.Y);
            _incrementWidthHeight = new Point(0, -point.Y);
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

    public class UpRight : IDirection
    {
        const int RADIUS = 7;
        Point _incrementX1Y1;
        Point _incrementWidthHeight;
        Cursor _cursors = Cursors.SizeNESW;
        public Cursor Cursor
        {
            get { return _cursors; }
        }
        // 是否按到外框的圓
        public bool IsClickBorderCircle(Point xy, Point widthHeight, Point clickPoint)
        {
            return (xy.X + widthHeight.X + RADIUS) >= clickPoint.X
                && clickPoint.X >= (xy.X + widthHeight.X - RADIUS)
                && (xy.Y + RADIUS) >= clickPoint.Y
                && clickPoint.Y >= (xy.Y - RADIUS);
        }

        // 設定增量
        public void SetIncrementPoint(Point point)
        {
            _incrementX1Y1 = new Point(0, point.Y);
            _incrementWidthHeight = new Point(point.X, -point.Y);
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

    public class Right : IDirection
    {
        const int RADIUS = 7;
        const int TWO = 2;
        Point _incrementX1Y1;
        Point _incrementWidthHeight;
        Cursor _cursors = Cursors.SizeWE;
        public Cursor Cursor
        {
            get { return _cursors; }
        }
        // 是否按到外框的圓
        public bool IsClickBorderCircle(Point xy, Point widthHeight, Point clickPoint)
        {
            return (xy.X + widthHeight.X + RADIUS) >= clickPoint.X
                && clickPoint.X >= (xy.X + widthHeight.X - RADIUS)
                && (xy.Y + widthHeight.Y / TWO  + RADIUS) >= clickPoint.Y
                && clickPoint.Y >= (xy.Y + widthHeight.Y / TWO - RADIUS);
        }

        // 設定增量
        public void SetIncrementPoint(Point point)
        {
            _incrementX1Y1 = new Point(0, 0);
            _incrementWidthHeight = new Point(point.X, 0);
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

    public class DownRight : IDirection
    {
        const int RADIUS = 7;
        Point _incrementX1Y1;
        Point _incrementWidthHeight;
        Cursor _cursors = Cursors.SizeNWSE;
        public Cursor Cursor
        {
            get { return _cursors; }
        }
        // 是否按到外框的圓
        public bool IsClickBorderCircle(Point xy, Point widthHeight, Point clickPoint)
        {
            return (xy.X + widthHeight.X + RADIUS) >= clickPoint.X
                && clickPoint.X >= (xy.X + widthHeight.X - RADIUS)
                && (xy.Y + widthHeight.Y + RADIUS) >= clickPoint.Y
                && clickPoint.Y >= (xy.Y + widthHeight.Y - RADIUS);
        }

        // 設定增量
        public void SetIncrementPoint(Point point)
        {
            _incrementX1Y1 = new Point(0, 0);
            _incrementWidthHeight = new Point(point.X, point.Y);
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

    public class Down : IDirection
    {
        const int RADIUS = 7;
        const int TWO = 2;
        Point _incrementX1Y1;
        Point _incrementWidthHeight;
        Cursor _cursors = Cursors.SizeNS;
        public Cursor Cursor
        {
            get { return _cursors; }
        }
        // 是否按到外框的圓
        public bool IsClickBorderCircle(Point xy, Point widthHeight, Point clickPoint)
        {
            return (xy.X + widthHeight.X / TWO + RADIUS) >= clickPoint.X
                && clickPoint.X >= (xy.X + widthHeight.X / TWO - RADIUS)
                && (xy.Y + widthHeight.Y + RADIUS) >= clickPoint.Y
                && clickPoint.Y >= (xy.Y + widthHeight.Y - RADIUS);
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

    public class DownLeft : IDirection
    {
        const int RADIUS = 7;
        Point _incrementX1Y1;
        Point _incrementWidthHeight;
        Cursor _cursors = Cursors.SizeNESW;
        public Cursor Cursor
        {
            get { return _cursors; }
        }
        // 是否按到外框的圓
        public bool IsClickBorderCircle(Point xy, Point widthHeight, Point clickPoint)
        {
            return (xy.X + RADIUS) >= clickPoint.X
                && clickPoint.X >= (xy.X - RADIUS)
                && (xy.Y + widthHeight.Y + RADIUS) >= clickPoint.Y
                && clickPoint.Y >= (xy.Y + widthHeight.Y - RADIUS);
        }

        // 設定增量
        public void SetIncrementPoint(Point point)
        {
            _incrementX1Y1 = new Point(point.X, 0);
            _incrementWidthHeight = new Point(-point.X, point.Y);
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

    public class Left : IDirection
    {
        const int RADIUS = 7;
        const int TWO = 2;
        Point _incrementX1Y1;
        Point _incrementWidthHeight;
        Cursor _cursors = Cursors.SizeWE;
        public Cursor Cursor
        {
            get { return _cursors; }
        }
        // 是否按到外框的圓
        public bool IsClickBorderCircle(Point xy, Point widthHeight, Point clickPoint)
        {
            return (xy.X + RADIUS) >= clickPoint.X
                && clickPoint.X >= (xy.X - RADIUS)
                && (xy.Y + widthHeight.Y / TWO + RADIUS) >= clickPoint.Y
                && clickPoint.Y >= (xy.Y + widthHeight.Y / TWO - RADIUS);
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
