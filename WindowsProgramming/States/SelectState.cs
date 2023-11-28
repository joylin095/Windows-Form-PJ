using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsPractice.States
{
    public class SelectState : IState
    {
        bool _mousePressed = false;
        Model _model;

        public SelectState(bool mousePressed)
        {
            this._mousePressed = mousePressed;
        }

        // 在畫布滑鼠按下
        public override void PanelMouseDown(Model model, Point point)
        {
            _model = model;
            _mousePressed = true;
            _model.FirstPoint = point;
            if (_model.IsClickBorderCircle(point))
            {
                return;
            }
            else if (_model.IsSelectedAndInPoint(point) || _model.IsNotSelectedButInPoint(point))
            {
                return;
            }
            _model.State = new NormalState(true);
        }

        // 在畫布滑鼠移動
        public override void PanelMouseMove(Model model, Point point)
        {
            _model = model;
            if (_mousePressed)
            {
                _model.ShapeMove(point);
            }
        }

        // 在畫布滑鼠放開
        public override void PanelMouseUp(Model model, Point point)
        {
            _model = model;
            if (_mousePressed)
            {
                _mousePressed = false;
            }
        }
    }
}
