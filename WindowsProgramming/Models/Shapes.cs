﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using WindowsPractice.Directions;

namespace WindowsPractice
{
    public class Shapes
    {
        BindingList<Shape> _shapesList;
        List<IDirection> _directionList;
        Shape _shape;
        Factory _factory;
        public Shapes()
        {
            _shapesList = new BindingList<Shape>();
            _directionList = new List<IDirection>();
            _factory = new Factory();
            InitializeDirection();
        }

        // 初始化direction
        public void InitializeDirection()
        {
            Direction = -1;
            _directionList.Add(new UpLeft());
            _directionList.Add(new Up());
            _directionList.Add(new UpRight());
            _directionList.Add(new Right());
            _directionList.Add(new DownRight());
            _directionList.Add(new Down());
            _directionList.Add(new DownLeft());
            _directionList.Add(new Left());
        }

        public bool IsDrawing
        {
            get;
            set;
        }

        public int Direction
        {
            get;
            set;
        }

        public BindingList<Shape> ShapeList
        {
            get 
            {
                return _shapesList; 
            }
        }

        public Shape Shape
        {
            get
            {
                return _shape;
            }
        }

        // 呼叫factory來創建shape
        public void CreateShape(string shapeName, Point x1Y1 = default, Point x2Y2 = default)
        {
            _shape = _factory.CreateShape(shapeName, x1Y1, x2Y2);
        }

        // 家shape到list
        public void AddShape(Shape shape = null, int insertIndex = -1)
        {
            if (shape == null)
            {
                _shapesList.Add(_shape);
            }
            else if (insertIndex != -1)
            {
                _shapesList.Insert(insertIndex, shape);
            }
            else
            {
                _shapesList.Add(shape);
            }
            _shape = null;
        }

        // 刪除shape
        public void DeleteData(int deleteRowIndex)
        {
            _shapesList.RemoveAt(deleteRowIndex);
        }

        // 把形狀畫出來
        public void DrawAll(IGraphics graphics)
        {
            foreach (Shape shape in _shapesList)
            {
                shape.Draw(graphics);
            }
            if (IsDrawing && _shape != null)
            {
                _shape.Draw(graphics);
            }
        }

        // 更新座標
        public void UpdateLocation(Point firstPoint, Point newPoint)
        {
            _shape.UpdateLocation(firstPoint, newPoint);
        }

        // 初始shape的selected
        public void InitialShapeSelected(Shape exceptionShape = null)
        {
            foreach (Shape shape in _shapesList)
            {
                if (shape != exceptionShape)
                {
                    shape.Selected = false;
                }      
            }
        }

        // 判斷shape有被選到 而且 鼠標也指到
        public bool IsSelectedAndInPoint(Point point)
        {
            foreach (Shape shape in _shapesList)
            {
                if (shape.IsSelectedAndInPoint(point))
                {
                    return true;
                }
            }
            return false;
        }

        // 判斷shape沒被選到 但是 鼠標有指到
        public bool IsNotSelectedButInPoint(Point point)
        {
            foreach (Shape shape in _shapesList)
            {
                if (shape.IsNotSelectedButInPoint(point))
                {
                    InitialShapeSelected(shape);
                    return true;
                }
            }
            return false;
        }

        //移動選取的shape
        public void ShapeMove(Point point)
        {
            if (Direction != -1)
            {
                _directionList[Direction].SetIncrementPoint(point);
                foreach (Shape shape in _shapesList)
                {
                    shape.ZoomInOut(_directionList[Direction].IncrementX1Y1, _directionList[Direction].IncrementWidthHeight);
                }
            }
            else
            {
                foreach (Shape shape in _shapesList)
                {
                    shape.Move(point);
                }
            }
        }

        // 是否按到外框的圓
        public bool IsClickBorderCircle(Point point)
        {
            Direction = -1;
            foreach (Shape shape in _shapesList)
            {
                if (shape.Selected)
                {
                    foreach (IDirection direction in _directionList)
                    {
                        if (direction.IsClickBorderCircle(shape.GetX1Y1Point(), shape.GetWidthHeightPoint(), point))
                        {
                            Direction = _directionList.IndexOf(direction);
                        }
                    }
                }
            }
            return Direction != -1;
        }

        // 是否移動到外框的圓
        public Cursor GetCursorAtBorderCircle(Point point)
        {
            foreach (Shape shape in _shapesList)
            {
                if (shape.Selected)
                {
                    foreach (IDirection direction in _directionList)
                    {
                        if (direction.IsClickBorderCircle(shape.GetX1Y1Point(), shape.GetWidthHeightPoint(), point))
                        {
                            return direction.Cursor;
                        }
                    }
                }
            }
            return Cursors.Default;
        }

        // 直接設定圖形位置
        public void SetDirect(Point x1y1, Point widthHeight, int index)
        {
            _shapesList[index].SetX1Y1WidthHeightTuple(x1y1, widthHeight);
        }

        // scale point
        public void SetScale(float width, float height)
        {
            foreach (Shape shape in _shapesList)
            {
                shape.SetScale(width, height);
            }
        }
    }
}
