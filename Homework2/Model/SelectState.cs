using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Homework2
{
    class SelectState : IState
    {
        bool _mousePressed = false;

        public SelectState(bool mousePressed)
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

        // 判斷shape有被選到 而且 鼠標也指到
        private bool IsSelectedAndInPoint(Model model, Point point)
        {
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
        private bool IsNotSelectedButInPoint(Model model, Point point)
        {
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
            _mousePressed = true;
            model.FirstPoint = point;
            if (IsSelectedAndInPoint(model, point))
            {
                return;
            }
            if (IsNotSelectedButInPoint(model, point))
            {
                return;
            }
            model.State = new NormalState(true);
        }

        // 在畫布滑鼠移動
        public override void PanelMouseMove(Model model, Point point)
        {
            if (_mousePressed)
            {
                foreach (Shape shape in model.BindingShapeList)
                {
                    if (shape.Selected)
                    {
                        shape.Move(new Point(point.X - model.FirstPoint.X, point.Y - model.FirstPoint.Y));
                    }
                }
                model.FirstPoint = point;
            }
        }

        // 在畫布滑鼠放開
        public override void PanelMouseUp(Model model, Point point)
        {
            if (_mousePressed)
            {
                _mousePressed = false;
            }
        }
    }
}
