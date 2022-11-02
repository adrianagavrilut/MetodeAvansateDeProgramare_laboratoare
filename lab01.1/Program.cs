using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ex01();
            //Ex02();
            //Ex03();
            //Ex03v2();
            //Ex04();

        }

        private static void Ex03v2()
        {
            //vf n prim - cel mai ineficient
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            bool ok = true;
            for (int d = 2; d < n; d++)
            {
                if (n % d == 0)
                {
                    ok = false;
                }
            }
            if (ok)
            {
                Console.WriteLine(" Numarul este prim");
            }
            else
            {
                Console.WriteLine("Numarul nu este prim");
            }
        }

        private static void Ex04()
        {
            //descompuneti n in factori primi
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int x = n;
            Console.Write("{0} = ", n);
            for (int d = 2; d <= x; d++)
            {
                if (x % d == 0)
                {
                    int p = 0;
                    while (x % d == 0)
                    {
                        p++;
                        x /= d;
                    }
                    Console.Write("{0}^{1} * ", d, p);
                }
            }
            Console.WriteLine("1");
        }

        private static void Ex03()
        {
            //vf n prim
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            bool ok = true;
            if (n < 2) ok = false;
            if (n == 2) ok =  true;
            if (n % 2 == 0) ok =  false;
            for (int i = 3; i * i <= n; i+=2)
            {
                if(n % i == 0)
                {
                    ok =  false;
                }
            }
            if (ok)
            {
                Console.WriteLine(" Numarul este prim");
            }
            else
            {
                Console.WriteLine("Numarul nu este prim");
            }
        }

        private static void Ex02()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int oglindit = 0;
            int c1, c2, ma;
            while (n > 9)
            {
                c1 = n % 10;
                n /= 10;
                c2 = n % 10;
                ma = (c1 + c2) / 2;
                oglindit = oglindit * 10 + c1;
                oglindit = oglindit * 10 + ma;
            }
            while (oglindit > 0)
            {
                int c = oglindit % 10;
                oglindit /= 10;
                n = n * 10 + c;
            }
            Console.WriteLine("Rezultat : " + n);
            Console.ReadKey();
        }

        private static void Ex01()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int oglindit = 0;
            while (n > 0)
            {
                int c = n % 10;
                n /= 10;
                if (c % 2 != 0)
                {
                    oglindit = oglindit * 10 + c;
                }
            }
            while (oglindit > 0)
            {
                int c = oglindit % 10;
                oglindit /= 10;
                n = n * 10 + c;
            }
            Console.WriteLine("Rezultat : " + n);
        }
    }
}
