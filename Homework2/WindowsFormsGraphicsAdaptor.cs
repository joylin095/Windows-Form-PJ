using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Homework2
{
    class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        Pen _pen;
        public WindowsFormsGraphicsAdaptor(Graphics graphics, Pen pen)
        {
            _graphics = graphics;
            _pen = pen;
        }

        // 清空畫面
        public void ClearAll()
        {

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
    }
}
