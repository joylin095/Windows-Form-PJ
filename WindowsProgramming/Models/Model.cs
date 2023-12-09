﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using WindowsPractice.States;
using WindowsPractice.Command;

namespace WindowsPractice
{
    public class Model
    {
        public delegate void PanelChangedEventHandler(object sender);
        public event PanelChangedEventHandler _panelChanged;
        public delegate void CursorToDefaultEventHandler(object sender);
        public event CursorToDefaultEventHandler _cursorToDefault;

        Shapes _shapes;
        Pen _pen;
        CommandManager _commandManager;
        Dictionary<(Point X1Y1, Point WidthHeight), int> _beforeMove;
        Dictionary<(Point X1Y1, Point WidthHeight), int> _afterMove;

        public Model()
        {
            _shapes = new Shapes();
            _pen = new Pen(Color.Green);
            _commandManager = new CommandManager();
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

        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }

        // 創建shape
        public void CreateShapes()
        {
            _shapes.CreateShape(SelectShapeName);
        }

        // 加入shape到list
        public void AddShape(Shape shape = null, int insertIndex = -1)
        {
            _shapes.AddShape(shape, insertIndex);
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
            ChangeCursor(point);
            if (_panelChanged != null)
            {
                _panelChanged(this);
            }
        }

        // 在畫布滑鼠放開
        public void PanelMouseUp(Point point)
        {
            State.PanelMouseUp(this, point);
            _shapes.Direction = -1;
            if (_cursorToDefault != null)
            {
                _cursorToDefault(this);
            }
        }

        // 直接設定圖形
        public void SetDirectly(Point X1Y1, Point WidthHeight, int index)
        {
            _shapes.SetDirect(X1Y1, WidthHeight, index);
        }

        // 鍵盤按下按鍵
        public void FormKeyDown(System.Windows.Forms.Keys keys)
        {
            Dictionary<Shape, int> deleteShapeList = new Dictionary<Shape, int>();
            if (keys == System.Windows.Forms.Keys.Delete)
            {
                foreach (Shape shape in _shapes.ShapeList.ToArray())
                {
                    if (shape.Selected == true)
                    {
                        deleteShapeList.Add(shape, _shapes.ShapeList.IndexOf(shape));
                        if (_panelChanged != null)
                        {
                            _panelChanged(this);
                        }
                    }
                }
                DeleteCommand(deleteShapeList);
            }
        }

        // 在畫布移動滑鼠時的cursor
        public void ChangeCursor(Point point)
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

        // scale point
        public void SetScale(float width, float height)
        {
            _shapes.SetScale(width, height);
        }

        // 畫圖command
        public void DrawCommand()
        {
            _commandManager.Execute(new DrawCommand(this, _shapes.Shape));
        }

        // add button command
        public void AddCommand(string selectShapeName)
        {
            SelectShapeName = selectShapeName;
            CreateShapes();
            _commandManager.Execute(new AddCommand(this, _shapes.Shape));
        }

        // delete command
        public void DeleteCommand(Dictionary<Shape, int> deleteShapeList)
        {
            if (deleteShapeList.Count != 0)
            {
                _commandManager.Execute(new DeleteCommand(this, deleteShapeList));
            }
        }

        // move command
        public void MoveCommand()
        {
            _afterMove = new Dictionary<(Point X1Y1, Point WidthHeight), int>();
            foreach (Shape shape in _shapes.ShapeList.ToArray())
            {
                if (shape.Selected)
                {
                    _afterMove.Add(shape.GetX1Y1WidthHeightTuple(), _shapes.ShapeList.IndexOf(shape));
                }
            }
            _commandManager.Execute(new MoveCommand(this, _beforeMove, _afterMove));
        }

        // move before
        public void MoveBefore()
        {
            _beforeMove = new Dictionary<(Point X1Y1, Point WidthHeight), int>();
            foreach (Shape shape in _shapes.ShapeList.ToArray())
            {
                if (shape.Selected)
                {
                    _beforeMove.Add(shape.GetX1Y1WidthHeightTuple(), _shapes.ShapeList.IndexOf(shape));
                }
            }
        }

        // undo click
        public void Undo()
        {
            _commandManager.Undo();
        }

        // redo click
        public void Redo()
        {
            _commandManager.Redo();
        }
    }
}
