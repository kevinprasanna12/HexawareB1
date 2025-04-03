using System;


namespace Sample_pro
{
    internal class Count_function
    {
        static int count;

        public static void Counter()
        {
            count++;
            Console.WriteLine($"The function called {count}");
        }
    }
}
