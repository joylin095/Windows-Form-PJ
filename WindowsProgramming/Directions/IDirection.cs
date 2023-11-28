using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsPractice.Directions
{
    public interface IDirection
    {
        Cursor Cursor
        {
            get;
        }

        Point IncrementX1Y1
        {
            get;
            set;
        }

        Point IncrementWidthHeight
        {
            get;
            set;
        }
        // 是否按到外框的圓
        bool IsClickBorderCircle(Point x1y1, Point widthHeight, Point clickPoint);

        // 設定增量
        void SetIncrementPoint(Point point);
    }
}
