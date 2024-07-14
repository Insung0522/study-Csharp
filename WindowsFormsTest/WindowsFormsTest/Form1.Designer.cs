
namespace WindowsFormsTest
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
            this.Src_Image = new System.Windows.Forms.PictureBox();
            this.Dst_Image = new System.Windows.Forms.PictureBox();
            this.Src = new System.Windows.Forms.Label();
            this.Dst = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.B_GrayScale = new System.Windows.Forms.Button();
            this.B_Gaussian = new System.Windows.Forms.Button();
            this.B_Canny = new System.Windows.Forms.Button();
            this.B_Binary = new System.Windows.Forms.Button();
            this.B_Contour = new System.Windows.Forms.Button();
            this.B_Load = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.Src_Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dst_Image)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Src_Image
            // 
            this.Src_Image.Image = global::WindowsFormsTest.Properties.Resources.carnumber;
            this.Src_Image.Location = new System.Drawing.Point(36, 89);
            this.Src_Image.Name = "Src_Image";
            this.Src_Image.Size = new System.Drawing.Size(454, 402);
            this.Src_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Src_Image.TabIndex = 0;
            this.Src_Image.TabStop = false;
            // 
            // Dst_Image
            // 
            this.Dst_Image.Location = new System.Drawing.Point(496, 89);
            this.Dst_Image.Name = "Dst_Image";
            this.Dst_Image.Size = new System.Drawing.Size(454, 402);
            this.Dst_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Dst_Image.TabIndex = 1;
            this.Dst_Image.TabStop = false;
            // 
            // Src
            // 
            this.Src.AutoSize = true;
            this.Src.Location = new System.Drawing.Point(56, 55);
            this.Src.Name = "Src";
            this.Src.Size = new System.Drawing.Size(29, 15);
            this.Src.TabIndex = 2;
            this.Src.Text = "Src";
            // 
            // Dst
            // 
            this.Dst.AutoSize = true;
            this.Dst.Location = new System.Drawing.Point(512, 59);
            this.Dst.Name = "Dst";
            this.Dst.Size = new System.Drawing.Size(29, 15);
            this.Dst.TabIndex = 3;
            this.Dst.Text = "Dst";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(991, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기ToolStripMenuItem,
            this.저장ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.열기ToolStripMenuItem.Text = "열기";
            this.열기ToolStripMenuItem.Click += new System.EventHandler(this.열기ToolStripMenuItem_Click);
            // 
            // 저장ToolStripMenuItem
            // 
            this.저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            this.저장ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.저장ToolStripMenuItem.Text = "저장";
            // 
            // B_GrayScale
            // 
            this.B_GrayScale.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.B_GrayScale.Location = new System.Drawing.Point(152, 536);
            this.B_GrayScale.Name = "B_GrayScale";
            this.B_GrayScale.Size = new System.Drawing.Size(87, 40);
            this.B_GrayScale.TabIndex = 5;
            this.B_GrayScale.Text = "Gray";
            this.B_GrayScale.UseVisualStyleBackColor = true;
            this.B_GrayScale.Click += new System.EventHandler(this.B_GrayScale_Click);
            // 
            // B_Gaussian
            // 
            this.B_Gaussian.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.B_Gaussian.Location = new System.Drawing.Point(245, 536);
            this.B_Gaussian.Name = "B_Gaussian";
            this.B_Gaussian.Size = new System.Drawing.Size(137, 40);
            this.B_Gaussian.TabIndex = 6;
            this.B_Gaussian.Text = "Gaussian";
            this.B_Gaussian.UseVisualStyleBackColor = true;
            this.B_Gaussian.Click += new System.EventHandler(this.B_Gaussian_Click);
            // 
            // B_Canny
            // 
            this.B_Canny.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.B_Canny.Location = new System.Drawing.Point(388, 536);
            this.B_Canny.Name = "B_Canny";
            this.B_Canny.Size = new System.Drawing.Size(102, 40);
            this.B_Canny.TabIndex = 7;
            this.B_Canny.Text = "Canny";
            this.B_Canny.UseVisualStyleBackColor = true;
            this.B_Canny.Click += new System.EventHandler(this.B_Canny_Click);
            // 
            // B_Binary
            // 
            this.B_Binary.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.B_Binary.Location = new System.Drawing.Point(496, 536);
            this.B_Binary.Name = "B_Binary";
            this.B_Binary.Size = new System.Drawing.Size(102, 40);
            this.B_Binary.TabIndex = 8;
            this.B_Binary.Text = "Binary";
            this.B_Binary.UseVisualStyleBackColor = true;
            this.B_Binary.Click += new System.EventHandler(this.B_Binary_Click);
            // 
            // B_Contour
            // 
            this.B_Contour.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.B_Contour.Location = new System.Drawing.Point(59, 582);
            this.B_Contour.Name = "B_Contour";
            this.B_Contour.Size = new System.Drawing.Size(123, 40);
            this.B_Contour.TabIndex = 9;
            this.B_Contour.Text = "Contour";
            this.B_Contour.UseVisualStyleBackColor = true;
            this.B_Contour.Click += new System.EventHandler(this.B_Contour_Click);
            // 
            // B_Load
            // 
            this.B_Load.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.B_Load.Location = new System.Drawing.Point(59, 536);
            this.B_Load.Name = "B_Load";
            this.B_Load.Size = new System.Drawing.Size(87, 40);
            this.B_Load.TabIndex = 10;
            this.B_Load.Text = "Load";
            this.B_Load.UseVisualStyleBackColor = true;
            this.B_Load.Click += new System.EventHandler(this.B_Load_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 670);
            this.Controls.Add(this.B_Load);
            this.Controls.Add(this.B_Contour);
            this.Controls.Add(this.B_Binary);
            this.Controls.Add(this.B_Canny);
            this.Controls.Add(this.B_Gaussian);
            this.Controls.Add(this.B_GrayScale);
            this.Controls.Add(this.Dst);
            this.Controls.Add(this.Src);
            this.Controls.Add(this.Dst_Image);
            this.Controls.Add(this.Src_Image);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Src_Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dst_Image)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Src_Image;
        private System.Windows.Forms.PictureBox Dst_Image;
        private System.Windows.Forms.Label Src;
        private System.Windows.Forms.Label Dst;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 저장ToolStripMenuItem;
        private System.Windows.Forms.Button B_GrayScale;
        private System.Windows.Forms.Button B_Gaussian;
        private System.Windows.Forms.Button B_Canny;
        private System.Windows.Forms.Button B_Binary;
        private System.Windows.Forms.Button B_Contour;
        private System.Windows.Forms.Button B_Load;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

