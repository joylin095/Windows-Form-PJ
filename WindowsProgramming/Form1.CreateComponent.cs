using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsPractice
{
    public partial class Form1
    {
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "圓";
        const string MOUSE = "選取";
        const string NEW_PAGE = "新增頁面";
        const string UNDO = "Undo";
        const string REDO = "Redo";
        const string CHECKED = "Checked";
        const string VALUE = "Value";
        const string IMAGE_PATH = "images";
        const string IMAGE_NAME_LINE = "1.png";
        const string IMAGE_NAME_RECTANGLE = "2.png";
        const string IMAGE_NAME_CIRCLE = "3.png";
        const string IMAGE_NAME_MOUSE = "4.jpg";
        const string IMAGE_NAME_NEW_PAGE = "newPage.png";
        const string IMAGE_NAME_UNDO = "undo.png";
        const string IMAGE_NAME_REDO = "redo.png";
        const string EXCEPTION_STRING = "FileNotFoundException: ";

        // 創ToolStripButtonLine
        private void CreateToolStripButtonLine()
        {
            ToolStripBindButton lineButton = new ToolStripBindButton();
            lineButton.Text = LINE;
            lineButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            try
            {
                string FILE_PATH = Path.Combine(_solutionPath, IMAGE_PATH, IMAGE_NAME_LINE);
                lineButton.Image = Bitmap.FromFile(FILE_PATH);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(EXCEPTION_STRING + ex.Message);
            }
            lineButton.DataBindings.Add(CHECKED, _presentationModel.ToolBarCheckedList[0], VALUE);
            lineButton.Click += ToolStripButtonClick;
            _toolStrip1.Items.Add(lineButton);
        }

        // 創ToolStripButtonRectangle
        private void CreateToolStripButtonRectangle()
        {
            ToolStripBindButton rectangleButton = new ToolStripBindButton();
            rectangleButton.Text = RECTANGLE;
            rectangleButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            try
            {
                string FILE_PATH = Path.Combine(_solutionPath, IMAGE_PATH, IMAGE_NAME_RECTANGLE);
                rectangleButton.Image = Bitmap.FromFile(FILE_PATH);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(EXCEPTION_STRING + ex.Message);
            }
            rectangleButton.DataBindings.Add(CHECKED, _presentationModel.ToolBarCheckedList[1], VALUE);
            rectangleButton.Click += ToolStripButtonClick;
            _toolStrip1.Items.Add(rectangleButton);
        }

        // 創ToolStripButtonCircle
        private void CreateToolStripButtonCircle()
        {
            const int TWO = 2;
            ToolStripBindButton circleButton = new ToolStripBindButton();
            circleButton.Text = CIRCLE;
            circleButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            try
            {
                string FILE_PATH = Path.Combine(_solutionPath, IMAGE_PATH, IMAGE_NAME_CIRCLE);
                circleButton.Image = Bitmap.FromFile(FILE_PATH);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(EXCEPTION_STRING + ex.Message);
            }
            circleButton.DataBindings.Add(CHECKED, _presentationModel.ToolBarCheckedList[TWO], VALUE);
            circleButton.Click += ToolStripButtonClick;
            _toolStrip1.Items.Add(circleButton);
        }

        // 創ToolStripButtonMouse
        private void CreateToolStripButtonMouse()
        {
            const int THREE = 3;
            ToolStripBindButton mouseButton = new ToolStripBindButton();
            mouseButton.Text = MOUSE;
            mouseButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            try
            {
                string FILE_PATH = Path.Combine(_solutionPath, IMAGE_PATH, IMAGE_NAME_MOUSE);
                mouseButton.Image = Bitmap.FromFile(FILE_PATH);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(EXCEPTION_STRING + ex.Message);
            }
            mouseButton.DataBindings.Add(CHECKED, _presentationModel.ToolBarCheckedList[THREE], VALUE);
            mouseButton.Click += ToolStripButtonClick;
            _toolStrip1.Items.Add(mouseButton);
        }

        // 創ToolStripButtonNewPage
        private void CreateToolStripButtonNewPage()
        {   
            _newPageButton = new ToolStripButton();
            _newPageButton.Click += AddNewPageClick;
            _newPageButton.Text = NEW_PAGE;
            _newPageButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            try
            {
                string FILE_PATH = Path.Combine(_solutionPath, IMAGE_PATH, IMAGE_NAME_NEW_PAGE);
                _newPageButton.Image = Bitmap.FromFile(FILE_PATH);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(EXCEPTION_STRING + ex.Message);
            }
            _toolStrip1.Items.Add(_newPageButton);
        }

        // 創ToolStripButtonUndo
        private void CreateToolStripButtonUndo()
        {
            _undoButton = new ToolStripButton();
            _undoButton.Click += UndoClick;
            _undoButton.Enabled = false;
            _undoButton.Text = UNDO;
            _undoButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            try
            {
                string FILE_PATH = Path.Combine(_solutionPath, IMAGE_PATH, IMAGE_NAME_UNDO);
                _undoButton.Image = Bitmap.FromFile(FILE_PATH);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(EXCEPTION_STRING + ex.Message);
            }
            _toolStrip1.Items.Add(_undoButton);
        }

        // 創ToolStripButtonRedo
        private void CreateToolStripButtonRedo()
        {
            _redoButton = new ToolStripButton();
            _redoButton.Click += RedoClick;
            _redoButton.Enabled = false;
            _redoButton.Text = REDO;
            _redoButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            try
            {
                string FILE_PATH = Path.Combine(_solutionPath, IMAGE_PATH, IMAGE_NAME_REDO);
                _redoButton.Image = Bitmap.FromFile(FILE_PATH);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(EXCEPTION_STRING + ex.Message);
            }
            _toolStrip1.Items.Add(_redoButton);
        }

        // create button
        private void CreateButton()
        {
            Point point;
            Button button = new Button();
            button.Width = _splitContainer1.Panel1.Width;
            button.Height = (int)((button.Width / SCALE16) * SCALE9);
            button.BackColor = Color.White;
            point = _buttonList[_buttonList.Count - 1].Location;
            point.Y += (SMALL_INTEGER + button.Height);
            button.Location = point;
            button.Click += ButtonClick;
            button.Paint += ButtonPaint;
            button.FlatStyle = FlatStyle.Flat;
            _splitContainer1.Panel1.Controls.Add(button);
            _buttonList.Add(button);
        }

        // 更新畫佈
        private void HandlePanelChanged(object sender)
        {
            _panel1.Invalidate();
            foreach (Button button in _buttonList)
            {
                button.Invalidate();
            }
        }

        // 畫完圖形改變游標
        private void HandleCursorToDefault(object sender)
        {
            this.Cursor = Cursors.Default;
            RefreshUi();
        }

        // create new page
        private void HandleAddPage(object sender)
        {
            CreateButton();
            SetButtonBorder(_buttonList.Count - 1);
            RefreshUi();
        }

        // delete page
        private void HandleDeletePage(object sender, int pageIndex)
        {
            _splitContainer1.Panel1.Controls.Remove(_buttonList[pageIndex]);
            _buttonList.RemoveAt(pageIndex);
            SetButtonBorder(pageIndex);
            RefreshUi();
        }

        // set current page
        private void HandleSetButtonBorder(object sender, int pageIndex)
        {
            SetButtonBorder(pageIndex);
        }
    }
}
