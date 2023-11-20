using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Homework2
{
    public abstract class Shape
    {
        public string Name
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        public bool Selected
        {
            get;
            set;
        }

        // 形狀位置
        public abstract string GetLocation();

        // 更新座標
        public abstract void UpdateLocation(Point firstPoint, Point newPoint);

        // 畫圖
        public abstract void Draw(IGraphics graphics);

        // 判斷點是否在範圍內
        public abstract bool IsRangeInPoint(Point point);

        //判斷選取範圍是否在範圍內
        public abstract bool IsRangeInArea(Point firstPoint, Point secondPoint2);

        // 移動圖形
        public abstract void Move(Point point);
    }
}
