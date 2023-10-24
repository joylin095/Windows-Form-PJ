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
            _presentationModel = new PresentationModel(model);
            _presentationModel.drawInPanel += HandleDrawInPanel;
            _presentationModel.addToDataGridView += HandleAddDataGridView;
            _recordDataGridView.DataSource = _model.GetBindingShapeList;
            CallViewModelToRecordAllShapeName();
        }

        // 把全部的shape name傳給ViewModel
        private void CallViewModelToRecordAllShapeName()
        {
            List<string> shapeName = new List<string>();
            foreach (string shape in _selectShapeBox.Items)
            {
                shapeName.Add(shape);
            }
            _presentationModel.RecordAllShapeName(shapeName);
        }
        // 更新畫佈
        private void HandleDrawInPanel(object sender)
        {
            _panel1.Invalidate();
            this.Cursor = Cursors.Cross;
        }

        // 新增資料至DataGridView
        private void HandleAddDataGridView(object sender)
        {
            AddDataToDataGridView();
            this.Cursor = Cursors.Default;
        }

        // 把shape資訊放入datagridview
        private void AddDataToDataGridView()
        {
            //DataGridViewRow row = new DataGridViewRow();
            //DataGridViewButtonCell deleteButtonCell = new DataGridViewButtonCell();
            //deleteButtonCell.Value = DELETE;
            //row.Cells.Add(deleteButtonCell);
            //string[] datas = _model.GetInformation();
            //foreach (string data in datas)
            //{
            //    row.Cells.Add(new DataGridViewTextBoxCell
            //    {
            //        Value = data
            //    });
            //}
            //_recordDataGridView.Rows.Add(row);
        }

        // 更新ToolStripButton的checked狀態
        private void RefreshToolStripButtonStatus()
        {
            foreach (string shapeName in _selectShapeBox.Items)
            {
                foreach(ToolStripItem toolStripItem in _toolStrip1.Items)
                {
                    if (toolStripItem is ToolStripButton button &&  button.Text == shapeName)
                    {
                        button.Checked = _presentationModel.IsToolStripShapeChecked(shapeName);
                        break;
                    }
                }
            }
        }

        // 按下新增鍵
        private void AddDataButtonClick(object sender, EventArgs e)
        {
            _model.CreateShapes(_selectShapeBox.SelectedItem.ToString());
            _model.AddShape();
            //AddDataToDataGridView();
            _panel1.Invalidate();
        }

        //判斷是刪除哪行
        private void RecordDataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DELETE_BUTTON_COLUMN_INDEX && e.RowIndex >= 0)
            {
                _recordDataGridView.Rows.RemoveAt(e.RowIndex);
                _panel1.Invalidate();
            }
        }

        // 畫面繪製
        private void Panel1Paint(object sender, PaintEventArgs e)
        {
            _model.Draw(e.Graphics);
        }

        // 當ToolStripButton按下去時
        private void ToolStripButtonClick(object sender, EventArgs e)
        {
            ToolStripButton toolStripButton = sender as ToolStripButton;
            _presentationModel.ToolStripButtonClick(toolStripButton.Text);
            RefreshToolStripButtonStatus();
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
        }

        // 當在畫佈放開滑鼠時
        private void Panel1MouseUp(object sender, MouseEventArgs e)
        {
            _presentationModel.Panel1MouseUp();
            RefreshToolStripButtonStatus();
        }

        // 當在滑鼠進入畫布時
        private void Panel1MouseEnter(object sender, EventArgs e)
        {
            if (_presentationModel.CanDrawing())
            {
                this.Cursor = Cursors.Cross;
            }
        }

        // 當在滑鼠離開畫布時
        private void Panel1MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
