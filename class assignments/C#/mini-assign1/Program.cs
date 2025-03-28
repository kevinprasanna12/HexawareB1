using System.Xml.Linq;

namespace Sample_pro
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Student stud_obj = new Student();

            stud_obj.get_student_details();
            stud_obj.display_student_details();

        }
    }
}
