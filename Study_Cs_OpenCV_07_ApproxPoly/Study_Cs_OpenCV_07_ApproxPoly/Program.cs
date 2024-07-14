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
            //다각형 근사는 검출된 윤곽선의 형상을 분석할 때 정점(Vertex)의 수가 적은 다각형으로 표현할 수 있게 다각형 곡선을 근사하는 방법
            //더글라스-패커 알고리즘 사용
            //반복과 끝점을 이용해 선분으로 구성된 윤곽선들을 더 적은 수의 윤곽점으로 동일하거나 비슷한 윤곽선으로 데시메이트(Decimate)함
            //더글라스-패커 알고리즘은 근사치 정확도(Epsilon)의 값으로 기존의 다각형과 윤곽점이 압축된 다각형의 최대 편차를 고려해 다각형을 근사
            //데시메이트란 일정 간격으로 샘플링된 데이터를 기존 간격보다 더 큰 샘플링 간격으로 다시 샘플링하는 것

            Mat src = new Mat("hex.webp");
            Mat yellow = new Mat();
            Mat dst = src.Clone();

            //다각형 근사 알고리즘은 윤곽선 형태의 배열 구조를 사용하여 근사
            //다각형 근사 알고리즘은 하나의 다각형을 근사하므로, 반복문을 활용해 개별의 다각형을 근사
            Point[][] contours;
            HierarchyIndex[] hierarchy;

            Cv2.InRange(src, new Scalar(0, 127, 127), new Scalar(100, 255, 255), yellow);
            Cv2.FindContours(yellow, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);

            List<Point[]> new_contours = new List<Point[]>();
            foreach (Point[] p in contours)
            {
                double length = Cv2.ArcLength(p, true);
                if (length < 100) continue;

                //다각형 근사 함수(Cv2.ApproxPolyDP)를 통해 근사치 정확도(Epsilon)의 값으로 근사
                //원본 배열에서 근사치 정확도 값으로 근사를 진행
                //폐곡선 여부는 시작점과 끝점의 연결 여부를 의미
                //참이 경우, 마지막 점과 시작 점이 연결된 것으로 간주
                //다각형 근사 함수에서 가장 중요한 것은 근사치 정확도
                //일반적으로 전체 윤곽선 길이의 1~5%의 값을 사용
                //Cv2.ApproxPolyDP(원본, 근차시 정확도, 폐곡선 여부)
                new_contours.Add(Cv2.ApproxPolyDP(p, length * 0.01, true));
                //다각형 근사 함수는 새로운 윤곽 배열을 반환, 이를 바로 new_contours에 추가
            }

            Cv2.DrawContours(dst, new_contours, -1, new Scalar(255, 0, 0), 2, LineTypes.AntiAlias, null, 1);
            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            //이메일 변경 수정
        }
    }
}
