using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Homework2
{
    public class SelectState : IState
    {
        bool _mousePressed = false;
        Model _model;

        public SelectState(bool mousePressed)
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

        // 判斷shape有被選到 而且 鼠標也指到
        public bool IsSelectedAndInPoint(Model model, Point point)
        {
            _model = model;
            foreach (Shape shape in model.BindingShapeList)
            {
                if (shape.Selected && shape.IsRangeInPoint(point))
                {
                    return true;
                }
            }
            return false;
        }

        // 判斷shape沒被選到 但是 鼠標有指到
        public bool IsNotSelectedButInPoint(Model model, Point point)
        {
            _model = model;
            foreach (Shape shape in model.BindingShapeList)
            {
                if (!shape.Selected && shape.IsRangeInPoint(point))
                {
                    InitialShapeSelected(model);
                    shape.Selected = true;
                    return true;
                }
            }
            return false;
        }

        // 在畫布滑鼠按下
        public override void PanelMouseDown(Model model, Point point)
        {
            _model = model;
            _mousePressed = true;
            _model.FirstPoint = point;
            if (IsSelectedAndInPoint(_model, point))
            {
                return;
            }
            if (IsNotSelectedButInPoint(_model, point))
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
                foreach (Shape shape in _model.BindingShapeList)
                {
                    if (shape.Selected)
                    {
                        shape.Move(new Point(point.X - _model.FirstPoint.X, point.Y - _model.FirstPoint.Y));
                    }
                }
                _model.FirstPoint = point;
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
