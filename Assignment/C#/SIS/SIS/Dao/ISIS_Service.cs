using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Dao
{
    public interface ISIS_Service
    {
        void EnrollInCourse(int enrollment_id, int Studentid, int Courseid);
        void UpdateStudentInfo(int studentid, string firstname, string lastname, string dob, string email, string phone);
        void DisplayStudentInfo(int studentid);
        void GetEnrolledCourses(string studentname);
        void GetPaymentHistory(string studentname);

        //--------------course------------------

        void AssignTeacher(int teacherid, int courseid);
        void DisplayCourseInfo(string coursename);
        void GetEnrollments(string coursename);
        void Getteacher(string coursename);
        void Updatecourseinfo(string coursename, int teacherid, int courseid, int credit);

        //-----------teacher----------------------

        void UpdateTeacherinfo(int teacherid, string first_name, string last_name, string email);
        void Displayteacherinfo(string teacher_name);
        void GetAssignedCourse(int teacherid);
       
        //------enroll--------------------------------
        void GetStudent(string studentname);
        void GetCourse(int enrollid);

        //-----------------payment-------------------

        void GetStudent(int paymentid);
        void GetpaymentAmount(int studid);
        void GetPaymentDate(int paymentid);
    }
}
