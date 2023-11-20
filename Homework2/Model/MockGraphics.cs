using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public class MockGraphics : IGraphics
    {
        public int _x1;
        public int _y1;
        public int _x2;
        public int _y2;
        public int _width;
        public int _height;
        public int _upLeftX;
        public int _upLeftY;
        public int _upX;
        public int _upY;
        public int _upRightX;
        public int _upRightY;
        public int _leftX;
        public int _leftY;
        public int _rightX;
        public int _rightY;
        public int _downLeftX;
        public int _downLeftY;
        public int _downX;
        public int _downY;
        public int _downRightX;
        public int _downRightY;
        public int _diameter;

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
            const int RADIUS = 5;
            const int TWO = 2;
            const int MULTIPLE = 2;
            this._diameter = MULTIPLE * RADIUS;
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
