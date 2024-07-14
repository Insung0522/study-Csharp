using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Study_Cs_12_PictureBox_Graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox1.Image;
        }


        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            //우클릭에서만 이벤트 발생
            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Graphics grp = pictureBox2.CreateGraphics();
                Pen pen = new Pen(Color.SteelBlue);
                grp.DrawLine(pen, e.X - 3, e.Y - 10, e.X + 6, e.Y); //  ↘
                grp.DrawLine(pen, e.X - 14, e.Y, e.X + 6, e.Y);     // --→
                grp.DrawLine(pen, e.X - 3, e.Y + e.X, e.X + 6, e.Y);//  ↗
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Graphics grp = pictureBox2.CreateGraphics();
                Pen pen = new Pen(Color.SteelBlue);
                grp.DrawLine(pen, e.X - 3, e.Y - 10, e.X + 6, e.Y); //  ↘
                grp.DrawLine(pen, e.X - 14, e.Y, e.X + 6, e.Y);     // --→
                grp.DrawLine(pen, e.X - 3, e.Y + 10, e.X + 6, e.Y); //  ↗
            }
        }
    }
}
