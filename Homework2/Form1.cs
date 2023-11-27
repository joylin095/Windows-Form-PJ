using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework2
{
    public partial class Form1 : Form
    {
        Model _model;
        PresentationModel _presentationModel;
        const string DELETE = "刪除";
        const int DELETE_BUTTON_COLUMN_INDEX = 0;
        public Form1(Model model)
        {
            InitializeComponent();
            _selectShapeBox.SelectedItem = _selectShapeBox.Items[0];
            _model = model;
            _model.PanelChanged += HandlePanelChanged;
            _model.CursorToDefault += HandleCursorToDefault;
            _presentationModel = new PresentationModel(model);
            _recordDataGridView.DataSource = _model.BindingShapeList;
            CallViewModelToRecordAllShapeName();
            CreateToolStripButtonLine();
            CreateToolStripButtonRectangle();
            CreateToolStripButtonCircle();
            CreateToolStripButtonMouse();
        }

        // 創ToolStripButtonLine
        private void CreateToolStripButtonLine()
        {
            const string LINE = "線";
            const string CHECKED = "Checked";
            const string VALUE = "Value";
            const string FILE_PATH = "c:\\Users\\USER\\Desktop\\Homework2\\images\\1.png";
            ToolStripBindButton lineButton = new ToolStripBindButton();
            lineButton.Text = LINE;
            lineButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            lineButton.Image = Bitmap.FromFile(FILE_PATH);
            lineButton.DataBindings.Add(CHECKED, _presentationModel.ToolBarCheckedList[0], VALUE);
            lineButton.Click += ToolStripButtonClick;
            _toolStrip1.Items.Add(lineButton);
        }

        // 創ToolStripButtonRectangle
        private void CreateToolStripButtonRectangle()
        {
            const string RECTANGLE = "矩形";
            const string CHECKED = "Checked";
            const string VALUE = "Value";
            const string FILE_PATH = "c:\\Users\\USER\\Desktop\\Homework2\\images\\2.png";
            ToolStripBindButton rectangleButton = new ToolStripBindButton();
            rectangleButton.Text = RECTANGLE;
            rectangleButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            rectangleButton.Image = Bitmap.FromFile(FILE_PATH);
            rectangleButton.DataBindings.Add(CHECKED, _presentationModel.ToolBarCheckedList[1], VALUE);
            rectangleButton.Click += ToolStripButtonClick;
            _toolStrip1.Items.Add(rectangleButton);
        }

        // 創ToolStripButtonCircle
        private void CreateToolStripButtonCircle()
        {
            const string CIRCLE = "圓";
            const string CHECKED = "Checked";
            const string VALUE = "Value";
            const int TWO = 2;
            const string FILE_PATH = "c:\\Users\\USER\\Desktop\\Homework2\\images\\3.png";
            ToolStripBindButton circleButton = new ToolStripBindButton();
            circleButton.Text = CIRCLE;
            circleButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            circleButton.Image = Bitmap.FromFile(FILE_PATH);
            circleButton.DataBindings.Add(CHECKED, _presentationModel.ToolBarCheckedList[TWO], VALUE);
            circleButton.Click += ToolStripButtonClick;
            _toolStrip1.Items.Add(circleButton);
        }

        // 創ToolStripButtonMouse
        private void CreateToolStripButtonMouse()
        {
            const string MOUSE = "選取";
            const string CHECKED = "Checked";
            const string VALUE = "Value";
            const int THREE = 3;
            const string FILE_PATH = "c:\\Users\\USER\\Desktop\\Homework2\\images\\4.jpg";
            ToolStripBindButton mouseButton = new ToolStripBindButton();
            mouseButton.Text = MOUSE;
            mouseButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            mouseButton.Image = Bitmap.FromFile(FILE_PATH);
            mouseButton.DataBindings.Add(CHECKED, _presentationModel.ToolBarCheckedList[THREE], VALUE);
            mouseButton.Click += ToolStripButtonClick;
            _toolStrip1.Items.Add(mouseButton);
        }

        // 把全部的shape name傳給ViewModel
        private void CallViewModelToRecordAllShapeName()
        {
            List<string> shapeNameList = new List<string>();
            foreach (string shape in _selectShapeBox.Items)
            {
                shapeNameList.Add(shape);
            }
            _presentationModel.RecordAllShapeName(shapeNameList);
        }

        // 更新畫佈
        private void HandlePanelChanged(object sender)
        {
            _panel1.Invalidate();
            _button1.Invalidate();
        }

        // 畫完圖形改變游標
        private void HandleCursorToDefault(object sender)
        {
            this.Cursor = Cursors.Default;
            _recordDataGridView.Invalidate();
        }

        // 按下新增鍵
        private void AddDataButtonClick(object sender, EventArgs e)
        {
            _model.SelectShapeName = _selectShapeBox.SelectedItem.ToString();
            _model.CreateShapes();
            _model.AddShape();
            _panel1.Invalidate();
            _button1.Invalidate();
        }

        //判斷是刪除哪行
        private void RecordDataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DELETE_BUTTON_COLUMN_INDEX && e.RowIndex >= 0)
            {
                _model.DeleteData(e.RowIndex);
                _panel1.Invalidate();
            }
        }

        // panel畫面繪製
        private void Panel1Paint(object sender, PaintEventArgs e)
        {
            _model.Draw(new WindowsFormsGraphicsAdaptor(e.Graphics, new Pen(Color.Green)));
        }

        // button畫面繪製
        private void Button1Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.ScaleTransform((float)_button1.Width / _panel1.Width, (float)_button1.Height / _panel1.Height);
            _model.Draw(new WindowsFormsGraphicsAdaptor(e.Graphics, new Pen(Color.Green)));
        }

        // 當ToolStripButton按下去時
        private void ToolStripButtonClick(object sender, EventArgs e)
        {
            ToolStripButton toolStripButton = sender as ToolStripButton;
            _presentationModel.ToolStripButtonClick(toolStripButton.Text);
        }

        // 當在畫佈按下滑鼠時
        private void Panel1MouseDown(object sender, MouseEventArgs e)
        {
            _presentationModel.Panel1MouseDown(e.Location);
        }

        // 當在畫佈移動滑鼠時
        private void Panel1MouseMove(object sender, MouseEventArgs e)
        {
            _presentationModel.Panel1MouseMove(e.Location);
            this.Cursor = _model.Cursor;
        }

        // 當在畫佈放開滑鼠時
        private void Panel1MouseUp(object sender, MouseEventArgs e)
        {
            _presentationModel.Panel1MouseUp(e.Location);
        }

        // 當在滑鼠進入畫布時
        private void Panel1MouseEnter(object sender, EventArgs e)
        {
            if (_model.IsDrawing)
            {
                this.Cursor = Cursors.Cross;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        // 當在滑鼠離開畫布時
        private void Panel1MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        // 鍵盤按下按鍵
        private void Form1KeyDown(object sender, KeyEventArgs e)
        {
            _model.FormKeyDown(e.KeyCode);
        }
    }
}
