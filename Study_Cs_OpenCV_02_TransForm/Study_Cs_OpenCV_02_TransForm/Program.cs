using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Study_Cs_OpenCV_02_TransForm
{
    class Program
    {
        static void Main(string[] args)
        {
            //색상 공간 변환
            //색상 공간 변환 함수는 데이터 타입을 같게 유지하고 채널을 변환함
            Mat src = Cv2.ImRead("cat.jpg"); // 원본
            Mat dst = new Mat(src.Size(), MatType.CV_8UC1); // 변환된 이미지가 저장될 공간. 3채널 이미지에서 1채널 이미지로 변환할 예정이므로 단일 채널 사용
            //Cv2.CvtColor(원본, 걀과, 색상변환코드)
            //단일 채널로부터 3채널, 4채널의 색상 공간으로도 변환 가능
            //단, 그레이스케일 변환은 다중 채널에서 단일 채널로 변환하기 떄문에 dst의 채널 수는 1이어야 함
            Cv2.CvtColor(src, dst, ColorConversionCodes.BGR2GRAY);

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();

            //대칭
            //2차원 유클리드 공간에서의 기하학적인 변환의 하나로 R^2(2차원 유클리드 공간) 위의 선형 변환을 진행한다.
            //대칭은 변환할 행렬(이미지)에 대해 2X2 행렬을 왼쪽 곱셈함
            dst = new Mat(src.Size(), MatType.CV_8UC3);
            //Cv2.Flip(원본, 결과, 태칭 축)으로 색상 공간을 변환
            Cv2.Flip(src, dst, FlipMode.Y);

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();

            //확대 & 축소
            src = new Mat("cat.jpg", ImreadModes.ReducedColor2);
            Mat pyrUp = new Mat(); // 확대 이미지 저장 변수
            Mat pyrDown = new Mat(); //축소 이미지 저장 변수

            //Cv2.Pyr*(원본 이미지, 결과 이미지, 결과 이미지 크기, 테두리 외삽법)으로 이미지 크기 변환
            //걀과 이미지 크기는 매개변수에 직접 인수를 할당해서 (업/다운)샘플링을 수행 가능
            //테두리 외삽법은 확대 또는 축소할 경우, 영역 밖의 픽셀은 추정해서 값을 할당
            //이미지 밖의 픽셀을 외삽하는데 사용되는 테두리 모드. 외삽 방식 설정
            Cv2.PyrUp(src, pyrUp);
            Cv2.PyrDown(src, pyrDown);
            Cv2.ImShow("pyrUp", pyrUp);
            Cv2.ImShow("pyrDown", pyrDown);
            Cv2.WaitKey(0);

            //크기 조절
            //Cv2.Resize*(원본, 결과, 절대 크기, 상대 크기(X), 상대 크기(Y), 보간법)으로 이미지 크기 변환
            //이미지 크기 조절 시, 절대 크기 또는 상대 크기를 사용해 이미지의 크기 조절
            //절대 크기는 Size 구조체로 크기 설정 가능
            //절대 크기는 필수 매개변수이며, 상대 크기는 선택 매개변수
            //아래는 절대 크기로 변환
            Cv2.Resize(src, dst, new Size(500, 250));
            //아래는 상대 크기로 변환
            //절대 크기의 Size 구조체의 값 중 하나 이상은 0의 값을 사용해야 상대 크기의 값으로 인식
            Cv2.Resize(src, dst, new Size(0, 0), 0.5, 0.5);
            //보간법은 기본값으로 쌍 선형 보간법으로 할당
            //보간법은 테두리 외삽법과 같은 속성을 가짐
            Cv2.ImShow("src", src);
            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);

            //자르기
            //이미지를 자르는 것을 관심 영역 지정 또는 하위 행렬 생성이라 부름
            //특정 영역에 대해서 작업하기 떄문에 관심 영역이라 부르며, 이미지는 행렬이므로 특정 부분을 잘라내기 떄문에 하위 행렬이라 부름
            src = new Mat("cat.jpg");
            dst = src.SubMat(new Rect(300, 300, 500, 300)); //하위 행렬 매서드(*.SubMat)을 활용해 하위 행렬을 생성
            //*.SubMat()은 Range 구조체, Rect 구조체, int 할당 등을 통해 생성 가능.
            //예제는 int 방식

            //다른 방식으로, Mat 클래스를 생성해서 영역을 복사하는 방법과 영역 설정 방법기 있음
            //모두 동일하게 영역을 잘라내며, 하위 행렬 메서드와 마찬가지로 Range 구조체, Rect 구조체, int 할당 등을 통해 생성 가능
            Mat roi1 = new Mat(src, new Rect(300, 300, 100, 100));
            Mat roi2 = src[0, 100, 0, 100];

            Cv2.ImShow("src", src);
            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);

        }
    }
}
