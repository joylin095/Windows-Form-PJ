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
    public partial class InputForm : Form
    {
        private Label _label1;
        private Label _label2;
        private Label _label3;
        private Label _label4;
        private TextBox _topLeftTextBoxX;
        private TextBox _topLeftTextBoxY;
        private TextBox _bottomRightTextBoxX;
        private TextBox _bottomRightTextBoxY;
        private Button _okButton;
        private Button _cancelButton;
        bool _isValid1;
        bool _isValid2;
        bool _isValid3;
        bool _isValid4;
        const string TITLE = "輸入座標範圍";
        const string TOP_LEFT_LABEL_X = "左上角座標X：";
        const string TOP_LEFT_INPUT_X = "_topLeftInputX";
        const string TOP_LEFT_LABEL_Y = "左上角座標Y：";
        const string TOP_LEFT_INPUT_Y = "_topLeftInputY";
        const string BOTTOM_RIGHT_LABEL_X = "右下角座標X：";
        const string BOTTOM_RIGHT_INPUT_X = "_bottomRightInputX";
        const string BOTTOM_RIGHT_LABEL_Y = "右下角座標Y：";
        const string BOTTOM_RIGHT_INPUT_Y = "_bottomRightInputY";
        const string CONFIRM = "確定";
        const string CANCEL = "取消";
        const string NEGATIVE = "-";
        const string DOT = ".";

        const int MAIN_FORM_SIZE_X = 300;
        const int MAIN_FORM_SIZE_Y = 200;

        const int LABEL1_POINT_X = 10;
        const int LABEL1_POINT_Y = 10;
        const int TOP_LEFT_TEXT_BOX_X_LOCATION_X = 10;
        const int TOP_LEFT_TEXT_BOX_X_LOCATION_Y = 35;
        const int TOP_LEFT_TEXT_BOX_X_SIZE_X = 100;
        const int TOP_LEFT_TEXT_BOX_X_SIZE_Y = 20;

        const int LABEL2_POINT_X = 150;
        const int LABEL2_POINT_Y = 10;
        const int TOP_LEFT_TEXT_BOX_Y_LOCATION_X = 150;
        const int TOP_LEFT_TEXT_BOX_Y_LOCATION_Y = 35;
        const int TOP_LEFT_TEXT_BOX_Y_SIZE_X = 100;
        const int TOP_LEFT_TEXT_BOX_Y_SIZE_Y = 20;

        const int LABEL3_POINT_X = 10;
        const int LABEL3_POINT_Y = 80;
        const int BOTTOM_RIGHT_TEXT_BOX_X_LOCATION_X = 10;
        const int BOTTOM_RIGHT_TEXT_BOX_X_LOCATION_Y = 105;
        const int BOTTOM_RIGHT_TEXT_BOX_X_SIZE_X = 100;
        const int BOTTOM_RIGHT_TEXT_BOX_X_SIZE_Y = 20;

        const int LABEL4_POINT_X = 150;
        const int LABEL4_POINT_Y = 80;
        const int BOTTOM_RIGHT_TEXT_BOX_Y_LOCATION_X = 150;
        const int BOTTOM_RIGHT_TEXT_BOX_Y_LOCATION_Y = 105;
        const int BOTTOM_RIGHT_TEXT_BOX_Y_SIZE_X = 100;
        const int BOTTOM_RIGHT_TEXT_BOX_Y_SIZE_Y = 20;

        const int OK_BUTTON_LOCATION_X = 10;
        const int OK_BUTTON_LOCATION_Y = 145;

        const int CANCEL_BUTTON_LOCATION_X = 150;
        const int CANCEL_BUTTON_LOCATION_Y = 145;

        public InputForm()
        {
            InitializeComponent();
            InitializeNewComponent();
            SetMainForm();
            SetTopLeftComponent();
            SetBottomRightComponent();
            SetOkCancelButton();
            AddControl();
            _isValid1 = _isValid2 = _isValid3 = _isValid4 = false;
        }

        // 初始化控件
        private void InitializeNewComponent()
        {
            _label1 = new Label();
            _label2 = new Label();
            _label3 = new Label();
            _label4 = new Label();
            _topLeftTextBoxX = new TextBox();
            _topLeftTextBoxY = new TextBox();
            _bottomRightTextBoxX = new TextBox();
            _bottomRightTextBoxY = new TextBox();
            _okButton = new Button();
            _cancelButton = new Button();
        }

        // 設定對話框屬性
        private void SetMainForm()
        {
            this.Text = TITLE;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ClientSize = new Size(MAIN_FORM_SIZE_X, MAIN_FORM_SIZE_Y);
        }

        // 左上元件設定
        private void SetTopLeftComponent()
        {
            _label1.Text = TOP_LEFT_LABEL_X;
            _label1.Location = new Point(LABEL1_POINT_X, LABEL1_POINT_Y);
            _topLeftTextBoxX.ImeMode = ImeMode.Disable;
            _topLeftTextBoxX.Name = TOP_LEFT_INPUT_X;
            _topLeftTextBoxX.Location = new Point(TOP_LEFT_TEXT_BOX_X_LOCATION_X, TOP_LEFT_TEXT_BOX_X_LOCATION_Y);
            _topLeftTextBoxX.Size = new Size(TOP_LEFT_TEXT_BOX_X_SIZE_X, TOP_LEFT_TEXT_BOX_X_SIZE_Y);
            _topLeftTextBoxX.TextChanged += ChangedTextBox1Text;

            _label2.Text = TOP_LEFT_LABEL_Y;
            _label2.Location = new Point(LABEL2_POINT_X, LABEL2_POINT_Y);
            _topLeftTextBoxY.ImeMode = ImeMode.Disable;
            _topLeftTextBoxY.Name = TOP_LEFT_INPUT_Y;
            _topLeftTextBoxY.Location = new Point(TOP_LEFT_TEXT_BOX_Y_LOCATION_X, TOP_LEFT_TEXT_BOX_Y_LOCATION_Y);
            _topLeftTextBoxY.Size = new Size(TOP_LEFT_TEXT_BOX_Y_SIZE_X, TOP_LEFT_TEXT_BOX_Y_SIZE_Y);
            _topLeftTextBoxY.TextChanged += ChangedTextBox2Text;
        }

        // 右下元件設定
        private void SetBottomRightComponent()
        {
            _label3.Text = BOTTOM_RIGHT_LABEL_X;
            _label3.Location = new Point(LABEL3_POINT_X, LABEL3_POINT_Y);
            _bottomRightTextBoxX.ImeMode = ImeMode.Disable;
            _bottomRightTextBoxX.Name = BOTTOM_RIGHT_INPUT_X;
            _bottomRightTextBoxX.Location = new Point(BOTTOM_RIGHT_TEXT_BOX_X_LOCATION_X, BOTTOM_RIGHT_TEXT_BOX_X_LOCATION_Y);
            _bottomRightTextBoxX.Size = new Size(BOTTOM_RIGHT_TEXT_BOX_X_SIZE_X, BOTTOM_RIGHT_TEXT_BOX_X_SIZE_Y);
            _bottomRightTextBoxX.TextChanged += ChangedTextBox3Text;

            _label4.Text = BOTTOM_RIGHT_LABEL_Y;
            _label4.Location = new Point(LABEL4_POINT_X, LABEL4_POINT_Y);
            _bottomRightTextBoxY.ImeMode = ImeMode.Disable;
            _bottomRightTextBoxY.Name = BOTTOM_RIGHT_INPUT_Y;
            _bottomRightTextBoxY.Location = new Point(BOTTOM_RIGHT_TEXT_BOX_Y_LOCATION_X, BOTTOM_RIGHT_TEXT_BOX_Y_LOCATION_Y);
            _bottomRightTextBoxY.Size = new Size(BOTTOM_RIGHT_TEXT_BOX_Y_SIZE_X, BOTTOM_RIGHT_TEXT_BOX_Y_SIZE_Y);
            _bottomRightTextBoxY.TextChanged += ChangedTextBox4Text;
        }

        // ok cancel button 設定
        private void SetOkCancelButton()
        {
            _okButton.Text = CONFIRM;
            _okButton.Location = new Point(OK_BUTTON_LOCATION_X, OK_BUTTON_LOCATION_Y);
            _okButton.Enabled = false;
            _okButton.Click += ClickOkButton;

            _cancelButton.Text = CANCEL;
            _cancelButton.Location = new Point(CANCEL_BUTTON_LOCATION_X, CANCEL_BUTTON_LOCATION_Y);
            _cancelButton.Click += ClickCancelButton;
        }

        // 加入control
        private void AddControl()
        {
            this.Controls.Add(_label1);
            this.Controls.Add(_topLeftTextBoxX);
            this.Controls.Add(_label2);
            this.Controls.Add(_topLeftTextBoxY);
            this.Controls.Add(_label3);
            this.Controls.Add(_bottomRightTextBoxX);
            this.Controls.Add(_label4);
            this.Controls.Add(_bottomRightTextBoxY);
            this.Controls.Add(_okButton);
            this.Controls.Add(_cancelButton);
        }

        // TextBox_TextChanged
        private void ChangedTextBox1Text(object sender, EventArgs e)
        {
            _isValid1 = !_topLeftTextBoxX.Text.Contains(NEGATIVE) && !_topLeftTextBoxX.Text.Contains(DOT) && _topLeftTextBoxX.Text.Length != 0;
            IsOkButtonValid();
        }

        // TextBox_TextChanged
        private void ChangedTextBox2Text(object sender, EventArgs e)
        {
            _isValid2 = !_topLeftTextBoxY.Text.Contains(NEGATIVE) && !_topLeftTextBoxY.Text.Contains(DOT) && _topLeftTextBoxY.Text.Length != 0;
            IsOkButtonValid();
        }

        // TextBox_TextChanged
        private void ChangedTextBox3Text(object sender, EventArgs e)
        {
            _isValid3 = !_bottomRightTextBoxX.Text.Contains(NEGATIVE) && !_bottomRightTextBoxX.Text.Contains(DOT) && _bottomRightTextBoxX.Text.Length != 0;
            IsOkButtonValid();
        }

        // TextBox_TextChanged
        private void ChangedTextBox4Text(object sender, EventArgs e)
        {
            _isValid4 = !_bottomRightTextBoxY.Text.Contains(NEGATIVE) && !_bottomRightTextBoxY.Text.Contains(DOT) && _bottomRightTextBoxY.Text.Length != 0;
            IsOkButtonValid();
        }

        // ok button enable
        private void IsOkButtonValid()
        {
            if (_isValid1 && _isValid2 && _isValid3 && _isValid4)
            {
                _okButton.Enabled = true;
            }
            else
            {
                _okButton.Enabled = false;
            }
        }

        //OkButton_Click
        private void ClickOkButton(object sender, EventArgs e)
        {
            // 在這裡處理按下確定按鈕的邏輯，可以將座標回傳給主視窗
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //CancelButton_Click
        private void ClickCancelButton(object sender, EventArgs e)
        {
            // 在這裡處理按下取消按鈕的邏輯
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // get top Left point
        public Point GetTopLeftPoint()
        {
            return new Point(Int32.Parse(_topLeftTextBoxX.Text), Int32.Parse(_topLeftTextBoxY.Text));
        }

        // get bottom right point
        public Point GetBottomRightPoint()
        {
            return new Point(Int32.Parse(_bottomRightTextBoxX.Text), Int32.Parse(_bottomRightTextBoxY.Text));
        }
    }
}
