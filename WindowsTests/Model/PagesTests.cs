using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsPractice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPractice.Tests
{
    [TestClass()]
    public class PagesTests
    {
        Shapes _shapes = new Shapes();
        int _currentPage;
        Pages pages = new Pages();
        PrivateObject privateObject;

        // test
        [TestInitialize()]
        public void InitializeTest()
        {
            _shapes = new Shapes();
            pages = new Pages();
            _currentPage = 0;
            privateObject = new PrivateObject(pages);
        }

        //test
        [TestMethod()]
        public void SetCurrentPageTest()
        {
            pages.SetCurrentPage(_currentPage);
            Assert.AreEqual(_currentPage, privateObject.GetFieldOrProperty("_currentPage"));
        }

        // get test
        [TestMethod()]
        public void GetPageTest()
        {
            pages.InsertPage(_currentPage, _shapes);
            pages.GetPage(_currentPage);
        }

        // create page
        [TestMethod()]
        public void CreateNewPageTest()
        {
            pages.CreateNewPage();
        }

        // delete test
        [TestMethod()]
        public void DeletePageTest()
        {
            pages.DeletePage(_currentPage);
        }

        // test insert
        [TestMethod()]
        public void InsertPageTest()
        {
            pages.InsertPage(_currentPage, _shapes);
        }
    }
}