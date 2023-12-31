﻿using System;
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
        }

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
    }
}
