using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Homework2
{
    class DrawingState : IState
    {
        bool _mousePressed = false;

        public DrawingState(bool mousePressed)
        {
            this._mousePressed = mousePressed;
        }
        // 在畫布滑鼠按下
        public override void PanelMouseDown(Model model, Point point)
        {
            _mousePressed = true;
            model.CreateShapes();
            model.SetShapeFirstPoint(point);
            foreach (Shape shape in model.BindingShapeList)
            {
                shape.Selected = false;
            }
        }

        // 在畫布滑鼠移動
        public override void PanelMouseMove(Model model, Point point)
        {
            if (_mousePressed)
            {
                model.UpdateLocation(point);
            }
        }

        // 在畫布滑鼠放開
        public override void PanelMouseUp(Model model, Point point)
        {
            if (_mousePressed)
            {
                model.IsDrawing = false;
                _mousePressed = false;
                model.AddShape();
                model.State = new SelectState(false) ;
            }
        }
    }
}
