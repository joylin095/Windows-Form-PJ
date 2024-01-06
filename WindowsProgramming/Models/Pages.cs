using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPractice
{
    public class Pages
    {
        Shapes _shapes = new Shapes();
        List<Shapes> _shapesList;
        int _currentPage;

        public Pages()
        {

            _shapesList = new List<Shapes>()
            {
                _shapes
            };
            _currentPage = 0;
        }

        public Shapes ShapeList
        {
            get
            {
                return _shapesList[_currentPage];
            }
        }

        public Shapes TempShapes
        {
            get
            {
                return _shapes;
            }
        }

        public int PageSum
        {
            get
            {
                return _shapesList.Count;
            }
        }

        // set current page
        public void SetCurrentPage(int currentPage)
        {
            _currentPage = currentPage;
        }

        // get page
        public Shapes GetPage(int pageIndex)
        {
            return _shapesList[pageIndex];
        }

        // 增加頁面
        public void CreateNewPage()
        {
            _shapes = new Shapes();
            //_shapesList.Add(_shapes);
        }

        // add shapes
        //public void AddPage(Shapes shapes)
        //{
        //    _shapesList.Add(shapes);
        //}

        // delete page
        public void DeletePage(int pageIndex)
        {
            _shapesList.RemoveAt(pageIndex);
        }

        // insert page
        public void InsertPage(int pageIndex, Shapes shapes)
        {
            _shapesList.Insert(pageIndex, shapes);
        }

        // draw shape
        //public void DrawShape(IGraphics graphics, bool isDrawing, int drawPage = -1)
        //{
        //    if (drawPage == -1)
        //    {
        //        _shapesList[_currentPage].DrawAll(graphics);
        //        _shapesList[_currentPage].IsDrawing = isDrawing;
        //    }
        //    else
        //    {
        //        _shapesList[drawPage].DrawAll(graphics);
        //        _shapesList[drawPage].IsDrawing = isDrawing;
        //    }
        //}

        // create shape
        //public void CreateShape(string selectShapeName, Point x1Y1 = default, Point x2Y2 = default)
        //{
        //    _shapesList[_currentPage].CreateShape(selectShapeName, x1Y1, x2Y2);
        //}

        //加入shape到list
        //public void AddShape(Shape shape = null, int insertIndex = -1)
        //{
        //    _shapesList[_currentPage].AddShape(shape, insertIndex);
        //}

        // 更新shape座標
        //public void UpdateLocation(Point firstPoint, Point newPoint)
        //{
        //    _shapesList[_currentPage].UpdateLocation(firstPoint, newPoint);
        //}
    }
}
