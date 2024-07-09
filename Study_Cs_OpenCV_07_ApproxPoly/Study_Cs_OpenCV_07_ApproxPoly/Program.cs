using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Study_Cs_OpenCV_07_ApproxPoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat src = new Mat("hex.webp");
            Mat yellow = new Mat();
            Mat dst = src.Clone();

            //다각형 근사 알고리즘은 윤곽선 형태의 배열 구조를 사용하여 근사
            //다각형 근사 알고리즘은 하나의 다각형을 근사하므로, 반복문을 활용해 개별의 다각형 근사
            Point[][] contours;
            HierarchyIndex[] hierarchy;

            Cv2.InRange(src, new Scalar(0, 127, 127), new Scalar(100, 255, 255), yellow);
            Cv2.FindContours(yellow, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);

            List<Point[]> new_contours = new List<Point[]>();
            foreach (Point[] p in contours)
            {
                double length = Cv2.ArcLength(p, true);
                if (length < 100) continue;

                //다각형 근사 함수(ApproxPolyDP)를 통해 근사치 정확도(Epsilon)의 값으로 근사
                //원본 배열에서 근사치 정확도 값으로 다각형 근사를 진행
                //폐곡선 여부는 시작점과 끝점의 연결 여부를 의미. 참일 경우, 마지막 점과 시작 점이 연결된 것으로 간주
                //다각형 근사 함수에서 가장 중요한 매개변수는 근사치 정확도.
                //일반적으로 전체 윤곽선 길이의 1~5%의 값을 사용
                //다각형 근사 함수는 새로운 윤곽 배열을 반환하며, 이 값을 바로 new_contours에 추가
                //Cv2.ApproxPolyDP(원본, 근사치 정확도, 폐곡선 여부)
                new_contours.Add(Cv2.ApproxPolyDP(p, length * 0.01, true));
            }

            Cv2.DrawContours(dst, new_contours, -1, new Scalar(255, 0, 0), 2, LineTypes.AntiAlias, null, 1);
            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
        }
    }
}
