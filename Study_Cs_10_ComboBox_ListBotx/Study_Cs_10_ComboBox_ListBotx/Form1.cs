using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Study_Cs_10_ComboBox_ListBotx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ListBox의 목록을 초기화
            ltbx.Items.Clear();

            //lst 배열 생성하여 ListBox에 들어갈 목록 생성
            string[] lst1 = { "1-1번", "1-2번", "1-3번" };
            string[] lst2 = { "2-1번", "2-2번", "2-3번" };
            string[] lst3 = { "3-1번", "3-2번", "3-3번" };
            string[] lst4 = { "4-1번", "4-2번", "4-3번" };

            //선택된 Index를 비교하여 ListBox의 목록에 한 번에 저장
            if (cmbx.SelectedIndex == 0) ltbx.Items.AddRange(lst1);
            if (cmbx.SelectedIndex == 1) ltbx.Items.AddRange(lst2);
            //Index가 아닌 Item의 이름으로 비교. 직관적 코딩 가능
            if (cmbx.SelectedItem == "3번 목록") ltbx.Items.AddRange(lst3);
            if (cmbx.SelectedIndex == 3) ltbx.Items.AddRange(lst4);

        }

        private void ltbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_info.Text = Convert.ToString(ltbx.SelectedItem);
        }
    }
}
