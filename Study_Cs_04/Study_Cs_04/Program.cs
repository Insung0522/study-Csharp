using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Cs_04
{
    class Program
    {
        static void Main(string[] args)
        {
            //배열을 사용하는 방법 3가지
            int[] array1 = new int[3];
            array1[0] = 10;
            array1[1] = 20;
            array1[2] = 30;
            for (int i = 0; i < 3; i++) {
                Console.WriteLine(array1[i]);
            }

            int[] array2 = new int[] { 1, 2, 3 };
            for (int i = 0; i < array2.Length; i++)
            {
                Console.WriteLine(array2[i]);
            }
            int[] array3 = { 4, 5, 6 };

            foreach (int i in array3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
