using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Entity
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Expertise { get; set; }
        public List<Course> AssignedCourses { get; set; } = new List<Course>();

        public Teacher() { }

        public Teacher(int teacherId, string firstName, string lastName, string email, string expertise)
        {
            TeacherID = teacherId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Expertise = expertise;
        }
    }
}
