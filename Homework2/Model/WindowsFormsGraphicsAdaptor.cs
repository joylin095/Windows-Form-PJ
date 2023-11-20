using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Homework2
{
    public class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        Pen _pen;
        public WindowsFormsGraphicsAdaptor(Graphics graphics, Pen pen)
        {
            _graphics = graphics;
            _pen = pen;
        }

        // 畫線
        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            _graphics.DrawLine(_pen, x1, y1, x2, y2);
        }

        // 畫矩形
        public void DrawRectangle(int x1, int y1, int width, int height)
        {
            _graphics.DrawRectangle(_pen, x1, y1, width, height);
        }

        // 畫圓
        public void DrawCircle(int x1, int y1, int width, int height)
        {
            _graphics.DrawEllipse(_pen, x1, y1, width, height);
        }

        // 畫外框
        public void DrawSelectionBorder(int x1, int y1, int width, int height)
        {
            const int RADIUS = 5;
            const int TWO = 2;
            const int MULTIPLE = 2;
            Pen pen = new Pen(Color.Gray);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            _graphics.DrawRectangle(pen, x1, y1, width, height);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            _graphics.DrawEllipse(pen, x1 - RADIUS, y1 - RADIUS, MULTIPLE * RADIUS, MULTIPLE * RADIUS);//左上
            _graphics.DrawEllipse(pen, x1 + (width / TWO) - RADIUS, y1 - RADIUS, MULTIPLE * RADIUS, MULTIPLE * RADIUS);//中上
            _graphics.DrawEllipse(pen, x1 + width - RADIUS, y1 - RADIUS, MULTIPLE * RADIUS, MULTIPLE * RADIUS);//右上
            _graphics.DrawEllipse(pen, x1 + width - RADIUS, y1 + (height / TWO) - RADIUS, MULTIPLE * RADIUS, MULTIPLE * RADIUS);//右中
            _graphics.DrawEllipse(pen, x1 + width - RADIUS, y1 + height - RADIUS, MULTIPLE * RADIUS, MULTIPLE * RADIUS);//右下
            _graphics.DrawEllipse(pen, x1 + (width / TWO) - RADIUS, y1 + height - RADIUS, MULTIPLE * RADIUS, MULTIPLE * RADIUS);//中下
            _graphics.DrawEllipse(pen, x1 - RADIUS, y1 + height - RADIUS, MULTIPLE * RADIUS, MULTIPLE * RADIUS);//左下
            _graphics.DrawEllipse(pen, x1 - RADIUS, y1 + (height / TWO) - RADIUS, MULTIPLE * RADIUS, MULTIPLE * RADIUS);//左中
        }
    }
}
