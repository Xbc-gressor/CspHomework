using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManagement;

namespace OrderForm
{
    public partial class addOrderForm : Form
    {
        private Order order = new Order();         // 新建的Order对象
        private BindingSource orderBinding;        // 上一级所有Orders数据列表
        private Order oldOrder;                    // 要被修改的订单
        private MainForm mainForm;                 // 主界面

        private enum OpeType
        {
            ADD,
            EDIT
        }

        private OpeType opeType;                   // 当前是添加还是修改操作

        private void bind()
        {
            // 绑定orderDetails
            this.orderNumberTextBox.DataBindings.Add("Text", order, "orderNumber");
            this.addressTextBox.DataBindings.Add("Text", order, "address");
            this.timeTextBox.DataBindings.Add("Text", order, "time");
            this.buyerTextBox.DataBindings.Add("Text", order, "client");
            this.sellerTextBox.DataBindings.Add("Text", order, "seller");

            this.detailBinding.DataSource = order.orderDetails;
            this.addDetailGrid.DataSource = detailBinding;

            this.addDetailGrid.Columns[1].Width = 90;
            this.addDetailGrid.Columns[2].Width = 90;
            this.addDetailGrid.Columns[3].Width = 90;
        }

        // 只传入了上一级的数据列表，就是添加操作
        public addOrderForm(MainForm mainForm, BindingSource orderBinding)
        {
            InitializeComponent();
            this.orderBinding = orderBinding;
            this.mainForm = mainForm;
            typeLabel.Text = "添加订单";
            opeType = OpeType.ADD;
            bind();
        }

        // 同时传入了上一级的数据列表和某个订单编号，就是修改操作
        public addOrderForm(MainForm mainForm, BindingSource orderBinding, Order editOrder)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.orderBinding = orderBinding;
            // 深拷贝Order对象
            this.order = Order.DeepCopyByXml<Order>(editOrder);
            this.oldOrder = editOrder;

            typeLabel.Text = "修改订单";
            opeType = OpeType.EDIT;
            bind();
        }

        // 确认按钮
        private void okButton_Click(object sender, EventArgs e)
        {
            if(opeType == OpeType.ADD)
            {
                if (orderBinding.Contains(order))
                {
                    resLabel.Text = $"{order.orderNumber}号订单已存在！";
                }
                else
                {
                    mainForm.afterAdd(order);
                    this.Close();
                }
            }
            else if(opeType == OpeType.EDIT)
            {
                if (order.orderNumber != oldOrder.orderNumber && orderBinding.Contains(order)) // 修改了订单号，但是改成了已存在的
                {
                    resLabel.Text = $"{order.orderNumber}号订单已存在！";
                }
                else
                {
                    mainForm.afterEdit(oldOrder, order);
                    this.Close();
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
