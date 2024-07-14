using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Study_Cs_OpenCV_12_PerspectiveTransformation
{
    class Program
    {
        static void Main(string[] args)
        {
            //원근 변환이란 원근감을 표현하기 위한 변환
            //아핀 변환과 비슷하지만 선의 수평성을 유지하지 않고, 직선의 성질만 유지되며 사각형을 임의의 사각형 형태로 변환하는 것
            //뒤틀림이나 원근 왜곡을 표현해야 하므로 아핀 변환보다 더 많은 미지수를 요구
            /*
             원근 변환 행렬
            |x2|   |a00 a01 b0| |x1|
            |y2| = |a10 a11 b1| |y1|
            |1 |   |a20 a21 1 | |1 |

            |x2|   |a00x1 + a01y1 + b0|
            |y2| = |a10x1 + a11y1 + b1|
            |1 |   |a20x1 + a21y1 + 1 |
             */
            //아핀 변환 행렬과 비슷한 형태를 가지지만 원근 변환 행렬은 0, 0, 1이 a20, a21, 1로 변경되어 미지수의 갯수가 6 -> 8로 늘어남
            //따라서 아핀 변환은 원근 변환의 하위 영역에 속함
            //x1, y1은 변환 전 원본 이미지의 픽셀 좌표. x2, y2는 변환 후의 결과 이미지의 픽셀 좌표
            //여덟개의 미지수를 구하기 위해 네개의 좌표를 활용


            Mat src = new Mat("C:\\Users\\USER\\source\\repos\\plate.jpg");
            Mat dst = new Mat();

            //원근 맵 행렬 생성
            //4개의 픽셀 좌표 필요
            //src_pts와 dst_pts의 픽셀 좌표들의 순서는 1:1 매칭
            List<Point2f> src_pts = new List<Point2f>()
            {
                new Point2f(0.0f, 0.0f),
                new Point2f(0.0f, src.Height),
                new Point2f(src.Width, src.Height),
                new Point2f(src.Width, 0.0f)
            };

            List<Point2f> dst_pts = new List<Point2f>()
            {
               new Point2f(300.0f, 100.0f),
               new Point2f(300.0f, src.Height),
               new Point2f(src.Width - 400.0f, src.Height - 200.0f),
               new Point2f(src.Width - 200.0f, 200.0f)
            };

            //원근 맵 행렬 생성 함수(Cv2.GEtPerspectiveTransform)는 변환 전, 후의 각 네개의 픽셀 좌표를 이용해 원근 맵 행렬 생성
            //Cv2.GetPerspectiveTransform(변환 전 빅셀 좌표, 변환 후 픽셀 좌표)
            Mat matrix = Cv2.GetPerspectiveTransform(src_pts, dst_pts);
            //원근변환 진행
            //결과 배열의 크기를 설정하는 이유는 원본 배열의 이미지와 크기가 다를 수 있기 떄문
            //Cv2.WarpPerspective(원본, 결과, 행렬, 결과 배열의 크기, 보간법, 테두리 외삽법, 테두리 색상)
            Cv2.WarpPerspective(src, dst, matrix, new Size(src.Width, src.Height));

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
        }
    }
}
