using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Study_Cs_OpenCV_01_Output
{
    

    class Program
    {
        static void Main(string[] args)
        {
            //카메라 출력
            VideoCapture video = new VideoCapture(0);
            Mat frame = new Mat();

            while (Cv2.WaitKey(33) != 'q')
            {
                video.Read(frame);
                Cv2.ImShow("frame", frame);
            }

            frame.Dispose();
            video.Release();
            Cv2.DestroyAllWindows();

            //이미지 출력
            //경로는 bin\Debug\
            Mat image = Cv2.ImRead("cat.jpg", ImreadModes.Grayscale);
            //Mat image = new Mat("cat.jpg", ImreadModes.Grayscale);
            if (image.Empty())
            {
                Console.WriteLine("이미지를 올바르게 불러오지 못했습니다.");
                return;
            }
            Cv2.ImShow("image", image);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();

            //비디오 출력
            VideoCapture video2 = new VideoCapture("sample.mp4");
            Mat frame2 = new Mat();

            while (video2.PosFrames != video2.FrameCount && Cv2.WaitKey(33) != 'q')
            {
                video2.Read(frame2);
                Cv2.ImShow("frame", frame2);
                Cv2.WaitKey(33);
            }
            frame2.Dispose();
            video2.Release();
            Cv2.DestroyAllWindows();


        }
    }
    }