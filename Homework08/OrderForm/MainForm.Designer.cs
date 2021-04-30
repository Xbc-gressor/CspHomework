
namespace OrderForm
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.exportOrder = new System.Windows.Forms.Button();
            this.importOrder = new System.Windows.Forms.Button();
            this.deleteOrder = new System.Windows.Forms.Button();
            this.editOrder = new System.Windows.Forms.Button();
            this.addOrder = new System.Windows.Forms.Button();
            this.orderListBox = new System.Windows.Forms.GroupBox();
            this.orderListGrid = new System.Windows.Forms.DataGridView();
            this.detailListBox = new System.Windows.Forms.GroupBox();
            this.detailListGrid = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.allButton = new System.Windows.Forms.Button();
            this.quaryTextBox = new System.Windows.Forms.TextBox();
            this.quaryTypeCombox = new System.Windows.Forms.ComboBox();
            this.quaryButton = new System.Windows.Forms.Button();
            this.orderBinding = new System.Windows.Forms.BindingSource(this.components);
            this.detailBinding = new System.Windows.Forms.BindingSource(this.components);
            this.quaryOrderBinding = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.orderListBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderListGrid)).BeginInit();
            this.detailListBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailListGrid)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderBinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailBinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quaryOrderBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.52225F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.47775F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.orderListBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.detailListBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.77778F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1191, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.30769F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.69231F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.exportOrder, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.importOrder, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.deleteOrder, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.editOrder, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.addOrder, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(698, 13);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(480, 56);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // exportOrder
            // 
            this.exportOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportOrder.Location = new System.Drawing.Point(382, 3);
            this.exportOrder.Name = "exportOrder";
            this.exportOrder.Size = new System.Drawing.Size(95, 50);
            this.exportOrder.TabIndex = 4;
            this.exportOrder.Text = "导出";
            this.exportOrder.UseVisualStyleBackColor = true;
            this.exportOrder.Click += new System.EventHandler(this.exportOrder_Click);
            // 
            // importOrder
            // 
            this.importOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importOrder.Location = new System.Drawing.Point(288, 3);
            this.importOrder.Name = "importOrder";
            this.importOrder.Size = new System.Drawing.Size(88, 50);
            this.importOrder.TabIndex = 3;
            this.importOrder.Text = "导入";
            this.importOrder.UseVisualStyleBackColor = true;
            this.importOrder.Click += new System.EventHandler(this.importOrder_Click);
            // 
            // deleteOrder
            // 
            this.deleteOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteOrder.Location = new System.Drawing.Point(194, 3);
            this.deleteOrder.Name = "deleteOrder";
            this.deleteOrder.Size = new System.Drawing.Size(88, 50);
            this.deleteOrder.TabIndex = 2;
            this.deleteOrder.Text = "删除";
            this.deleteOrder.UseVisualStyleBackColor = true;
            this.deleteOrder.Click += new System.EventHandler(this.deleteOrder_Click);
            // 
            // editOrder
            // 
            this.editOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editOrder.Location = new System.Drawing.Point(103, 3);
            this.editOrder.Name = "editOrder";
            this.editOrder.Size = new System.Drawing.Size(85, 50);
            this.editOrder.TabIndex = 1;
            this.editOrder.Text = "修改";
            this.editOrder.UseVisualStyleBackColor = true;
            this.editOrder.Click += new System.EventHandler(this.editOrder_Click);
            // 
            // addOrder
            // 
            this.addOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addOrder.Location = new System.Drawing.Point(3, 3);
            this.addOrder.Name = "addOrder";
            this.addOrder.Size = new System.Drawing.Size(94, 50);
            this.addOrder.TabIndex = 0;
            this.addOrder.Text = "添加";
            this.addOrder.UseVisualStyleBackColor = true;
            this.addOrder.Click += new System.EventHandler(this.addOrder_Click);
            // 
            // orderListBox
            // 
            this.orderListBox.Controls.Add(this.orderListGrid);
            this.orderListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderListBox.Location = new System.Drawing.Point(13, 75);
            this.orderListBox.Name = "orderListBox";
            this.orderListBox.Padding = new System.Windows.Forms.Padding(13, 3, 3, 13);
            this.orderListBox.Size = new System.Drawing.Size(679, 372);
            this.orderListBox.TabIndex = 1;
            this.orderListBox.TabStop = false;
            this.orderListBox.Text = "订单列表";
            // 
            // orderListGrid
            // 
            this.orderListGrid.AllowUserToAddRows = false;
            this.orderListGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.orderListGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.orderListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.orderListGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.orderListGrid.Location = new System.Drawing.Point(9, 26);
            this.orderListGrid.Name = "orderListGrid";
            this.orderListGrid.ReadOnly = true;
            this.orderListGrid.RowHeadersWidth = 51;
            this.orderListGrid.RowTemplate.Height = 29;
            this.orderListGrid.Size = new System.Drawing.Size(675, 335);
            this.orderListGrid.TabIndex = 0;
            this.orderListGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.orderListGrid_CellMouseDoubleClick);
            // 
            // detailListBox
            // 
            this.detailListBox.Controls.Add(this.detailListGrid);
            this.detailListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailListBox.Location = new System.Drawing.Point(698, 75);
            this.detailListBox.Name = "detailListBox";
            this.detailListBox.Size = new System.Drawing.Size(480, 372);
            this.detailListBox.TabIndex = 2;
            this.detailListBox.TabStop = false;
            this.detailListBox.Text = "订单明细";
            // 
            // detailListGrid
            // 
            this.detailListGrid.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.detailListGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.detailListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.detailListGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.detailListGrid.Location = new System.Drawing.Point(15, 26);
            this.detailListGrid.Name = "detailListGrid";
            this.detailListGrid.ReadOnly = true;
            this.detailListGrid.RowHeadersWidth = 51;
            this.detailListGrid.RowTemplate.Height = 29;
            this.detailListGrid.Size = new System.Drawing.Size(459, 335);
            this.detailListGrid.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel3.Controls.Add(this.allButton, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.quaryTextBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.quaryTypeCombox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.quaryButton, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(73, 13);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(30, 3, 10, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(579, 56);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // allButton
            // 
            this.allButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.allButton.Location = new System.Drawing.Point(437, 13);
            this.allButton.Name = "allButton";
            this.allButton.Size = new System.Drawing.Size(94, 29);
            this.allButton.TabIndex = 3;
            this.allButton.Text = "所有";
            this.allButton.UseVisualStyleBackColor = true;
            this.allButton.Click += new System.EventHandler(this.allButton_Click);
            // 
            // quaryTextBox
            // 
            this.quaryTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.quaryTextBox.Location = new System.Drawing.Point(3, 14);
            this.quaryTextBox.Name = "quaryTextBox";
            this.quaryTextBox.Size = new System.Drawing.Size(179, 27);
            this.quaryTextBox.TabIndex = 0;
            // 
            // quaryTypeCombox
            // 
            this.quaryTypeCombox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.quaryTypeCombox.FormattingEnabled = true;
            this.quaryTypeCombox.Items.AddRange(new object[] {
            "单号",
            "地址",
            "日期",
            "买家",
            "卖家",
            "商品"});
            this.quaryTypeCombox.Location = new System.Drawing.Point(196, 14);
            this.quaryTypeCombox.Name = "quaryTypeCombox";
            this.quaryTypeCombox.Size = new System.Drawing.Size(95, 28);
            this.quaryTypeCombox.TabIndex = 1;
            this.quaryTypeCombox.Text = "查询方式";
            // 
            // quaryButton
            // 
            this.quaryButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.quaryButton.Location = new System.Drawing.Point(321, 13);
            this.quaryButton.Name = "quaryButton";
            this.quaryButton.Size = new System.Drawing.Size(94, 29);
            this.quaryButton.TabIndex = 2;
            this.quaryButton.Text = "查询";
            this.quaryButton.UseVisualStyleBackColor = true;
            this.quaryButton.Click += new System.EventHandler(this.quaryButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.orderListBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderListGrid)).EndInit();
            this.detailListBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detailListGrid)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderBinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailBinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quaryOrderBinding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button exportOrder;
        private System.Windows.Forms.Button importOrder;
        private System.Windows.Forms.Button deleteOrder;
        private System.Windows.Forms.Button editOrder;
        private System.Windows.Forms.Button addOrder;
        private System.Windows.Forms.GroupBox orderListBox;
        private System.Windows.Forms.DataGridView orderListGrid;
        private System.Windows.Forms.GroupBox detailListBox;
        private System.Windows.Forms.DataGridView detailListGrid;
        private System.Windows.Forms.BindingSource orderBinding;
        private System.Windows.Forms.BindingSource detailBinding;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button allButton;
        private System.Windows.Forms.TextBox quaryTextBox;
        private System.Windows.Forms.ComboBox quaryTypeCombox;
        private System.Windows.Forms.Button quaryButton;
        private System.Windows.Forms.BindingSource quaryOrderBinding;
    }
}

