using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Study_Cs_OpenCV_10_ImageRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            //이미지 회전은 강체 변환(Rigid Transformation)과 유사 변환(Similarity Transformation)에 포함되는 변환 중 하나
            //이미지 회전은 두 가지의 변환에 포함. 등방성(Isotropic) 크기 변환의 유/무로 변환의 방식 결정
            //강체 변환은 변환의 기준점으로부터 크기와 각도가 보존되는 변환
            //유사 변환은 강체 변환에 등방성의 크기 변환이 추가된 변환
            //단순한 회전은 강체 변환, 크기가 변환되며 회전하면 유사 변환

            //회전 행렬은 좌표의 값을 회전시키는 좌표 회전 행렬과 좌표축을 회전시키는 좌표축 회전 행렬이 존재
            //좌표의 회전 행렬은 원점을 중심으로 좌푯값을 회전시켜 매핑    A[2, 2] {{cos, -sin}, {sin, cos}}
            //좌표축 회전 행렬은 원점을 중심으로 행렬 자체를 회전시켜 새로운 행렬의 값을 구성    B[2, 2] {{cos, sin}, {-sin, cos}}
            //두 회전 모두 원점을 중심으로 계산을 진행

            //임의의 중심점을 기반으로 회전을 수행하기 위해서는 아핀 변환(Affine Transformation)에 기반을 둔 회전 행렬을 활용
            //2 x 3 회전 행렬을 사용할 경우 회전 축의 기준점 변경과 비율을 조정 가능
            /*
             Z[2, 3] {{ A, B, (1-A)xCenter(x)-BxCenter(y) },
                      {-B, A, BxCenter(x)-(1-A)xCenter(y) }};
            A = scale x cos seta
            B = scale x sin seta
             */
            //Center는 중심점의 좌표, scale은 비율, seta는 회전 각도
            Mat src = new Mat("wine.jpg");
            Mat dst = new Mat();

            //회전 행렬 생성
            //2x3 회전 행렬 생성 함수(Cv2.GetRotationMatrix2D)는 Mat 형식의 회전 행렬을 생성
            //중심점의 좌표를 기준으로 회전 각도 만큼 회전하며, 비율 만큼 크기를 변경
            //Cv2.GetRotationMatrix2D(중심점의 좌표, 회전 각도, 비율)
            Mat matrix = Cv2.GetRotationMatrix2D(new Point2f(src.Width / 2, src.Height / 2), 45.0, 1.0);
            //생성된 회전 행렬으로 아핀 변환을 진행
            //아핀 변환 함수는 회전 행렬을 사용해 회전된 이미지를 생성
            //결과 배열의 크기를 설정하는 이유는 회전 후, 원본 배열의 이미지 크기와 다를 수 있기 때문
            //만약 45도 이미지를 회전한다면, 사각형 프레임 안에 포함시켜야 함
            //그로 인해 더 큰 공간이나 더 작은 공간에 포함할 수 있음
            //따라서, 결과 배열의 크기를 새로 할당하거나, 원본 배열의 크기와 동일하게 사용
            //CV2.WarpAffine(원본, 결과, 행렬, 결과 배열의 크기)
            Cv2.WarpAffine(src, dst, matrix, new Size(src.Width, src.Height));

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
        }
    }
}
