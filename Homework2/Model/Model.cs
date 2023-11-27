using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

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

        public Cursor Cursor
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

        // 刪除shape
        public void DeleteData(int deleteRowIndex)
        {
            _shapes.DeleteData(deleteRowIndex);
        }

        // 畫圖
        public void Draw(IGraphics graphics)
        {
            _shapes.DrawAll(graphics);
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

        // 判斷shape有被選到 而且 鼠標也指到
        public bool IsSelectedAndInPoint(Point point)
        {
            return _shapes.IsSelectedAndInPoint(point);
        }

        // 判斷shape沒被選到 但是 鼠標有指到
        public bool IsNotSelectedButInPoint(Point point)
        {
            return _shapes.IsNotSelectedButInPoint(point);
        }

        // 移動選取的shape
        public void ShapeMove(Point point)
        {
            _shapes.ShapeMove(new Point(point.X - FirstPoint.X, point.Y - FirstPoint.Y));
            FirstPoint = point;
        }

        // 是否按到外框的圓
        public bool IsClickBorderCircle(Point point)
        {
            return _shapes.IsClickBorderCircle(point);
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
            CursorChanged(point);
            PanelChanged?.Invoke(this);
        }

        // 在畫布滑鼠放開
        public void PanelMouseUp(Point point)
        {
            State.PanelMouseUp(this, point);
            _shapes.Direction = -1;
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

        // 在畫布移動滑鼠時的cursor
        public void CursorChanged(Point point)
        {
            if (IsDrawing)
            {
                Cursor = Cursors.Cross;
            }
            else
            {
                if (_shapes.Direction == -1)
                {
                    Cursor = _shapes.GetCursorAtBorderCircle(point);
                }
                else
                {
                    Cursor = Cursors.Cross;
                }
            }
        }
    }
}
