using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        const float SCALE16 = 16.0f;
        const float SCALE9 = 9.0f;
        const int TWO = 2;
        string _solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
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
            ToolStripBindButton lineButton = new ToolStripBindButton();
            lineButton.Text = LINE;
            lineButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            try
            {

                string FILE_PATH = Path.Combine(_solutionPath,"images", "1.png");
                lineButton.Image = Bitmap.FromFile(FILE_PATH);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"FileNotFoundException: {ex.Message}");
            }
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
            ToolStripBindButton rectangleButton = new ToolStripBindButton();
            rectangleButton.Text = RECTANGLE;
            rectangleButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            try
            {
                string FILE_PATH = Path.Combine(_solutionPath, "images", "2.png");
                rectangleButton.Image = Bitmap.FromFile(FILE_PATH);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"FileNotFoundException: {ex.Message}");
            }
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
            ToolStripBindButton circleButton = new ToolStripBindButton();
            circleButton.Text = CIRCLE;
            circleButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            try
            {
                string FILE_PATH = Path.Combine(_solutionPath, "images", "3.png");
                circleButton.Image = Bitmap.FromFile(FILE_PATH);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"FileNotFoundException: {ex.Message}");
            }
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
            ToolStripBindButton mouseButton = new ToolStripBindButton();
            mouseButton.Text = MOUSE;
            mouseButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            try
            {
                string FILE_PATH = Path.Combine(_solutionPath, "images", "4.jpg");
                mouseButton.Image = Bitmap.FromFile(FILE_PATH);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"FileNotFoundException: {ex.Message}");
            }
            mouseButton.DataBindings.Add(CHECKED, _presentationModel.ToolBarCheckedList[THREE], VALUE);
            mouseButton.Click += ToolStripButtonClick;
            _toolStrip1.Items.Add(mouseButton);
        }

        // 創ToolStripButtonUndo
        private void CreateToolStripButtonUndo()
        {
            const string UNDO = "Undo";
            _undoButton = new ToolStripButton();
            _undoButton.Click += UndoClick;
            _undoButton.Enabled = false;
            _undoButton.Text = UNDO;
            _undoButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            try
            {
                string FILE_PATH = Path.Combine(_solutionPath, "images", "undo.png");
                _undoButton.Image = Bitmap.FromFile(FILE_PATH);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"FileNotFoundException: {ex.Message}");
            }
            _toolStrip1.Items.Add(_undoButton);
        }

        // 創ToolStripButtonRedo
        private void CreateToolStripButtonRedo()
        {
            const string REDO = "Redo";
            _redoButton = new ToolStripButton();
            _redoButton.Click += RedoClick;
            _redoButton.Enabled = false;
            _redoButton.Text = REDO;
            _redoButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            try
            {
                string FILE_PATH = Path.Combine(_solutionPath, "images", "redo.png");
                _redoButton.Image = Bitmap.FromFile(FILE_PATH);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"FileNotFoundException: {ex.Message}");
            }
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
            _button1.Height = (int)((_button1.Width / SCALE16) * SCALE9);
            
        }

        // panel縮放更新
        private void PanelRefresh()
        {
            _panel1.Width = _splitContainer2.Panel1.Width;
            _panel1.Height = (int)((_panel1.Width / SCALE16) * SCALE9);
            Point test = _panel1.Location;
            test.Y = (_splitContainer1.Height - _panel1.Height) / TWO;
            _panel1.Location = test;
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
            RefreshUi();
        }

        // 按下新增鍵
        private void AddDataButtonClick(object sender, EventArgs e)
        {
            inputForm dialog = new inputForm();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _model.AddCommand(_selectShapeBox.SelectedItem.ToString(), dialog.GetTopLeftPoint(), dialog.GetBottomRightPoint());
                RefreshUi();
            }  
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
