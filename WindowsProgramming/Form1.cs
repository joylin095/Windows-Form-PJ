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
        ToolStripButton _newPageButton;
        const string DELETE = "刪除";
        const string BUTTON_NAME = "_button";
        const int DELETE_BUTTON_COLUMN_INDEX = 0;
        const float SCALE16 = 16.0f;
        const float SCALE9 = 9.0f;
        const int TWO = 2;
        const int SMALL_INTEGER = 5;
        const string PATH = "..\\..\\..\\";
        string _solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, PATH));
        List<Button> _buttonList = new List<Button>();
        public Form1(Model model)
        {
            InitializeComponent();
            _selectShapeBox.SelectedItem = _selectShapeBox.Items[0];
            _model = model;
            _model._panelChanged += HandlePanelChanged;
            _model._cursorToDefault += HandleCursorToDefault;
            _model._addPageEvent += HandleAddPage;
            _model._deletePageEvent += HandleDeletePage;
            _model._currentPageEvent += HandleSetButtonBorder;
            _presentationModel = new PresentationModel(model);
            _recordDataGridView.DataSource = _model.BindingShapeList;
            CallViewModelToRecordAllShapeName();
            CreateToolStripButton();
            _presentationModel.InitialPanelSize = _panel1.Size;
            _buttonList.Add(_button1);
            ButtonRefresh();
        }

        // create全部 CreateToolStripButton
        private void CreateToolStripButton()
        {
            CreateToolStripButtonLine();
            CreateToolStripButtonRectangle();
            CreateToolStripButtonCircle();
            CreateToolStripButtonMouse();
            CreateToolStripButtonNewPage();
            CreateToolStripButtonUndo();
            CreateToolStripButtonRedo();
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
        private void ButtonRefresh()
        {
            for (int i = 0; i < _buttonList.Count; i++)
            {
                ResetButton(i);
            }
        }

        // reset button
        private void ResetButton(int index)
        {
            Point point;
            _buttonList[index].Name = BUTTON_NAME + index.ToString();
            _buttonList[index].Width = _splitContainer1.Panel1.Width - SMALL_INTEGER;
            _buttonList[index].Height = (int)((_buttonList[index].Width / SCALE16) * SCALE9);
            if (index != 0)
            {
                point = _buttonList[index - 1].Location;
                point.Y += (SMALL_INTEGER + _buttonList[index].Height);
                _buttonList[index].Location = point;
            }
            else
            {
                _buttonList[index].Location = new Point(0, 0);
            }
            _buttonList[index].Invalidate();
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

        // 按下新增鍵
        private void AddDataButtonClick(object sender, EventArgs e)
        {
            InputForm dialog = new InputForm();
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
        private void ButtonPaint(object sender, PaintEventArgs e)
        {
            foreach (Button button in _buttonList)
            {
                if (button == sender)
                {
                    e.Graphics.ScaleTransform((float)button.Width / _presentationModel.InitialPanelSize.Width, (float)button.Height / _presentationModel.InitialPanelSize.Height);
                    _model.Draw(new WindowsFormsGraphicsAdaptor(e.Graphics, new Pen(Color.Green)), _buttonList.IndexOf(button));
                }
            }
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
            ButtonRefresh();
            _model.SetScale(_presentationModel.WidthScale, _presentationModel.HeightScale);
            _recordDataGridView.DataSource = _model.BindingShapeList;
            _recordDataGridView.Invalidate();
        }

        // new page click
        private void AddNewPageClick(object sender, EventArgs e)
        {
            _model.AddPageCommand(_buttonList.Count);
            RefreshUi();
        }

        // button click
        private void ButtonClick(object sender, EventArgs e)
        {
            foreach (Button button in _buttonList)
            {
                if (button == sender)
                {
                    _model.ClickCreatePage(_buttonList.IndexOf(button));
                    SetButtonBorder(_buttonList.IndexOf(button));
                }
            }
            RefreshUi();
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
            ButtonRefresh();
            if (_presentationModel != null && !_presentationModel.InitialPanelSize.IsEmpty)
            {
                _presentationModel.NewPanelSize = _panel1.Size;
                _presentationModel.SetScale();
                RefreshUi();
            }
        }

        // set button border
        private void SetButtonBorder(int index)
        {
            if (index >= _buttonList.Count)
            {
                _buttonList[_buttonList.Count - 1].FlatAppearance.BorderColor = Color.Red;
                _buttonList[_buttonList.Count - 1].FlatAppearance.BorderSize = 1;
                return;
            }
            for (int i = 0; i < _buttonList.Count; i++)
            {
                SetEveryButtonBorder(index, i);
            }
        }

        // set every button border
        private void SetEveryButtonBorder(int clickIndex, int buttonIndex)
        {
            if (buttonIndex == clickIndex)
            {
                _buttonList[buttonIndex].FlatAppearance.BorderColor = Color.Red;
                _buttonList[buttonIndex].FlatAppearance.BorderSize = 1;
            }
            else
            {
                _buttonList[buttonIndex].FlatAppearance.BorderSize = 0;
            }
        }
    }
}
