﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Study_Cs_OpenCV_11_AffineTransformation
{
    class Program
    {
        static void Main(string[] args)
        {
            //아핀 변환은 선형 변환에 이동 변환까지 포함된 변환
            //선의 수평성을 유지하며, 변환 전의 서로 평행한 선은 변환 후에도 평행함을 의미
            //즉, 길이의 비와 평행성이 보존되는 변환. 사각형을 평행사변형으로 변환하는 것을 아핀 변환으로 간주
            //2x2의 단순 행렬이 아닌 2x3 행렬의 변환을 위한 

            /*
             | x2 |   | a00  a01  b0 || x1 |
             | y2 | = | a10  a11  b1 || y1 |
             | 1  |   |  0    0   1  || 1  |
             
             | x2 |   | a00x1 + a01y1 + b0 |
             | y2 | = | a10x1 + a11y1 + b1 |
             | 1  |   | 0 + 0 + 1          |
             */
            //아핀 변환 행렬의 기본형은 3x3이지만, 세번째 행의 값은 0, 0, 1의 값을 지님
            //좌변의 행렬과 우변의 행렬의 세번째 행의 값은 항상 같은 값을 지니게 되어 OpenCV에서는 2x3 행렬로 표현
            //행렬의 x1,y1은 변환 전 원본 이미지의 픽셀 좌표를 의미. x2,y2는 변환 후의 결과 이미지의 픽셀 좌표를 의미
            //변환 후의 픽셀 좌표를 계싼하기 위해서는 미지수 a00 a01 a10 a11 b0 b1의 값을 알아야 함
            //여섯 개의 미지수를 구하기 위해 세 개의 좌표를 활용해 미지수를 계산

            //Mat src = new Mat("wine.jpg");
            Mat src = new Mat("snow.jpg");
            Mat dst = new Mat();


            //아핀 변환을 진행하기 위해선 아핀 맵 행렬을 생성해야 함
            //아핀 맵 행렬 생성 함수(Cv2.GetAffineTransform)은 변환 전 세 개의 픽셀 좌표(src)pts)와 변환 후 세 개의 픽셀 좌표(dst)pts)를 이용해 아핀 맵 행렬을 생성
            
            //픽셀 좌표는 3개의 픽셀 좌표를 포함해야 하므로, 리스트를 톨해 Point2f 형식의 좌표 생삿
            //src_pts와 dts_pts의 픽셀 좌표들의 순서는 1:1 매칭
            List<Point2f> src_pts = new List<Point2f>()
            {
                new Point2f(0.0f, 0.0f),
                new Point2f(0.0f, src.Height),
                new Point2f(src.Width, src.Height)
            };

            List<Point2f> dst_pts = new List<Point2f>()
            {
               new Point2f(300.0f, 300.0f),
               new Point2f(300.0f, src.Height),
               new Point2f(src.Width - 400.0f, src.Height - 200.0f)
            };

            //Cv2.getAffineTransform(변환 전 픽셀 좌표, 변환 후 픽셀 좌표)
            Mat matrix = Cv2.GetAffineTransform(src_pts, dst_pts);

            //생성된 아핀 행렬을 활용해 아핀 변환 진행
            //아핀 변환 함수는 아핀 행렬을 사용해 변환된 이미지 생성
            //결과 배열의 크기를 지정하는 이유는 회전 후, 원본 배열의 이미지 크기와 다를 수 있기 떄문
            //보간법, 테두리 외삽법, 테두리 색상 또한 새로운 공간에 이미지를 할당하므로, 보간에 필요한 매개변수들을 활용할 수 있습니다.
            //Cv2.WarpAffine(원본, 결과, 행렬, 결과 배열의 크기, 보간법, 테두리 외삽법, 테두리 색상)
            Cv2.WarpAffine(src, dst, matrix, new Size(src.Width, src.Height));

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
        }
    }
}
