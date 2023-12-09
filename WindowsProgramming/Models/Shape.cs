using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace WindowsPractice
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

        // 判斷有被選到 而且 鼠標也指到
        public bool IsSelectedAndInPoint(Point point)
        {
            if (Selected && IsRangeInPoint(point))
            {
                return true;
            }
            return false;
        }

        // 判斷沒被選到 但是 鼠標有指到
        public bool IsNotSelectedButInPoint(Point point)
        {
            if (!Selected && IsRangeInPoint(point))
            {
                Selected = true;
                return true;
            }
            return false;
        }

        // 形狀位置
        public abstract string GetLocation();

        // 更新座標(給2個座標)
        public abstract void UpdateLocation(Point firstPoint, Point newPoint);

        // 畫圖
        public abstract void Draw(IGraphics graphics);

        // 判斷點是否在範圍內
        public abstract bool IsRangeInPoint(Point point);

        //判斷選取範圍是否在範圍內
        public abstract bool IsRangeInArea(Point firstPoint, Point secondPoint2);

        // 移動圖形
        public abstract void Move(Point point);

        // 放大縮小
        public abstract void ZoomInOut(Point incrementX1Y1, Point incrementWidthHeight);

        //xy point
        public abstract Point GetX1Y1Point();

        // 寬高point
        public abstract Point GetWidthHeightPoint();

        // get寬高(tuple)
        public abstract (Point x1Y1, Point widthHeight) GetX1Y1WidthHeightTuple();

        // set寬高(tuple)
        public abstract void SetX1Y1WidthHeightTuple(Point x1Y1, Point widthHeight);

        // scale point
        public abstract void SetScale(float width, float height);

    }
}
