using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Study_Cs_OpenCV_09_ContourRelatedFunctions_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat src = new Mat("hex.jpg");
            Mat yellow = new Mat();
            Mat dst = src.Clone();

            Point[][] contours;
            HierarchyIndex[] hierarchy;

            Cv2.InRange(src, new Scalar(0, 137, 137), new Scalar(100, 255, 255), yellow);
            Cv2.FindContours(yellow, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);

            foreach(Point[] p in contours)
            {
                double length = Cv2.ArcLength(p, true);
                double area = Cv2.ContourArea(p, true);

                if (length < 100 && area < 1000 && p.Length < 5) continue;

                //볼록성 시험 함수는 윤곽선이 볼록한 형태인지 확인
                //Cv2.IsCOntourConvex(윤곽선 배열)로 볼록성 확인
                //볼록한 형태는 볼록한 형태나 수직한 형태를 갖는 것을 의미
                //볼록한 형태라면 단순한 다각형 형태를 지님
                //즉, 교차하는 점이 없는 형태가 되어 하나의 윤곽선 그룹안에 하나의 다각형만 존재
                //볼록하다면 true, 볼록하지 않다면 false
                bool convex = Cv2.IsContourConvex(p);
                //볼록 껍질 함수는 윤곽선의 경계면을 둘러싸는 다각형을 변환
                //볼록한 형태를 반환하므로, 윤곽선 배열과 동일한 값을 반환
                //방향은 검출된 볼록 껍질 배열의 색인 순서를 결정
                //참일 경우, 시계방향
                //볼록 껍질 알고리즘은 O(nlogN)시간 복잡도를 갖는 스크랜스키(Sklansky) 알고리즘을 이용해 입력된 좌표들의 볼록한 외곽을 찾음
                //스크랜스키 알고리즘은 윤곽점에서 경계 사각형의 정점을 검출
                //경계면을 둘러싸는 다각형을 경계 사각형 내부에 포함되며, 해당 정점을 볼록점으로 사용
                //Cv2.ConvexHull(윤곽선 배열, 방향)
                Point[] hull = Cv2.ConvexHull(p, true);
                //모멘트 함수는 윤곽선의 0차 모멘트부터 3차 모멘트까지 계싼
                //이진화 이미지는 입력된 배열 매개변수가 이미지일 경우, 이미지 픽셀 값들을 이진화 처리할지 결정
                //이진화 이미지 매개변수에 true를 할당한다면 이미지의 픽셀 값이 0이 아닌 값은 모두 1의 값으로 변경해 모멘트를 계산
                //모멘트 함수는 공간 모멘트(Spatial Moments), 중심 모멘트(Central Moments) 정규화된 중심 모멘트(Normalized Central Moments)를 계산
                //모멘트 값을 활용하면, 윤곽선의 질량 중심을 계산 가능
                ////이 값을 주로, 객체의 중심점으로 활용
                //Cv2.Moments(배열, 이진화 이미지)
                Moments moments = Cv2.Moments(p, false);

                //그리기 함수
                //아래 함수들은 2차원 배열을 입력 값으로 요구하므로, 2차원 배열로 변경하여 값을 입력
                //Cv2.FillConvexPoly(dst, hull, Scalar.White);
                //Cv2.Polylines(dst, new Point[][] { hull }, true, Scalar.White, 1);
                Cv2.DrawContours(dst, new Point[][] { hull }, -1, Scalar.White, 1);

                //모멘트 반환 값을 통해 윤곽선의 중심점(무게 중심) 계산 가능
                //모멘트 M_ij는 윤곽선(이미지)의 모든 픽셀에 대한 합으로 정의
                //X 좌표는 M_10 / M_00로, Y 좌표는 M_01 / M_00로 무게 중심 (X, Y)를 계산 가능
                Cv2.Circle(dst, (int)(moments.M10 / moments.M00), (int)(moments.M01 / moments.M00), 5, Scalar.Black, -1);
            }

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
        }
    }
}
