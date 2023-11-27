using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Homework2.States
{
    public class DrawingState : IState
    {
        bool _mousePressed = false;
        Model _model;

        public DrawingState(bool mousePressed)
        {
            this._mousePressed = mousePressed;
        }

        // 在畫布滑鼠按下
        public override void PanelMouseDown(Model model, Point point)
        {
            _model = model;
            _mousePressed = true;
            _model.CreateShapes();
            _model.SetShapeFirstPoint(point);
            foreach (Shape shape in _model.BindingShapeList)
            {
                shape.Selected = false;
            }
        }

        // 在畫布滑鼠移動
        public override void PanelMouseMove(Model model, Point point)
        {
            _model = model;
            if (_mousePressed)
            {
                _model.UpdateLocation(point);
            }
        }

        // 在畫布滑鼠放開
        public override void PanelMouseUp(Model model, Point point)
        {
            _model = model;
            if (_mousePressed)
            {
                _model.IsDrawing = false;
                _mousePressed = false;
                _model.AddShape();
                _model.State = new SelectState(false) ;
            }
        }
    }
}
