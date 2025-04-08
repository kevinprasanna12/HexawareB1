using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Dao
{
    public interface IStudent_operation
    {
        void EnrollInCourse(int enrollment_id, int Studentid, int Courseid);
        void UpdateStudentInfo(int studentid, string firstname, string lastname, string dob, string email, string phone);
        void DisplayStudentInfo(int studentid);
        void GetEnrolledCourses(string studentname);
        void GetPaymentHistory(string studentname);
    }
}
