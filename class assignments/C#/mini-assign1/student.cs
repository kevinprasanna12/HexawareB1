using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_pro
{
    internal class Student
    {
        int student_id;
        string name;
        int age;
        string department;
    
    public  void get_student_details()
        {
            Console.Write("Enter student ID: ");
            student_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter name: ");
            name = Console.ReadLine();

            Console.Write("Enter age: ");
            age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter department: ");
            department = Console.ReadLine();


        }
        public  void display_student_details()
        {
            Console.WriteLine("\nstudent details:");
            Console.WriteLine($"ID: {student_id}");
            Console.WriteLine($"name: {name}");
            Console.WriteLine($"age: {age}");
            Console.WriteLine($"department: {department}");
        }
    }
}
