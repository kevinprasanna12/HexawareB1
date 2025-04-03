using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace sample_3
{
    internal class Strings
    {
        public string str;

        public void Get_string()
        {
            Console.WriteLine("Enter input");
            str = Console.ReadLine();
        }

        public void String_length()
        {
            Console.WriteLine($"The length of string {str.Length}");

        }
        public void String_reverse()
        {
            string reverse_str = new string(str.Reverse().ToArray());
            Console.WriteLine($"The reverse of string is {reverse_str}");
        }
        public void String_check() 
        {
            Console.WriteLine("Enter two inputs");
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();
            bool check_str = str1.Equals(str2);
            if (check_str == true)
                Console.WriteLine("The strings are equal");
            else
                Console.WriteLine("The strings are not equal");
        }
    }
}
