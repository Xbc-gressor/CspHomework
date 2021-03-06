﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            operatorBox_Load();
        }
        private void operatorBox_Load()
        {
            operatorBox.Items.Add("   +");
            operatorBox.Items.Add("   -");
            operatorBox.Items.Add("   *");
            operatorBox.Items.Add("   /");
            operatorBox.Items.Add("   ^");
        }
        private void operatorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            answerText.Text = "";
        }

        private void o1Text_TextChanged(object sender, EventArgs e)
        {
            answerText.Text = "";
        }

        private void o2Text_TextChanged(object sender, EventArgs e)
        {
            answerText.Text = "";
        }

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                double o1 = double.Parse(o1Text.Text);
                double o2 = double.Parse(o2Text.Text);

                string operator_ = operatorBox.Text.Trim();
                string answer = "";
                switch (operator_)
                {
                    case "+": answer = (o1 + o2).ToString(); break;
                    case "-": answer = (o1 - o2).ToString(); break;
                    case "*": answer = (o1 * o2).ToString(); break;
                    case "/": answer = (o1 / o2).ToString(); break;
                    case "^": answer = (Math.Pow(o1, o2)).ToString(); break;
                    default : answer = "请选择运算符"; break;
                }

                answerText.Text = answer;
            }catch(Exception ex)
            {
                answerText.Text = "Error";

            }


        }
    }
}
