using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Homework2
{
    public class NormalState : IState
    {
        bool _mousePressed = false;
        Model _model;
        public NormalState(bool mousePressed)
        {
            this._mousePressed = mousePressed;
            
        }

        // 初始shape的selected
        public void InitialShapeSelected(Model model)
        {
            _model = model;
            foreach (Shape shape in _model.BindingShapeList)
            {
                shape.Selected = false;
            }
        }

        // 是否有在選取範圍
        public bool HasSelectedInArea(Model model, Point point)
        {
            _model = model;
            bool hasSelected = false;
            foreach (Shape shape in _model.BindingShapeList)
            {
                if (shape.IsRangeInArea(_model.FirstPoint, point))
                {
                    shape.Selected = hasSelected = true;
                }
            }
            return hasSelected;
        }

        // 在畫布滑鼠按下
        public override void PanelMouseDown(Model model, Point point)
        {
            _model = model;
            InitialShapeSelected(_model);
            _model.FirstPoint = point;
            _mousePressed = true;
            foreach (Shape shape in _model.BindingShapeList)
            {
                if (shape.IsRangeInPoint(point))
                {
                    shape.Selected = true;
                    _model.State = new SelectState(true);
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
            _model = model;
            if (_mousePressed)
            {
                InitialShapeSelected(_model);
                _mousePressed = false;
                
                if (HasSelectedInArea(_model, point))
                {
                    _model.State = new SelectState(false);
                }
            }
        }
    }
}
