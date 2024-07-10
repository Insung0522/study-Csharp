using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Reading_CarNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //카메라 출력
            //VideoCapture video = new VideoCapture(0);
            //Mat frame = new Mat();

            //while(Cv2.WaitKey(33) != 'q')
            //{
            //    video.Read(frame);
            //    Cv2.ImShow("frame", frame);
            //}

            //frame.Dispose();
            //video.Release();
            //Cv2.DestroyAllWindows();

            //Mat image = Cv2.ImRead("../../../../carnumber_a01.png", ImreadModes.Grayscale);
            Mat image = new Mat("../../../../carnumber_a01.png"); //원문
            //Mat image = new Mat("../../../../carnumber.jpg");
            //Cv2.ImShow("image", image);

            //그레이스케일
            Mat gray = new Mat();
            Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);
            //Cv2.ImShow("gray", gray);

            //가우시안 블러
            Mat gaussianblur = new Mat();
            Cv2.GaussianBlur(gray, gaussianblur, new Size(5, 5), 0);
            Cv2.ImShow("gaussianBlur", gaussianblur);

            //캐니
            Mat canny = new Mat();
            Cv2.Canny(gaussianblur, canny, 100, 300, 3);
            Cv2.ImShow("canny",canny);

            //이진화 (Thresholding)
            Mat binary = new Mat(); //이진화될 공간
            Cv2.Threshold(canny, binary, 157, 255, ThresholdTypes.Binary);
            Cv2.ImShow("binary", binary);


            //윤곽선 검출
            Mat black = new Mat();
            Mat drawing = binary.Clone();

            Point[][] contours;
            HierarchyIndex[] hierarchy;

            Cv2.InRange(binary, new Scalar(255, 255, 255), new Scalar(255, 255, 255), black);
            Cv2.FindContours(black, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);
            Cv2.ImShow("contours", contours);


            //불필요한 윤곽선 제거
            List<Point[]> new_contours = new List<Point[]>();
            foreach (Point[] p in contours)
            {
                double length = Cv2.ArcLength(p, true);
                double area = Cv2.ContourArea(p, true);
                //if (length > 10)
                //{
                //new_contours.Add(p);
                //}
                Console.WriteLine("length : " + length); //100 ~ 200
                Console.WriteLine("area : " + area); // 200 ~ 700
                if ((length < 100 && area < 200) || (length > 200 && area > 700) && p.Length > 5) continue;

                Rect boundingRect = Cv2.BoundingRect(p);
                new_contours.Add(p);
                Cv2.Rectangle(drawing, boundingRect, Scalar.Red, 2);
                //Cv2.ImShow("dst", dst);
                //Cv2.WaitKey(0);

            }

            Cv2.DrawContours(drawing, new_contours, -1, new Scalar(255, 0, 0), 2, LineTypes.AntiAlias, null, 1);
            Cv2.ImShow("drawing", drawing);

            //데이터 비교
            


            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
