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
        Shapes shapes = new Shapes();
        List<Shapes> _shapesList;
        int _currentPage;

        public Shapes ShapeList
        {
            get
            {
                return _shapesList[_currentPage];
            }
        }

        public Pages()
        {

            _shapesList = new List<Shapes>()
            {
                shapes
            };
            _currentPage = 0;
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
            shapes = new Shapes();
            _shapesList.Add(shapes);
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
