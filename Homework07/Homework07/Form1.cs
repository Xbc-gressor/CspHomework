using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework07
{

    public partial class Form1 : Form
    {
        //private int n;
        //private double length;
        private double per1 = 0.6;
        private double per2 = 0.7;
        private double th1 = 30 * Math.PI / 180;
        private double th2 = 20 * Math.PI / 180;
        private Graphics graphics = null;
        private Pen myPen = new Pen(Color.Pink, 2);

        private bool isDraw = false; // 
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(myPen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        void drawCayleyTree(int n, double x0, double y0, double length, double th)
        {
            if (n == 0 || !isDraw) return;
            double x1 = x0 + length * Math.Cos(th);
            double y1 = y0 + length * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * length, th + this.th1);
            drawCayleyTree(n - 1, x1, y1, per2 * length, th - this.th2);

        }

        // 根据画笔颜色调整画布背景色
        private void setBackgroundColorAndClear()
        {
            if (myPen.Color.GetBrightness() > 0.3)
            {
                graphics.Clear(Color.Black);
            }
            else
            {
                graphics.Clear(Color.White);
            }
        }
        private void drawButton_Click(object sender, EventArgs e)
        {
            isDraw = false;
            // 获取参数
            int n = (int)deepUD.Value;              // 递归深度
            double length = (double)lengthUD.Value; // 主干长度
            this.per1 = (double)rightRateUD.Value; // 右分支长度比
            this.per2 = (double)leftRateUD.Value;  // 左分支长度比
            this.th1 = (double)rightDegreeUD.Value * Math.PI / 180; // 右分支角度
            this.th2 = (double)leftDegreeUD.Value * Math.PI / 180;  // 左分支角度

            double x0 = panelBoard.Width / 2;
            double y0 = panelBoard.Height * 0.95;

            if (graphics == null)
                graphics = this.panelBoard.CreateGraphics();
            setBackgroundColorAndClear();

            isDraw = true;
            drawCayleyTree(n, x0, y0, length, -Math.PI / 2);

        }

        private void lengthUD_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void colorChoose_Click(object sender, EventArgs e)
        {
            using var color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                this.colorExample.BackColor = color.Color;
                myPen.Color = color.Color;
            }
        }

        private void penWidth_ValueChanged(object sender, EventArgs e)
        {
            myPen.Width = (int)penWidth.Value;
        }
    }
}
