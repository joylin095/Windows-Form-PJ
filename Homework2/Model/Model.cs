using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Homework2
{
    public class Model
    {
        Shapes _shapes;
        Pen _pen;

        public delegate void PanelChangedEventHandler(object sender);
        public event PanelChangedEventHandler PanelChanged;

        public delegate void CursorToDefaultEventHandler(object sender);
        public event CursorToDefaultEventHandler CursorToDefault;
        public Model()
        {
            _shapes = new Shapes();
            _pen = new Pen(Color.Green);
            IsDrawing = false;
        }

        public BindingList<Shape> BindingShapeList
        {
            get 
            { 
                return _shapes.ShapeList; 
            }
        }

        public IState State
        {
            get;
            set;
        }

        public string SelectShapeName
        {
            get;
            set;
        }

        public Point FirstPoint
        {
            get;
            set;
        }

        public bool IsDrawing
        {
            get;
            set;
        }
        
        // 創建shape
        public void CreateShapes()
        {
            _shapes.CreateShape(SelectShapeName);
        }

        // 加入shape到list
        public void AddShape()
        {
            _shapes.AddShape();
        }

        // 獲取shape資訊
        public string[] GetInformation()
        {
            return _shapes.GetInformation();
        }

        // 刪除shape
        public void DeleteData(int deleteRowIndex)
        {
            _shapes.DeleteData(deleteRowIndex);
        }

        // 畫圖
        public void Draw(Graphics graphics)
        {
            _shapes.DrawAll(new WindowsFormsGraphicsAdaptor(graphics, _pen));
            _shapes.IsDrawing = IsDrawing;
        }

        // 紀錄第一個按下去的點
        public void SetShapeFirstPoint(Point point)
        {
            FirstPoint = point;
        }

        // 更新座標
        public void UpdateLocation(Point newPoint)
        {
            _shapes.UpdateLocation(FirstPoint, newPoint);
        }

        // 在畫布滑鼠按下
        public void PanelMouseDown(Point point)
        {
            State.PanelMouseDown(this, point);
        }

        // 在畫布滑鼠移動
        public void PanelMouseMove(Point point)
        {
            State.PanelMouseMove(this, point);
            PanelChanged?.Invoke(this);
        }

        // 在畫布滑鼠放開
        public void PanelMouseUp(Point point)
        {
            State.PanelMouseUp(this, point);
            CursorToDefault?.Invoke(this);
        }

        // 鍵盤按下按鍵
        public void FormKeyDown(System.Windows.Forms.Keys keys)
        {
            if (keys == System.Windows.Forms.Keys.Delete)
            {
                foreach (Shape shape in _shapes.ShapeList.ToArray())
                {
                    if (shape.Selected == true)
                    {
                        DeleteData(_shapes.ShapeList.IndexOf(shape));
                        PanelChanged?.Invoke(this);
                    }
                }
            }
        }
    }
}
