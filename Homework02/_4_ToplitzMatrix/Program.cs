using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_ToplitzMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,]{{ 1, 2, 3, 4 },{ 5, 1, 2, 3 },{ 9, 5, 1, 2 }};

            Console.WriteLine(isToplitz(matrix));
        }

        static bool isToplitz(int[,] matrix)
        {
            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N && i*j==0; j++)
                {
                    int val = matrix[i,j];
                    int a = i, b = j;
                    while (++a < M && ++b < N)
                        if (matrix[a,b] != val)
                            return false;
                }
            }
            return true;
        }
    }
}
