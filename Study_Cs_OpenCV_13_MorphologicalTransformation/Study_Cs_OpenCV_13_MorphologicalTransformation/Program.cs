using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Study_Cs_OpenCV_13_MorphologicalTransformation
{
    class Program
    {
        static void Main(string[] args)
        {
            //모폴로지 변환은 영상이나 이미지를 형태학적 관점에서 접근하는 기법
            //주로 영상 내 픽셀값 대체에 사용. 이를 응용하여 노이즈 제거, 요소 결합 및 분리, 강도 피크 검출등에 이용
            //집합의 포함 관계, 이동(translation), 대칭(reflection), 여집합(complemet), 차집합(difference)등의 성질 이용

            //팽창(Dilation)은 커널 영역 안에 존재하는 모든 픽셀의 값을 커널 내부의 극댓값(local maximum)으로 대체
            //구조 요소(element)를 왈용해 이웃한 픽셀들을 최대 픽셀값으로 대체
            //팽창 연산을 적용하면 어두운 영역이 줄어들고 밝은 영역이 늘어남
            //커널의 크기나 반복 횟수에 따라 밝은 영역이 늘어나 스펙클(Speckle)이 커지며 객체 내부의 홀이 사라짐
            //팽창 연산은 노이즈 제거 후 줄어든 크기를 복구하고자 할 떄 주로 사용
            /*dilate(x,y) = max src(x+i, y+j)*/

            //침식(Erosion)은 커널 영역 안에 존재하는 모든 픽셀의 값은 커널 내부의 극솟값으로 대체
            //구조 요소를 활용해 이웃한 픽셀을 최소 픽셀값으로 대체
            //침식 연산을 적용하면 밝은 영역이 줄어들고 어두운 영역이 늘어남
            //커널의 크기나 반복 횟수에 따라 어두운 영역이 늘어나 스펙클이 사라지며, 객체 내부의 홀이 커짐
            //침식 연산은 주로 노이즈 제거에 사용
            /*erodc(x,y) = min src(x+i, y+j)*/
            Mat src = new Mat("..\\..\\..\\..\\nape.jpg");
            Mat dilate = new Mat();
            Mat erode = new Mat();
            Mat dst = new Mat();
            
            //모폴로지 연산을 진행하기 위한 구조요소 생성
            //구조 요소 생성 함수(CV2.GetStructuringElement)는 커널의 형태(Shape)와 커널의 크기(size), 고정점(anchor)를 설정
            //커널의 형태는 직사각형(rect), 십자가(Cross), 타원(Ellipse)가 있음
            //커널의 크기는 구조 요소의 크기를 의미. 너무 작다면 커널의 형태는 영향을 받지 않음
            //고정점은 커널의 중심 위치를 나타냄. 필수 매개변수가 아니며, 설정하지 않을 경우 사용되는 함수에서 값이 결정
            //고정점을 할당하지 않을 경우 조금 더 유동적인 커널이 됨
            //Cv2.GetPerspectiveTransform(커널의 형태, 커널의 크기, 중심점)
            Mat element = Cv2.GetStructuringElement(MorphShapes.Cross, new Size(5, 5));
            //생성된 구조 요소를 활용해 모폴로지 변환을 적용
            //팽창 함수(Cv2.Dilate)와 침식 함수(Cv2.Erode)로 모폴로지 변환 진행
            //Cv2.Dilate(원본, 결과, 구조, 고정점, 반복 횟수, 테두리 외삽법, 테두리 색상)
            //Cv2.ErodE(원본, 결과, 구조, 고정점, 반복 횟수, 테두리 외삽법, 테두리 색상)
            //고정점을 (-1,-1)로 할당할 경우, 커널의 중심부에 고정점이 위치
            Cv2.Dilate(src, dilate, element, new Point(2, 2), 3);
            Cv2.Erode(src, erode, element, new Point(-1, -1), 3);

            //수평 연결 함수(CV2.HConcat)로 팽창 결과와 침식 결과를 하나의 이미지로 연결
            //Cv2.HConcat(연결할 이미지 배열들, 결과 배열)
            //수직 방향은 수직 연결 함수(Cv2.VConcat)으로 연결 가능
            Cv2.HConcat(new Mat[] { dilate, erode }, dst);
            //Cv2.VConcat(new Mat[] { dilate, erode }, dst);
            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
        }
    }
}
