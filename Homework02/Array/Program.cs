using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayPro
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("请输入一个整数数组(以空格隔开):");
                    int[] li = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    process(li);
                }
                catch(Exception e)
                {
                    break;
                }
            }
        }

        static void process(int[] li)
        {
            int length = li.Length;
            if (length == 0)
                return;

            int minN = li[0], maxN = li[0], totalN = li[0];
            
            for (int i = 1; i < length; i++)
            {
                minN = Math.Min(minN, li[i]);
                maxN = Math.Max(maxN, li[i]);
                totalN += li[i];
            }

            double average = Convert.ToDouble(totalN) / length;
            Console.WriteLine($"该数组的最大值为: {maxN}\n" + 
                $"\t最小值为: {minN}\n" + 
                $"\t平均值为: {average}\n" + 
                $"\t元素和为: {totalN}\n");
        }
    }
}
