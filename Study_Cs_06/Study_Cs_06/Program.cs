using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Cs_06
{
    class Program
    {
        static void Main(string[] args)
        {
            //예외처리
            Console.Write("나눌 숫자를 입력하세요 : ");
            //ReadLine은 문자열로 읽어옴    
            //int.Parse로 자료형을 바꾸어주어야 함
            int divider = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine(10 / divider);
            }
            catch
            {
                Console.WriteLine("0으로 나눌 수 없습니다");
            }

            try
            {
                Console.WriteLine(100 / divider);
            }
            catch(Exception e)
            {
                Console.WriteLine("예외 : " + e.Message);
            }
        }
    }
}
