using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WindowsPractice.States;

namespace WindowsPractice
{
    public class PresentationModel
    {
        Model _model;
        const string MOUSE = "選取";
        List<string> _allShapeNameList = new List<string>();
        BindingList<ToolBarChecked> _toolBarCheckedList = new BindingList<ToolBarChecked>();

        public PresentationModel(Model model)
        {
            _model = model;
            _model.State = new NormalState(false);
        }

        public BindingList<ToolBarChecked> ToolBarCheckedList
        {
            get
            {
                return _toolBarCheckedList;
            }
        }

        // 儲存全部shape的名稱
        public void RecordAllShapeName(List<string> allShapeNameList)
        {
            this._allShapeNameList = allShapeNameList;
            foreach (string shapeName in allShapeNameList)
            {
                _toolBarCheckedList.Add(new ToolBarChecked(shapeName, false));
            }
            _toolBarCheckedList.Add(new ToolBarChecked(MOUSE, false));
        }

        // 更新狀態
        public void SetState()
        {
            foreach (ToolBarChecked toolBarChecked in _toolBarCheckedList)
            {
                if (toolBarChecked.IsDrawingState())
                {
                    _model.State = new DrawingState(false);
                    _model.SelectShapeName = toolBarChecked.Key;
                    _model.IsDrawing = true;
                    return;
                }
            }
            if (!(_model.State is SelectState))
            {
                _model.State = new NormalState(false);
                _model.SelectShapeName = null;
                _model.IsDrawing = false;
            } 
        }

        // 按ToolStripButton時更改Button狀態
        public void ToolStripButtonClick(string shapeName)
        {
            foreach (var toolBarChecked in _toolBarCheckedList)
            {
                toolBarChecked.SetCheckedValue(shapeName);
            }
            SetState();
        }

        // 在畫佈按下左鍵時
        public void Panel1MouseDown(System.Drawing.Point point)
        {
            _model.PanelMouseDown(point);
        }

        // 在畫佈移動滑鼠時
        public void Panel1MouseMove(System.Drawing.Point point)
        {
            _model.PanelMouseMove(point);
        }

        // 在畫佈放開左鍵時
        public void Panel1MouseUp(System.Drawing.Point point)
        {
            _model.PanelMouseUp(point);
            foreach (var toolBarChecked in _toolBarCheckedList)
            {
                toolBarChecked.SetCheckedValue(MOUSE);
            }
        }
    }
}

