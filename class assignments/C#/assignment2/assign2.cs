using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_pro
{
    internal class assign2
    {
        public void swapnum()
        {
            Console.WriteLine("Enter inputs");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"before swap a={a} , b={b}");
            (a, b) = (b, a);
            Console.WriteLine($"after swap a={a} , b={b}");
        }
        public void Four_value_num()
        {
            Console.WriteLine("enter input");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0} {0} {0} {0}",num);
            Console.WriteLine("{0}{0}{0}{0}", num);
        }

    }
}
