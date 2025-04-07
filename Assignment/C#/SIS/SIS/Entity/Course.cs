using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Entity
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string InstructorName { get; set; }
        public Teacher Teacher { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public Course() { }

        public Course(int courseId, string courseName, string courseCode, string instructorName)
        {
            CourseID = courseId;
            CourseName = courseName;
            CourseCode = courseCode;
            InstructorName = instructorName;
        }


    }
}
