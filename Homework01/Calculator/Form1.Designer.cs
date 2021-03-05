namespace Calculator
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn = new System.Windows.Forms.Button();
            this.operatorBox = new System.Windows.Forms.ComboBox();
            this.answerText = new System.Windows.Forms.TextBox();
            this.o1Text = new System.Windows.Forms.TextBox();
            this.o2Text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn.Location = new System.Drawing.Point(74, 224);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(126, 58);
            this.btn.TabIndex = 0;
            this.btn.Text = "calculate";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // operatorBox
            // 
            this.operatorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operatorBox.Font = new System.Drawing.Font("宋体", 15F);
            this.operatorBox.FormattingEnabled = true;
            this.operatorBox.Location = new System.Drawing.Point(272, 224);
            this.operatorBox.Name = "operatorBox";
            this.operatorBox.Size = new System.Drawing.Size(127, 38);
            this.operatorBox.TabIndex = 1;
            this.operatorBox.SelectedIndexChanged += new System.EventHandler(this.operatorBox_SelectedIndexChanged);
            // 
            // answerText
            // 
            this.answerText.Enabled = false;
            this.answerText.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.answerText.Location = new System.Drawing.Point(65, 48);
            this.answerText.Name = "answerText";
            this.answerText.Size = new System.Drawing.Size(344, 42);
            this.answerText.TabIndex = 2;
            this.answerText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // o1Text
            // 
            this.o1Text.Font = new System.Drawing.Font("宋体", 15F);
            this.o1Text.ForeColor = System.Drawing.SystemColors.WindowText;
            this.o1Text.Location = new System.Drawing.Point(65, 139);
            this.o1Text.Name = "o1Text";
            this.o1Text.Size = new System.Drawing.Size(146, 42);
            this.o1Text.TabIndex = 3;
            this.o1Text.TextChanged += new System.EventHandler(this.o1Text_TextChanged);
            // 
            // o2Text
            // 
            this.o2Text.Font = new System.Drawing.Font("宋体", 15F);
            this.o2Text.Location = new System.Drawing.Point(263, 139);
            this.o2Text.Name = "o2Text";
            this.o2Text.Size = new System.Drawing.Size(146, 42);
            this.o2Text.TabIndex = 4;
            this.o2Text.TextChanged += new System.EventHandler(this.o2Text_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(466, 395);
            this.Controls.Add(this.o2Text);
            this.Controls.Add(this.o1Text);
            this.Controls.Add(this.answerText);
            this.Controls.Add(this.operatorBox);
            this.Controls.Add(this.btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.ComboBox operatorBox;
        private System.Windows.Forms.TextBox answerText;
        private System.Windows.Forms.TextBox o1Text;
        private System.Windows.Forms.TextBox o2Text;
    }
}

