
namespace Study_Cs_10_ComboBox_ListBotx
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbx = new System.Windows.Forms.ComboBox();
            this.ltbx = new System.Windows.Forms.ListBox();
            this.lbl_select = new System.Windows.Forms.Label();
            this.lbl_info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbx
            // 
            this.cmbx.FormattingEnabled = true;
            this.cmbx.Items.AddRange(new object[] {
            "1번 목록",
            "2번 목록",
            "3번 목록",
            "4번 목록"});
            this.cmbx.Location = new System.Drawing.Point(25, 26);
            this.cmbx.Name = "cmbx";
            this.cmbx.Size = new System.Drawing.Size(121, 23);
            this.cmbx.TabIndex = 0;
            this.cmbx.Text = "선택하세요.";
            this.cmbx.SelectedIndexChanged += new System.EventHandler(this.cmbx_SelectedIndexChanged);
            // 
            // ltbx
            // 
            this.ltbx.FormattingEnabled = true;
            this.ltbx.ItemHeight = 15;
            this.ltbx.Location = new System.Drawing.Point(238, 26);
            this.ltbx.Name = "ltbx";
            this.ltbx.Size = new System.Drawing.Size(120, 94);
            this.ltbx.TabIndex = 1;
            this.ltbx.SelectedIndexChanged += new System.EventHandler(this.ltbx_SelectedIndexChanged);
            // 
            // lbl_select
            // 
            this.lbl_select.AutoSize = true;
            this.lbl_select.Location = new System.Drawing.Point(22, 217);
            this.lbl_select.Name = "lbl_select";
            this.lbl_select.Size = new System.Drawing.Size(52, 15);
            this.lbl_select.TabIndex = 2;
            this.lbl_select.Text = "선택 : ";
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(90, 217);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(15, 15);
            this.lbl_info.TabIndex = 3;
            this.lbl_info.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 302);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.lbl_select);
            this.Controls.Add(this.ltbx);
            this.Controls.Add(this.cmbx);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbx;
        private System.Windows.Forms.ListBox ltbx;
        private System.Windows.Forms.Label lbl_select;
        private System.Windows.Forms.Label lbl_info;
    }
}

