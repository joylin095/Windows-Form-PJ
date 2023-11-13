using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Homework2
{
    class NormalState : IState
    {
        bool _mousePressed = false;

        public NormalState(bool mousePressed)
        {
            this._mousePressed = mousePressed;
        }

        // 初始shape的selected
        private void InitialShapeSelected(Model model)
        {
            foreach (Shape shape in model.BindingShapeList)
            {
                shape.Selected = false;
            }
        }

        // 是否有在選取範圍
        private bool HasSelectedInArea(Model model, Point point)
        {
            bool hasSelected = false;
            foreach (Shape shape in model.BindingShapeList)
            {
                if (shape.IsRangeInArea(model.FirstPoint, point))
                {
                    shape.Selected = hasSelected = true;
                }
            }
            return hasSelected;
        }

        // 在畫布滑鼠按下
        public override void PanelMouseDown(Model model, Point point)
        {
            InitialShapeSelected(model);
            model.FirstPoint = point;
            _mousePressed = true;
            foreach (Shape shape in model.BindingShapeList)
            {
                if (shape.IsRangeInPoint(point))
                {
                    shape.Selected = true;
                    model.State = new SelectState(true);
                    return;
                }
            }
        }

        // 在畫布滑鼠移動
        public override void PanelMouseMove(Model model, Point point)
        {
            
        }

        // 在畫布滑鼠放開
        public override void PanelMouseUp(Model model, Point point)
        {
            if (_mousePressed)
            {
                InitialShapeSelected(model);
                _mousePressed = false;
                
                if (HasSelectedInArea(model, point))
                {
                    model.State = new SelectState(false);
                }
            }
        }
    }
}
