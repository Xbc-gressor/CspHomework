using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    返回一个整数n的所有素数因子
 */
namespace _3_EratoPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入整数n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n{n}的所有素数因子为:");
            
            while(n > 1)
            {
                for(int prime = 2; ; prime++)
                {
                    if(isPrime(prime) && n % prime==0)
                    {
                        while(n % prime == 0) // 把n中所有的该素数因子都除掉
                            n /= prime;
                        Console.Write(prime + " ");
                    }
                }
            }

        }

        static bool isPrime(int n)
        {
            if (n < 2)
                return false;

            for (int i = 2; i <= Convert.ToInt32(Math.Sqrt(n)); i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }


    }
}
