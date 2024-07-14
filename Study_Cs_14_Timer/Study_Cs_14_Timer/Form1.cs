using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Study_Cs_14_Timer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value >= progressBar1.Maximum) return;
            progressBar1.Value += 1;
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = Convert.ToString(progressBar1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            timer1.Interval = Convert.ToInt32(textBox1.Text);
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            timer1.Enabled = false;
            progressBar1.Value = 0;
        }
    }
}
