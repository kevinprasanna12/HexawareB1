using System;


namespace sample_3
{
    internal class Student
    {
        public int RollNo;
        public string Name;
        public string Class;
        public int Semester;
        public string Branch;
        public int[] Marks = new int[5];

        public Student(int rollNo, string name, string class_name, int semester, string branch)
        {
            RollNo = rollNo;
            Name = name;
            Class = class_name;
            Semester = semester;
            Branch = branch;
        }

        public void GetMarks()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter marks for subject {i + 1}: ");
                Marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void Get_result()
        {
            int Sum = 0;
            bool result_check = true;
            foreach (int i in Marks)
            {
                if (i < 35)
                {
                    result_check = false;
                }

                Sum += i;
            }

            int mark_avg = Sum / 5;

            if (mark_avg > 50 && result_check == true) 
            {
                Console.WriteLine("Passed");                   
            }
            else
                Console.WriteLine("Failed");
        }

        public void DisplayData() 
        {
            Console.WriteLine("Student Details:");
            Console.WriteLine($"Roll No: {RollNo}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Class: {Class}");
            Console.WriteLine($"Semester: {Semester}");
            Console.WriteLine($"Branch: {Branch}");
            Console.WriteLine("Marks : ");
            foreach (int i in Marks)
            {
                Console.Write(i + " ");
            }
        }
    }
}
