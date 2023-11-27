using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Homework2.Directions
{
    public interface IDirection
    {
        Cursor Cursor
        {
            get;
        }

        // 是否按到外框的圓
        bool IsClickBorderCircle(Point x1y1, Point widthHeight, Point clickPoint);

        // 設定增量
        void SetIncrementPoint(Point point);

        // XY增量
        Point GetIncrementX1Y1();

        // Width Height增量
        Point GetIncrementWidthHeight();
    }
}
