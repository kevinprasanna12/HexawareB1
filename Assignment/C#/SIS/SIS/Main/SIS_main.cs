using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.Util;
using SIS.Dao;
using SIS.Exceptions;
using static SIS.Exceptions.MY_Exception;

namespace SIS.Main
{
    public class SIS_main
    {
        static ISIS_Service sis = new SIS_ServiceImpl();

        public static void Main(string[] args)
        {
            try
            {
                ShowMainmenu();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured : {e.Message}");
                Console.WriteLine("press any key to exit.....");
                Console.ReadKey();
            }

        }

        public static void ShowMainmenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Student Information System (SIS)");
                Console.WriteLine("===============================");
                Console.WriteLine("1. Student Management");
                Console.WriteLine("2. Course Management");
                Console.WriteLine("3. Teacher Management");
                Console.WriteLine("4. Enrollment Management");
                Console.WriteLine("5. Payment Management");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Showstudentmenu();
                        break;
                    case "2":
                        Showcoursemenu();
                        break;
                    case "3":
                        Showteachermenu();
                        break;
                    case "4":
                        Showenrollmenu();
                        break;
                    case "5":
                        Showpaymentmenu();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please try again");
                        Console.ReadKey();
                        break;

                }


            }
        }
        //-----------------student menu----------
        public static void Showstudentmenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Student Management");
                Console.WriteLine("==================");
                Console.WriteLine("1.Display student info :");
                Console.WriteLine("2.Update student detail :");
                Console.WriteLine("3.Enroll student in a course :");
                Console.WriteLine("4.course detail of student :");
                Console.WriteLine("5.student payment history :");
                Console.WriteLine("6.Exit :");
                Console.WriteLine("Enter your choice :");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.WriteLine("enter student id");
                            int stud_id = Convert.ToInt32(Console.ReadLine());
                            sis.DisplayStudentInfo(stud_id);
                        }
                        catch (StudentNotFoundException ex)
                        {
                            Console.WriteLine($"Error :{ex.Message}");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Enter student id:");
                            int studentid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter first name:");
                            string firstname = Console.ReadLine();
                            Console.WriteLine("Enter last name :");
                            string lastname = Console.ReadLine();
                            Console.WriteLine("Enter Date Of Birth (yy-mm-dd):");
                            string studdate = Console.ReadLine();
                            Console.WriteLine("Enter email :");
                            string email = Console.ReadLine();
                            Console.WriteLine("Enter phone :");
                            string phone = Console.ReadLine();

                            sis.UpdateStudentInfo(studentid, firstname, lastname, studdate, email, phone);
                            Console.WriteLine("Student updated successfully..");
                        }
                        catch (InvalidStudentDataException ex)
                        {
                            Console.WriteLine($"Error :{ex.Message}");
                            Console.ReadLine();
                        }
                        break;

                    case "3":
                        try
                        {
                            Console.WriteLine("Enter enroll id(eg:213 or 217)");
                            int enroll_id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the studentid to enroll :");
                            int stud_id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the course id to enroll :");
                            int courseid = Convert.ToInt32(Console.ReadLine());
                            sis.EnrollInCourse(enroll_id, stud_id, courseid);
                            Console.WriteLine("Student enrolled successfully");
                        }
                        catch (InvalidEnrollmentDataException ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        try
                        {
                            Console.WriteLine("Enter student name :");
                            string stud_name = Console.ReadLine();
                            sis.GetEnrolledCourses(stud_name);
                        }
                        catch (CourseNotFoundException ex)
                        {
                            Console.WriteLine($"Error :{ex.Message}");
                            Console.ReadLine();
                        }
                        break;
                    case "5":
                        try
                        {
                            Console.WriteLine("Enter student name: ");
                            string stud_name = Console.ReadLine();

                            sis.GetPaymentHistory(stud_name);
                        }
                        catch (PaymentValidationException ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                            Console.ReadLine();
                        }
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice...please enter correct input");
                        break;
                }
            }

        }

        //----------------Course menu---------------------------------

        public static void Showcoursemenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("================");
                Console.WriteLine("1.Course Details");
                Console.WriteLine("2.Course Enrollment detail");
                Console.WriteLine("3.Assign teacher to course");
                Console.WriteLine("4.Teacher details of the course");
                Console.WriteLine("5.Update a course");
                Console.WriteLine("6.Exit");
                Console.WriteLine("Enter your choice");

                string choice = Console.ReadLine();
                switch (choice)
                {

                    case "1":
                        try
                        {
                            Console.WriteLine("Enter course name");
                            string coursename = Console.ReadLine();
                            sis.DisplayCourseInfo(coursename);
                        }
                        catch (CourseNotFoundException ex)
                        {
                            Console.WriteLine($"Error:{ex.Message}");
                            Console.ReadLine();
                        }
                        break;

                    case "2":
                        try
                        {
                            Console.WriteLine("Enter Course name:");
                            string cname = Console.ReadLine();
                            sis.GetEnrollments(cname);
                        }
                        catch (CourseNotFoundException ex)
                        {
                            Console.WriteLine($"Error:{ex.Message}");
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        try
                        {
                            Console.WriteLine("Enter teacher id");
                            int teacher_id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter course id to assign:");
                            int courseid = Convert.ToInt32(Console.ReadLine());
                            sis.AssignTeacher(teacher_id, courseid);
                        }
                        catch (TeacherNotFoundException ex)
                        {
                            Console.WriteLine($"error:{ex.Message}");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        try
                        {
                            Console.WriteLine("Enter Course name");
                            string course_name = Console.ReadLine();
                            sis.Getteacher(course_name);
                        }
                        catch (InvalidTeacherDataException e)
                        {
                            Console.WriteLine($"Error: {e.Message}");
                            Console.ReadLine();
                        }
                        break;
                    case "5":
                        try
                        {
                            Console.WriteLine("Enter course id to update :");
                            int course_id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the new course name:");
                            string Coursename = Console.ReadLine();
                            Console.WriteLine("Enter the new teacher id :");
                            int teacherid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the new credit:");
                            int credits = Convert.ToInt32(Console.ReadLine());

                            sis.Updatecourseinfo(Coursename, teacherid, course_id, credits);
                        }
                        catch (InvalidCourseDataException ex)
                        {
                            Console.WriteLine($"Error:{ex.Message}");
                            Console.ReadLine();
                        }
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid input....please try again");
                        break;


                }

            }
        }
        //---------------------teacher menu-----------------------------------
        public static void Showteachermenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===================");
                Console.WriteLine("1.Display teacher details");
                Console.WriteLine("2.Update teacher details");
                Console.WriteLine("3.Teacher assigned courses");
                Console.WriteLine("4.Exit");
                Console.WriteLine("Enter your choice :");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.WriteLine("Enter Teacher name :");
                            string teacher_name = Console.ReadLine();
                            sis.Displayteacherinfo(teacher_name);
                        }
                        catch (TeacherNotFoundException e)
                        {
                            Console.WriteLine($"Error:{e.Message}");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Enter Teacher ID to update:");
                            int teacherid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter new first name:");
                            string first_name = Console.ReadLine();
                            Console.WriteLine("Enter last name");
                            string last_name = Console.ReadLine();
                            Console.WriteLine("Enter new email:");
                            string email = Console.ReadLine();

                            sis.UpdateTeacherinfo(teacherid, first_name, last_name, email);
                        }
                        catch (InvalidTeacherDataException e)
                        {
                            Console.WriteLine($"Error:{e.Message}");
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        try
                        {
                            Console.WriteLine("Enter teacher id:");
                            int teacherid = Convert.ToInt32(Console.ReadLine());
                            sis.GetAssignedCourse(teacherid);
                        }
                        catch (TeacherNotFoundException e)
                        {
                            Console.WriteLine($"Error: {e.Message}");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid input....please try again");
                        Console.ReadLine();
                        break;
                }
            }
        }

        //-----------------------enrollment menu--------------------------------------
        public static void Showenrollmenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.Students Enrollment");
                Console.WriteLine("2.Course Enrollments");
                Console.WriteLine("3.Exit");
                Console.WriteLine("Enter your choice:");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.WriteLine("Enter student name:");
                            string stud_name = Console.ReadLine();

                            sis.GetStudent(stud_name);
                        }
                        catch (StudentNotFoundException e)
                        {
                            Console.WriteLine($"Error:{e.Message}");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Enter Enroll id :");
                            int enroll_id = Convert.ToInt32(Console.ReadLine());
                            sis.GetCourse(enroll_id);
                        }
                        catch (InvalidEnrollmentDataException e)
                        {
                            Console.WriteLine($"Error : {e.Message}");
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid input.....please try again");
                        break;
                }

            }
        }
        //--------------------payment menu-------------------------------

        public static void Showpaymentmenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.payment details of a student");
                Console.WriteLine("2.Total payment of student");
                Console.WriteLine("3.Payment date");
                Console.WriteLine("4.Exit");
                Console.WriteLine("Enter your choice:");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.WriteLine("Enter the Payment id");
                            int pid = Convert.ToInt32(Console.ReadLine());
                            sis.GetStudent(pid);
                        }
                        catch (StudentNotFoundException e)
                        {
                            Console.WriteLine($"Error : {e.Message}");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Enter student id:");
                            int stud_id = Convert.ToInt32(Console.ReadLine());
                            sis.GetpaymentAmount(stud_id);
                        }
                        catch (InsufficientFundsException e)
                        {
                            Console.WriteLine($"Error: {e.Message}");
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        try
                        {
                            Console.WriteLine("Enter payment id:");
                            int paymentid = Convert.ToInt32(Console.ReadLine());
                            sis.GetpaymentAmount(paymentid);
                        }
                        catch (PaymentValidationException e)
                        {
                            Console.WriteLine($"Error:{e.Message}");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid input....please try again");
                        break;
                }
            }
        }

    }
}
