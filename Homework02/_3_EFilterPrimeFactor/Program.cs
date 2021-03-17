using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_EPrimeFactor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入上限n:");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] prime = new int[n + 1];
            int[] visit = new int[n + 1];
            //准备完毕
            for (int i = 2; i <= n; i++)
                if (visit[i] == 0)
                {
                    prime[++prime[0]] = i;//记录素数和个数
                    for (int j = 2 * i; j <= n; j += i)
                        visit[j] = 1;     //剔除该素数的所有倍数
                }
            
            int num = 0;
            for (int i = 1; i <= prime[0]; i++)
                Console.Write(prime[i] + (++num % 10 == 0 ? "\n" : " "));

        }
    }
}

/* 欧拉筛选法，在埃氏筛选法的基础上，只用一个合数的最小素因子筛去它
static void Prime(int n, int[] prime, int[] visit)
{
    for (int i = 2; i <= n; i++)
    {
        if (visit[i] == 0) // 0为素数，1为偶数
            prime[++prime[0]] = i;      //纪录素数， 这个prime[0] 存储素数的总个数          
        for (int j = 1; j <= prime[0] && i * prime[j] <= n; j++)
        {
            visit[i * prime[j]] = 1;
            if (i % prime[j] == 0)
                break;
        }
    }
}
*/
