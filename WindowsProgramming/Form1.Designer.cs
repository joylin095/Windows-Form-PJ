
namespace WindowsPractice
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._addDataButton = new System.Windows.Forms.Button();
            this._selectShapeBox = new System.Windows.Forms.ComboBox();
            this._recordDataGridView = new System.Windows.Forms.DataGridView();
            this._delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._splitContainer3 = new System.Windows.Forms.SplitContainer();
            this._about = new System.Windows.Forms.ToolStripMenuItem();
            this._caption = new System.Windows.Forms.ToolStripMenuItem();
            this._menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._button1 = new System.Windows.Forms.Button();
            this._toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._panel1 = new WindowsPractice.DoubleBufferedPanel();
            this._shape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._shapeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._recordDataGridView)).BeginInit();
            this._groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer3)).BeginInit();
            this._splitContainer3.Panel1.SuspendLayout();
            this._splitContainer3.Panel2.SuspendLayout();
            this._splitContainer3.SuspendLayout();
            this._menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).BeginInit();
            this._splitContainer1.Panel1.SuspendLayout();
            this._splitContainer1.Panel2.SuspendLayout();
            this._splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).BeginInit();
            this._splitContainer2.Panel1.SuspendLayout();
            this._splitContainer2.Panel2.SuspendLayout();
            this._splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shapeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _addDataButton
            // 
            this._addDataButton.Location = new System.Drawing.Point(22, 28);
            this._addDataButton.Name = "_addDataButton";
            this._addDataButton.Size = new System.Drawing.Size(87, 53);
            this._addDataButton.TabIndex = 4;
            this._addDataButton.Text = "新增";
            this._addDataButton.UseVisualStyleBackColor = true;
            this._addDataButton.Click += new System.EventHandler(this.AddDataButtonClick);
            // 
            // _selectShapeBox
            // 
            this._selectShapeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._selectShapeBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._selectShapeBox.FormattingEnabled = true;
            this._selectShapeBox.Items.AddRange(new object[] {
            "線",
            "矩形",
            "圓"});
            this._selectShapeBox.Location = new System.Drawing.Point(136, 44);
            this._selectShapeBox.Name = "_selectShapeBox";
            this._selectShapeBox.Size = new System.Drawing.Size(142, 23);
            this._selectShapeBox.TabIndex = 4;
            // 
            // _recordDataGridView
            // 
            this._recordDataGridView.AutoGenerateColumns = false;
            this._recordDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._recordDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this._recordDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._recordDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._delete,
            this._shape,
            this._info,
            this._nameDataGridViewTextBoxColumn,
            this._locationDataGridViewTextBoxColumn});
            this._recordDataGridView.DataSource = this._shapeBindingSource;
            this._recordDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._recordDataGridView.Location = new System.Drawing.Point(0, 0);
            this._recordDataGridView.Name = "_recordDataGridView";
            this._recordDataGridView.ReadOnly = true;
            this._recordDataGridView.RowHeadersVisible = false;
            this._recordDataGridView.RowHeadersWidth = 51;
            this._recordDataGridView.RowTemplate.Height = 27;
            this._recordDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._recordDataGridView.Size = new System.Drawing.Size(297, 524);
            this._recordDataGridView.TabIndex = 5;
            this._recordDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RecordDataGridViewCellContentClick);
            // 
            // _delete
            // 
            this._delete.FillWeight = 20F;
            this._delete.HeaderText = "刪除";
            this._delete.MinimumWidth = 6;
            this._delete.Name = "_delete";
            this._delete.ReadOnly = true;
            this._delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._delete.Text = "刪除";
            this._delete.UseColumnTextForButtonValue = true;
            // 
            // _groupBox1
            // 
            this._groupBox1.Controls.Add(this._splitContainer3);
            this._groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBox1.Location = new System.Drawing.Point(0, 0);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Size = new System.Drawing.Size(303, 666);
            this._groupBox1.TabIndex = 3;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "資料顯示";
            // 
            // _splitContainer3
            // 
            this._splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._splitContainer3.Location = new System.Drawing.Point(3, 21);
            this._splitContainer3.Name = "_splitContainer3";
            this._splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _splitContainer3.Panel1
            // 
            this._splitContainer3.Panel1.Controls.Add(this._selectShapeBox);
            this._splitContainer3.Panel1.Controls.Add(this._addDataButton);
            // 
            // _splitContainer3.Panel2
            // 
            this._splitContainer3.Panel2.Controls.Add(this._recordDataGridView);
            this._splitContainer3.Size = new System.Drawing.Size(297, 642);
            this._splitContainer3.SplitterDistance = 114;
            this._splitContainer3.TabIndex = 6;
            // 
            // _about
            // 
            this._about.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._caption});
            this._about.Name = "_about";
            this._about.Size = new System.Drawing.Size(53, 26);
            this._about.Text = "說明";
            // 
            // _caption
            // 
            this._caption.Name = "_caption";
            this._caption.Size = new System.Drawing.Size(122, 26);
            this._caption.Text = "關於";
            // 
            // _menuStrip1
            // 
            this._menuStrip1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this._menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._about});
            this._menuStrip1.Location = new System.Drawing.Point(0, 0);
            this._menuStrip1.Name = "_menuStrip1";
            this._menuStrip1.Size = new System.Drawing.Size(1450, 30);
            this._menuStrip1.TabIndex = 0;
            this._menuStrip1.Text = "menuStrip1";
            // 
            // _button1
            // 
            this._button1.AutoSize = true;
            this._button1.BackColor = System.Drawing.Color.White;
            this._button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this._button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._button1.Location = new System.Drawing.Point(-2, 0);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(159, 126);
            this._button1.TabIndex = 1;
            this._button1.UseVisualStyleBackColor = false;
            this._button1.Click += new System.EventHandler(this.ButtonClick);
            this._button1.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonPaint);
            // 
            // _toolStrip1
            // 
            this._toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._toolStrip1.Location = new System.Drawing.Point(0, 30);
            this._toolStrip1.Name = "_toolStrip1";
            this._toolStrip1.Size = new System.Drawing.Size(1450, 31);
            this._toolStrip1.TabIndex = 6;
            this._toolStrip1.Text = "toolStrip1";
            // 
            // _splitContainer1
            // 
            this._splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._splitContainer1.Location = new System.Drawing.Point(0, 61);
            this._splitContainer1.Name = "_splitContainer1";
            // 
            // _splitContainer1.Panel1
            // 
            this._splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._splitContainer1.Panel1.Controls.Add(this._button1);
            // 
            // _splitContainer1.Panel2
            // 
            this._splitContainer1.Panel2.Controls.Add(this._splitContainer2);
            this._splitContainer1.Size = new System.Drawing.Size(1450, 670);
            this._splitContainer1.SplitterDistance = 185;
            this._splitContainer1.TabIndex = 7;
            // 
            // _splitContainer2
            // 
            this._splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._splitContainer2.Location = new System.Drawing.Point(0, 0);
            this._splitContainer2.Name = "_splitContainer2";
            // 
            // _splitContainer2.Panel1
            // 
            this._splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._splitContainer2.Panel1.Controls.Add(this._panel1);
            this._splitContainer2.Panel1.Resize += new System.EventHandler(this.SplitContainer2Panel1Resize);
            // 
            // _splitContainer2.Panel2
            // 
            this._splitContainer2.Panel2.Controls.Add(this._groupBox1);
            this._splitContainer2.Size = new System.Drawing.Size(1261, 670);
            this._splitContainer2.SplitterDistance = 950;
            this._splitContainer2.TabIndex = 0;
            // 
            // _panel1
            // 
            this._panel1.BackColor = System.Drawing.Color.White;
            this._panel1.Location = new System.Drawing.Point(1, 1);
            this._panel1.Name = "_panel1";
            this._panel1.Padding = new System.Windows.Forms.Padding(10);
            this._panel1.Size = new System.Drawing.Size(740, 670);
            this._panel1.TabIndex = 5;
            this._panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1Paint);
            this._panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1MouseDown);
            this._panel1.MouseEnter += new System.EventHandler(this.Panel1MouseEnter);
            this._panel1.MouseLeave += new System.EventHandler(this.Panel1MouseLeave);
            this._panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1MouseMove);
            this._panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel1MouseUp);
            // 
            // _shape
            // 
            this._shape.DataPropertyName = "Name";
            this._shape.FillWeight = 25F;
            this._shape.HeaderText = "形狀";
            this._shape.MinimumWidth = 6;
            this._shape.Name = "_shape";
            this._shape.ReadOnly = true;
            // 
            // _info
            // 
            this._info.DataPropertyName = "Location";
            this._info.FillWeight = 55F;
            this._info.HeaderText = "資訊";
            this._info.MinimumWidth = 6;
            this._info.Name = "_info";
            this._info.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this._nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this._nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this._nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this._nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this._nameDataGridViewTextBoxColumn.ReadOnly = true;
            this._nameDataGridViewTextBoxColumn.Visible = false;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this._locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this._locationDataGridViewTextBoxColumn.HeaderText = "Location";
            this._locationDataGridViewTextBoxColumn.MinimumWidth = 6;
            this._locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            this._locationDataGridViewTextBoxColumn.ReadOnly = true;
            this._locationDataGridViewTextBoxColumn.Visible = false;
            // 
            // _shapeBindingSource
            // 
            this._shapeBindingSource.DataSource = typeof(WindowsPractice.Shape);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 731);
            this.Controls.Add(this._splitContainer1);
            this.Controls.Add(this._toolStrip1);
            this.Controls.Add(this._menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this._menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this._recordDataGridView)).EndInit();
            this._groupBox1.ResumeLayout(false);
            this._splitContainer3.Panel1.ResumeLayout(false);
            this._splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer3)).EndInit();
            this._splitContainer3.ResumeLayout(false);
            this._menuStrip1.ResumeLayout(false);
            this._menuStrip1.PerformLayout();
            this._splitContainer1.Panel1.ResumeLayout(false);
            this._splitContainer1.Panel1.PerformLayout();
            this._splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).EndInit();
            this._splitContainer1.ResumeLayout(false);
            this._splitContainer2.Panel1.ResumeLayout(false);
            this._splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).EndInit();
            this._splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._shapeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _addDataButton;
        private System.Windows.Forms.ComboBox _selectShapeBox;
        private System.Windows.Forms.DataGridView _recordDataGridView;
        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.ToolStripMenuItem _about;
        private System.Windows.Forms.ToolStripMenuItem _caption;
        private System.Windows.Forms.MenuStrip _menuStrip1;
        private System.Windows.Forms.Button _button1;
        private System.Windows.Forms.ToolStrip _toolStrip1;
        private System.Windows.Forms.BindingSource _shapeBindingSource;
        private DoubleBufferedPanel _panel1;
        private System.Windows.Forms.SplitContainer _splitContainer1;
        private System.Windows.Forms.SplitContainer _splitContainer2;
        private System.Windows.Forms.SplitContainer _splitContainer3;
        private System.Windows.Forms.DataGridViewButtonColumn _delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shape;
        private System.Windows.Forms.DataGridViewTextBoxColumn _info;
        private System.Windows.Forms.DataGridViewTextBoxColumn _nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _locationDataGridViewTextBoxColumn;
    }
}

