using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SIS.Exceptions;
using SIS.Util;

namespace SIS.Dao
{
    public class SIS_ServiceImpl : IStudent_operation,ICourse_operation,ITeacher_operation,IEnrollment_operation,IPayment_operation
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader dr;

        public void EnrollInCourse(int enrollment_id, int Studentid, int Courseid)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {

                cmd = new SqlCommand("insert into Enrollment (Enroll_id,Student_ID, Course_ID, Enroll_Date) values (@enrollid,@studentid, @courseid, @date)", con);
                cmd.Parameters.AddWithValue("@enrollid", enrollment_id);
                cmd.Parameters.AddWithValue("@StudentID", Studentid);
                cmd.Parameters.AddWithValue("@CourseID", Courseid);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    throw new MY_Exception.InvalidEnrollmentDataException();
                }
                else
                    Console.WriteLine("Enrollment Successfully Done......");

                Console.ReadLine();
                con.Close();
            }
        }
        public void UpdateStudentInfo(int studentid, string firstname, string lastname, string dob, string email, string phone)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("UPDATE Students SET First_Name = @FirstName,Last_Name = @LastName,Date_Of_Birth = @DOB,Email = @Email,Phone = @Phone " +
                    "where student_id = @ID", con);

                cmd.Parameters.AddWithValue("@ID", studentid);
                cmd.Parameters.AddWithValue("@FirstName", firstname);
                cmd.Parameters.AddWithValue("@LastName", lastname);
                cmd.Parameters.AddWithValue("@DOB", dob);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);

                int result = cmd.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new MY_Exception.InvalidStudentDataException();
                }
                else
                {
                    Console.WriteLine("Updated successfully...");
                }
                Console.ReadLine();
                con.Close();
            }
        }
        public void DisplayStudentInfo(int studentid)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("select * from students where student_id = @sid", con);
                cmd.Parameters.AddWithValue("@sid", studentid);

                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine("Studentid = " + dr["student_id"]);
                        Console.WriteLine("studentname = " + dr["first_name"] + dr["last_name"]);
                        Console.WriteLine("Date of birth = " + dr["date_of_birth"]);
                        Console.WriteLine("Email =" + dr["email"]);
                        Console.WriteLine("Phone = " + dr["phone"]);

                    }
                }
                else
                {
                    throw new MY_Exception.StudentNotFoundException();
                }
                Console.ReadLine();
                con.Close();
            }
        }
        public void GetEnrolledCourses(string studentname)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select c.course_id,c.course_name from students s join enrollment e on s.student_id=e.student_id " +
                    "join courses c on e.course_id = c.course_id " +
                    "where s.first_name = @studentname", con);
                cmd.Parameters.AddWithValue("@studentname", studentname);
                dr = cmd.ExecuteReader();
                if (studentname.Contains(" "))
                {
                    Console.WriteLine("Enter first name only..Try again please");
                    Console.ReadLine();
                    return;
                }
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine("Course ID :" + dr["course_id"]);
                        Console.WriteLine("Course Name :" + dr["course_name"]);
                    }
                }
                else
                {
                    throw new MY_Exception.CourseNotFoundException();

                }
                Console.ReadLine();
                dr.Close();
                con.Close();

            }
        }
        public void GetPaymentHistory(string studentname)
        {
            SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from payments " +
                "where student_id = (select student_id from students where first_name = @studentname)", con);

            cmd.Parameters.AddWithValue("@studentname", studentname);
            dr = cmd.ExecuteReader();
            if (studentname.Contains(" "))
            {
                Console.WriteLine("Enter first name only..Try again please");
                Console.ReadLine();
                return;
            }
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Console.WriteLine("Payment ID: " + dr["payment_id"]);
                    Console.WriteLine("Amount: " + dr["amount"]);
                    Console.WriteLine("Date: " + dr["payment_date"]);
                }
            }
            else
                throw new MY_Exception.InvalidStudentDataException();

            Console.ReadLine();
            con.Close();
        }

        //--------------teacher-----------------------------
        public void AddnewTeacher(int teacherid, string first_name, string last_name, string email)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("Insert teacher(teacher_id,first_name,last_name,email) values (@tid,@fname,@lname,@email)",con);
                cmd.Parameters.AddWithValue("@fname", first_name);
                cmd.Parameters.AddWithValue("@lname", last_name);
                cmd.Parameters.AddWithValue("@tid", teacherid);
                cmd.Parameters.AddWithValue("@email", email);

                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    throw new MY_Exception.InvalidTeacherDataException();   
                }
                Console.WriteLine("Added successfully....");
                Console.ReadLine();
                
                con.Close();
            }
        }


        public void AssignTeacher(int teacherid, int courseid)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("update courses set teacher_id = @teacherid where course_id = @courseid", con);
                cmd.Parameters.AddWithValue("@teacherid", teacherid);
                cmd.Parameters.AddWithValue("@courseid", courseid);

                int result=cmd.ExecuteNonQuery();
                if(result == 0)
                {
                    throw new MY_Exception.InvalidTeacherDataException();
                }
                else 
                    Console.WriteLine("Assiggned successfully...");
                Console.ReadLine();

            }
            con.Close();
        }
        public void DisplayCourseInfo(string coursename)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("select * from courses where course_name = @coursename", con);
                cmd.Parameters.AddWithValue("@coursename", coursename);
                dr = cmd.ExecuteReader();
                if (coursename.Contains(" "))
                {
                    Console.WriteLine("Invalid input....avoid spaces");
                    Console.ReadLine();
                    return;
                }
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine("Course Name :" + dr["course_name"]);
                        Console.WriteLine("Course ID:" + dr["course_id"]);
                        Console.WriteLine("Course credits:" + dr["credits"]);
                        Console.WriteLine("Teacher:" + dr["teacher_id"]);
                    }
                    Console.ReadLine();
                }
                else
                {
                    throw new MY_Exception.CourseNotFoundException();
                }
                dr.Close();
                con.Close();
            }
        }
        public void GetEnrollments(string coursename)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();

                cmd = new SqlCommand("select c.course_name,s.first_name,e.enroll_id from students s " +
                    "join enrollment e on e.student_id = s.student_id " +
                    "join courses c on e.course_id = c.course_id where course_name = @coursename", con);
                cmd.Parameters.AddWithValue("@coursename", coursename);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            string columnName = dr.GetName(i);
                            object value = dr.GetValue(i);
                            Console.WriteLine($"{columnName}: {value}");
                        }
                    }
                    Console.ReadLine();
                }
                else
                {
                    throw new MY_Exception.CourseNotFoundException();
                }
                dr.Close();
                con.Close();
            }
        }
        public void Getteacher(string coursename)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("select c.course_name,t.teacher_id,t.first_name + t.last_name as Teachername,t.email from courses c " +
                    "join teacher t on c.teacher_id = t.teacher_id " +
                    "where course_name = @coursename", con);
                cmd.Parameters.AddWithValue("@coursename", coursename);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            string columnName = dr.GetName(i);
                            object value = dr.GetValue(i);
                            Console.WriteLine($"{columnName}: {value}");
                        }

                    }
                    Console.ReadLine();
                }
                else
                {
                    throw new MY_Exception.TeacherNotFoundException();

                }
                dr.Close();
                con.Close();
            }
        }
        public void Updatecourseinfo(string coursename, int teacherid, int courseid, int credit)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("update courses set course_name = @cname ,teacher_id = @tid , credits=@credit " +
                                    "where course_id = @cid", con);
                cmd.Parameters.AddWithValue("@cname", coursename);
                cmd.Parameters.AddWithValue("@tid", teacherid);
                cmd.Parameters.AddWithValue("cid", courseid);
                cmd.Parameters.AddWithValue("credit", credit);

                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    throw new MY_Exception.InvalidCourseDataException();
                }
                else
                    Console.WriteLine("Course updated successfully...");

                Console.ReadLine();
                con.Close();
              
            }
        }
        public void UpdateTeacherinfo(int teacherid, string first_name, string last_name, string email)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("update teacher set first_name=@fname, last_name=@lname, email=@email where teacher_id = @tid", con);
                cmd.Parameters.AddWithValue("@tid", teacherid);
                cmd.Parameters.AddWithValue("@fname", first_name);
                cmd.Parameters.AddWithValue("@lname", last_name);
                cmd.Parameters.AddWithValue("@email", email);

                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    throw new MY_Exception.InvalidTeacherDataException();
                }
                else
                    Console.WriteLine("Updated successfully.......");

                Console.ReadLine();

            }
            con.Close();
        }
        public void Displayteacherinfo(string teacher_name)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("select * from teacher where first_name = @name", con);
                cmd.Parameters.AddWithValue("@name", teacher_name);
                dr = cmd.ExecuteReader();
                if (teacher_name.Contains(" "))
                {
                    Console.WriteLine("Enter first name only....");
                    Console.ReadLine();
                    return;
                }
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            string columnName = dr.GetName(i);
                            object value = dr.GetValue(i);
                            Console.WriteLine($"{columnName}: {value}");

                        }
                    }
                   
                }
                else
                {
                    throw new MY_Exception.TeacherNotFoundException();
                }
                Console.ReadLine();
                dr.Close();
                con.Close();
            }
        }
        public void GetAssignedCourse(int teacherid)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("select t.first_name,c.course_name,c.course_id, c.credits from courses c " +
                                    "join teacher t on t.teacher_id = c.teacher_id " +
                                    "where t.teacher_id =@tid", con);
                cmd.Parameters.AddWithValue("@tid", teacherid);

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            string columnName = dr.GetName(i);
                            object value = dr.GetValue(i);
                            Console.WriteLine($"{columnName}: {value}");

                        }
                        
                    }
                }
                else
                    throw new MY_Exception.CourseNotFoundException();
                Console.ReadLine();
                dr.Close();
                con.Close();
            }

        }
        public void GetStudent(string studentname,string lastname)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("select e.* from enrollment e join students s " +
                    "on s.student_id = e.student_id " +
                    "where s.first_name = @studentname and s.last_name= @Lastname", con);
                cmd.Parameters.AddWithValue("@studentname", studentname);
                cmd.Parameters.AddWithValue("@Lastname", lastname);
                if (studentname.Contains(" "))
                {
                    Console.WriteLine("Enter first name only.....avoid spaces");
                    return;
                }
                dr = cmd.ExecuteReader();
                int count = 1;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine($"{count}.");
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            string columnName = dr.GetName(i);
                            object value = dr.GetValue(i);
                            Console.WriteLine($"{columnName}: {value}");
                        }
                        
                        Console.WriteLine("---------------------------");
                        count++;
                    }
                   
                }
                else
                {
                    throw new MY_Exception.StudentNotFoundException();
                }
                Console.ReadLine();
                con.Close();
            }
        }
        public void GetCourse(int enrollid)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("select c.* from courses c join enrollment e on e.course_id = c.course_id where e.enroll_id= @enrollid", con);
                cmd.Parameters.AddWithValue("@enrollid", enrollid);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            string columnName = dr.GetName(i);
                            object value = dr.GetValue(i);
                            Console.WriteLine($"{columnName}: {value}");
                        }
                        
                    }
                }
                else
                {
                    throw new MY_Exception.InvalidEnrollmentDataException();
                }
                Console.ReadLine();
                dr.Close();
                con.Close();
            }
        }
        public void GetStudent(int paymentid)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("select * from students where student_id = (select student_id from payments where payment_id = @pid)", con);
                cmd.Parameters.AddWithValue("@pid", paymentid);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            string columnName = dr.GetName(i);
                            object value = dr.GetValue(i);
                            Console.WriteLine($"{columnName}: {value}");
                        }
                    }
                }
                else
                {
                    throw new MY_Exception.StudentNotFoundException();
                }
                Console.ReadLine();
                dr.Close();
                con.Close();
                
            }
        }
        public void GetpaymentAmount(int studid)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("select sum(amount) from payments where student_id = (select student_id from students where student_id = @sid) group by student_id as total_payment", con);
                cmd.Parameters.AddWithValue("@sid", studid);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            string columnName = dr.GetName(i);
                            object value = dr.GetValue(i);
                            Console.WriteLine($"{columnName}: {value}");
                        }
                       

                    }
                }
                else
                {
                    throw new MY_Exception.InsufficientFundsException();
                }
                Console.ReadLine();
                con.Close();
            }
        }
        public void GetPaymentDate(int paymentid)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("select payment_date from payment where payment_id=@pid", con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            string columnName = dr.GetName(i);
                            object value = dr.GetValue(i);
                            Console.WriteLine($"{columnName}: {value}");
                        }

                    }
                }
                else
                {
                    throw new MY_Exception.PaymentValidationException();
                }
                Console.Read();
                con.Close();
            }
        }
        public void MakePayment(string paymentid, string studid, string amount, string date)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("Insert payments (payment_id,student_id,amount,payment_date) values (@pid,@sid,@amount,@date)", con);
                cmd.Parameters.AddWithValue("pid",paymentid);
                cmd.Parameters.AddWithValue("sid",studid);
                cmd.Parameters.AddWithValue("amount",amount);
                cmd.Parameters.AddWithValue("date",date);

                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    throw new MY_Exception.PaymentValidationException();
                }
                else
                    Console.WriteLine("Payment successfull....");
                Console.ReadLine();
                con.Close();
            }
        }
        public void ReportGeneration(string coursename)
        {
            using (SqlConnection con = DBConnUtil.GetConnection(DBConnUtil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("select s.first_name + ' ' +s.last_name as Student_Name ,e.enroll_id,e.enroll_date,s.email,s.phone,s.date_of_birth from students s " +
                    "join enrollment e on e.student_id = s.student_id join courses c on e.course_id = c.course_id " +
                    "where c.course_name = @coursename", con);
                cmd.Parameters.AddWithValue("@coursename",coursename);

                dr= cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while(dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            string columnName = dr.GetName(i);
                            object value = dr.GetValue(i);
                            Console.WriteLine($"{columnName}: {value}");
                           
                        }
                        Console.WriteLine("--------------------------------");
                    }
                }
                else
                    throw new MY_Exception.InvalidEnrollmentDataException();
                
                Console.ReadLine ();
                con.Close();
            }
        }
    }
}
