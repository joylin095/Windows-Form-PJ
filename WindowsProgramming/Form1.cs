using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsPractice
{
    public partial class Form1 : Form
    {
        Model _model;
        PresentationModel _presentationModel;
        ToolStripButton _redoButton;
        ToolStripButton _undoButton;
        const string DELETE = "刪除";
        const int DELETE_BUTTON_COLUMN_INDEX = 0;
        const int SCALE16 = 16;
        const int SCALE9 = 9;
        const int TWO = 2;
        public Form1(Model model)
        {
            InitializeComponent();
            _selectShapeBox.SelectedItem = _selectShapeBox.Items[0];
            _model = model;
            _model._panelChanged += HandlePanelChanged;
            _model._cursorToDefault += HandleCursorToDefault;
            _presentationModel = new PresentationModel(model);
            _recordDataGridView.DataSource = _model.BindingShapeList;
            CallViewModelToRecordAllShapeName();
            CreateToolStripButtonLine();
            CreateToolStripButtonRectangle();
            CreateToolStripButtonCircle();
            CreateToolStripButtonMouse();
            CreateToolStripButtonUndo();
            CreateToolStripButtonRedo();
            _presentationModel.InitialPanelSize = _panel1.Size;
        }

        // 創ToolStripButtonLine
        private void CreateToolStripButtonLine()
        {
            const string LINE = "線";
            const string CHECKED = "Checked";
            const string VALUE = "Value";
            const string FILE_PATH = "../../../images/1.png";
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
            const string FILE_PATH = "../../../images/2.png";
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
            const string FILE_PATH = "../../../images/3.png";
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
            const string FILE_PATH = "../../../images/4.jpg";
            ToolStripBindButton mouseButton = new ToolStripBindButton();
            mouseButton.Text = MOUSE;
            mouseButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            mouseButton.Image = Bitmap.FromFile(FILE_PATH);
            mouseButton.DataBindings.Add(CHECKED, _presentationModel.ToolBarCheckedList[THREE], VALUE);
            mouseButton.Click += ToolStripButtonClick;
            _toolStrip1.Items.Add(mouseButton);
        }

        // 創ToolStripButtonUndo
        private void CreateToolStripButtonUndo()
        {
            const string UNDO = "Undo";
            const string FILE_PATH = "../../../images/undo.png";
            _undoButton = new ToolStripButton();
            _undoButton.Click += UndoClick;
            _undoButton.Enabled = false;
            _undoButton.Text = UNDO;
            _undoButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _undoButton.Image = Bitmap.FromFile(FILE_PATH);
            _toolStrip1.Items.Add(_undoButton);
        }

        // 創ToolStripButtonRedo
        private void CreateToolStripButtonRedo()
        {
            const string REDO = "Redo";
            const string FILE_PATH = "../../../images/redo.png";
            _redoButton = new ToolStripButton();
            _redoButton.Click += RedoClick;
            _redoButton.Enabled = false;
            _redoButton.Text = REDO;
            _redoButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _redoButton.Image = Bitmap.FromFile(FILE_PATH);
            _toolStrip1.Items.Add(_redoButton);
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

        // button縮放更新
        private void Button1Refresh()
        {
            _button1.Width = _splitContainer1.Panel1.Width;
            _button1.Height = (_button1.Width / SCALE16) * SCALE9;
        }

        // panel縮放更新
        private void PanelRefresh()
        {
            _panel1.Width = _splitContainer2.Panel1.Width;
            _panel1.Height = (_panel1.Width / SCALE16) * SCALE9;
            Point test = _panel1.Location;
            test.Y = (_splitContainer1.Height - _panel1.Height) / TWO;
            _panel1.Location = test;
        }

        // 更新畫佈
        private void HandlePanelChanged(object sender)
        {
            RefreshUi();
        }

        // 畫完圖形改變游標
        private void HandleCursorToDefault(object sender)
        {
            this.Cursor = Cursors.Default;
            RefreshUi();
        }

        // 按下新增鍵
        private void AddDataButtonClick(object sender, EventArgs e)
        {
            _model.AddCommand(_selectShapeBox.SelectedItem.ToString());
            RefreshUi();
        }

        //判斷是刪除哪行
        private void RecordDataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DELETE_BUTTON_COLUMN_INDEX && e.RowIndex >= 0)
            {
                _model.DeleteCommand(new Dictionary<Shape, int>() 
                {
                    { 
                        _model.BindingShapeList[e.RowIndex], e.RowIndex 
                    } 
                });
                RefreshUi();
            }
        }

        // panel畫面繪製
        private void Panel1Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.ScaleTransform(_presentationModel.WidthScale, _presentationModel.HeightScale);
            _model.Draw(new WindowsFormsGraphicsAdaptor(e.Graphics, new Pen(Color.Green)));
        }

        // button畫面繪製
        private void Button1Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.ScaleTransform((float)_button1.Width / _presentationModel.InitialPanelSize.Width, (float)_button1.Height / _presentationModel.InitialPanelSize.Height);
            _model.Draw(new WindowsFormsGraphicsAdaptor(e.Graphics, new Pen(Color.Green)));
        }

        // 當ToolStripButton按下去時
        private void ToolStripButtonClick(object sender, EventArgs e)
        {
            ToolStripButton toolStripButton = sender as ToolStripButton;
            _presentationModel.ToolStripButtonClick(toolStripButton.Text);
        }

        // all UI refresh
        private void RefreshUi()
        {
            _undoButton.Enabled = _model.IsUndoEnabled;
            _redoButton.Enabled = _model.IsRedoEnabled;
            _panel1.Invalidate();
            _button1.Invalidate();
            _model.SetScale(_presentationModel.WidthScale, _presentationModel.HeightScale);
            _recordDataGridView.Invalidate();
        }

        // undo click
        private void UndoClick(object sender, EventArgs e)
        {
            _model.Undo();
            RefreshUi();
        }

        // redo click
        private void RedoClick(object sender, EventArgs e)
        {
            _model.Redo();
            RefreshUi();
        }

        // 當在畫佈按下滑鼠時
        private void Panel1MouseDown(object sender, MouseEventArgs e)
        {
            _presentationModel.Panel1MouseDown(e.Location);
            //RefreshUi();
        }

        // 當在畫佈移動滑鼠時
        private void Panel1MouseMove(object sender, MouseEventArgs e)
        {
            _presentationModel.Panel1MouseMove(e.Location);
            RefreshUi();
            this.Cursor = _model.Cursor;
        }

        // 當在畫佈放開滑鼠時
        private void Panel1MouseUp(object sender, MouseEventArgs e)
        {
            _presentationModel.Panel1MouseUp(e.Location);
            RefreshUi();
        }

        // 當在滑鼠進入畫布時
        private void Panel1MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = _model.IsDrawing ? Cursors.Cross : Cursors.Default;
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

        // panel resize
        private void SplitContainer2Panel1Resize(object sender, EventArgs e)
        {
            PanelRefresh();
            Button1Refresh();
            if (_presentationModel != null && !_presentationModel.InitialPanelSize.IsEmpty)
            {
                _presentationModel.NewPanelSize = _panel1.Size;
                _presentationModel.SetScale();
                RefreshUi();
            }
        }
    }
}
