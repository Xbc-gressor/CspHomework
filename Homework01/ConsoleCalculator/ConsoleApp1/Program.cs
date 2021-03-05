using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            while(true)
            {
                try
                {
                    // 输入两个操作数，一行一个
                    Console.WriteLine("Enter two operands(one per line):");
                    double o1 = double.Parse(Console.ReadLine());
                    double o2 = double.Parse(Console.ReadLine());
                    // 输入操作符
                    Console.WriteLine("Enter the operator:");
                    string operator_ = Console.ReadLine();
                    double answer = 0;
                    switch (operator_)
                    {
                        case "+": answer = o1 + o2; break;
                        case "-": answer = o1 - o2; break;
                        case "*": answer = o1 * o2; break;
                        case "/": answer = o1 / o2; break;
                        case "^": answer = Math.Pow(o1, o2); break;
                        default : throw new ArgumentOutOfRangeException();
                    }
                    Console.WriteLine($"The answer is: {o1} {operator_} {o2} = {answer}");
                }catch(Exception e)
                {
                    Console.WriteLine("错误信息为:" +e);
                }

                Console.WriteLine("Continue? (y/n):");
                char k = (char)Console.Read();
                if (k == 'n')
                    break;
                string temp = Console.ReadLine();
            }

            Console.Write("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}
