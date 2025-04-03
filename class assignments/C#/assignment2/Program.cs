using System.Xml.Linq;

namespace Sample_pro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Output");

            var emp1 = new Employee(1223, "ram", "Analyst", 44000);
            Manager mgr = new Manager(1299, "hari", "Analytics Manager", 67000, 6000, 5000);

            emp1.Display_details();
            emp1.Total_salary();
            mgr.Display_details();
            mgr.Total_salary();
            Count_function.Counter();
            Count_function.Counter();
            Count_function.Counter();
            Count_function.Counter();
            Count_function.Counter();
        }
    }
}
