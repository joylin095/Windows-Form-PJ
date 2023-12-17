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
    public partial class inputForm : Form
    {
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox topLeftTextBoxX;
        private TextBox topLeftTextBoxY;
        private TextBox bottomRightTextBoxX;
        private TextBox bottomRightTextBoxY;
        private Button okButton;
        private Button cancelButton;
        bool isValid1;
        bool isValid2;
        bool isValid3;
        bool isValid4;

        public inputForm()
        {
            InitializeComponent();
            Initialize();
        }

        // init
        private void Initialize()
        {
            // 初始化控件
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            topLeftTextBoxX = new TextBox();
            topLeftTextBoxY = new TextBox();
            bottomRightTextBoxX = new TextBox();
            bottomRightTextBoxY = new TextBox();
            okButton = new Button();
            cancelButton = new Button();

            // 設定對話框屬性
            this.Text = "輸入座標範圍";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ClientSize = new System.Drawing.Size(300, 200);

            // 設定控件屬性
            label1.Text = "左上角座標X：";
            label1.Location = new System.Drawing.Point(10, 10);
            topLeftTextBoxX.Location = new System.Drawing.Point(10, 35);
            topLeftTextBoxX.Size = new System.Drawing.Size(100, 20);
            topLeftTextBoxX.TextChanged += TextBox1_TextChanged;

            label2.Text = "左上角座標Y：";
            label2.Location = new System.Drawing.Point(150, 10);
            topLeftTextBoxY.Location = new System.Drawing.Point(150, 35);
            topLeftTextBoxY.Size = new System.Drawing.Size(100, 20);
            topLeftTextBoxY.TextChanged += TextBox2_TextChanged;

            label3.Text = "右下角座標X：";
            label3.Location = new System.Drawing.Point(10, 80);
            bottomRightTextBoxX.Location = new System.Drawing.Point(10, 105);
            bottomRightTextBoxX.Size = new System.Drawing.Size(100, 20);
            bottomRightTextBoxX.TextChanged += TextBox3_TextChanged;

            label4.Text = "右下角座標Y：";
            label4.Location = new System.Drawing.Point(150, 80);
            bottomRightTextBoxY.Location = new System.Drawing.Point(150, 105);
            bottomRightTextBoxY.Size = new System.Drawing.Size(100, 20);
            bottomRightTextBoxY.TextChanged += TextBox4_TextChanged;

            okButton.Text = "確定";
            okButton.Location = new System.Drawing.Point(10, 145);
            okButton.Enabled = false;
            okButton.Click += OkButton_Click;

            cancelButton.Text = "取消";
            cancelButton.Location = new System.Drawing.Point(150, 145);
            cancelButton.Click += CancelButton_Click;

            // 將控件添加到對話框
            this.Controls.Add(label1);
            this.Controls.Add(topLeftTextBoxX);
            this.Controls.Add(label2);
            this.Controls.Add(topLeftTextBoxY);
            this.Controls.Add(label3);
            this.Controls.Add(bottomRightTextBoxX);
            this.Controls.Add(label4);
            this.Controls.Add(bottomRightTextBoxY);
            this.Controls.Add(okButton);
            this.Controls.Add(cancelButton);

            isValid1 = isValid2 = isValid3 = isValid4 = false;
        }

        // TextBox_TextChanged
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            isValid1 = !topLeftTextBoxX.Text.Contains('-') && !topLeftTextBoxX.Text.Contains('.') && topLeftTextBoxX.Text.Length != 0;
            OkButtonIsVaild();
        }

        // TextBox_TextChanged
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            isValid2 = !topLeftTextBoxY.Text.Contains('-') && !topLeftTextBoxY.Text.Contains('.') && topLeftTextBoxY.Text.Length != 0;
            OkButtonIsVaild();
        }

        // TextBox_TextChanged
        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            isValid3 = !bottomRightTextBoxX.Text.Contains('-') && !bottomRightTextBoxX.Text.Contains('.') && bottomRightTextBoxX.Text.Length != 0;
            OkButtonIsVaild();
        }

        // TextBox_TextChanged
        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            isValid4 = !bottomRightTextBoxY.Text.Contains("-") && !bottomRightTextBoxY.Text.Contains(".") && bottomRightTextBoxY.Text.Length != 0;
            OkButtonIsVaild();
        }

        // ok button enable
        private void OkButtonIsVaild()
        {
            if (isValid1 && isValid2 && isValid3 && isValid4)
            {
                okButton.Enabled = true;
            }
            else
            {
                okButton.Enabled = false;
            }
        }

        //OkButton_Click
        private void OkButton_Click(object sender, EventArgs e)
        {
            // 在這裡處理按下確定按鈕的邏輯，可以將座標回傳給主視窗
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //CancelButton_Click
        private void CancelButton_Click(object sender, EventArgs e)
        {
            // 在這裡處理按下取消按鈕的邏輯
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // get top Left point
        public Point GetTopLeftPoint()
        {
            return new Point(Int32.Parse(topLeftTextBoxX.Text), Int32.Parse(topLeftTextBoxY.Text));
        }

        // get bottom right point
        public Point GetBottomRightPoint()
        {
            return new Point(Int32.Parse(bottomRightTextBoxX.Text), Int32.Parse(bottomRightTextBoxY.Text));
        }
    }
}
