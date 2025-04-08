using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Dao
{
    public interface ITeacher_operation
    {
        void UpdateTeacherinfo(int teacherid, string first_name, string last_name, string email);
        void Displayteacherinfo(string teacher_name);
        void GetAssignedCourse(int teacherid);
        void AddnewTeacher(int teacherid, string first_name, string last_name, string email);
    }
}
