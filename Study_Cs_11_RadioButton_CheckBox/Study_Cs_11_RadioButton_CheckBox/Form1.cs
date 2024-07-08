using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Study_Cs_11_RadioButton_CheckBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string rad = "미선택";
        int cost = 0;

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                radioButton4.Checked = true;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
            }
            else
            {
                radioButton4.Checked = false;
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) rad = "결제:현금";
            else if (radioButton2.Checked == true) rad = "결제:카드";
            else if (radioButton3.Checked == true) rad = "결제:쿠폰";
            else rad = "미선택";

            cost = 0;
            if (checkBox1.Checked == true) cost += 3500;
            if (checkBox2.Checked == true) cost += 4000;
            if (checkBox3.Checked == true) cost += 10000;

            if (rad == "선택" || cost == 0) return;
            MessageBox.Show(rad + " 가격: " + cost);
        }
    }
}
