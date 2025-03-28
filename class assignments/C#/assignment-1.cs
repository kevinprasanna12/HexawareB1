using System.Buffers;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //1.
            Console.WriteLine("enter the inputs :");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{a} and {b} are equal");
            //2
            checkpositive();
            //3
            opertaions();
            //4
            multi_table();
            //5
            two_sum(); 
        }

        public static void checkpositive()
        {
            Console.WriteLine("Enter the value :");
            int num = Convert.ToInt32(Console.ReadLine());
            string? result = null;
            if (num > 0)
            {
                result = "positive";
            }
            else if (num < 0)
            {
                result = "negative";
            }
            else
            {
                result = "neither negative nor positive";
            }
            Console.WriteLine($"{num} is {result}");
        }
        public static void opertaions()
        {
            Console.WriteLine("Input first number : ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the operation");
            char op = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Enter the second number : ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int result;

            if (op == '+')

                result = num1 + num2;

            else if (op == '-')
                result = num1 - num2;

            else if (op == '*')
                result = num1 * num2;

            else if (op == '/')
                result = num1 / num2;

            else
                result = 0;

            Console.WriteLine($"{num1}{op}{num2} = {result}");

        }
        public static void multi_table()
        {
            Console.WriteLine("Enter the input");
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine($"{num} * {i} = {num*i}");
            }
        }
        public static void two_sum()
        {
            Console.WriteLine("enter the input 1 : ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the input 2 : ");
            int num2 = Convert.ToInt32 (Console.ReadLine());
            if (num1 != num2)
                Console.WriteLine($"sum is {num1 + num2}");
            else
                Console.WriteLine($"result is {num1 + num1 + num1}");
        }
    }
    
}

