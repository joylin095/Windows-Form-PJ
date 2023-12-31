﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPractice
{
    public interface IGraphics
    {
        // 畫線
        void DrawLine(int x1, int y1, int x2, int y2);

        // 畫矩形
        void DrawRectangle(int x1, int y1, int width, int height);

        // 畫圓
        void DrawCircle(int x1, int y1, int width, int height);

        //畫外框
        void DrawSelectionBorder(int x1, int y1, int width, int height);
    }
}
