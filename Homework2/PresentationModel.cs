using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public class PresentationModel
    {
        Model _model;
        string _selectShape;
        List<string> _allShapeName = new List<string>();
        Dictionary<string, bool> _shapeStatus = new Dictionary<string, bool>();

        public delegate void DrawInPanelEventHandler(object sender);
        public event DrawInPanelEventHandler drawInPanel;

        public delegate void AddToDataGridViewEventHandler(object sender);
        public event AddToDataGridViewEventHandler addToDataGridView;

        public PresentationModel(Model model)
        {
            _model = model;
            IsDrawing = false;
        }

        // 儲存全部shape的名稱
        public void RecordAllShapeName(List<string> allShapeName)
        {
            this._allShapeName = allShapeName;
            foreach (string shapeName in allShapeName)
            {
                _shapeStatus[shapeName] = false;
            }
        }

        // 回傳ToolStripButton的checked
        public bool IsToolStripShapeChecked(string shapeName)
        {
            return _shapeStatus[shapeName];
        }

        public bool IsDrawing
        {
            get;
            set;
        }

        // 判斷是否可以畫圖狀態
        public bool CanDrawing()
        {
            foreach (string shape in _allShapeName)
            {
                if (_shapeStatus[shape])
                {
                    return true;
                }
            }
            return false;
        }

        // 按ToolStripButton時更改Button狀態
        public void ToolStripButtonClick(string shapeName)
        {
            foreach (string shape in _shapeStatus.Keys.ToList())
            {
                _shapeStatus[shape] = (shape == shapeName) ? !_shapeStatus[shape] : false;
            }
            _selectShape = shapeName;
        }

        // 在畫佈按下左鍵時
        public void Panel1MouseDown(System.Drawing.Point point)
        {
            if (CanDrawing())
            {
                _model.IsDrawing = IsDrawing = true;
                _model.CreateShapes(_selectShape);
                _model.SetShapeFirstPoint(point);
            }
        }

        // 在畫佈移動滑鼠時
        public void Panel1MouseMove(System.Drawing.Point point)
        {
            if (IsDrawing)
            {
                _model.UpdateLocation(point);
                drawInPanel?.Invoke(this);
            }
        }

        // 在畫佈放開左鍵時
        public void Panel1MouseUp()
        {
            if (IsDrawing)
            {
                foreach (string shape in _allShapeName)
                {
                    _shapeStatus[shape] = false;
                }
                _model.IsDrawing = IsDrawing = false;
                _model.AddShape();
                addToDataGridView?.Invoke(this);
            }
        }
    }
}
