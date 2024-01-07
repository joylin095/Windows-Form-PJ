using System;
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
    public partial class Model
    {

        public Shapes Shapes
        {
            get
            {
                return _pages.ShapeList;
            }
        }

        public BindingList<Shape> BindingShapeList
        {
            get
            {
                return Shapes.ShapeList;
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

        // add page command
        public void AddPageCommand(int currentPage)
        {
            CreateNewPage(currentPage);
            Shapes shapes = _pages.TempShapes;
            _commandManager.Execute(new AddPageCommand(this, shapes, currentPage));
        }

        // delete page command
        public void DeletePageCommand(int currentPage)
        {
            _commandManager.Execute(new DeletePageCommand(this, Shapes, currentPage));
        }

        // 畫圖command
        public void DrawCommand()
        {
            _clickPage = -1;
            _commandManager.Execute(new DrawCommand(this, Shapes.Shape, _currentPage));
        }

        // add button command
        public void AddCommand(string selectShapeName, Point x1Y1, Point x2Y2)
        {
            _clickPage = -1;
            SelectShapeName = selectShapeName;
            CreateShapes(x1Y1, x2Y2);
            _commandManager.Execute(new AddCommand(this, Shapes.Shape, _currentPage));
        }

        // delete command
        public void DeleteCommand(Dictionary<Shape, int> deleteShapeList)
        {
            if (deleteShapeList.Count != 0)
            {
                _clickPage = -1;
                _commandManager.Execute(new DeleteCommand(this, deleteShapeList, _currentPage));
            }
        }

        // move command
        public void MoveCommand()
        {
            _afterMove = new Dictionary<int, (Point X1Y1, Point WidthHeight)>();
            foreach (Shape shape in Shapes.ShapeList.ToArray())
            {
                if (shape.Selected)
                {
                    if (_beforeMove[Shapes.ShapeList.IndexOf(shape)] != shape.GetX1Y1WidthHeightTuple())
                    {
                        _afterMove.Add(Shapes.ShapeList.IndexOf(shape), shape.GetX1Y1WidthHeightTuple());
                    }
                }
            }
            if (_beforeMove.Count != 0 && _beforeMove.Count == _afterMove.Count)
            {
                _clickPage = -1;
                _commandManager.Execute(new MoveCommand(this, _beforeMove, _afterMove, _currentPage));
            }
        }

        // move before
        public void MoveBefore()
        {
            _beforeMove = new Dictionary<int, (Point X1Y1, Point WidthHeight)>();
            foreach (Shape shape in Shapes.ShapeList.ToArray())
            {
                if (shape.Selected)
                {
                    _beforeMove.Add(Shapes.ShapeList.IndexOf(shape), shape.GetX1Y1WidthHeightTuple());
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
