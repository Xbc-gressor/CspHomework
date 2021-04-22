using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManagement;

namespace OrderForm
{
    public partial class MainForm : Form
    {
        // 订单服务
        OrderService orderService = new OrderService();
        /*
            有两个BindingSource，一个绑定在所有的订单上，一个绑定在当前查询到的Order列表上
            点击不同的按钮后，改变DataGridView.DataSource，在添加删除的时候，若正处于查询状态，要同时改变两个视图
         */
        
        private enum CurSituation
        {
            Quary,
            All
        }
        private CurSituation curSit; // 当前是查询状态还是全显示状态

        private void Add()
        {
            List<OrderDetail> orderDetails1 = new List<OrderDetail>();
            orderDetails1.Add(new OrderDetail(new Good("book", 12), 3));
            orderDetails1.Add(new OrderDetail(new Good("Costa", 17), 5));
            orderDetails1.Add(new OrderDetail(new Good("Costa", 17), 2));
            Order order1 = new Order(orderNumber: 1, address: "WHU", time: new DateTime(2021, 3, 21, 12, 12, 6), "XBC", "DL", orderDetails1);

            List<OrderDetail> orderDetails2 = new List<OrderDetail>();
            orderDetails2.Add(new OrderDetail(new Good("mat", 12.5), 3));
            orderDetails2.Add(new OrderDetail(new Good("toothbrush", 5), 2));
            orderDetails2.Add(new OrderDetail(new Good("matchstick", 0.1), 50));
            Order order2 = new Order(orderNumber: 5, address: "WHU", time: new DateTime(2020, 3, 22, 13, 11, 7), "LBW", "NB", orderDetails2);

            //List<OrderDetail> orderDetails3 = new List<OrderDetail>();
            //orderDetails3.Add(new OrderDetail(new Good("computer", 11999), 1));
            //orderDetails3.Add(new OrderDetail(new Good("mouse", 88), 1));
            //orderDetails3.Add(new OrderDetail(new Good("mat", 15.3), 2));
            //Order order3 = new Order(orderNumber: 3, address: "THU", time: new DateTime(2021, 3, 21, 11, 12, 6), "XBC", "DL", orderDetails3);

            //List<OrderDetail> orderDetails4 = new List<OrderDetail>();
            //orderDetails4.Add(new OrderDetail(new Good("facial cleanser", 33), 2));
            //orderDetails4.Add(new OrderDetail(new Good("shower", 37), 1));
            //orderDetails4.Add(new OrderDetail(new Good("mat", 16.2), 8));
            //Order order4 = new Order(orderNumber: 2, address: "SJTU", time: new DateTime(2019, 3, 21, 3, 51, 6), "YSW", "NB", orderDetails4);

            //List<OrderDetail> orderDetails5 = new List<OrderDetail>();
            //orderDetails5.Add(new OrderDetail(new Good("knife", 50), 2));
            //orderDetails5.Add(new OrderDetail(new Good("sword", 77), 1));
            //orderDetails5.Add(new OrderDetail(new Good("shield", 199), 1));
            //Order order5 = new Order(orderNumber: 4, address: "FDU", time: new DateTime(2019, 11, 13, 2, 31, 6), "RSC", "DL", orderDetails5);



            orderService.Add(order1);
            orderService.Add(order2);
            //orderService.Add(order3);
            //orderService.Add(order4);
            //orderService.Add(order5);

        }
        public MainForm()
        {

            InitializeComponent();
            Add();
            orderService.Sort();

            // 订单列表数据绑定
            this.orderBinding.DataSource = orderService.orderList;
            this.orderListGrid.DataSource = orderBinding;
            this.orderListGrid.Columns[0].HeaderText = "orderID";
            this.orderListGrid.Columns[0].Width = 70;
            this.orderListGrid.Columns[1].Width = 90;
            this.orderListGrid.Columns[2].Width = 150;
            this.orderListGrid.Columns[3].Width = 90;
            this.orderListGrid.Columns[4].Width = 90;


            // 订单明细列表数据绑定
            this.detailListGrid.DataSource = detailBinding;


        }


        private void orderListGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            int number = (int)orderListGrid.Rows[index].Cells[0].Value;

            Order order = orderService.SearchByNumber(number);
            this.detailBinding.DataSource = order.orderDetails;
            this.detailListGrid.Columns[1].Width = 90;
            this.detailListGrid.Columns[2].Width = 90;
            this.detailListGrid.Columns[3].Width = 90;

        }

        /*
         *  添加
         */
        private void addOrder_Click(object sender, EventArgs e)
        {
            new addOrderForm(this, orderBinding).Show(this);
        }
        public void afterAdd(Order order)
        {
            orderBinding.Add(order);
            orderService.Sort();

            if(curSit == CurSituation.Quary)
            {
                quaryOrderBinding.Add(order);
            }
        }


        /*
         *  修改
         */
        private void editOrder_Click(object sender, EventArgs e)
        {
            // 修改当前选中的订单行
            int count = orderListGrid.SelectedRows.Count;
            if (count < 1)
            {
                return;
            }

            int orderNumber = (int)orderListGrid.SelectedRows[count - 1].Cells[0].Value;
            
            new addOrderForm(this, orderBinding, orderService.SearchByNumber(orderNumber)).ShowDialog(this);
        }
        public void afterEdit(Order oldOrder, Order order)
        {
            orderBinding.Remove(oldOrder);
            orderBinding.Add(order);
            orderService.Sort();
            if(curSit == CurSituation.Quary)
            {
                quaryOrderBinding.Remove(oldOrder);
                quaryOrderBinding.Add(order);
            }
            
        }

        /*
         *  删除
         */
        private void deleteOrder_Click(object sender, EventArgs e)
        {
            // 删除所有选中的订单
            int k = orderListGrid.SelectedRows.Count;
            DialogResult dr = MessageBox.Show("您确认要删除这" + Convert.ToString(k) + "项订单吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                for (int i = k-1; i >= 0; i--)
                {
                    Order delOrder = orderService.SearchByNumber((int)orderListGrid.SelectedRows[i].Cells[0].Value);
                    orderBinding.Remove(delOrder);
                    if(curSit == CurSituation.Quary)
                    {
                        quaryOrderBinding.Remove(delOrder);
                    }
                }
            }
        }

        /*
         *  导入
         */
        private void importOrder_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.AddExtension = true;
            ofd.Filter = "Xml 文件 (*.xml)|*.xml|所有文件|*.*";
            ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.DefaultExt = ".xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    orderService.Import(ofd.FileName);
                    // 更新bindingSource
                    this.orderBinding.DataSource = orderService.orderList;

                    MessageBox.Show("导入成功");
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }

        /*
         * 导出
         */
        private void exportOrder_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.Filter = "Xml 文件 (*.xml)|*.xml|所有文件|*.*";
            sfd.InitialDirectory = Environment.CurrentDirectory;
            sfd.DefaultExt = ".xml";
            sfd.OverwritePrompt = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    orderService.Export(sfd.FileName);
                    MessageBox.Show("导出成功");
                }
                catch (Exception)
                {
                    MessageBox.Show("导出失败");
                }
            }
        }

        /*
         * 查询
         */
        private void quaryButton_Click(object sender, EventArgs e)
        {
            String type = quaryTypeCombox.Text;
            if (type == "查询方式")
                return;
            try
            {
                switch (type)
                {
                    case "单号":
                        List<Order> temp = new List<Order>();
                        temp.Add(orderService.SearchByNumber(Convert.ToInt32(quaryTextBox.Text)));
                        quaryOrderBinding.DataSource = temp;
                        break;
                    case "地址":
                        quaryOrderBinding.DataSource = orderService.SearchByAddress(quaryTextBox.Text);
                        break;
                    case "日期":
                        String dtFormat = "yyyy/MM/dd";
                        CultureInfo provider = new CultureInfo("fr-FR");
                        DateTime dt = DateTime.ParseExact(quaryTextBox.Text, dtFormat, provider);
                        quaryOrderBinding.DataSource = orderService.SearchByDate(dt);
                        break;
                    case "买家":
                        quaryOrderBinding.DataSource = orderService.SearchByClient(quaryTextBox.Text);
                        break;
                    case "卖家":
                        quaryOrderBinding.DataSource = orderService.SearchBySeller(quaryTextBox.Text);
                        break;
                    case "商品":
                        quaryOrderBinding.DataSource = orderService.SearchByGood(quaryTextBox.Text);
                        break;
                    default:
                        throw new ArgumentException();

                }

                // Grid绑定到查询order source上
                this.orderListGrid.DataSource = quaryOrderBinding;
                curSit = CurSituation.Quary;
            }
            catch(Exception)
            {
                MessageBox.Show("参数错误");
            }


        }

        private void allButton_Click(object sender, EventArgs e)
        {
            this.orderListGrid.DataSource = orderBinding;
            curSit = CurSituation.All;

        }
        /*
单号
地址
日期
买家
卖家
商品
*/
    }
}
