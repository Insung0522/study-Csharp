using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Study_Cs_OpenCV_08_ContourRelatedFunctions_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //윤곽선 관련 함수는 분석 및 재가공에 사용되는 함수
            //윤곽선 검출 정보를 활용하여 파생될 수 있는 정보를 제공
            //윤곽선 객체의 중심점, 길이, 넓이, 최소 사각형 등 윤곽선 정보를 통해 계산할 수 있는 정보들을 쉽게 구할 수 있음
            Mat src = new Mat("hex.webp");
            Mat yellow = new Mat(); //전처리 결과 저장 공간
            Mat dst = src.Clone(); //연산 결과 저장 공간

            //윤곽선 형태 배열 구조
            Point[][] contours;
            HierarchyIndex[] hierarchy;

            Cv2.InRange(src, new Scalar(0, 137, 137), new Scalar(100, 255, 255), yellow);
            Cv2.FindContours(yellow, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);


            //반복문으로 개별 윤곽선의 정보 계산
            foreach (Point[] p in contours)
            {
                //폐곡선 여부는 시작점과 끝점의 연결 여부
                //폐곡선 여부에 따라 결과값이 바뀜
                //Cv2.ArcLength(윤곽선 배열, 폐곡선 여부) -> 윤곽선의 전체 길이
                double length = Cv2.ArcLength(p, true);
                //Cv2.ContourArea(윤곽선 배열, 폐곡선 여부) -> 윤곽선의 면적
                double area = Cv2.ContourArea(p, true);

                //유의미한 정보만 계산. 윤곽선 길이가 100 미만, 면적이 1000미만, 윤곽점의 개수가 5미만인 윤곽선 무시
                if (length < 100 && area < 1000 && p.Length < 5) continue;

                //경계 사각형 함수(Cv2.BoundingRect)는 윤곽선의 경계면을 둘러싸는 사각형을 계산
                //Cv2.BoundingRect(윤곽선 배열) -> Rect 구조체 반환.
                Rect boundingRect = Cv2.BoundingRect(p);
                //최소 면적 사각형 함수(Cv2.MinAreaRect)는 윤곽선의 경계면을 둘러싸는 최소 크기의 사각형을 계산
                //Cv2.MinAreaRect(윤곽선 배열) -> RotatedRect 구조체 반환
                RotatedRect rotatedRect = Cv2.MinAreaRect(p);
                //최소 면적 원 함수(Cv2.FitEllipse)는 윤곽선의 경계면을 둘러싸는 최소 크기의 원을 계산
                //Cv2.FitEllipse(윤곽선 배열) -> RotatedRect) 구조체 반환 (타원 형태를 가질 수 있음)
                RotatedRect ellipse = Cv2.FitEllipse(p);

                //타원 피팅 함수(Cv2.MinEnclosingCircle)은 윤곽선에 가장 근사한 원을 계산
                //out 키워드를 활용해 중심점과 반지름을 반환
                //Cv2.MinEnclosingCircle(윤곽선 배열, 중심점, 반지름) xkdnjs rPtks
                Point2f center;
                float radius;
                Cv2.MinEnclosingCircle(p, out center, out radius);

                //그리기 함수
                Cv2.Rectangle(dst, boundingRect, Scalar.Red, 2);
                Cv2.Ellipse(dst, rotatedRect, Scalar.Blue, 2);
                Cv2.Ellipse(dst, ellipse, Scalar.Green, 2);
                Cv2.Circle(dst, (int)center.X, (int)center.Y, (int)radius, Scalar.Yellow, 2);
            }

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
        }
    }
}
