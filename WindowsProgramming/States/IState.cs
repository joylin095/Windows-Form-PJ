using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsPractice.States
{
    public abstract class IState
    {
        public bool TestMousePressed
        {
            get;
            set;
        }
        public Point TestPoint
        {
            get;
            set;
        }
        // 在畫布滑鼠按下
        public abstract void PanelMouseDown(Model model, Point point);

        // 在畫布滑鼠移動
        public abstract void PanelMouseMove(Model model, Point point);

        // 在畫布滑鼠放開
        public abstract void PanelMouseUp(Model model, Point point);

    }
}
