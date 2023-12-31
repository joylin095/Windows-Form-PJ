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
    public partial class Model
    {
        public delegate void PanelChangedEventHandler(object sender);
        public event PanelChangedEventHandler _panelChanged;
        public delegate void CursorToDefaultEventHandler(object sender);
        public event CursorToDefaultEventHandler _cursorToDefault;
        public delegate void AddPageEventHandler(object sender);
        public event AddPageEventHandler _addPageEvent;
        public delegate void DeletePageEventHandler(object sender, int pageIndex);
        public event DeletePageEventHandler _deletePageEvent;
        public delegate void CurrentPageEventHandler(object sender, int pageIndex);
        public event CurrentPageEventHandler _currentPageEvent;

        Pages _pages;
        Pen _pen;
        CommandManager _commandManager;
        Dictionary<int, (Point X1Y1, Point WidthHeight)> _beforeMove = new Dictionary<int, (Point X1Y1, Point WidthHeight)>();
        Dictionary<int, (Point X1Y1, Point WidthHeight)> _afterMove = new Dictionary<int, (Point X1Y1, Point WidthHeight)>();
        int _currentPage;
        int _clickPage;

        public Model()
        {  
            _pages = new Pages();
            _pen = new Pen(Color.Green);
            _commandManager = new CommandManager();
            IsDrawing = false;
            _currentPage = 0;
            _clickPage = -1;
        }

        // 點擊button時
        public void ClickCreatePage(int currentPage)
        {
            _currentPage = currentPage;
            _clickPage = currentPage;
            _pages.SetCurrentPage(_currentPage);
        }

        // 新增頁面
        public void CreateNewPage(int currentPage)
        {
            _currentPage = currentPage;
            _pages.CreateNewPage();
            _pages.SetCurrentPage(_currentPage);
        }

        // delete page
        public void DeletePage(int pageIndex)
        {
            _pages.DeletePage(pageIndex);
            if (_pages.PageSum <= pageIndex)
            {
                SetCurrentPage(_pages.PageSum - 1);
            }
            else
            {
                SetCurrentPage(pageIndex);
            }
        }

        // insert page
        public void InsertPage(int pageIndex, Shapes shapes)
        {
            _pages.InsertPage(pageIndex, shapes);
            SetCurrentPage(pageIndex);
        }

        // set current page
        public void SetCurrentPage(int currentPage)
        {
            _currentPage = currentPage;
            _pages.SetCurrentPage(_currentPage);
            if (_currentPageEvent != null)
            {
                _currentPageEvent(this, currentPage);
            }
        }

        // 創建shape
        public void CreateShapes(Point x1Y1 = default, Point x2Y2 = default)
        {
            Shapes.CreateShape(SelectShapeName, x1Y1, x2Y2);
        }

        // 加入shape到list
        public void AddShape(Shape shape = null, int insertIndex = -1)
        {
            Shapes.AddShape(shape, insertIndex);
        }

        // 刪除shape
        public void DeleteData(int deleteRowIndex)
        {
            Shapes.DeleteData(deleteRowIndex);
        }

        // 畫圖
        public void Draw(IGraphics graphics, int drawPage = -1)
        {
            Shapes shapes = drawPage != -1 ? _pages.GetPage(drawPage) : _pages.GetPage(_currentPage);
            shapes.DrawAll(graphics);
            shapes.IsDrawing = IsDrawing;
        }

        // 紀錄第一個按下去的點
        public void SetShapeFirstPoint(Point point)
        {
            FirstPoint = point;
        }

        // 更新座標
        public void UpdateLocation(Point newPoint)
        {
            Shapes.UpdateLocation(FirstPoint, newPoint);
        }

        // 判斷shape有被選到 而且 鼠標也指到
        public bool IsSelectedAndInPoint(Point point)
        {
            return Shapes.IsSelectedAndInPoint(point);
        }

        // 判斷shape沒被選到 但是 鼠標有指到
        public bool IsNotSelectedButInPoint(Point point)
        {
            return Shapes.IsNotSelectedButInPoint(point);
        }

        // 移動選取的shape
        public void ShapeMove(Point point)
        {
            Shapes.ShapeMove(new Point(point.X - FirstPoint.X, point.Y - FirstPoint.Y));
            FirstPoint = point;
        }

        // 是否按到外框的圓
        public bool IsClickBorderCircle(Point point)
        {
            return Shapes.IsClickBorderCircle(point);
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
            Shapes.Direction = -1;
            if (_cursorToDefault != null)
            {
                _cursorToDefault(this);
            }
        }

        // 直接設定圖形
        public void SetDirectly(Point X1Y1, Point WidthHeight, int index)
        {
            Shapes.SetDirect(X1Y1, WidthHeight, index);
        }

        // 鍵盤按下按鍵
        public void FormKeyDown(System.Windows.Forms.Keys keys)
        {
            if (keys == System.Windows.Forms.Keys.Delete)
            {
                if (_clickPage != -1 && _pages.PageSum > 1)
                {
                    DeletePageCommand(_clickPage);
                    _clickPage = -1;
                    return;
                }
                DeleteShapeList();
            }
        }

        // delete shape list
        public void DeleteShapeList()
        {
            Dictionary<Shape, int> deleteShapeList = new Dictionary<Shape, int>();
            foreach (Shape shape in Shapes.ShapeList.ToArray())
            {
                if (shape.Selected == true)
                {
                    deleteShapeList.Add(shape, Shapes.ShapeList.IndexOf(shape));
                    if (_panelChanged != null)
                    {
                        _panelChanged(this);
                    }
                }
            }
            DeleteCommand(deleteShapeList);
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
                if (Shapes.Direction == -1)
                {
                    Cursor = Shapes.GetCursorAtBorderCircle(point);
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
            Shapes.SetScale(width, height);
        }

        // add page handler
        public void HandleAddPage()
        {
            if (_addPageEvent != null)
            {
                _addPageEvent(this);
            }
        }

        // delete page handler
        public void HandleDeletePage(int pageIndex)
        {
            if (_deletePageEvent != null)
            {
                _deletePageEvent(this, pageIndex);
            }
        }
    }
}
