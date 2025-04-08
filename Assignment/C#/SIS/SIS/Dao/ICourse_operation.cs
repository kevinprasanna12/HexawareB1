using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Dao
{
    public interface ICourse_operation
    {
        void AssignTeacher(int teacherid, int courseid);
        void DisplayCourseInfo(string coursename);
        void GetEnrollments(string coursename);
        void Getteacher(string coursename);
        void Updatecourseinfo(string coursename, int teacherid, int courseid, int credit);
    }
}
