using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Study_Cs_OpenCV_06_ContoursDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            //가장자리 검출은 검출된 객체들의 세그먼트 구성 요소가 구분돼 있지 않아 어떤 형태인지 파악 불가
            //윤곽선 검출은 전처리가 진행된 이미지에서 가장자리로 검출된 픽셀을 대상으로 세그먼테이션 작업을 진행
            //따라서, 윤곽선 검출 알고리즘은 검출된 객체들을 값으로 반환해 사용 가능
            //세그먼트(Segment)는 서로 다른 두 점을 연결하는 가장 짧은 선
            //세그먼테이션(Segmentation)은 이미지에서 각각의 픽셀들을 분류해 그룹화 하는것

            Mat src = new Mat("cat.jpg");
            Mat yellow = new Mat(); //전처리 결과 저장 공간
            Mat dst = src.Clone();

            //윤곽선 검출 알고리즘은 윤곽선의 실제 값이 저장될 contours와 그 윤곽선들의 계층 구조를 저장할 hierarchy를 선언
            //contours는 Point 형식의 2차원 배열, hierarchy는 HierarchyIndex 형식의 1차원 배열
            //contours의 차원구조는 점 좌표(x,y)의 묶음과 그 좌표들을 한 번 더 묶는 구조
            //좌표를 저장하기 위해서 Point 형식. 좌표들을 하나로 묶어 윤곽선을 구성하기 위해 Point[]
            //이후, 윤곽선은 n개 이상 발생 가능하므로 Point[]를 묶는 Point[][]
            Point[][] contours;
            //hierarchy에는 현재 노드의 정보가 담겨있음
            //다음 윤곽선, 이전 윤곽선, 자식 노드, 부모 노드가 담겨있음
            //자식 노드는 자기 자신 안쪽에 있는 윤곽선
            //부모 노드는 자기 자신 바깥쪽에 있는 윤곽선
            HierarchyIndex[] hierarchy;

            //연산량을 줄이고 정확성을 높이기 위해 간단한 전처리(배열 요소의 범위 설정 함수)를 적용
            //CV2.InRage(원본, 범위, 범위, 전처리 결과)
            Cv2.InRange(src, new Scalar(0, 0, 0), new Scalar(70, 255, 255), yellow);
            //윤곽선 검출 함수는 객체의 구조를 판단하는데 가장 많이 사용되는 알고리즘
            //검출된 윤곽선은 out 키워드를 활용해 함수에서 검출된 윤곽선 저장
            //계층 구조는 out 키워드를 활용하여 함수에서 검출된 계층구조 저장
            //검색 방법은 윤곽선을 검출해 어떤 계층 구조의 형태를 사용할지 설정
            //근사 방법은 윤곽점의 근사법을 설정. 근사 방법에 따라 검출된 윤곽선에 포함될 좌표의 수나 정교함으 수준이 달라짐
            //오프셋은 반환된 윤곽점들의 좌푯값에 이동할 값을 설정. 일반적으로 잘 사용 X
            //Cv2.FindContours(원본, 검출된 윤곽선, 계층 구조, 검색 방법, 근사 방법, 오프셋)
            Cv2.FindContours(yellow, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);
            
            //간단하게 불필요한 윤곽선을 제거하기 위해, List 형식의 Point[] 배열 선언
            //List를 사용하기 위해 네임스페이스에 using System>Colletcions.Genericl; 추가
            //new_contours 변수에 일정 조건 이상의 윤곽선만 포함
            List<Point[]> new_contours = new List<Point[]>();
            //검출된 윤곽선의 값(contours)을 검사하고, 윤곽선 길이 함수(Cv2.ArchLength)를 활용해 length가 100 이상의 값만 추출
            foreach (Point[] p in contours)
            {
                double length = Cv2.ArcLength(p, true);
                if (length > 10)
                {
                    new_contours.Add(p);
                }
            }

            //윤곽선 그리기 함수(Cv2.DrawContours)는 윤곽선을 간단하게 그려볼 수있음
            //윤곽선 번호는 지정된 윤곽선만 그릴 수 있음. 윤곽선 번호의 값을 -1로 두면, 모든 윤곽선 그림
            //계층 구조는 윤곽선 검출 함수에서 반환된 계층 구조
            //계층 구조 최대 레벨은 그려질 계층 구조의 깊이를 설정. 계층 구조 최대 레벨을 0으로 설정할 경우, 최상위 레벨만 그려짐
            //현재 새로운 윤곽선을 구성하였으므로, 계층 구조가 맞지 않으니 null 사용
            //마찬가지로 계층 구조가 존재하지 않으니 최대 레벨을 0 이상의 값으로 사용
            //Cv2.DrawContours(결과, 검출된 윤곽선, 윤곽선 번호, 색상, 두께, 선형 타입, 계층 구조, 계층 구조 최대 레벨)
            Cv2.DrawContours(dst, new_contours, -1, new Scalar(255, 0, 0), 2, LineTypes.AntiAlias, null, 1);
            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
        }
    }
}
