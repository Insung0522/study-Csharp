using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace WindowsFormsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const int MIN_AREA = 250;
        const int MAX_AREA = 400;
        const double MIN_RATIO = 1;
        const double MAX_RATIO = 1.3;

        Mat src_image = new Mat();
        Mat gray = new Mat();
        Mat gaussianblur = new Mat();
        Mat canny = new Mat();
        Mat binary = new Mat();


        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Src_Image.Load(openFileDialog1.FileName);
            }
        }

        private void B_Load_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Src_Image.Load(openFileDialog1.FileName);
            }
            src_image = new Mat(openFileDialog1.FileName);
            Dst_Image.Image = Src_Image.Image;
        }
        private void B_GrayScale_Click(object sender, EventArgs e)
        {
            Cv2.CvtColor(src_image, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.ImWrite("grayImage.jpg", gray);
            Dst_Image.Load(@"./grayImage.jpg");
        }

        private void B_Gaussian_Click(object sender, EventArgs e)
        {
            Cv2.GaussianBlur(gray, gaussianblur, new OpenCvSharp.Size(5, 5), 0);
            Cv2.ImWrite("gaussianImage.jpg", gaussianblur);
            Dst_Image.Load(@"./gaussianImage.jpg");
        }

        private void B_Canny_Click(object sender, EventArgs e)
        {
            Cv2.Canny(gaussianblur, canny, 100, 300, 3);
            Cv2.ImWrite("cannyImage.jpg", canny);
            Dst_Image.Load(@"./cannyImage.jpg");
        }

        private void B_Binary_Click(object sender, EventArgs e)
        {
            Cv2.Threshold(canny, binary, 157, 255, ThresholdTypes.Binary);
            Cv2.ImWrite("binaryImage.jpg", binary);
            Dst_Image.Load(@"./binaryImage.jpg");
        }

        private void B_Contour_Click(object sender, EventArgs e)
        {
            Mat black = new Mat();
            Mat drawing = binary.Clone();

            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchy;

            Cv2.InRange(binary, new Scalar(255, 255, 255), new Scalar(255, 255, 255), black);
            Cv2.FindContours(black, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);

            List<OpenCvSharp.Point[]> new_contours = new List<OpenCvSharp.Point[]>();
            foreach (OpenCvSharp.Point[] p in contours)
            {
                Rect boundingRect = Cv2.BoundingRect(p);
                Console.WriteLine("Height : " + boundingRect.Height);
                Console.WriteLine("Width : " + boundingRect.Width);

                double ratio = (double)boundingRect.Width / (double)boundingRect.Height;
                double area2 = boundingRect.Width * boundingRect.Height;
                Console.WriteLine("Ratio : " + ratio);
                Console.WriteLine("Area : " + area2);

                if (ratio < MIN_RATIO || ratio > MAX_RATIO || area2 < MIN_AREA || area2 > MAX_AREA) continue;
                new_contours.Add(p);
                Cv2.Rectangle(drawing, boundingRect, Scalar.White, 2);
            }
            Cv2.ImWrite("contours.jpg", drawing);
            Dst_Image.Load(@"./contours.jpg");
        }
    }
}
