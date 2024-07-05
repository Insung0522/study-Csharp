using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Study_Cs_08_WinForm
{
    public partial class Form1 : Form
    {
        private int findNumber = 0;
        private int chance = 0;

        public Form1()
        {
            InitializeComponent();
        }
        //public void Exit()
        //{
        //    Thread.Sleep(2000);
        //    Close();
        //}

        private void inputButton_Click(object sender, EventArgs e)
        {
            int inputNumber = 0;
            try
            {
                inputNumber = Int32.Parse(textBox1.Text);
            }
            catch(Exception error)
            {
                label1.Text = "예외 : " + error.Message + "가 발생했습니다.";
            }
            if (chance <= 0)
            {
                label1.Text = "실패했습니다.";
                return;
                //Exit();
            }

            if (inputNumber == findNumber)
            {
                label1.Text = "승리했습니다!!";
            }
            else
            {
                chance--;
                label1.Text = "기회는 " + chance + "번 남았습니다.";
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            findNumber = rand.Next(1, 3);//1~20 난수 생성
            chance = 10;
            label1.Text = "맞출 숫자를 입력하세요";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
