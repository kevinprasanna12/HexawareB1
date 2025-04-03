using System;


namespace Sample_pro { 

    internal class Employee
    {

        int Emp_id;
        string Emp_name;
        string Job;
        int Salary;

        public Employee(int id, string name, string job, int salary)
        {
            Emp_id = id;
            Emp_name = name;
            Job = job;
            Salary = salary;
        }
        public virtual int Total_salary()
        {
            return Salary;
        }
        public virtual void Display_details()
        {
            Console.WriteLine($"id:{Emp_id} name:{Emp_name} job:{Job} salary:{Salary}");
        }
    }
    class Manager : Employee
    {
        int Onsite_sal;
        int Bonus;

        public Manager(int id, string name, string job, int salary, int onsite_sal, int bonus) : base(id, name, job, salary)
        {
            Onsite_sal = onsite_sal;
            Bonus = bonus;
        }
        public override int Total_salary()
        {
            return base.Total_salary() + Onsite_sal * Bonus;
        }
        public override void Display_details()
        {
            base.Display_details();
            Console.WriteLine($"Onsite ; {Onsite_sal} Bonus: {Bonus}");
        }

    }

}
