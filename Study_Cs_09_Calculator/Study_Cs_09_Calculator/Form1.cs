using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Study_Cs_09_Calculator
{
    public partial class Form1 : Form
    {
        enum Operators
        {
            NONE,
            ADD,
            SUBTRACT,
            MULTIPLY,
            DIVIDE,
            RESULT
        }
        Operators currentOperator = Operators.NONE;
        bool operatorChangeFlag = true;
        double firstOperand = 0;
        double secondOperand = 0;
        double tmpOperand = 0;
        string errMessage = "0으로는 나눌 수 없습니다.";
        //private void Button_Click(object sender, EventArgs e)
        //{
        //    if(operatorChangeFlag == true)
        //    {
        //        printNum.Text = "";
        //        operatorChangeFlag = false;
        //    }
        //    string strNumber = printNum.Text += "1";
        //    int intNumber = Int32.Parse(strNumber);
        //    printNum.Text = intNumber.ToString(); 
        //}
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            secondOperand = Double.Parse(printNum.Text);
            switch (currentOperator)
            {
                case Operators.NONE:
                    {
                        printNum.Text = firstOperand.ToString();
                        break;
                    }
                case Operators.ADD:
                    {
                        firstOperand += secondOperand;
                        printNum.Text = firstOperand.ToString();
                        break;
                    }
                case Operators.SUBTRACT:
                    {
                        firstOperand -= secondOperand;
                        printNum.Text = firstOperand.ToString();
                        break;
                    }
                case Operators.MULTIPLY:
                    {
                        firstOperand *= secondOperand;
                        printNum.Text = firstOperand.ToString();
                        break;
                    }
                case Operators.DIVIDE:
                    {
                        //try-catch 예외처리 안됨. 확인 필요
                        //try
                        //{
                        //    firstOperand = firstOperand / secondOperand;
                        //    printNum.Text = firstOperand.ToString();
                        //}
                        //catch (Exception error)
                        //{
                        //    printNum.Text = "예외 : " + error.Message;
                        //}
                        if(secondOperand == 0)
                        {
                            printNum.Text = errMessage;
                        }
                        else
                        {
                            firstOperand = firstOperand / secondOperand;
                            printNum.Text = firstOperand.ToString();
                        }
                        break;
                    }
                case Operators.RESULT:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
                
        }

        private void buttonNum_Click(string num)
        {
            if (operatorChangeFlag == true)
            {
                printNum.Text = "";
                operatorChangeFlag = false;
            }
            if (printNum.Text == "0" || printNum.Text == "" || printNum.Text == errMessage)
            {
                printNum.Text = num;
            }
            else
            {
                printNum.Text += num;
            }
            tmpOperand = double.Parse(printNum.Text);
        }
        private void button0_Click(object sender, EventArgs e)
        {
            string num = "0";
            buttonNum_Click(num);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string num = "1";
            buttonNum_Click(num);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string num = "2";
            buttonNum_Click(num);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string num = "3";
            buttonNum_Click(num);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string num = "4";
            buttonNum_Click(num);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string num = "5";
            buttonNum_Click(num);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string num = "6";
            buttonNum_Click(num);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string num = "7";
            buttonNum_Click(num);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string num = "8";
            buttonNum_Click(num);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string num = "9";
            buttonNum_Click(num);
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            //firstOperand = Double.Parse(printNum.Text);
            firstOperand = tmpOperand;
            currentOperator = Operators.ADD;
            operatorChangeFlag = true;
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            //firstOperand = Double.Parse(printNum.Text);
            firstOperand = tmpOperand;
            currentOperator = Operators.SUBTRACT;
            operatorChangeFlag = true;
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            //firstOperand = Double.Parse(printNum.Text);
            firstOperand = tmpOperand;
            currentOperator = Operators.MULTIPLY;
            operatorChangeFlag = true;
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            //firstOperand = Double.Parse(printNum.Text);
            firstOperand = tmpOperand;
            currentOperator = Operators.DIVIDE;
            operatorChangeFlag = true;
        }

        private void buttonAC_Click(object sender, EventArgs e)
        {
            firstOperand = 0;
            secondOperand = 0;
            tmpOperand = 0;
            currentOperator = Operators.NONE;
            printNum.Text = "0";
            operatorChangeFlag = true;
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            string num = ".";
            buttonNum_Click(num);
        }
    }
}
