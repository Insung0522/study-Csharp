using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Study_Cs_OpenCV_05_EdgeDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            //가장자리 검출(Edge Detection)
            //가장자리(Edge)는 '객체'
            //이미지 상에서 가장자리는 전경(foreground)과 배경(background)이 구분되는 지점. 전경과 배경 사이에서 밝기가 큰 폭으로 변하는 지점이 객체의 가장자리
            //즉, 픽셀의 밝기 변화율이 높은 부분이 가장자리
            //가장자리 검출 함수는 크게 소벨 미분, 샤르 필터, 라플라시안, 캐니 엣지가 있음

            //미분(Derivative)
            //1차 미분이나 2차 미분을 이용해 변화율이 높은 지점을 가장자리로 간주
            //따라서, 노이즈에 큰 영향을 받음 -> 블러 처리를 진행한 후에 가장자리 검출
            //이미지는 샘플링과 양자화가 처리된 데이터이므로 밝기의 평균변화율이 아닌 순간변화율을 구해 계산

            Mat src = new Mat("cat.jpg");
            Mat blur = new Mat();

            Mat sobel = new Mat();
            Mat scharr = new Mat();
            Mat laplacian = new Mat();
            Mat canny = new Mat();

            Cv2.GaussianBlur(src, blur, new Size(3, 3), 1, 0, BorderTypes.Default);

            //소벨 미분 함수는 미분 값을 구할 떄 가장 많이 사용되는 연산자
            //입력 이미지가 8비트의 정밀도를 갖는 경우 오버플로가 발생 가능. 16비트 이상의 정밀도를 결과 배열의 정밀도로 사용해야 함
            //차수는 0, 1, 2를 사용. 두 차수의 합은 1 이상이 되어야 함
            //커널(ksize)은 홀수 값만 사용 가능하며, 31까지의 크기만 지원
            //비율과 오프셋은 출력 이미지를 반환하기 전에 계산되며, 8비트 정밀도의 이미지를 사용해 이미지를 시각적으로 확인하고자 할 떄 조절값으로 사용
            //테두리 외삽법은 컨벌루션 연산이므로, 이미지 가장자리 부분의 계산 방법을 설정
            //ConvertTo 함수는 이미지 출력 함수(Cv2.Imshow)가 8비트 이미지만 지원하므로 출력을 위해 변환
            //원본 배열.ConvertTo(결과, 반환 형식)
            //Cv2.Sobel(원본, 결과, 결과 배열 정밀도, X 방향 미분 차수, Y 방향 미분 차수, 커널, 비율, 오프셋, 테두리 외삽법)
            Cv2.Sobel(blur, sobel, MatType.CV_32F, 1, 0, ksize: 3, scale: 1, delta: 0, BorderTypes.Default);
            sobel.ConvertTo(sobel, MatType.CV_8UC1);

            //샤르 필터 함수는 소벨 미분의 단점을 보완한 방식
            //소벨 미분은 커널의 크기가 작으면 정확도가 떨어지는데, 크기가 작은 3 X 3 소벨 미분의 경우 기울기(Gradient)의 각도가 수평이나 수직에서 멀어질 수록 정확도 떨어짐
            //이를 보완하고자 샤르 필터를 사용. 샤르 필터는 커널의 크기가 3 X 3만 지원.
            //Cv2.Scharr(원본, 결과, 결과 배열 정밀도, X 방향 미분 차수, Y방향 미분 차수, 비율, 오프셋, 테두리 외삽법)
            Cv2.Scharr(blur, scharr, MatType.CV_32F, 1, 0, scale: 1, delta: 0, BorderTypes.Default);
            scharr.ConvertTo(scharr, MatType.CV_8UC1);

            //라플라시안 함수는 2차 미분 형태로 반환
            //가장자리가 밝은 부분에서 발생한 것인지, 어두운 부분에서 발생한 것인지 파악 가능
            //2차 미분 방식은 x축과 y축을 따라 2차 미분한 합을 의미
            //커널의 크기가 1일 때는 라플라시안 단일 커널을 적용해 계산
            //Cv2.Laplacian(원본, 결과, 결과 배열 정밀도, 커널, 비율, 오프셋, 테두리 외삽법)
            Cv2.Laplacian(blur, laplacian, MatType.CV_32F, ksize: 3, scale: 1, delta: 0, BorderTypes.Default);
            laplacian.ConvertTo(laplacian, MatType.CV_8UC1);

            //캐니 엣지는 라플라스 필터 방식을 캐니가 개선한 방식으로, x와 y에 대해 1차 미분을 계산한 다음, 네 방향으로 미분
            //동작 순서는 아래와 같음
            //1. 노이즈 제거를 위해 가우시안 필터를 사용해 흐림 효과 적용
            //2. 기울기 값이 높은 지점을 검출(소벨 마스크 적용)
            //3. 최댓값이 아닌 픽셀의 값을 0으로 변경(명백하게 가장자리가 아닌 값을 제거)
            //4. 히스테리시스 임곗값 적용
            //하위 임곗값은 픽셀 값이 하위 임곗값보다 낮은 경우 가장자리로 고려하지 않음
            //상위 임곗값은 픽셀 값이 상위 임곘값보다 큰 기울기를 가지면 픽셀을 가장자리로 간주
            //상위 임곗값보다 낮으면서, 하위 임곗값보다 높은 경우 상위 임곗값에 연결된 경우만 가장자리 픽셀로 간주
            //상위 임곗값이 200, 하위 임곗값이 100일 겨우 100이하의 픽셀 모두 제거. 200 이상의 값을 하나라도 포함하고 있는 100 이상의 모든 픽셀은 가장자리로 간주
            //소벨 연산에 기반을 두고 있기 떄문에 소벨 연산자 마스크 크기(apertureSize)를 설정
            //L2 그레디언트(기울기)는 L2-norm으로 방향성 그레디언트를 정확하게 계산할지, 정확성은 떨어지지만 속도가 더 빠른 L1-norm으로 계산할지 선택
            //Cv2.Canny(원본, 결과, 하위 임곗값, 상위 임곗값, 소벨 연산자 크기, L2 그레디언트)
            Cv2.Canny(blur, canny, 100, 200, 3, true);
            //Mat canny2 = new Mat();
            //Cv2.Canny(blur, canny2, 100, 200, 3, false);
            //Cv2.ImShow("Canny2",canny2);


            Cv2.ImShow("sobel", sobel);
            Cv2.ImShow("scharr", scharr);
            Cv2.ImShow("laplacian", laplacian);
            Cv2.ImShow("canny", canny);
            Cv2.WaitKey(0);
        }
    }
}
