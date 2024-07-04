using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Cs_05
{
    class Program
    {
        static void Main(string[] args)
        {
            //배열리스트. 자료형이 달라도 되는 리스트
            Console.WriteLine("배열 리스트");
            ArrayList al = new ArrayList();

            al.Add(1);
            al.Add("Hello");
            al.Add(3.3);
            al.Add(true);

            foreach(var item in al)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            al.Remove("Hello");

            foreach(var item in al)
            {
                Console.WriteLine(item);
            }

            //큐 FIFO
            Console.WriteLine("\n큐");
            Queue qu = new Queue();

            qu.Enqueue(1);
            qu.Enqueue(2);
            qu.Enqueue(3);

            while (qu.Count > 0)
            {
                Console.WriteLine(qu.Dequeue());
            }

            //스택 LIFO
            Console.WriteLine("\n스택");
            Stack st = new Stack();

            st.Push(1);
            st.Push(2);
            st.Push(3);

            while (st.Count > 0)
            {
                Console.WriteLine(st.Pop());
            }

            //해시테이블 Key-Value
            Console.WriteLine("\n해시테이블");
        }
    }
}
