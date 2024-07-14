using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Study_Cs_OpenCV_04_Blur
{
    class Program
    {
        static void Main(string[] args)
        {
            //흐림 효과
            //블러링(Blurring) 또는 스무딩(Smoothing)이라 불리며, 노이즈를 줄이거나 외부 영향 최소화 하는 데 사용
            //단순히 이미지를 흐리게 만드는 것 뿐만 아니라 노이즈를 제거해서 연산 시 계산을 빠르고 정확하게 수행

            //커널은 이미지에서 (x,y)의 픽셀과 (x,y) 픽셀 주변을 포한한 작은 크기의 공간을 의미
            //이 영역 각 픽셀에 특정한 수식이나 함수등을 적용해 새로운 이미지를 얻는 알고리즘에서 사용

            //고정점(Anchor Point)은 커널을 통해 컨벌루션(합성곱)된 값을 할당한 지점
            //컨벌루션(Convolution)은 새로운 픽셀을 만들어 내기 위해 커널 크기의 화소 값을 이용해 어떤 시스템을 통과해 계산하는 것을 의미
            //커널 내에서 고정점은 하나의 지점만을 가지며, 이미지와 어떻게 정렬되는지를 나타냄

            //테두리 외삽법(Border Extrapolation)은 컨벌루션을 적용할 때, 이미지 가장자리 부분의 처리 방식
            //컨벌루션을 적용하면 이미지 가장자리 부분은 계산이 불가능 -> 테두리의 이미지 바깥쪽에 가상의 픽셀을 만들어 처리
            //가상 픽셀의 값을 0으로 처리하거나, 임의의 값을 할당하거나, 커널이 연산할 수 있는 부분부터 연산을 수행

            Mat src = new Mat("cat.jpg");
            Mat blur = new Mat();
            Mat box_filter = new Mat();
            Mat median_blur = new Mat();
            Mat gaussian_blur = new Mat();
            Mat bilateral_filter = new Mat();

            //단순 흐림 효과 함수는 각 픽셀에 대해 커널을 적용해 모든 픽셀의 단순 평균을 구함
            //Cv2.Blur(원본, 결과, 커널, 고정점, 테두리 외삽법)
            //고정점의 위치가 (-1,-1)일 경우, 고정점이 중앙에 위치
            Cv2.Blur(src, blur, new Size(9, 9), new Point(-1, -1), BorderTypes.Default);
            //박스 필터 흐림 효과 함수는 커널의 내부 값이 모두 같은 값으로 값을 구함
            //CV2.BoxFilter(원본, 결과, 결과 배열 정밀도, 커널, 고정점, bool nomalize, 테두리 외삽법)
            //결과 배열 정밀도를 MatType.CV_64FC3로 할당할 경우, 64비트 double 형식의 배열로 반환
            Cv2.BoxFilter(src, box_filter, MatType.CV_8UC3, new Size(9, 9), new Point(-1, -1), true, BorderTypes.Default);
            //중간값 흐림 효과 함수는 고정점을 사용하지 않고 중심 픽셀 주변으로 사각형 크기(ksize X Ksize)의 이웃한 픽셀들의 중간값을 사용해 각 픽셀의 값을 변경
            //Cv2.MedianBlur(원본, 결과, 커널 크기)
            //커널 크기는 int 형식을 사용하며, 홀수만 가능
            Cv2.MedianBlur(src, median_blur, 9);
            //가우시안 흐림 효과 함수는 이미지의 각 지점에 가우시안 커널을 적용해 합산한 후에 출력 이미지를 반환
            //가우시안 필터란 대상점과 가까운 픽셀이 번 픽셀보다 더 연관이 있다는 사실을 반영하여 가까운 픽셀에 더 많은 가중치를 준 것
            //표준편차(σ)가 클 수록 대상점과 멀어질 때 값이 작아지는 정도가 커짐 = 블러링 효과가 커짐
            //Cv2.GaussianBlur(원본, 결과, 커널, X 방향 표준편차, Y 방퍙 표준편차, 테두리 외삽법)
            //X방향 표준편차가 0인 경우, Y방향 표준편차의 값은 X방향 표준편차의 값과 같아짐
            //전부 0으로 설정시, 커널 크기를 고려하여 자동 설정됨
            Cv2.GaussianBlur(src, gaussian_blur, new Size(9, 9), 1, 1, BorderTypes.Default);
            //양방향 필터 흐림 효과 함수는 가장자리(Edge)를 선명하게 보존하면서 노이즈를 우수하게 제거하는 흐림 효과 함수
            //Cv2.BilateralFilter(원본, 결과, 지름, 시그마 색상, 시그마 공간, 테두리 외삽법)
            //지름은 흐림 효과를 적용할 각 픽셀 영역의 지름
            //시그마 색상은 색상 공간에서 사용할 가우시안 커널의 너비를 설정. 매개변수의 값이 클 수록 흐림 효과에 포함될 강도의 범위 넓어짐
            //시그마 공간은 좌표 공간에서 사용될 가우시안 커널의 너비를 설정. 값이 클 수록 인접한 픽셀에 영향을 미침
            Cv2.BilateralFilter(src, bilateral_filter, 9, 3, 3, BorderTypes.Default);

            //Mat bilateral_filter2 = new Mat();
            //Mat gaussian_blur2 = new Mat();
            //Cv2.GaussianBlur(src, gaussian_blur2, new Size(9, 9), 10, 1, BorderTypes.Default);
            //Cv2.BilateralFilter(src, bilateral_filter2, 9, 30, 3, BorderTypes.Default);
            //Cv2.ImShow("gaussian_blur2", gaussian_blur2);
            //Cv2.ImShow("bilateral_filter2", bilateral_filter2);


            Cv2.ImShow("src", src);
            Cv2.ImShow("blur", blur);
            Cv2.ImShow("box_filter", box_filter);
            Cv2.ImShow("median_blur", median_blur);
            Cv2.ImShow("gaussian_blur", gaussian_blur);
            Cv2.ImShow("bilateral_filter", bilateral_filter);
            Cv2.WaitKey(0);
        }
    }
}
