using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Study_Cs_OpenCV_03_ImageCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            //이진화
            //영상이나 이미지의 어느 지점을 기준으로 픽셀을 분류해 제외하는 것
            //특정 값을 기준으로 값이 높거나 낮은 픽셀을 검은색 또는 흰색의 값으로 변경
            //기준값에 따라 이분법적으로 구분해 픽셀을 참 또는 거짓으로 나누는 연산
            Mat src = new Mat("cat.jpg");
            Mat gray = new Mat(); // src를 그레이스케일로 변화시켜 단일 채널로 변경하기 위한 공간
            Mat binary = new Mat(); //이진화된 이미지가 저장될 공간. dst

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);//색상 이미지에서 흑백 이미지로 변환
            //Cv2.Threshold를 통해 이미지 이진화
            //Cv2.Threshold(원본, 결과, 임곘값, 최댓값, 입곗값 형식)
            //임곗값 형식에 따라 이진화 방식 설정
            //임곗값보다 낮은 픽셀값은 0이나 원본 픽셀값으로 변경하며, 임곘값보다 높은 픽셀값은 최댓값으로 변경
            Cv2.Threshold(gray, binary, 150, 255, ThresholdTypes.Binary);

            Cv2.ImShow("src", src);
            Cv2.ImShow("dst", binary);
            Cv2.WaitKey(0);

            Cv2.DestroyAllWindows();
            //이미지 연산(1)
            //이미지 연산이란 하나 또는 둘 이상의 이미지에 대한 수학적 연산을 수행
            //Mat 클래스의 행렬 연산은 C# OpenCvSharp의 대수적 표현을 통해서도 Mat 클래스 간의 연산을 수행 가능
            src = new Mat("cat.jpg", ImreadModes.ReducedColor2);
            Mat val = new Mat(src.Size(), MatType.CV_8UC3, new Scalar(0, 0, 30)); // 이미지 연산을 위한 값. B:0, G:0, R:30으로 행렬 연산
            //연산을 위한 이미지는 src와 이미지 크기, 데이터 타입, 깊이가 모두 일치해야 한다.

            //연산 결과를 저장할 공간. 대부분의 이미지 연산 관련 함수는 반환 형식을 void로 가진다. 즉, 메모리 공간에 미리 할당된다.
            Mat add = new Mat();
            Mat sub = new Mat();
            Mat mul = new Mat();
            Mat div = new Mat();
            Mat max = new Mat();
            Mat min = new Mat();
            Mat abs = new Mat();
            Mat absdiff = new Mat();

            //Cv2.Add(원본 배열1, 원본 배열2, 결과 배열, 마스크, 반환형식)
            //마스크가 null이 아닌 경우, 마스크의 요솟값이 0이 아닌 곳만 연산을 진행
            Cv2.Add(src, val, add); // 배열과 배열 또는, 배열과 스칼라의 요소별 합 계산 // dst = src1 + src2;

            //Cv2.Subtract(원본 배열1, 원본 배열2, 결과 배열, 마스크, 반환형식)
            //마스크가 null이 아닌 경우, 마스크의 요솟값이 0이 아닌 곳만 연산을 진행
            //src1과 src2의 위치에 따라 결과가 달라지므로 배열 순서 유의
            Cv2.Subtract(src, val, sub); // 배열과 배열 또는, 배열과 스칼라의 요소별 차 계산

            //Cv2.Multiply(원본 배열1, 원본 배열2, 결과 배열, 비율, 반환형식)
            //비율이 null이 아닌 경우, 연산에 비율 값을 추가로 곱함
            Cv2.Multiply(src, val, mul);

            //Cv2.Divide(원본 배열1, 원본 배열2, 결과 배열, 비율, 반환 형식)
            //비율이 null이 아닌 경우, 연산에 비율 값을 추가로 곱함
            Cv2.Divide(src, val, div);

            //Cv2.Max(원본 배열1, 원본 배열2, 결과 배열)
            //두 배열의 요소 중 최댓값인 값으로 결과 배열의 요솟값이 할당
            Cv2.Max(src, mul, max);

            //Cv2.Min(원본 배열1, 원본 배열2, 결과 배열)
            //두 배열의 요소 중 최솟값인 값으로 결과 배열의 요솟값이 할당
            Cv2.Min(src, mul, min);

            //Cv2.Abs(원본 배열)로 배열의 요소별 절댓값 계산
            //절댓값 함수는 반환 형식이 행렬 표현식(MatExpr 클래스)이며, 매개변수로도 활용할 수 있어 특수한 경우 적절한 연산을 수행할 수 있다.
            abs = Cv2.Abs(mul);

            //Cv2.Absdiff(원본 배열1, 원본 배열2, 결과 배열)로 절댓값 차이를 적용
            //덧셈이나 뺄셈 함수에서는 두 배열의 요소의 결과가 음수가 발생하면 0을 반환
            //절댓값 차이 함수는 이 값을 절댓값으로 변경해서 양수 형태로 반환
            Cv2.Absdiff(src, mul, absdiff);

            Cv2.ImShow("src", src);
            Cv2.ImShow("add", add);
            Cv2.ImShow("sub", sub);
            Cv2.ImShow("mul", mul);
            Cv2.ImShow("div", div);
            Cv2.ImShow("max", max);
            Cv2.ImShow("min", min);
            Cv2.ImShow("abs", abs);
            Cv2.ImShow("absdiff", absdiff);
            Cv2.WaitKey(0);

            Cv2.DestroyAllWindows();
            //이미지 연산(2)
            //하나 또는 둘 이상의 이미지에 대한 비트 연산 또는 비교 연산을 수행
            //Mat 클래스의 행렬 연산은 C#OpenCvSharp의 비트 연산 표현을 통해서도 Mat 클래스 간의 연산을 수행 가능
            //OpenCvSharp에서는 비교 연산 표현을 지원하지 않음

            Mat src1 = new Mat("cat.jpg", ImreadModes.ReducedColor2);
            Mat src2 = src1.Flip(FlipMode.Y);

            Mat and = new Mat();
            Mat or = new Mat();
            Mat xor = new Mat();
            Mat not = new Mat();
            Mat compare = new Mat();

            //Cv2.BitwiseAnd(원본 배열1, 원본 배열2, 결과 배열)로 논리곱 적용
            //src1의 픽셀 값이 (243, 243, 243)이고, src2의 픽셀값이 (249, 249, 249)라면 and 픽셀값은 (241, 241, 241)이 됨
            //243의 비트값은 11110011
            //249의 비트값은 11111001
            //241의 비트값은 11110001
            Cv2.BitwiseAnd(src1, src2, and);

            //Cv2.BitwiseOr(원본 배열 1, 원본 배열 2, 결과 배열)로 논리곱 적용
            Cv2.BitwiseOr(src1, src2, or);

            //Cv2.BitwiseXor(원본 배열 1, 원본 배열 2, 결과 배열)로 배타적 논리합 적용
            Cv2.BitwiseXor(src1, src2, xor);

            //Cv2.BitwiseNot(원본 배열, 결과 배열)로 배타적 논리 부정 적용
            Cv2.BitwiseNot(src1, not);

            //Cv2.Compare(원본 배열 1, 원본 배열 2, 결과 배열, 비교 플래그)로 비교 적용
            //src1의 픽셀값이 (245, 245, 245)이고, src2의 픽셀값이 (245, 244, 246)라면, compare 픽셀값은 (255, 0, 0)
            //비교 함수의 결과값은 조건에 부합하면 255, 아니라면 0
            Cv2.Compare(src1, src2, compare, CmpType.EQ);

            Cv2.ImShow("and", and);
            Cv2.ImShow("or", or);
            Cv2.ImShow("xor", xor);
            Cv2.ImShow("not", not);
            Cv2.ImShow("compare", compare);
            Cv2.WaitKey(0);

            Cv2.DestroyAllWindows();
        }
    }
}
