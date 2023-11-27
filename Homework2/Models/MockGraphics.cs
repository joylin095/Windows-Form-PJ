using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public class MockGraphics : IGraphics
    {
        int _x1;
        int _y1;
        int _x2;
        int _y2;
        int _width;
        int _height;
        int _upLeftX;
        int _upLeftY;
        int _upX;
        int _upY;
        int _upRightX;
        int _upRightY;
        int _leftX;
        int _leftY;
        int _rightX;
        int _rightY;
        int _downLeftX;
        int _downLeftY;
        int _downX;
        int _downY;
        int _downRightX;
        int _downRightY;
        const int RADIUS = 5;
        const int TWO = 2;
        const int MULTIPLE = 2;
        // 畫線
        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            this._x1 = x1;
            this._y1 = y1;
            this._x2 = x2;
            this._y2 = y2;
        }

        // 畫矩形
        public void DrawRectangle(int x1, int y1, int width, int height)
        {
            this._x1 = x1;
            this._y1 = y1;
            this._width = width;
            this._height = height;
        }

        // 畫圓
        public void DrawCircle(int x1, int y1, int width, int height)
        {
            this._x1 = x1;
            this._y1 = y1;
            this._width = width;
            this._height = height;
        }

        // 畫外框
        public void DrawSelectionBorder(int x1, int y1, int width, int height)
        {
            this._x1 = x1;
            this._y1 = y1;
            this._width = width;
            this._height = height;
            //左上
            this._upLeftX = x1 - RADIUS;
            this._upLeftY = y1 - RADIUS;
            //上中
            this._upX = x1 + (width / TWO) - RADIUS;
            this._upY = y1 - RADIUS;
            //右上
            this._upRightX = x1 + width - RADIUS;
            this._upRightY = y1 - RADIUS;
            DrawSelectionBorderOther(x1, y1, width, height);
        }

        // 接續DrawSelectionBorder
        public void DrawSelectionBorderOther(int x1, int y1, int width, int height)
        {
            //右中
            this._rightX = x1 + width - RADIUS;
            this._rightY = y1 + (height / TWO) - RADIUS;
            //右下
            this._downRightX = x1 + width - RADIUS;
            this._downRightY = y1 + height - RADIUS;
            //中下
            this._downX = x1 + (width / TWO) - RADIUS;
            this._downY = y1 + height - RADIUS;
            // 左下
            this._downLeftX = x1 - RADIUS;
            this._downLeftY = y1 + height - RADIUS;
            //左中
            this._leftX = x1 - RADIUS;
            this._leftY = y1 + (height / TWO) - RADIUS;
        }
    }
}
